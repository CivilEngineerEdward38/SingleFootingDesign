using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ACAD_API.SINGLE_FOOTING.Model
{
    public class SettingModel : BaseViewModel
    {
        private double _bMhM;

        public double BmHm
        {
            get { return _bMhM; }
            set { _bMhM = value; OnPropertyChanged(); }
        }
        private double _hM;

        public double Hm
        {
            get { return _hM; }
            set { _hM = value; OnPropertyChanged(); }
        }
        private double _d;

        public double D
        {
            get { return _d; }
            set { _d = value; OnPropertyChanged(); }
        }
        private double _bChC;

        public double BcHc
        {
            get { return _bChC; }
            set { _bChC = value; OnPropertyChanged(); }
        }
        private double _hB;

        public double Hb
        {
            get { return _hB; }
            set { _hB = value; OnPropertyChanged(); }
        }
        private double _hV;

        public double Hv
        {
            get { return _hV; }
            set { _hV = value; OnPropertyChanged(); }
        }
        private double _btbvDay;

        public double BTBVDay
        {
            get { return _btbvDay; }
            set { _btbvDay = value; OnPropertyChanged(); }
        }
        private double _btbvConLai;

        public double BTBVConLai
        {
            get { return _btbvConLai; }
            set { _btbvConLai = value; OnPropertyChanged(); }
        }
        private List<int> _tyLeBV;

        public List<int> TyLeBV
        {
            get { return _tyLeBV; }
            set { _tyLeBV = value; OnPropertyChanged(); }
        }
        private int _chonTyLe;

        public int ChonTyLe
        {
            get { return _chonTyLe; }
            set { _chonTyLe = value; OnPropertyChanged(); }
        }
        private double _hatchScale;

        public double HatchScale
        {
            get { return _hatchScale; }
            set { _hatchScale = value; OnPropertyChanged(); }
        }
        #region RadioButton
        private bool _typeofA;

        public bool TypeOfA
        {
            get { return _typeofA; }
            set { _typeofA = value; OnPropertyChanged(); }
        }
        private bool _typeofB;
        public bool TypeOfB
        {
            get { return _typeofB; }
            set { _typeofB = value; OnPropertyChanged(); }
        }

        #endregion

        public SettingModel()
        {
            //Initialization : khởi tạo các giá trị đầu vào default trong constructor 
            BmHm = 4.0;
            Hm = 3.4;
            D = 0.5;
            BcHc = 0.8;
            Hb = 1.0;
            Hv = 0.4;
            BTBVDay = 50;
            BTBVConLai = 40;
            TyLeBV = new List<int> { 25, 50, 75, 100, 150, 200 };
            ChonTyLe = TyLeBV[3];
            HatchScale = 5;
            //initial type of Singlefooting
            TypeOfA = true;
            TypeOfB = false;

        }
        public static void CreateLayer()
        {
            ClCAD.CreateLayer("MAIN", 3, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("DIM", 4, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("COTTHEP", 2, "Continuous", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
            ClCAD.CreateLayer("CENTER", 4, "CENTER", Autodesk.AutoCAD.DatabaseServices.LineWeight.ByLineWeightDefault, true);
        }
        public static void CreateTextStyle()
        {
            ClCAD.CreateTextStyle("PECC3_Tahoma", "Tahoma", 0, 1, false, false);
        }
        public static void CreateDimStyle(List<int> dsTyLe)
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
        #region Method 
        public void VeMatBangMongCoThang(Point3d ptDiemVe)
        {
            Point3d p0 = ptDiemVe;
            // Hệ số quy đổi kích thước thực (m) -> đơn vị vẽ theo tỷ lệ đang chọn
            double heSo = 1000.0 / ChonTyLe;
            double V(double kichThuocThucMet) => kichThuocThucMet * heSo;
            // Các kích thước thực -> quy đổi sang kích thước vẽ
            double bmhmVe = V(BmHm);
            double bchcVe = V(BcHc);
            double mepCoMongVe = V(0.1);
            double mepBTLotMongVe = V(0.1);
            double moNeoVe = V(0.1);           // mỏ neo cốt thép (gốc 100mm thực)
            double btbvVe = BTBVDay / ChonTyLe; // BTBVDay là mm thực: (BTBVDay/1000)*heSo = BTBVDay/ChonTyLe
            // 1. Khối đế móng (p1 -> p4)
            Point3d p1 = new Point3d(p0.X - bmhmVe / 2, p0.Y - bmhmVe / 2, 0);
            Point3d p2 = new Point3d(p0.X - bmhmVe / 2, p0.Y + bmhmVe / 2, 0);
            Point3d p3 = new Point3d(p0.X + bmhmVe / 2, p0.Y + bmhmVe / 2, 0);
            Point3d p4 = new Point3d(p0.X + bmhmVe / 2, p0.Y - bmhmVe / 2, 0);
            // 2. Khối cổ móng (p5 -> p8)
            Point3d p5 = new Point3d(p0.X - bchcVe / 2, p0.Y - bchcVe / 2, 0);
            Point3d p6 = new Point3d(p0.X - bchcVe / 2, p0.Y + bchcVe / 2, 0);
            Point3d p7 = new Point3d(p0.X + bchcVe / 2, p0.Y + bchcVe / 2, 0);
            Point3d p8 = new Point3d(p0.X + bchcVe / 2, p0.Y - bchcVe / 2, 0);
            // 3. Khối mở rộng cổ móng
            double n = bchcVe / 2 + mepCoMongVe;
            Point3d p9 = new Point3d(p0.X - n, p0.Y - n, 0);
            Point3d p10 = new Point3d(p0.X - n, p0.Y + n, 0);
            Point3d p11 = new Point3d(p0.X + n, p0.Y + n, 0);
            Point3d p12 = new Point3d(p0.X + n, p0.Y - n, 0);
            // 4. Lớp BT lót
            Point3d p13 = new Point3d(p0.X - bmhmVe / 2 - mepBTLotMongVe, p0.Y - bmhmVe / 2 - mepBTLotMongVe, 0);
            Point3d p14 = new Point3d(p0.X - bmhmVe / 2 - mepBTLotMongVe, p0.Y + bmhmVe / 2 + mepBTLotMongVe, 0);
            Point3d p15 = new Point3d(p0.X + bmhmVe / 2 + mepBTLotMongVe, p0.Y + bmhmVe / 2 + mepBTLotMongVe, 0);
            Point3d p16 = new Point3d(p0.X + bmhmVe / 2 + mepBTLotMongVe, p0.Y - bmhmVe / 2 - mepBTLotMongVe, 0);
            // 5. Trục tim
            Point3d p17 = new Point3d(p0.X - bmhmVe / 2 - btbvVe * 2, p0.Y, 0);
            Point3d p18 = new Point3d(p0.X + bmhmVe / 2 + btbvVe * 2, p0.Y, 0);
            Point3d p19 = new Point3d(p0.X, p0.Y - bmhmVe / 2 - btbvVe * 2, 0);
            Point3d p20 = new Point3d(p0.X, p0.Y + bmhmVe / 2 + btbvVe * 2, 0);
            // --- VẼ ĐƯỜNG BIÊN ---
            ClCAD.SetLayerCurrent("MAIN");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3, p4 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5, p6, p7, p8 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p9, p10, p11, p12 }, true);
            ClCAD.CreateLine(p1, p9);
            ClCAD.CreateLine(p2, p10);
            ClCAD.CreateLine(p3, p11);
            ClCAD.CreateLine(p4, p12);
            ClCAD.SetLayerCurrent("DIM");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p13, p14, p15, p16 }, true);
            ClCAD.SetLayerCurrent("CENTER");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p17, p18 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p19, p20 }, false);
            // --- CỐT THÉP XIÊN ---
            ClCAD.SetLayerCurrent("COTTHEP");
            double dx23 = (bmhmVe - bchcVe) / 3.0;
            double dy23 = (bmhmVe - bchcVe) / 3.0;
            double dxCoMong = (bmhmVe - bchcVe) / 12.0;
            double dyCoMong = (bmhmVe - bchcVe) / 12.0;
            Point3d pThep2 = new Point3d(p0.X - bmhmVe / 2.0 + dx23, p0.Y + bmhmVe / 2.0 - dx23, 0);
            Point3d pThep3 = new Point3d(p0.X - bmhmVe / 2.0 + dx23, p0.Y - bmhmVe / 2.0 + dx23, 0);
            Point3d pThep1 = new Point3d(p0.X - bmhmVe / 2.0 + dx23 - dxCoMong, p0.Y + bmhmVe / 2.0 - btbvVe, 0);
            Point3d pThep1_Mo = new Point3d(pThep1.X - moNeoVe, pThep1.Y, 0);
            Point3d pThep4 = new Point3d(p0.X - bmhmVe / 2.0 + dx23 - dxCoMong, p0.Y - bmhmVe / 2.0 + btbvVe, 0);
            Point3d pThep4_Mo = new Point3d(pThep4.X - moNeoVe, pThep4.Y, 0);
            ClCAD.CreateLine(pThep2, pThep3);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pThep1_Mo, pThep1, pThep2 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pThep3, pThep4, pThep4_Mo }, false);
            // --- CỐT THÉP NGANG ---
            double dx16 = (bmhmVe - bchcVe) / 6.0;
            double dy16 = (bmhmVe - bchcVe) / 6.0;
            Point3d pThep5 = new Point3d(p0.X - bmhmVe / 2.0 + btbvVe, p0.Y - bmhmVe / 2.0 + dy23 - dyCoMong, 0);
            Point3d pThep5_Mo = new Point3d(pThep5.X, pThep5.Y - moNeoVe, 0);
            Point3d pThep6 = new Point3d(p0.X - bmhmVe / 2.0 + dy23, p0.Y - bmhmVe / 2.0 + dy23, 0);
            Point3d pThep7 = new Point3d(p0.X, pThep6.Y, 0);
            double xThep89 = p0.X + bmhmVe / 2.0 - dx16;
            Point3d pThep8 = new Point3d(xThep89, p0.Y + bmhmVe / 2.0 - btbvVe, 0);
            Point3d pThep9 = new Point3d(xThep89, p0.Y - bmhmVe / 2.0 + btbvVe, 0);
            double yThep1011 = p0.Y + bmhmVe / 2.0 - dy16;
            Point3d pThep10 = new Point3d(p0.X + bmhmVe / 2.0 - btbvVe, yThep1011, 0);
            Point3d pThep11 = new Point3d(p0.X, yThep1011, 0);
            ClCAD.SetLayerCurrent("COTTHEP");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pThep5_Mo, pThep5, pThep6, pThep7 }, false);
            ClCAD.CreateLine(pThep8, pThep9);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pThep10, pThep11 }, false);
            #region
            ClCAD.SetLayerCurrent("DIM");
            string strScale = string.Format("TL1-{0}", ChonTyLe.ToString());
            ClCAD.SetDimStyleCurrent(strScale);
            double dimOffset = mepBTLotMongVe + moNeoVe;
            List<Point3d> dsX = new List<Point3d>()
            {
                new Point3d(p13.X, p13.Y , 0),
                new Point3d(p1.X, p13.Y, 0),
                new Point3d(p0.X, p13.Y , 0),
                new Point3d(p4.X, p13.Y , 0),
                new Point3d(p16.X, p13.Y, 0)
            };
            List<Point3d> dsX2 = new List<Point3d>()
            {
                new Point3d(p1.X, p13.Y, 0),
                new Point3d(p4.X, p13.Y, 0)
            };
            ClCAD.CreateDimension_X(dsX, ChonTyLe, 1,2);
            ClCAD.CreateDimension_X(dsX2, ChonTyLe, 2,2);
            List<Point3d> dsY = new List<Point3d>()
            {
                new Point3d(p13.X, p14.Y, 0), // Đỉnh BT lót (trên)
                new Point3d(p13.X , p2.Y, 0),  // Đỉnh móng
                new Point3d(p13.X , p0.Y, 0),  // Tim móng
                new Point3d(p13.X , p1.Y, 0),  // Đáy móng
                new Point3d(p13.X , p13.Y, 0)  // Đáy BT lót (dưới)
            };
            List<Point3d> dsY2 = new List<Point3d>()
            {
                new Point3d(p13.X, p2.Y, 0),
                new Point3d(p13.X, p1.Y, 0)
            };
            ClCAD.CreateDimension_Y(dsY, ChonTyLe, 1,2);
            ClCAD.CreateDimension_Y(dsY2, ChonTyLe, 2,2);
            #endregion
        }
        #endregion
    }
}
