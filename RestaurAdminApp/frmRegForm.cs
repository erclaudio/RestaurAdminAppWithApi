using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurAdminApp
{
    public partial class frmRegForm : Form
    {
        public frmRegForm()
        {
            InitializeComponent();
        }

        private void frmRegForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void btnreg_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await CallWebApiRegistration(CreateClientInfoObject());
                Models.CodiceControllo codice = new Models.CodiceControllo() { Codice = result };
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Info\DatiSensibili\RegInfo.json"))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(codice));
                    sw.Close();
                }
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private RequestModels.RequestClient CreateClientInfoObject()
        {
            RequestModels.RequestClient requestClientInfo = new RequestModels.RequestClient();
                if (string.IsNullOrEmpty(txbNome.Text) || string.IsNullOrEmpty(txbIva.Text) || string.IsNullOrEmpty(txbIndirizzo.Text)
                                || string.IsNullOrEmpty(txbTel.Text) || string.IsNullOrEmpty(txbMail.Text))
                {
                    MessageBox.Show("Errore, Compila tutti I campi", "Errore Compilazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txbMail.Text.Contains('@'))
                    {
                    
                        {

                            requestClientInfo.RegioneSociale = txbNome.Text.Trim().ToUpper();
                            requestClientInfo.Piva = txbIva.Text.Trim().ToUpper();
                            requestClientInfo.Email = txbMail.Text.Trim().ToLower();
                            requestClientInfo.Indirizzo = txbTel.Text.Trim().ToUpper();
                            requestClientInfo.Telefono = txbTel.Text.Trim().ToUpper();

                        };

                    }
                    else
                    {
                        MessageBox.Show("Errore, Compila la mail", "Errore Mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            return requestClientInfo;
        }
        private async Task<string> CallWebApiRegistration(RequestModels.RequestClient requestClientInfo) 
        { 
            string codice = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                var url = "http://localhost:64616/api/prova";
                var requestConent = new StringContent(JsonConvert.SerializeObject(requestClientInfo), Encoding.Unicode, "application/json");
                var response = await client.PostAsync(url, requestConent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    codice = await response.Content.ReadAsStringAsync();
                }
            }
            return codice;
        }
    }
}
