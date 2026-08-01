using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;
namespace SINGLE_FOOTING.SINGLE_FOOTING.Model
{
    public class RebarModel : BaseViewModel
    {
        private List<int> _allDuongKinhThep;

        public List<int> AllDuongKinhThep
        {
            get { return _allDuongKinhThep; }
            set { _allDuongKinhThep = value; OnPropertyChanged(); }
        }
        private int _duongKinhThepBan;

        public int DuongKinhThepBan
        {
            get { return _duongKinhThepBan; }
            set { _duongKinhThepBan = value; OnPropertyChanged(); }
        }
        private double _khoangCachThepBan;

        public double KhoangCachThepBan
        {
            get { return _khoangCachThepBan; }
            set { _khoangCachThepBan = value; OnPropertyChanged(); }
        }

        private int _duongKinhThepCoMong;

        public int DuongKinhThepCoMong
        {
            get { return _duongKinhThepCoMong; }
            set { _duongKinhThepCoMong = value; OnPropertyChanged(); }
        }
        private int _slThepCoMong;

        public int SLThepCoMong
        {
            get { return _slThepCoMong; }
            set { _slThepCoMong = value; OnPropertyChanged(); }
        }
        private int _duongKinhThepDai;

        public int DuongKinhThepDai
        {
            get { return _duongKinhThepDai; }
            set { _duongKinhThepDai = value; OnPropertyChanged(); }
        }
        private double _khoangCachRaiDai;

        public double KhoangCachRaiDai
        {
            get { return _khoangCachRaiDai; }
            set { _khoangCachRaiDai = value; OnPropertyChanged(); }
        }
        private string _ghiChuSLThepCm;

