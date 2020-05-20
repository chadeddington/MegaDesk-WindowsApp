using Newtonsoft.Json;
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

namespace MegaDesk_Eddington
{
    public partial class ViewAllQuotes : Form
    {
        public List<DeskQuote> DeskQuotes { get; set; }
        public MainMenu MainMenu { get; set; }

        public ViewAllQuotes(MainMenu mainMenu)
        {
            this.MainMenu = mainMenu;
            InitializeComponent();

            List<DeskQuote> deskQuotes = new List<DeskQuote>();
            var quotesFile = "quotes.json";

            if (File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    string quotes = reader.ReadToEnd();

                    if (quotes.Length > 0)
                    {
                        deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotes);
                    }
                }
            }

            dataGridView.DataSource = deskQuotes.Select(d => new
            {
                Date = d.DateCreated,
                Customer = d.CustomerName,
                Depth = d.Desk.Depth,
                Width = d.Desk.Width,
                Drawers = d.Desk.NumOfDrawers,
                SurfaceMaterial = d.Desk.SurfaceType,
                ShippingTime = d.ShippingTime,
                QuoteAmount = "$" + d.QuotePrice

            }).ToList();
        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.MainMenu.Show();
        }
    }
}
