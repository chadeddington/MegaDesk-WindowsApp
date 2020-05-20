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
    public partial class SearchQuotes : Form
    {
        public MainMenu MainMenu { get; set; }

        public SearchQuotes(MainMenu menu)
        {
            InitializeComponent();
            searchCmbo.DataSource = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();
            displaySearchResults(DesktopMaterial.Oak);
            this.MainMenu = menu;
        }

        private void displaySearchResults(DesktopMaterial surfaceType)
        {
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

            searchResultsDataGrid.DataSource = deskQuotes.Select(d => new
            {
                Date = d.DateCreated,
                Customer = d.CustomerName,
                Depth = d.Desk.Depth,
                Width = d.Desk.Width,
                Drawers = d.Desk.NumOfDrawers,
                SurfaceMaterial = d.Desk.SurfaceType,
                ShippingTime = d.ShippingTime,
                QuoteAmount = "$" + d.QuotePrice

            }).Where(d => d.SurfaceMaterial == surfaceType).ToList();
        }

        private void searchCmbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySearchResults((DesktopMaterial) searchCmbo.SelectedItem);
        }

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.MainMenu.Show();
        }
    }
}
