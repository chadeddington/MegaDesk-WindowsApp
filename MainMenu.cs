﻿using System;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newQuoteBtn_Click(object sender, EventArgs e)
        {
            AddQuote newQuote = new AddQuote(this);
            newQuote.Tag = this;
            newQuote.Show();
            this.Hide();
        }
    }
}
