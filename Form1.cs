using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Phase1
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (tb_make.Text == "" || tb_model.Text == "" || tb_year.Text == "" || tb_price.Text == "") {
                MessageBox.Show("Unvalid Input");
                return;
            }
            string maker = tb_make.Text;
            string model = tb_model.Text;
            int year = 0;
            double price = 0.0;
            try {
                year = int.Parse(tb_year.Text);
                price = double.Parse(tb_price.Text);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unvalid Input");
                return;
            }
            Car car = new Car(maker, model, year, price);
            this.cars.Add(car);
        }

        private void list_helper(List<Car> p_cars) {
            list_cars.Items.Clear();
            foreach (Car car in p_cars)
            {
                list_cars.Items.Add(car.ToString());
            }
        }

        private void bt_list_Click(object sender, EventArgs e)
        {
            this.list_helper(this.cars);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.cars.Count() == 0) {
                MessageBox.Show("There is no car data");
            }
            double total = 0;
            foreach (Car car in this.cars)
            {
                total += Convert.ToDouble(car.price) + car.getGST();
            }
            total /= this.cars.Count();
            MessageBox.Show("Average Price including GST : $" + total.ToString());
        }

        private double totalprice_helper(List<Car> p_cars)
        {
            double total = 0;
            foreach (Car car in p_cars)
            {
                total += Convert.ToDouble(car.price);
            }
            return total;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double total = totalprice_helper(this.cars);
            MessageBox.Show("Total Price excluding GST : $" + total.ToString());
        }

        private double tax_calculation(double total) {
            double[] tos = { 19999, 34999, 44999, 59999, 79999};
            double[] pers = { 0.17, 0.19, 0.21, 0.25, 0.30 };
            int i = tos.Length - 1;
            while (i >= 0) {
                if (total > tos[i]) return pers[i];
                i--;
            }
            return 0.0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double total = totalprice_helper(this.cars);
            double tax = total * tax_calculation(total);
            MessageBox.Show("Total Tax excluding GST : $" + tax.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileManager.SaveToTextFile(this.cars);
            this.list_cars.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.cars = FileManager.LoadFromTextFile();
            this.list_helper(this.cars);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Car> result = null;
            if (ft_make.Text != "") {
                result = Filter.SearchbyCarMake(this.cars, ft_make.Text);
            }

            if (ft_year.Text != "") {
                try
                {
                    int year = int.Parse(ft_year.Text);
                    if (result == null)
                        result = Filter.SearchforCarsSincetheYear(this.cars, year);
                    else 
                        result = Filter.SearchforCarsSincetheYear(result, year);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Invalid Search Term");
                    return;
                }
            }

            if (ft_min.Text != "" && ft_max.Text != "") {
                try
                {
                    double min = double.Parse(ft_min.Text);
                    double max = double.Parse(ft_max.Text);
                    if (result == null)
                        result = Filter.SearchforCarsWithinthePriceRange(this.cars, min, max);
                    else
                        result = Filter.SearchforCarsWithinthePriceRange(result, min, max);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Invalid Search Term");
                    return;
                }
            }

            if (result == null || result.Count == 0) {
                MessageBox.Show("No search result");
                return;
            }

            this.list_helper(result);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
