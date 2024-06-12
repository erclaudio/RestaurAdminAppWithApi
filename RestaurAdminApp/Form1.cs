using Newtonsoft.Json;
using RestaurAdminApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurAdminApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            try
            {
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Info\DatiSensibili";
                string key = txbChiave.Text;
                string result = string.Empty;
                var files = from file in Directory.EnumerateFiles(folderPath) select file;
                List<string> codici = new List<string>();
                foreach (var file in files)
                {
                    string codice = JsonConvert.DeserializeObject<string>(file);
                    codici.Add(codice);
                }
                MessageBox.Show("bravooo","Coglione", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

            }

        }
    }
}
