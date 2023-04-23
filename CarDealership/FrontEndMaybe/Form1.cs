using CarDealership.Data.Common;
using CarDealership.Data.Data;
using CarDealership.Data.DTOs.Import;
using CarDealership.Data.Models;
using CarDealership.Data.Models.Enums;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Windows.Forms;
using System;
using CarDealership;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace FrontEndMaybe
{
    public partial class StartingForm : Form
    {

        public StartingForm()
        {
            InitializeComponent();
        }
        public static CarDealershipContext context = new CarDealershipContext();
        private void button1_Click(object sender, EventArgs e)
        {
            CarDealershipContext context = new CarDealershipContext();
            InitialiseDB(context);
            FillDatabaseWithData(context);           
        }
        
        private void InitialiseDB(CarDealershipContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            MessageBox.Show("Succesful Connection!");
        }
        public static List<Vehicle> AllVehicles = new List<Vehicle>();
        private void FillDatabaseWithData(CarDealershipContext context)
        {
            string PathForSalesMen = File.ReadAllText(@"..\..\..\..\CarDealership.Data\Datasets\SalesMen.json");
            string PathForVehicles = File.ReadAllText(@"..\..\..\..\CarDealership.Data\Datasets\Vehicles.json");
            string PathForRentors = File.ReadAllText(@"..\..\..\..\CarDealership.Data\Datasets\Rentors.json");
            string PathForMechanics = File.ReadAllText(@"..\..\..\..\CarDealership.Data\Datasets\Mechanics.json");
            string result = ImportRentors(context, PathForRentors);
            string result1 = ImportVehicles(context, PathForVehicles);
            string result2 = ImportSalesMen(context, PathForSalesMen);
            string result3 = ImportMechanics(context, PathForMechanics);
            MessageBox.Show($"Succesfully imported all the given files!");
        }
        public int IDofTheLastClickedButton=0;
        public bool HasAlreadyBeenClicked=false;
        private void button2_Click(object sender, EventArgs e)
        {
            int id = 1;
            IDofTheLastClickedButton = id;
            listBox1.Show();
            button4.Show();
            if (HasAlreadyBeenClicked)
            {
                listBox1.Items.Clear();
            }
            AllVehicles=context.Vehicles.Where(v => v.IsRented == false).ToList();
            foreach ( var vehicle in AllVehicles ) 
            {
                listBox1.Items.Add( $"{vehicle.Make} {vehicle.Model} with {vehicle.HorsePower}hp will cost you {vehicle.Cost} lv. per day" );
            }
            HasAlreadyBeenClicked=true;
        }
        public static string ImportSalesMen(CarDealershipContext context, string inputjson)
        {
            StringBuilder sb = new StringBuilder();
            ImportSalesMenDTO[] salesMenDTOs = JsonConvert.DeserializeObject<ImportSalesMenDTO[]>(inputjson);
            ICollection<SalesMan> validSalesMen = new HashSet<SalesMan>();
            ICollection<int> ids = context.Vehicles.Select(x => x.VehicleId).ToList();
            foreach (var salesman in salesMenDTOs)
            {
                SalesMan sm = new SalesMan()
                {
                    FirstName = salesman.FirstName,
                    MiddleName = salesman.MiddleName,
                    LastName = salesman.LastName,
                    Salary= salesman.Salary,
                    BirthDate = DateTime.ParseExact(salesman.BirthDate,"dd/mm/yyyy",CultureInfo.InvariantCulture),
                    HireDate = DateTime.ParseExact(salesman.HireDate, "dd/mm/yyyy", CultureInfo.InvariantCulture),
                    Ranking = (InStoreRankings)salesman.Ranking
                };
                foreach (var i in salesman.Vehicles.Distinct())
                {
                    if (!ids.Contains(i))
                    {
                        sb.AppendLine(OutputMessages.ErrorNoSuchVehicle);
                        continue;
                    }
                    SalesMenVehicles smv = new SalesMenVehicles()
                    {
                        SalesMan = sm,
                        VehicleId = i
                    };
                    sm.SalesMenVehicles.Add(smv);
                   
                }
                validSalesMen.Add(sm);
                sb.AppendLine(string.Format(OutputMessages.SuccessfullyImportedSalesMen, sm.FirstName + " " + sm.LastName, sm.SalesMenVehicles.Count()));
            }
            context.AddRange(validSalesMen);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportVehicles(CarDealershipContext context, string inputjson)
        {
            StringBuilder sb = new StringBuilder();
            ImportVehiclesDto[] VehiclesDTOs = JsonConvert.DeserializeObject<ImportVehiclesDto[]>(inputjson);
            ICollection<Vehicle> validVehicles = new HashSet<Vehicle>();
            foreach (var vehicle in VehiclesDTOs)
            {
                Vehicle vh = new Vehicle()
                {
                    LicensePlate = vehicle.LicensePlate,
                    Make = (Makes)vehicle.Make,
                    Model = vehicle.Model,
                    RentedOn = null,
                    ReturnDate = null,
                    IsRented = false,
                    FuelType = (FuelTypes)vehicle.FuelType,
                    Mileage = vehicle.Mileage,
                    HorsePower = vehicle.HorsePower,
                    Cost = vehicle.Cost,
                    RentorId = 1
                };
                validVehicles.Add(vh);              
            }
            sb.AppendLine(string.Format(OutputMessages.SuccessfullyImportedVehicles, validVehicles.Count()));     
            context.AddRange(validVehicles);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportRentors(CarDealershipContext context, string inputjson)
        {
            StringBuilder sb = new StringBuilder();
            ImportRentorsDto[] RentorsDTOs = JsonConvert.DeserializeObject<ImportRentorsDto[]>(inputjson);
            ICollection<Rentor> validRentors = new HashSet<Rentor>();
            foreach (var rentor in RentorsDTOs)
            {
                Rentor r = new Rentor()
                {
                    FirstName = rentor.FirstName,
                    MiddleName = rentor.MiddleName,
                    LastName = rentor.LastName,
                    DriverLicense = rentor.DriverLicense,
                    BirthDate = DateTime.ParseExact(rentor.BirthDate, "dd/mm/yyyy", CultureInfo.InvariantCulture),
                    PaymentMethod = (PaymentMethods)rentor.PaymentMethod,
                };
                validRentors.Add(r);  
            }sb.AppendLine(string.Format(OutputMessages.SuccessfullyImportedRentors, validRentors.Count()));
            context.AddRange(validRentors);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportMechanics(CarDealershipContext context, string inputjson)
        {
            StringBuilder sb = new StringBuilder();
            ImportMechanicsDto[] MechanicsDTOs = JsonConvert.DeserializeObject<ImportMechanicsDto[]>(inputjson);
            ICollection<Mechanic> validMechanics = new HashSet<Mechanic>();
            ICollection<int> ids = context.Vehicles.Select(x => x.VehicleId).ToList();
            foreach (var mechanic in MechanicsDTOs)
            {
                Mechanic m = new Mechanic()
                {
                    FirstName = mechanic.FirstName,
                    MiddleName = mechanic.MiddleName,
                    LastName = mechanic.LastName,
                    Salary = mechanic.Salary,
                    BirthDate = DateTime.ParseExact(mechanic.BirthDate, "dd/mm/yyyy", CultureInfo.InvariantCulture),
                    HireDate = DateTime.ParseExact(mechanic.HireDate, "dd/mm/yyyy", CultureInfo.InvariantCulture),
                    Specialisation = (Specialisations)mechanic.Specialisation
                };
                foreach (var i in mechanic.Vehicles.Distinct())
                {
                    if (!ids.Contains(i))
                    {
                        sb.AppendLine(OutputMessages.ErrorNoSuchVehicle);
                        continue;
                    }
                    VehicleMechanic vm = new VehicleMechanic()
                    {
                        Mechanic = m,
                        VehicleId = i
                    };
                    m.VehiclesMechanics.Add(vm);

                }
                validMechanics.Add(m);
                sb.AppendLine(string.Format(OutputMessages.SuccessfullyImportedMechanic, m.FirstName + " " + m.LastName, m.VehiclesMechanics.Count));
            }
            context.AddRange(validMechanics);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            button5.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            label1.Hide();
            label2.Hide();
            dateTimePicker1.MinDate=DateTime.Now.Date;
            dateTimePicker2.MinDate = DateTime.Now.Date;
            listBox1.Hide();
            button4.Hide();
        }
        public Vehicle selectedvehicle = new Vehicle();
        private void button4_Click(object sender, EventArgs e)
        {
            string? curItem = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(curItem);
            selectedvehicle = AllVehicles[index];
            switch (IDofTheLastClickedButton)
            {
                case 1:
                 dateTimePicker1.Show();
                 dateTimePicker2.Show();
                 label1.Show();
                 label2.Show();  
                    break;
                    case 2:
                    DialogResult d = MessageBox.Show("Are you sure you would like to free this vehicle?", "Confirmation", MessageBoxButtons.YesNo);
                    if (d==DialogResult.Yes)
                    {
                        selectedvehicle.RentedOn = null;
                        selectedvehicle.ReturnDate = null;
                        selectedvehicle.IsRented = false;
                        context.SaveChanges();
                    }
                    break;
                default:
                    break;
            }
           
        }
        private DateTime previousValue = DateTime.Now.Date;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value>dateTimePicker2.Value)
            {
                MessageBox.Show("Can't set rent date after the renturn date", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DateTimePicker)sender).Focus();

                ((DateTimePicker)sender).Value = previousValue;
                return;
            }
            previousValue = ((DateTimePicker)sender).Value.Date;
        }
        
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {          
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Can't set return date before the rent date", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DateTimePicker)sender).Focus();

                ((DateTimePicker)sender).Value = previousValue;
                return;
               }
            button5.Show();
            previousValue = ((DateTimePicker)sender).Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TimeSpan days = dateTimePicker2.Value.Date - dateTimePicker1.Value.Date;
            decimal a = days.Days;
            MessageBox.Show($"Renting the {selectedvehicle.Make} {selectedvehicle.Model} for {days.Days.ToString()} days will cost you {selectedvehicle.Cost * a} lv.");
            DialogResult d = MessageBox.Show("Are you sure you would like to continue with the transaction?","Confirmation", MessageBoxButtons.YesNo);
            if (d==DialogResult.Yes)
            {
                selectedvehicle.RentedOn=dateTimePicker1.Value;
                selectedvehicle.ReturnDate = dateTimePicker2.Value;
                selectedvehicle.IsRented = true;
                MessageBox.Show("Congratulations on the succesful booking!");
                context.SaveChanges();
                dateTimePicker2.Hide();
                dateTimePicker1.Hide();
                button5.Hide();
                label1.Hide();
                label2.Hide();
            }
            else
            {
                dateTimePicker2.Hide();
                dateTimePicker1.Hide();
                button5.Hide();
                label1.Hide();
                label2.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = 2;
            IDofTheLastClickedButton = id;
            listBox1.Items.Clear();
            AllVehicles = context.Vehicles.Where(v=>v.IsRented==true).ToList();
            foreach (var item in AllVehicles)
            {
                listBox1.Items.Add($"{item.Make} {item.Model} rented on {item.RentedOn} due to be returned on {item.ReturnDate}");
            }

        }
    }
}