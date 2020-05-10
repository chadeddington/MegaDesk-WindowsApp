using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Eddington
{
    public enum DesktopMaterial
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer
    };

    public class Desk
    {
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public DesktopMaterial SurfaceType { get; set; }
        public decimal NumOfDrawers { get; set; }

        public Desk()
        {

        }
    }
}
