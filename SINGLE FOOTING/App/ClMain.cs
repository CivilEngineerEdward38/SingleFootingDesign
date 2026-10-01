using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINGLE_FOOTING.App
{
    public class ClMain
    {
        public static void SetDefault()
        {
            CreateLayer();
            CreateTextStyle();
            CreateDimStyle(new List<int> { 10,20, 25, 50,75, 100,150,200,250 });

        }
        private static void CreateLayer()
        {
            ClCAD.CreateLayer("MAIN", 3, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("DIM", 4, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("COTTHEP", 2, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("CENTER", 4, "CENTER", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("HIDDEN", 4, "HIDDEN", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("CHU", 3, "HIDDEN", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("HA", 4, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("NETCHINH", 3, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight018, true);
            ClCAD.CreateLayer("DUONGTRUC", 212, "CENTER", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight013, true);
            ClCAD.CreateLayer("NETTHEPCHU", 1, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight030, true);
            ClCAD.CreateLayer("NETTHEPDAI", 2, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight030, true);
            ClCAD.CreateLayer("NETDIM", 4, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight005, true);
            ClCAD.CreateLayer("NETPHU", 253, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight009, true);
            ClCAD.CreateLayer("NETMATCAT", 6, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight009, true);
            ClCAD.CreateLayer("NETTAGTHEP", 4, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight005, true);
            ClCAD.CreateLayer("NETHIDDEN", 4, "HIDDEN", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight013, false);
            ClCAD.CreateLayer("NETKHUNGA3", 0, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight013, true);
            ClCAD.CreateLayer("NETHATCH", 0, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight013, true);
            ClCAD.CreateLayer("NETVAIDIA", 244, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.LineWeight050, true);
        }
        private static void CreateTextStyle()
        {
            ClCAD.CreateTextStyle("PECC3_Tahoma", "Tahoma", 0, 1, false, false);
            ClCAD.CreateTextStyle("PECC3_Tahoma_Bold", "Tahoma", 0, 1, false, true);
            ClCAD.CreateTextStyle("VNIHC", "VNI-Helve-Condense", 0, 0.7, false, false);
            ClCAD.CreateTextStyle("CHUTIEUDE", "Arial", 0, 1, false, false);
            ClCAD.CreateTextStyle("CHUTHUONG", "Arial", 0, 1, false, false);
            ClCAD.CreateTextStyle("CHUINDAM", "Arial", 0, 1, false, true);
        }
        private static void CreateDimStyle(List<int> dsTyLe)
        {
            foreach (int tyLe in dsTyLe)
            {
                var setting = new ClCAD.DimStyleSettings()
                {
                    Name = $"TL1-{tyLe}",
                    fit = 1,
                    scaleFactor = tyLe
                };
                ClCAD.CreateDimStyles(setting);
            }
        }
    }
}
