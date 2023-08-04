using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phase1
{
    class Car
    {
        public string make;
        public string model;
        public int year;
        public double price;

        public Car(string make, string model, int year, double price) {
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
        }

        public double getGST() {
            return Convert.ToDouble(price) * 0.15;
        }

        public override string ToString() {
            return this.make + "\t" + this.model + "\t" + this.year.ToString() + "\t$" + this.price.ToString() + "\t$" + this.getGST().ToString();
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
