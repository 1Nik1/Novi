using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace botun2
{
    public partial class Form1 : Form
    {
        struct Podatak {
            public string Name;
            public string Surname;
            public string Birthyear;
            public string Email;
        }

        List<Podatak> podatci = new List<Podatak>();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Surname = textBox2.Text;
            string Birthyear = textBox3.Text;
            string email= textBox4.Text;

            if (!Regex.IsMatch(Name, @"^[a-zA-Z]*$"))
            {
                MessageBox.Show("Invalid Name!");
                return;
            }
            if (!Regex.IsMatch(Surname, @"^[a-zA-Z]*$"))
            {
                MessageBox.Show("Invalid Surname!");
                return;
            }
            if (!Regex.IsMatch(Birthyear, @"^\d{4}[-](0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])$"))
            {
                MessageBox.Show("Invalid Year of Birth. (GGGG-MM-DD)");
                return;
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Invalid E-mail address");
                return;
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            podatci.Add(new Podatak() {
                Name = Name,
                Surname = Surname,
                Birthyear = Birthyear,
                Email = email,
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> csvData = new List<string>();
            csvData.Add("Name,Surname,Birthyear,E-mail");

            foreach (Podatak podatak in podatci)
            {
                csvData.Add($"{podatak.Name},{podatak.Surname},{podatak.Birthyear},{podatak.Email}");
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Write the file
                File.WriteAllLines(saveFileDialog.FileName, csvData);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

 
}
