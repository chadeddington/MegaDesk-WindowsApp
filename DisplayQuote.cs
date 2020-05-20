using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Eddington
{
    public partial class DisplayQuote : Form
    {
        private Form _mainMenu;
        public DisplayQuote(Form mainMenu, Desk desk, DeskQuote quote)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            // Customer Info
            nameLabel.Text = quote.CustomerName;
            dateLabel.Text = quote.DateCreated.ToString("dd MMM yyyy");
            shippingLabel.Text = quote.ShippingTime;

            // Desk Info
            widthLabel.Text = desk.Width.ToString();
            depthLabel.Text = desk.Depth.ToString();
            drawersLabel.Text = desk.NumOfDrawers.ToString();
            materialLabel.Text = desk.SurfaceType.ToString();

            // Quote Price
            priceLabel.Text = "$" + quote.QuotePrice.ToString();

        }

        private void DisplayQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
            this.Hide();
        }
    }
}
