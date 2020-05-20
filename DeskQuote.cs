using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Eddington
{
    public class DeskQuote
    {
        private int[,] _rushOrderPrices;

        public string CustomerName { get; set; }
        public Desk Desk { get; set; }
        public DeliveryType ShippingTime { get; set; }
        public DateTime DateCreated { get; }
        public decimal QuotePrice { get; set; }



        public DeskQuote(Desk desk, string name, DeliveryType shippingTime)
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
            getRushOrder();
            
           switch (this.ShippingTime)
           {
                case DeliveryType.three:
                    if (surfaceArea < 1000)
                    {
                        shippingCost = _rushOrderPrices[0, 0];
                    }
                    else if (surfaceArea <= 2000)
                    {
                        shippingCost = _rushOrderPrices[0, 1];
                    }
                    else
                    {
                        shippingCost = _rushOrderPrices[0, 2];
                    }
                    break;
                case DeliveryType.five:
                    if (surfaceArea < 1000)
                    {
                        shippingCost = _rushOrderPrices[1, 0];
                    }
                    else if (surfaceArea <= 2000)
                    {
                        shippingCost = _rushOrderPrices[1, 1];
                    }
                    else
                    {
                        shippingCost = _rushOrderPrices[1, 2];
                    }
                    break;
                case DeliveryType.seven:
                    if (surfaceArea < 1000)
                    {
                        shippingCost = _rushOrderPrices[2, 0];
                    }
                    else if (surfaceArea <= 2000)
                    {
                        shippingCost = _rushOrderPrices[2, 1];
                    }
                    else
                    {
                        shippingCost = _rushOrderPrices[2, 2];
                    }
                    break;
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

        private void getRushOrder()
        {
            _rushOrderPrices = new int[3, 3];

            var pricesFile = @"rushOrderPrices.txt";

            try
            {
                string[] prices = File.ReadAllLines(pricesFile);
                int i = 0, j = 0;

                foreach (string price in prices)
                {
                    _rushOrderPrices[i, j] = int.Parse(price);

                    if (j == 2)
                    {
                        i++;
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