        public string GhiChuSLThepCm
        {
            get { return _ghiChuSLThepCm; }
            set { _ghiChuSLThepCm = value; OnPropertyChanged(); }
        }
        public RebarModel()
        {
            AllDuongKinhThep = new List<int> { 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32 };
            DuongKinhThepBan = AllDuongKinhThep[2];
            KhoangCachThepBan = 200;
            DuongKinhThepCoMong = AllDuongKinhThep[6];
            SLThepCoMong = 24;
            DuongKinhThepDai = AllDuongKinhThep[0];
            KhoangCachRaiDai = 200;
        }
        public void VeThepMatDungMongCoThang(Point3d ptDiemVe, double btbvDay, double btbvConLai, double bMhM, double bChC, double hB, double hV, double hM, double d, int dkThepBan, double kcThepBan, double scale)
        {
            #region Quy đổi kích thước 
            Point3d p0 = ptDiemVe;    //qa trái là trừ, qua phải là cộng, lên là cộng xuống là trừ 
            // Hệ số quy đổi kích thước thực (m) -> đơn vị vẽ theo tỷ lệ đang chọn
            double heSoQuyDoi = 1000.0 / scale;
            double ToDrawing(double meter) => meter * heSoQuyDoi;
            // Các kích thước thực -> quy đổi sang kích thước vẽ
            double bmhmVe = ToDrawing(bMhM);
            double bchcVe = ToDrawing(bChC);
            double hvVe = ToDrawing(hV);
            double hmVe = ToDrawing(hM);
            double hbVe = ToDrawing(hB);
            double mepCoMongVe = ToDrawing(0.1);
            double mepBTLotMongVe = ToDrawing(0.1);
            double dVe = ToDrawing(d);
            double btbvVe = btbvDay / scale; // BTBVDay là mm thực: (BTBVDay/1000)*heSoQuyDoi = BTBVDay/ChonTyLe
            double btbvConlaiVe = btbvConLai / scale; // BTBVConLai là mm thực: (BTBVConLai/1000)*heSoQuyDoi = BTBVConLai/ChonTyLe

            double yDayMong = p0.Y;
            // Tính toán độc lập các tầng cao độ (Y) tính từ đáy móng đi lên (đã chia scale)
            double yDeMong = yDayMong + hbVe;
            double yVatMong = yDayMong + hvVe;
            double yCos00 = yDayMong + hmVe;
            double yDinhCoMong = yCos00 + dVe; // Cổ móng nằm trên mặt đất 
            double yRaiThepDoanBuLongNeo = yDinhCoMong - 2 * heSoQuyDoi;
            // 3. TÍNH TOÁN TỌA ĐỘ CÁC ĐIỂM ĐỘC LẬP để dễ bảo trì -> Vẽ Khung móng 
            // Các điểm bên TRÁI trục đối xứng (X âm so với p0.X)
            #endregion
            #region Point
            Point3d p1 = new Point3d(p0.X - bmhmVe / 2, yDayMong, 0);
            Point3d p2 = new Point3d(p0.X - bmhmVe / 2, yVatMong, 0);
            Point3d p3 = new Point3d(p0.X - bchcVe / 2 - mepCoMongVe, yDeMong, 0);
            Point3d p4 = new Point3d(p0.X - bchcVe / 2, yDeMong, 0);
            Point3d p5 = new Point3d(p0.X - bchcVe / 2, yDinhCoMong, 0);
            Point3d p6 = new Point3d(p0.X + bchcVe / 2, yDinhCoMong, 0);
            Point3d p7 = new Point3d(p0.X + bchcVe / 2, yDeMong, 0);
            Point3d p8 = new Point3d(p0.X + bchcVe / 2 + mepCoMongVe, yDeMong, 0);
            Point3d p9 = new Point3d(p0.X + bmhmVe / 2, yVatMong, 0);
            Point3d p10 = new Point3d(p0.X + bmhmVe / 2, yDayMong, 0);
            //Lớp bê tông bảo vệ 
            Point3d p11 = new Point3d(p0.X - bmhmVe / 2 - mepBTLotMongVe, yDayMong, 0);
            Point3d p12 = new Point3d(p0.X + bmhmVe / 2 + mepBTLotMongVe, yDayMong, 0);
            Point3d p13 = new Point3d(p0.X + bmhmVe / 2 + mepBTLotMongVe, yDayMong - btbvVe * 2, 0);
            Point3d p14 = new Point3d(p0.X - bmhmVe / 2 - mepBTLotMongVe, yDayMong - btbvVe * 2, 0);
            //Trục đứng
            Point3d p15 = new Point3d(p0.X, yDayMong - 0.5 * heSoQuyDoi, 0);
            Point3d p16 = new Point3d(p0.X, yDinhCoMong + 0.5 * heSoQuyDoi, 0);
            //điểm để rải thép a100 đi từ đỉnh cổ móng xuống 2000 (thép dày hơn khu vực bu lông neo)
            Point3d pa100L = new Point3d(p5.X, p5.Y - 2 * heSoQuyDoi, 0);
            Point3d pa100R = new Point3d(p6.X, p6.Y - 2 * heSoQuyDoi, 0);
            #endregion
            #region Point thép xem đính kèm folder img để hiểu 
            Point3d p1t = new Point3d(p1.X + btbvVe, p1.Y + btbvVe, 0);
            Point3d p10t = new Point3d(p10.X - btbvVe, p10.Y + btbvVe, 0);
            Point3d p5t = new Point3d(p5.X + btbvConlaiVe, p5.Y - btbvConlaiVe, 0);
            Point3d p6t = new Point3d(p6.X - btbvConlaiVe, p6.Y - btbvConlaiVe, 0);
            //phần bulongneo chiếm chỗ 
            Point3d pa100Lt = new Point3d(pa100L.X + btbvConlaiVe, pa100L.Y, 0);
            Point3d pa100Rt = new Point3d(pa100R.X - btbvConlaiVe, pa100R.Y, 0);
            Point3d p4a200t = new Point3d(p4.X, p4.Y + btbvConlaiVe, 0);
            Point3d p7a200t = new Point3d(p7.X, p7.Y + btbvConlaiVe, 0);
            //chân thép cổ móng 
            Point3d p4a = new Point3d(p5t.X, yDayMong + dkThepBan * 5 / DrawingScaleDefault + btbvVe, 0);
            Point3d p7a = new Point3d(p6t.X, yDayMong + dkThepBan * 5 / DrawingScaleDefault + btbvVe, 0);
            //phần anchor chân thép cổ móng 
            Point3d p4anchor = new Point3d(p4a.X - 0.4 * heSoQuyDoi, p4a.Y, 0);
            Point3d p7anchor = new Point3d(p7a.X + 0.4 * heSoQuyDoi, p7a.Y, 0);
            #endregion
            #region Vẽ thép polyline 
            ClCAD.SetLayerCurrent("COTTHEP");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1t, p10t }, false);
            //Rải thép từ đỉnh cổ móng xuống 2000mm tăng cường khu vực bulongneo 
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5t, p4a, p4anchor }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p6t, p7a, p7anchor }, false);
            double chieuDaiRaiVe = (2 - 0.04) * heSoQuyDoi;      // 2 m -> đơn vị vẽ
            double kcRaiVe = KhoangCachRaiDai / scale;  // 200 mm -> đơn vị vẽ
            int soThanh = (int)(chieuDaiRaiVe / (kcRaiVe / 2)) + 1;
            double spacing = chieuDaiRaiVe / (soThanh - 1);
            for (int i = 0; i < soThanh; i++)
            {
                double y = p5t.Y - i * spacing;
                Point3d pTrai = new Point3d(p5t.X, y, 0);
                Point3d pPhai = new Point3d(p6t.X, y, 0);
                ClCAD.CreatePolylineFromListPoints(
                    new List<Point3d> { pTrai, pPhai },
                    false);
            }
            //Phần còn lại của cổ móng 
            double chieuDaiConLaiCM = pa100Lt.Y - p4a200t.Y;
            double kcRaiVeConLai = KhoangCachRaiDai / scale;
            int soThanhConLaiCM = (int)(chieuDaiConLaiCM / kcRaiVeConLai) + 1;
            double spacingConLai = chieuDaiConLaiCM / (soThanhConLaiCM - 1);
            for (int i = 0; i < soThanhConLaiCM; i++)
            {
                double y = pa100Lt.Y - i * spacingConLai;
                Point3d pTrai = new Point3d(pa100Lt.X, y, 0);
                Point3d pPhai = new Point3d(pa100Rt.X, y, 0);
                ClCAD.CreatePolylineFromListPoints(
                    new List<Point3d> { pTrai, pPhai },
                    false);
            }
            #endregion
            #region Rải thép tròn 
            Point3d p1tRai = new Point3d(p1t.X + dkThepBan * 2.5 / DrawingScaleDefault, p1t.Y + dkThepBan * 2.5 / DrawingScaleDefault, 0);
            Point3d p10tRai = new Point3d(p10t.X - dkThepBan * 2.5 / DrawingScaleDefault, p10t.Y + dkThepBan * 2.5 / DrawingScaleDefault, 0);
            ClCAD.SetLayerCurrent("DIM");
            ClBlock.CreateBlock_Thep(dkThepBan * 5);
            string nameBlock = "COTTHEP" + (5 * dkThepBan).ToString();
            double kcThepVe = kcThepBan / scale;
            List<Point3d> dsP = LayOutReinforcement(new Point3d(p1tRai.X, p1tRai.Y, 0), new Point3d(p10tRai.X, p10tRai.Y, 0), kcThepVe, nameBlock, scale: scale, heSoPhongTo: 1, remove: false);
            dsP.Reverse();
            #endregion

            #region Thép polyline phía trên 
            Point3d p1a = new Point3d(p1.X, yDayMong + btbvVe, 0);
            Point3d p10a = new Point3d(p10.X, yDayMong + btbvVe, 0);
            ClCAD.SetLayerCurrent("COTTHEP");
            List<Point3d> lstBeTong = new List<Point3d> { p1a, p2, p3, p8, p9, p10a };
            List<Point3d> lstBTBV = this.GetBTBVPoints(lstBeTong, btbvVe); //vẽ ofset
            ClCAD.CreatePolylineFromListPoints(lstBTBV, false);  //danh sách point bê tông bảo vệ vẽ móng bản
            #endregion

            #region Rải thép tròn áp sát polyline thép trên 
            Point3d pthx = lstBTBV[0];
            Point3d pthx2 = lstBTBV[1];
            Point3d pthx3 = lstBTBV[2];
            Point3d pthx4 = lstBTBV[3];
            Point3d pthx5 = lstBTBV[4];
            Point3d pthx6 = lstBTBV[5];
            List<Point3d> lstDiemdatthepxien = new List<Point3d> { pthx, pthx2, pthx3, pthx4, pthx5, pthx6 };
            // FIX: offset của dkThepBan phải quy đổi theo scale, giống cách quy đổi btbvVe = btbvDay/scale
            // Nếu không quy đổi, offset sẽ lớn gấp hàng chục lần so với offset btbvVe ở bước trước
            // -> làm lệch hoàn toàn các điểm offset, kéo theo tính sai số lượng thanh xiên
            double dkThepBanVe = dkThepBan / (double)scale;
            List<Point3d> duongvethepxien = this.GetBTBVPoints(lstDiemdatthepxien, dkThepBan * 2.5 / DrawingScaleDefault); //đường giả để rải thép xiên
            //ClCAD.CreatePolylineFromListPoints(duongvethepxien, false);  //danh sách point bê tông bảo vệ vẽ móng bản
            Point3d theptronxiendautien = duongvethepxien[1];
            Point3d theptronxienthuhai = duongvethepxien[2];
            Point3d theptronxienthuba = duongvethepxien[3];
            Point3d theptronxiencuoi = duongvethepxien[4];
            // FIX: kcRaiXienVe phải NHÂN heSoQuyDoi, không chia
            // Công thức cũ "kcThepBan/(1000*heSoQuyDoi)" do ưu tiên toán tử "/" từ trái sang phải
            // thực chất là chia cho (kcThepBan*1000*heSoQuyDoi) -> ra số cực nhỏ, làm mọi phép tính sau sai
            double kcRaiXienVe = kcThepBan / 1000.0 * heSoQuyDoi;  // 200mm -> đơn vị vẽ
            if (kcRaiXienVe <= 0)
                throw new ArgumentException("Khoảng cách th" +
                    "" +
                    "03082ép bản phải > 0", nameof(kcThepBan));
            // Tính số lượng thanh xiên dựa trên chiều dài ngang thực tế
            double chieuDaiNgangThucTe = Math.Abs(theptronxienthuhai.X - theptronxiendautien.X);
            int SLThanhxien = (int)(chieuDaiNgangThucTe / kcRaiXienVe) + 1;
            // Bên TRÁI - lấy từ CUỐI dsP
            int indexXienTraiBatDau = dsP.Count - SLThanhxien;
            int indexXienTraiKetThuc = dsP.Count - 1;
            // Bên PHẢI - lấy từ ĐẦU dsP
            int indexXienPhaiBatDau = 0;
            int indexXienPhaiKetThuc = SLThanhxien - 1;
            // Mép an toàn quy đổi (100mm), thay cho hằng số "100.0" thiếu quy đổi ở bản cũ
            double mepAnToanVe = 0.1 * heSoQuyDoi;
            // Tính số thanh đứng ở giữa
            int SLThanhDung = (int)(bmhmVe / kcRaiXienVe) + 1
                - ((int)((bmhmVe / 2.0 - bchcVe / 2.0 - mepAnToanVe) / kcRaiXienVe) + 1) * 2;
            if (SLThanhDung < 0)
            {
                throw new InvalidOperationException($"SLThanhDung tính ra âm ({SLThanhDung}). Kiểm tra lại bmhmVe/bchcVe/kcRaiXienVe.");
            }
            int indexCuoiDuoi = SLThanhxien + SLThanhDung - 1;
            if (indexCuoiDuoi < 0 || indexCuoiDuoi >= dsP.Count)
            {
                throw new InvalidOperationException($"indexCuoiDuoi ({indexCuoiDuoi}) vượt biên dsP.Count ({dsP.Count}). " +$"SLThanhxien={SLThanhxien}, SLThanhDung={SLThanhDung}.");
            }
            Point3d pDuoiCuoi = dsP[indexCuoiDuoi];
            // ================== VẼ THÉP XIÊN  ==================
            // Đảm bảo mỗi cặp điểm truyền vào LayoutReinforcementXien có X tăng dần,
            // vì hàm này dừng ngay khi xTarget > ptEnd.X
            Editor ed = CadApp.DocumentManager.MdiActiveDocument.Editor;
            // 3. In các thông báo ra Command Line bằng ed
            // ===== GỌI HÀM RẢI THÉP XIÊN, X LẤY THẲNG TỪ dsP (thép đáy) =====
            List<Point3d> dsXienTrai = LayoutReinforcementXien(
                dsP, indexXienTraiBatDau, indexXienTraiKetThuc,
                theptronxiendautien, theptronxienthuhai,
                nameBlock, remove: false, heSoPhongTo: 1.0);
            List<Point3d> dsXienPhai = LayoutReinforcementXien(
                dsP, indexXienPhaiBatDau, indexXienPhaiKetThuc,
                theptronxienthuba, theptronxiencuoi,
                nameBlock, remove: false, heSoPhongTo: 1.0);
            List<Point3d> dsThepTren = new List<Point3d>();
            double deltaY1 = hbVe + hvVe - 2 * btbvVe - dkThepBan * 2;
            Point3d pTrenBatDau = new Point3d(pDuoiCuoi.X, pDuoiCuoi.Y + deltaY1, 0.0);
            for (int i = 0; i < SLThanhDung; i++)
            {
                Point3d p = new Point3d(pTrenBatDau.X + i * kcRaiXienVe, pTrenBatDau.Y, 0.0);
                ClBlock.InsertBlock(nameBlock, p, 1, 0);
                dsThepTren.Add(p);
            }
            #endregion
        }

        #region Define layoutreinforcement
        /// <param name="ptStart">Điểm bắt đầu - đã quy đổi bằng ToDrawing (đơn vị vẽ, không phải mét thật)</param>
        /// <param name="ptEnd">Điểm kết thúc - đã quy đổi bằng ToDrawing</param>
        /// <param name="soLuong">Số lượng thanh thép cần rải</param>
        /// <param name="nameBlock">Tên block, vd "COTTHEP12"</param>
        /// <param name="scale">
        /// Tỉ lệ bản vẽ (vd 100 cho 1:100) - BẮT BUỘC truyền đúng giá trị scale
        /// đang dùng trong VeThepMatDungMongCoThang để đồng bộ.
        /// </param>
        /// <param name="heSoPhongTo">
        /// Hệ số phóng to riêng cho KÝ HIỆU thép (không ảnh hưởng các hình khác).
        /// Vì đường kính thép thật (mm) quy đổi đúng tỉ lệ sẽ quá nhỏ để nhìn thấy
        /// (vd Ø12 ở tỉ lệ 1:100 chỉ còn 0.12 đơn vị vẽ), nên cần phóng to thêm.
        /// Mặc định = 1 nghĩa là đúng tỉ lệ thật (thường không nhìn thấy được).
        /// Có thể tự tính: heSoPhongTo = (kichThuocVeMongMuon * scale) / duongkinh_mm
        /// </param>
        #endregion
        #region Method 
        public List<Point3d> LayOutReinforcement(
            Point3d ptStart, Point3d ptEnd, double kcThepVe,string nameBlock,
            double scale, double heSoPhongTo = 1.0, bool remove = false)
        {
            List<Point3d> dsP = new List<Point3d>();
            Vector3d vt = ptEnd - ptStart;
            double chieuDai = ptStart.DistanceTo(ptEnd);
            int soLuong = (int)(chieuDai / kcThepVe) + 1;
            // khoảng cách thực tế sau khi biết số thanh
            double spacing = chieuDai / (soLuong - 1);
            Vector3d buoc = vt.GetNormal() * spacing;
            // Hệ số quy đổi cho KÝ HIỆU thép (block định nghĩa bằng mm thật)   
            // sang đơn vị vẽ, đồng bộ với heSoQuyDoi = 1000/scale dùng cho chiều dài mét:
            // 1 đơn vị mm thật -> 1/scale đơn vị vẽ (vì heSoQuyDoi đã nhân sẵn 1000 để đổi m->mm)
            double heSoChenThep = (1.0 / DrawingScaleDefault) * heSoPhongTo;
            int start = remove ? 1 : 0;
            for (int i = start; i < soLuong; i++)
            {
                Point3d diemve = ptStart + buoc * i;
                ClBlock.InsertBlock(nameBlock,diemve,heSoChenThep,0);
                dsP.Add(diemve);
            }
            return dsP;
        }
  
        //phù hợp cho block thép cố định của bản vẽ. (tức kích thước bản vẽ giấy không đổi cho toàn bộ tỉ lệ)
        public const double DrawingScaleDefault = 75;
        //Các hàm dùng để bố trí thanh thép số 2 (thép mu rùa)
        private Point3d GetPolygonCentroid(List<Point3d> pts)
        {
            double cx = 0, cy = 0;
            foreach (var p in pts)
            {
                cx += p.X;
                cy += p.Y;
            }
            int n = pts.Count;
            return new Point3d(cx / n, cy / n, 0);
        }

        // Thêm tham số refCentroid, KHÔNG tự tính centroid cục bộ nữa
        public Point3d GetInsideOffsetPoint(Point3d pPrev, Point3d pCurr, Point3d pNext, double d, Point3d refCentroid)
        {
            const double EPS = 1e-8;
            Vector3d raw1 = pPrev - pCurr;
            Vector3d raw2 = pNext - pCurr;
            if (raw1.Length < EPS || raw2.Length < EPS)
                return pCurr;
            Vector3d v1 = raw1.GetNormal();
            Vector3d v2 = raw2.GetNormal();
            double theta = v1.GetAngleTo(v2);
            // TH1: hai cạnh gần thẳng hàng (bao gồm cả điểm đầu/cuối bị phản chiếu)
            if (theta < 1e-4 || Math.Abs(theta - Math.PI) < 1e-4)
            {
                Vector3d dir = pNext - pPrev;
                if (dir.Length < EPS)
                    return pCurr;
                dir = dir.GetNormal();
                Vector3d normal = new Vector3d(-dir.Y, dir.X, 0);
                Point3d pt1 = pCurr + normal * d;
                Point3d pt2 = pCurr - normal * d;
                return pt1.DistanceTo(refCentroid) <= pt2.DistanceTo(refCentroid) ? pt1 : pt2;
            }
            // TH2: offset theo tia phân giác
            Vector3d bisectorVec = v1 + v2;
            if (bisectorVec.Length < EPS)
            {
                Vector3d dir = (pNext - pPrev).GetNormal();
                Vector3d normal = new Vector3d(-dir.Y, dir.X, 0);
                Point3d pt1 = pCurr + normal * d;
                Point3d pt2 = pCurr - normal * d;
                return pt1.DistanceTo(refCentroid) <= pt2.DistanceTo(refCentroid) ? pt1 : pt2;
            }
            Vector3d bisector = bisectorVec.GetNormal();
            double sinHalf = Math.Sin(theta / 2.0);
            if (Math.Abs(sinHalf) < EPS)
                return pCurr;
            double L = d / sinHalf;
            Point3d forward = pCurr + bisector * L;
            Point3d backward = pCurr - bisector * L;
            return forward.DistanceTo(refCentroid) <= backward.DistanceTo(refCentroid) ? forward : backward;
        }
        public List<Point3d> GetBTBVPoints(List<Point3d> beTongPoints, double d)
        {
            if (beTongPoints == null)
                throw new ArgumentNullException(nameof(beTongPoints));
            if (beTongPoints.Count < 3)
                throw new ArgumentException("Danh sách phải có ít nhất 3 điểm.");
            // Tính centroid TOÀN CỤC 1 lần, dùng chung cho mọi điểm
            // -> fix lỗi centroid suy biến ở điểm đầu/cuối
            Point3d refCentroid = GetPolygonCentroid(beTongPoints);
            List<Point3d> result = new List<Point3d>(beTongPoints.Count);
            int count = beTongPoints.Count;
            for (int j = 0; j < count; j++)
            {
                Point3d prev;
                Point3d curr = beTongPoints[j];
                Point3d next;
                if (j == 0)
                {
                    prev = curr + (curr - beTongPoints[1]);
                    next = beTongPoints[1];
                }
                else if (j == count - 1)
                {
                    prev = beTongPoints[count - 2];
                    next = curr + (curr - beTongPoints[count - 2]);
                }
                else
                {
                    prev = beTongPoints[j - 1];
                    next = beTongPoints[j + 1];
                }

                result.Add(GetInsideOffsetPoint(prev, curr, next, d, refCentroid));
            }
            return result;
        }
       
        /// <summary>
        /// Rải thép xiên sao cho mỗi điểm thép xiên có cùng tọa độ X với điểm thép ngang (đáy) tương ứng
        /// trong dsPNgang, đảm bảo thẳng hàng theo phương đứng để nối bằng thép chữ C.
        /// KHÔNG tự tính spacing riêng - luôn lấy X thật từ dsPNgang.
        /// </summary>
        /// <param name="dsPNgang">Danh sách điểm thép ngang (đáy) đã rải sẵn - nguồn X chuẩn</param>
        /// <param name="indexBatDau">Index bắt đầu trong dsPNgang ứng với đoạn xiên này</param>
        /// <param name="indexKetThuc">Index kết thúc trong dsPNgang ứng với đoạn xiên này</param>
        /// <param name="ptStart">Điểm đầu đường xiên thực tế (mép trong bê tông bảo vệ)</param>
        /// <param name="ptEnd">Điểm cuối đường xiên thực tế</param>
        public List<Point3d> LayoutReinforcementXien(
            List<Point3d> dsPNgang, int indexBatDau, int indexKetThuc,
            Point3d ptStart, Point3d ptEnd, string nameBlock,
            bool remove, double heSoPhongTo = 1.0)
        {
            List<Point3d> dsP = new List<Point3d>();
            Vector3d vtXien = ptEnd - ptStart;
            double heSoChenThep = (1.0 / DrawingScaleDefault) * heSoPhongTo;

            int start = indexBatDau + (remove ? 1 : 0);
            for (int i = start; i <= indexKetThuc; i++)
            {
                double xTarget = dsPNgang[i].X;          // <-- X LẤY THẲNG TỪ THÉP ĐÁY, không tự tính
                double t = (xTarget - ptStart.X) / vtXien.X;
                Point3d diemve = ptStart + t * vtXien;

                ClBlock.InsertBlock(nameBlock, diemve, heSoChenThep, 0);
                dsP.Add(diemve);
            }
            return dsP;
        }
        #endregion
    }
}
