using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Eddington
{
    public class DeskQuote
    {
        private int[,] _shippingPrices;

        public string CustomerName { get; set; }
        public Desk Desk { get; set; }
        public string ShippingTime { get; set; }
        public DateTime DateCreated { get; }
        public decimal QuotePrice { get; set; }



        public DeskQuote(Desk desk, string name, string shippingTime)
        {
            this.Desk = desk;
            this.CustomerName = name;
            this.ShippingTime = shippingTime;
            this.DateCreated = DateTime.Today;

        }
        public decimal CalculateAmount()
        {
            decimal baseCost = 200;
            // Surface Area Cost
            decimal surfaceArea = this.Desk.Width * this.Desk.Depth;
            decimal surfaceAreaCost = 0;
            if (surfaceArea > 1000)
            {
                surfaceAreaCost = surfaceArea - 1000;
            }

            // ShippingCost
            decimal shippingCost = 0;
            if (this.ShippingTime == "3")
            {
                shippingCost = (surfaceArea < 1000) ? 60 : (surfaceArea < 2000) ? 70 : 80;
            }
            else if (this.ShippingTime == "5")
            {
                shippingCost = (surfaceArea < 1000) ?40 : (surfaceArea < 2000) ? 50 : 60;
            }
            else if (this.ShippingTime == "7")
            {
                shippingCost = (surfaceArea < 1000) ? 30 : (surfaceArea < 2000) ? 35 : 40;
            }

            // Drawers Cost
            decimal drawersCost = this.Desk.NumOfDrawers * 50;
             
            // Material Cost
            decimal materialCost = 0;
            switch (this.Desk.SurfaceType)
            {
                case DesktopMaterial.Oak:
                    materialCost = 200;
                    break;
                case DesktopMaterial.Laminate:
                    materialCost = 100;
                    break;
                case DesktopMaterial.Rosewood:
                    materialCost = 300;
                    break;
                case DesktopMaterial.Pine:
                    materialCost = 50;
                    break;
                case DesktopMaterial.Veneer:
                    materialCost = 125;
                    break;
            }

            decimal totalCost = baseCost + surfaceAreaCost + shippingCost + drawersCost + materialCost;
            return totalCost;
        }

        private decimal GetRushOrder()
        {
            return 0.00M;
        }
    }
}
