using CarDealership.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarDealership.Data;
using FrontEndMaybe;

namespace CarDealership
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle= ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Makes make in (Makes[])Enum.GetValues(typeof(Makes)))
            {
                comboBox1.Items.Add(make);
            }
            foreach (FuelTypes make in (FuelTypes[])Enum.GetValues(typeof(FuelTypes)))
            {
                comboBox2.Items.Add(make);
            }

        }
        public List<Vehicle> NewVehicles = new List<Vehicle>();
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty)
            {
                MessageBox.Show("Can't create a vehicle without a model","Model Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            var match = Regex.Match(textBox2.Text, Data.Common.ValidationConstraints.RegexLicensePlate);
            if (!match.Success) 
            {
                MessageBox.Show("Incorrect license plate","License plate Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return;
            }
            else
            {
                Vehicle vehicle = new Vehicle()
                {
                    Make = Enum.Parse<Makes>(comboBox1.Text),
                    Model = textBox1.Text,
                    LicensePlate = textBox2.Text,
                    Cost = decimal.Parse(textBox3.Text),
                    FuelType = Enum.Parse<FuelTypes>(comboBox2.Text),
                    Mileage = decimal.Parse(textBox4.Text),
                    HorsePower = decimal.Parse(textBox5.Text),
                    RentorId = 1
                };
                listBox1.Items.Add($"{vehicle.Make} {vehicle.Model} with {vehicle.HorsePower}hp");
                NewVehicles.Add(vehicle);
            }
        }
        
        public Vehicle selectedvehicle = new Vehicle();
        private void button3_Click(object sender, EventArgs e)
        {
            string? curItem = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(curItem);
            selectedvehicle = NewVehicles[index]; 
            DialogResult d = MessageBox.Show("Are you sure you would like to remove this vehicle?", "Confirmation", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                listBox1.Items.Remove(curItem);
                NewVehicles.RemoveAt(index);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var items = NewVehicles;
            StartingForm.context.AddRange(items);
            StartingForm.context.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem=null;
            comboBox2.SelectedItem = null;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }
    }
}
