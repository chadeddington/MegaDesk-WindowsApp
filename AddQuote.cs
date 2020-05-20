using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MegaDesk_Eddington
{
    // Shipping
    public enum DeliveryType
    {
        fourteen,
        three,
        five,
        seven
    }
    public partial class AddQuote : Form
    {
       
        

        private Form _mainMenu;
        public AddQuote(Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;

            // SurfaceMaterial
            var materials = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();
            surfaceMaterialCmbo.DataSource = materials;

            var delivery = Enum.GetValues(typeof(DeliveryType)).Cast<DeliveryType>().ToList();
            ShippingCmbo.DataSource = delivery;
        }

     

        private void AddQuoteToFile(DeskQuote quote)
        {
            List<DeskQuote> deskQuotes = new List<DeskQuote>();
            var quotesFile = "quotes.json";
            
            if (File.Exists(quotesFile))
            {
                using(StreamReader reader = new StreamReader(quotesFile))
                {
                    string quotes = reader.ReadToEnd();

                    if(quotes.Length > 0)
                    {
                        deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotes);
                    }
                }
            }

            deskQuotes.Add(quote);

            var serializedQuotes = JsonConvert.SerializeObject(deskQuotes);
            File.WriteAllText(quotesFile, serializedQuotes);
        }

        private void GenerateQuoteBtn_Click(object sender, EventArgs e)
        {
            string name = NameInput.Text;
            Desk desk = new Desk();
            desk.Width = deskWidth.Value;
            desk.Depth = deskDepth.Value;
            desk.NumOfDrawers = numOfDrawers.Value;
            desk.SurfaceType = (DesktopMaterial)surfaceMaterialCmbo.SelectedItem;

            DeskQuote quote = new DeskQuote(desk, name, (DeliveryType)ShippingCmbo.SelectedItem);
            quote.QuotePrice = quote.CalculateAmount();
            try
            {
                AddQuoteToFile(quote);
            }
            catch (Exception ex)
            {
                // Handle Exception
            }
            
            DisplayQuote display = new DisplayQuote(_mainMenu, desk, quote);
            display.Show();
            this.Hide();
        }

        private void AdQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
           _mainMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NameInput_TextChanged(object sender, EventArgs e)
        {
            if (NameInput.TextLength > 0)
            {
                GenerateQuoteBtn.Enabled = true;
            }
            else
            {
                GenerateQuoteBtn.Enabled = false;
            }
        }
    }
}
