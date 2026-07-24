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
        #region Method 
        public void VeMatBangMongCoThang(Point3d ptDiemVe)
        {
            Point3d p0 = ptDiemVe;
            double mepCoMong = 0.1;
            double mepBTLotMong = 0.1;
            // 1. Khối đế móng (p1 -> p4)
            Point3d p1 = new Point3d(p0.X - BmHm / 2, p0.Y - BmHm / 2, 0);
            Point3d p2 = new Point3d(p0.X - BmHm / 2, p0.Y + BmHm / 2, 0);
            Point3d p3 = new Point3d(p0.X + BmHm / 2, p0.Y + BmHm / 2, 0);
            Point3d p4 = new Point3d(p0.X + BmHm / 2, p0.Y - BmHm / 2, 0);
            // 2. Khối cổ móng (p5 -> p8)
            Point3d p5 = new Point3d(p0.X - BcHc / 2, p0.Y - BcHc / 2, 0);
            Point3d p6 = new Point3d(p0.X - BcHc / 2, p0.Y + BcHc / 2, 0);
            Point3d p7 = new Point3d(p0.X + BcHc / 2, p0.Y + BcHc / 2, 0);
            Point3d p8 = new Point3d(p0.X + BcHc / 2, p0.Y - BcHc / 2, 0);
            // 3. Khối mở rộng cổ móng (Phủ rộng đều ra 4 phía từ cổ móng, cân đối qua p0)
            double n = BcHc / 2 + mepCoMong;
            Point3d p9 = new Point3d(p0.X - n, p0.Y - n, 0);
            Point3d p10 = new Point3d(p0.X - n, p0.Y + n, 0);
            Point3d p11 = new Point3d(p0.X + n, p0.Y + n, 0);
            Point3d p12 = new Point3d(p0.X + n, p0.Y - n, 0);
            // 4. Lớp Bê tông lót (PBL) phủ rộng ra ngoài móng (p13 -> p16)
            Point3d p13 = new Point3d(p0.X - BmHm / 2 - mepBTLotMong, p0.Y - BmHm / 2 - mepBTLotMong, 0);
            Point3d p14 = new Point3d(p0.X - BmHm / 2 - mepBTLotMong, p0.Y + BmHm / 2 + mepBTLotMong, 0);
            Point3d p15 = new Point3d(p0.X + BmHm / 2 + mepBTLotMong, p0.Y + BmHm / 2 + mepBTLotMong, 0);
            Point3d p16 = new Point3d(p0.X + BmHm / 2 + mepBTLotMong, p0.Y - BmHm / 2 - mepBTLotMong, 0);
            // 5. Đường trục tim vượt ra ngoài biên móng 100mm (p17 -> p20)
            Point3d p17 = new Point3d(p0.X - BmHm / 2 - BTBVDay / 1000 * 2, p0.Y, 0); // Trục X trái
            Point3d p18 = new Point3d(p0.X + BmHm / 2 + BTBVDay / 1000 * 2, p0.Y, 0); // Trục X phải
            Point3d p19 = new Point3d(p0.X, p0.Y - BmHm / 2 - BTBVDay / 1000 * 2, 0); // Trục Y dưới
            Point3d p20 = new Point3d(p0.X, p0.Y + BmHm / 2 + BTBVDay / 1000 * 2, 0); // Trục Y trên
            // --- VẼ CÁC ĐỐI TƯỢNG VÀO CAD ---
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
            ClCAD.SetLayerCurrent("COTTHEP");
            // --- TÍNH TOÁN CÁC ĐIỂM THÉP XIÊN (TỶ LỆ 2/3) ---
            // Khoảng dịch chuyển 2/3 từ mép móng vào cổ móng
            double dx23 = (BmHm - BcHc) / 3.0; // 2/3 x (BmHm - BcHc)/2 = (BmHm - BcHc)/3
            double dy23 = (BmHm - BcHc) / 3.0;
            double dxCoMong = (BmHm - BcHc) / 12.0; // Khoảng lùi xiên của pThep1
            double dyCoMong = (BmHm - BcHc) / 12.0;
            // 1. Điểm giao đường xiên móng
            Point3d pThep2 = new Point3d(p0.X - BmHm / 2.0 + dx23, p0.Y + BmHm / 2.0 - dx23, 0);
            Point3d pThep3 = new Point3d(p0.X - BmHm / 2.0 + dx23, p0.Y - BmHm / 2.0 + dx23, 0);
            // 2. Điểm đỉnh, đáy và mỏ neo (pThep1 bị lùi xiên x về bên trái)
            Point3d pThep1 = new Point3d(p0.X - BmHm / 2.0 + dx23 - dxCoMong, p0.Y + BmHm / 2.0 - BTBVDay / 1000.0, 0);
            Point3d pThep1_Mo = new Point3d(pThep1.X - 0.1, pThep1.Y, 0);
            Point3d pThep4 = new Point3d(p0.X - BmHm / 2.0 + dx23 - dxCoMong, p0.Y - BmHm / 2.0 + BTBVDay / 1000.0, 0);
            Point3d pThep4_Mo = new Point3d(pThep4.X - 0.1, pThep4.Y, 0);
            // --- VẼ VÀO AUTOCAD ---
            ClCAD.SetLayerCurrent("COTTHEP");
            // Đoạn màu vàng ở giữa
            ClCAD.CreateLine(pThep2, pThep3);
            // Đoạn màu tím phía trên (Mỏ -> Đỉnh xiên -> Giao điểm 2)
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pThep1_Mo, pThep1, pThep2 }, false);
            // Đoạn màu tím phía dưới (Giao điểm 3 -> Đáy xiên -> Mỏ)
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pThep3, pThep4, pThep4_Mo }, false);
            // --- CÁC KHOẢNG KÍCH THƯỚC TIẾP THEO ---
            double dx16 = (BmHm - BcHc) / 6.0;        // Tỷ lệ 1/6 (Sát mép hơn)
            double dy16 = (BmHm - BcHc) / 6.0;
            double btbv = BTBVDay / 1000.0;            // Đổi mm sang m
            //---------THANH NGANG PHÍA DƯỚI DỪNG Ở TÂM (pThep5 -> pThep7)--------
            Point3d pThep5 = new Point3d(p0.X - BmHm / 2.0 + btbv, p0.Y - BmHm / 2.0 + dy23 - dyCoMong, 0);
            Point3d pThep5_Mo = new Point3d(pThep5.X, pThep5.Y - 0.1, 0); // Mỏ ngoắc xuống dưới
            Point3d pThep6 = new Point3d(p0.X - BmHm / 2.0 + dy23, p0.Y - BmHm / 2.0 + dy23, 0);
            // Giao điểm vát
            Point3d pThep7 = new Point3d(p0.X, pThep6.Y, 0);
            // Dừng tại tim móng (X = p0.X)
            double xThep89 = p0.X + BmHm / 2.0 - dx16;
            // Mép trên & mép dưới sát lớp bê tông bảo vệ
            Point3d pThep8 = new Point3d(xThep89, p0.Y + BmHm / 2.0 - btbv, 0);
            Point3d pThep9 = new Point3d(xThep89, p0.Y - BmHm / 2.0 + btbv, 0);
            // 2. THANH NGANG TRÊN PHẢI DỪNG Ở TÂM (pThep10 -> pThep11)
            double yThep1011 = p0.Y + BmHm / 2.0 - dy16;
            // pThep10: Lùi VÀO TRONG lòng móng từ mép phải (X trừ btbv)
            Point3d pThep10 = new Point3d(p0.X + BmHm / 2.0 - btbv, yThep1011, 0);
            // pThep11: Điểm dừng tại tim móng (X = p0.X)
            Point3d pThep11 = new Point3d(p0.X, yThep1011, 0);
            // -----THỰC HIỆN VẼ VÀO AUTOCAD-------
            ClCAD.SetLayerCurrent("THEP");
            // Vẽ Thanh Dọc Phải (Thẳng nối từ 8 -> 9)
            ClCAD.CreateLine(pThep8, pThep9);
            // Vẽ Thanh Ngang Trên (Mỏ 10 -> 10 -> 11)
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pThep10, pThep11 }, false);
        }
        #endregion
    }
}
