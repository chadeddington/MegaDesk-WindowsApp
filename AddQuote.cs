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
    public partial class AddQuote : Form
    {
        private Form _mainMenu;
        public AddQuote(Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;

            // SurfaceMaterial
            surfaceMaterialCmbo.DataSource = Enum.GetValues(typeof(DesktopMaterial));

            // Shipping
            ShippingCmbo.Items.Add(3);
            ShippingCmbo.Items.Add(5);
            ShippingCmbo.Items.Add(7);
            ShippingCmbo.Items.Add(14);
            ShippingCmbo.SelectedItem = 14;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GenerateQuoteBtn_Click(object sender, EventArgs e)
        {
            string name = "";
            Desk desk = new Desk();
            try
            {
                desk.Width = deskWidth.Value;
                desk.Depth = deskDepth.Value;
                desk.NumOfDrawers = numOfDrawers.Value;
                desk.SurfaceType = (DesktopMaterial) surfaceMaterialCmbo.SelectedItem;
                name = NameInput.Text;
            }
            catch (Exception ex)
            {
                // Handle Exception
            }

            DeskQuote quote = new DeskQuote(desk, name, ShippingCmbo.GetItemText(ShippingCmbo.SelectedItem));

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
