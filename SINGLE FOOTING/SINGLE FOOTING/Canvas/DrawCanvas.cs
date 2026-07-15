using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

public class DrawCanvas
{
    public static void VeMatBangMongCoThang(Canvas canvas, double chieuDai, double chieuRong, double chieuDaiCM, double chieuRongCM)
    {
        double rongCanvas = 370;
        double daiCanvas = 280;
        double side = 80;
        double top = 30;
        double chieuDaiMM = chieuDai * 1000;   // Ví dụ: 1.5m -> 1500mm
        double chieuRongMM = chieuRong * 1000;
        double chieuDaiCMMM = chieuDaiCM * 1000;
        double chieuRongCMMM = chieuRongCM * 1000;
        double scale = ScaleCanvas(chieuDaiMM, chieuRongMM, side, top, rongCanvas, daiCanvas);
        Point pCVCenter = new Point(rongCanvas / 2, daiCanvas / 2);
        // Khai báo rõ ràng kích thước sau khi scale để tránh viết nhầm công thức
        double nuaRong = (chieuRongMM / scale) / 2;
        double nuaDai = (chieuDaiMM / scale) / 2;
        // Tọa độ 4 góc
        Point pCV1 = new Point(pCVCenter.X - nuaRong, pCVCenter.Y - nuaDai); // Trên - Trái
        Point pCV2 = new Point(pCVCenter.X + nuaRong, pCVCenter.Y - nuaDai); // Trên - Phải
        Point pCV3 = new Point(pCVCenter.X + nuaRong, pCVCenter.Y + nuaDai); // Dưới - Phải
        Point pCV4 = new Point(pCVCenter.X - nuaRong, pCVCenter.Y + nuaDai); // Dưới - Trái
        SolidColorBrush solidColor = Brushes.Black;
        var danhSachDiem = new List<Point> { pCV1, pCV2, pCV3, pCV4, pCV1 };
        CreatePolyLine(canvas, danhSachDiem, 2, solidColor);
        Point pCV5 = new Point(pCVCenter.X - chieuRongCMMM / scale / 2, pCVCenter.Y - chieuDaiCMMM / scale / 2);
        Point pCV6 = new Point(pCVCenter.X + chieuRongCMMM / scale / 2, pCVCenter.Y - chieuDaiCMMM / scale / 2);
        Point pCV7 = new Point(pCVCenter.X + chieuRongCMMM / scale / 2, pCVCenter.Y + chieuDaiCMMM / scale / 2);
        Point pCV8 = new Point(pCVCenter.X - chieuRongCMMM / scale / 2, pCVCenter.Y + chieuDaiCMMM / scale / 2);
        var danhSachDiemCM = new List<Point> { pCV5, pCV6, pCV7, pCV8, pCV5 };
        CreatePolyLine(canvas, danhSachDiemCM, 2, solidColor);
        Point pCV9 = new Point(pCVCenter.X - chieuRongCMMM / scale / 2 - 100 / scale, pCVCenter.Y - chieuDaiCMMM / scale / 2 - 100 / scale);
        Point pCV10 = new Point(pCVCenter.X + chieuRongCMMM / scale / 2 + 100 / scale, pCVCenter.Y - chieuDaiCMMM / scale / 2 - 100 / scale);
        Point pCV11 = new Point(pCVCenter.X + chieuRongCMMM / scale / 2 + 100 / scale, pCVCenter.Y + chieuDaiCMMM / scale / 2 + 100 / scale);
        Point pCV12 = new Point(pCVCenter.X - chieuRongCMMM / scale / 2 - 100 / scale, pCVCenter.Y + chieuDaiCMMM / scale / 2 + 100 / scale);
        var danhSachDiemVanKhuonCM = new List<Point> { pCV9, pCV10, pCV11, pCV12, pCV9 };
        CreatePolyLine(canvas, danhSachDiemVanKhuonCM, 2, solidColor);
        CreatePolyLine(canvas, new List<Point> { pCV1, pCV9 }, 2, solidColor);
        CreatePolyLine(canvas, new List<Point> { pCV2, pCV10 }, 2, solidColor);
        CreatePolyLine(canvas, new List<Point> { pCV3, pCV11 }, 2, solidColor);
        CreatePolyLine(canvas, new List<Point> { pCV4, pCV12 }, 2, solidColor);
        #region CreateDimCanvas
        //Vertical
        Point pDim1 = new Point(pCVCenter.X - chieuRongMM / 2 / scale - chieuRongCMMM / scale / 3, pCVCenter.Y + chieuDaiMM / scale / 2);
        Point pDim2 = new Point(pDim1.X, pDim1.Y - chieuDaiMM / scale);
        solidColor = Brushes.Black;
        CreatePolyLine(canvas, new List<Point> { pDim1, pDim2 }, 0.75, solidColor);
        Point pe1 = new Point(pDim1.X - 50 / scale, pDim1.Y + 50 / scale);
        Point pe2 = new Point(pDim1.X + 50 / scale, pDim1.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { pe1, pe2 }, 0.75, solidColor);
        Point pe3 = new Point(pDim2.X - 50 / scale, pDim2.Y + 50 / scale);
        Point pe4 = new Point(pDim2.X + 50 / scale, pDim2.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { pe3, pe4 }, 0.75, solidColor);
        Point pMid = MidPoint(pDim1, pDim2);
        GhiChuDimVertical(canvas, pMid, "Bm= ", chieuDaiMM);
        //Horizontal
        Point pDim3 = new Point(pCVCenter.X - chieuRongMM / 2 / scale, pCVCenter.Y + chieuDaiMM / 2 / scale + chieuDaiCMMM / 3 / scale);
        Point pDim4 = new Point(pDim3.X + chieuRongMM / scale, pDim3.Y);
        CreatePolyLine(canvas, new List<Point> { pDim3, pDim4 }, 0.75, solidColor);
        Point pe5 = new Point(pDim3.X - 50 / scale, pDim3.Y + 50 / scale);
        Point pe6 = new Point(pDim3.X + 50 / scale, pDim3.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { pe5, pe6 }, 0.75, solidColor);
        Point pe7 = new Point(pDim4.X - 50 / scale, pDim4.Y + 50 / scale);
        Point pe8 = new Point(pDim4.X + 50 / scale, pDim4.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { pe7, pe8 }, 0.75, solidColor);
        pMid = MidPoint(pDim3, pDim4);
        GhiChuDimHorizontal(canvas, pMid, "Lm = ", chieuRongMM);
        #endregion
        #region Vẽ đường trục
        Point ptam = MidPoint(pCV1, pCV3);
        Point t1 = new Point(ptam.X, pCV1.Y - 500 / scale);
        Point t2 = new Point(ptam.X, pCV3.Y + 500 / scale);
        PolylineTruc(canvas, new List<Point> { t1, t2 });
        Point t3 = new Point(pCV1.X - 500 / scale, ptam.Y);
        Point t4 = new Point(pCV3.X + 500 / scale, ptam.Y);
        PolylineTruc(canvas, new List<Point> { t3, t4 });
        #endregion
    }
    public static void VeMatBangMongCoMoRong(Canvas canvas, double chieuDai, double chieuRong, double chieuDaiCM, double chieuRongCM)
    {
        double rongCanvas = 370;
        double daiCanvas = 280;
        double side = 80;
        double top = 30;

        // M sang MM
        double chieuDaiMM = chieuDai * 1000;
        double chieuRongMM = chieuRong * 1000;
        double chieuDaiCMMM = chieuDaiCM * 1000;
        double chieuRongCMMM = chieuRongCM * 1000;

        double scale = ScaleCanvas(chieuDaiMM, chieuRongMM, side, top, rongCanvas, daiCanvas);

        // Tâm hình học của Canvas dùng làm điểm mốc định vị
        Point pCVCenter = new Point(rongCanvas / 2, daiCanvas / 2);

        SolidColorBrush solidColor = Brushes.Black;

        // ==========================================
        // 2. VẼ ĐẾ MÓNG (Hình chữ nhật lớn ở ngoài)
        // ==========================================
        double nuaRong = (chieuRongMM / scale) / 2;
        double nuaDai = (chieuDaiMM / scale) / 2;

        Point f1 = new Point(pCVCenter.X - nuaRong, pCVCenter.Y - nuaDai); // Trên - Trái
        Point f2 = new Point(f1.X + chieuRongMM / scale, f1.Y);           // Trên - Phải
        Point f3 = new Point(f2.X, f2.Y + chieuDaiMM / scale);            // Dưới - Phải
        Point f4 = new Point(f1.X, f3.Y);                                 // Dưới - Trái

        CreatePolyLine(canvas, new List<Point> { f1, f2, f3, f4 }, 2, solidColor, true);

        // ==========================================
        // 3. VẼ VÁN KHUÔN CỔ CỘT (Hình chữ nhật trung gian, lệch tâm)
        // ==========================================
        // Lệch về góc Trên - Trái (f1), có khoảng hở móng rộng ra 100mm
        Point f5 = new Point(f4.X, f4.Y - chieuDaiCMMM / scale - 100 / scale);
        Point f6 = new Point(f5.X + chieuRongCMMM / scale + 100 / scale, f5.Y);
        Point f7 = new Point(f6.X, f4.Y);
        Point f8 = new Point(f5.X, f7.Y);

        CreatePolyLine(canvas, new List<Point> { f5, f6, f7, f8 }, 2, solidColor, true);

        // ==========================================
        // 4. VẼ CỔ CỘT BÊ TÔNG (Hình chữ nhật nhỏ nhất ở trong)
        // ==========================================
        // Hở vào 50mm so với ván khuôn
        Point f9 = new Point(f5.X + 100 / scale, f5.Y + 100 / scale);
        Point f10 = new Point(f9.X + chieuRongCMMM / scale, f9.Y);
        Point f11 = new Point(f10.X, f10.Y + chieuDaiCMMM / scale);
        Point f12 = new Point(f9.X, f11.Y);

        CreatePolyLine(canvas, new List<Point> { f9, f10, f11, f12 }, 2, solidColor, true);

        // Nối vát góc liên kết từ đế móng lên cổ cột
        CreatePolyLine(canvas, new List<Point> { f2, f6 }, 2, solidColor);

        // ==========================================
        // 5. HỆ THỐNG ĐƯỜNG DIM KÍCH THƯỚC
        // ==========================================
        solidColor = Brushes.Black;

        // --- Dim Đứng (Đo chiều dài chieuDaiMM) ---
        // Đặt ở bên trái, khoảng cách dạt ra tính bằng 1/3 kích thước cổ cột
        Point pDim1 = new Point(f1.X - chieuRongCMMM / scale / 3, f4.Y);
        Point pDim2 = new Point(pDim1.X, pDim1.Y - chieuDaiMM / scale);
        CreatePolyLine(canvas, new List<Point> { pDim1, pDim2 }, 0.75, solidColor);

        // Nét gạch chéo giới hạn Dim (TICK marks)
        CreatePolyLine(canvas, new List<Point> { new Point(pDim1.X - 50 / scale, pDim1.Y + 50 / scale), new Point(pDim1.X + 50 / scale, pDim1.Y - 50 / scale) }, 0.75, solidColor);
        CreatePolyLine(canvas, new List<Point> { new Point(pDim2.X - 50 / scale, pDim2.Y + 50 / scale), new Point(pDim2.X + 50 / scale, pDim2.Y - 50 / scale) }, 0.75, solidColor);

        Point pMidV = MidPoint(pDim1, pDim2);
        GhiChuDimVertical(canvas, pMidV, "Bm = ", chieuDaiMM);

        // --- Dim Ngang (Đo chiều rộng chieuRongMM) ---
        // Đặt ở phía dưới móng, dạt xuống một khoảng bằng 1/2 kích thước cổ cột
        Point pDim3 = new Point(f4.X, f4.Y + chieuDaiCMMM / 2 / scale);
        Point pDim4 = new Point(pDim3.X + chieuRongMM / scale, pDim3.Y);
        CreatePolyLine(canvas, new List<Point> { pDim3, pDim4 }, 0.75, solidColor);

        // Nét gạch chéo giới hạn Dim
        CreatePolyLine(canvas, new List<Point> { new Point(pDim3.X - 50 / scale, pDim3.Y + 50 / scale), new Point(pDim3.X + 50 / scale, pDim3.Y - 50 / scale) }, 0.75, solidColor);
        CreatePolyLine(canvas, new List<Point> { new Point(pDim4.X - 50 / scale, pDim4.Y + 50 / scale), new Point(pDim4.X + 50 / scale, pDim4.Y - 50 / scale) }, 0.75, solidColor);

        Point pMidH = MidPoint(pDim3, pDim4);
        GhiChuDimHorizontal(canvas, pMidH, "Lm = ", chieuRongMM);

        // ==========================================
        // 6. VẼ ĐƯỜNG TRỤC (Định vị theo tâm Cổ Cột)
        // ==========================================
        Point ptamCổCột = MidPoint(f9, f11);

        // Trục đứng: Đi qua tâm cổ cột, nhô ra ngoài biên móng 500mm
        Point t1 = new Point(ptamCổCột.X, f7.Y + 500 / scale);
        Point t2 = new Point(ptamCổCột.X, f1.Y - 500 / scale);
        PolylineTruc(canvas, new List<Point> { t1, t2 });

        // Trục ngang: Đi qua tâm cổ cột, nhô ra ngoài biên móng 500mm
        Point t3 = new Point(f5.X - 500 / scale, ptamCổCột.Y);
        Point t4 = new Point(f3.X + 500 / scale, ptamCổCột.Y);
        PolylineTruc(canvas, new List<Point> { t3, t4 });
    }

    public static void VeMatDungMongCoThang(Canvas canvas, double chieuDai, double chieuRong, double chieuRongCM,
   double chieuSauChonMong, double chieuCaoDeMong, double chieuCaoVat, double chieuCaoD)
    {
        double rongCanvas = 370;
        double daiCanvas = 280;
        double side = 80;
        double top = 30;

        // 1. QUY ĐỔI TOÀN BỘ ĐẦU VÀO SANG MILIMET (MM)
        double chieuDaiMM = chieuDai * 1000;
        double chieuRongMM = chieuRong * 1000;
        double chieuRongCMMM = chieuRongCM * 1000;
        double chieuSauChonMongMM = chieuSauChonMong * 1000;
        double chieuCaoDeMongMM = chieuCaoDeMong * 1000;
        double chieuCaoVatMM = chieuCaoVat * 1000;
        double chieuCaoDMM = chieuCaoD * 1000;

        // Chiều cao tổng thể của hình vẽ mặt đứng (dùng để tính tỷ lệ scale đứng)
        double chieuDungMM = chieuSauChonMongMM + chieuCaoDMM;

        // Tính toán tỷ lệ scale
        double scale = ScaleCanvas(chieuDaiMM, chieuRongMM, side, top, rongCanvas, daiCanvas);
        double scaleMDung = ScaleCanvas(chieuDungMM, chieuRongMM, side, top, rongCanvas, daiCanvas);

        // 2. THIẾT LẬP TÂM VÀ CÁC MỐC CAO ĐỘ (Y) ĐỘC LẬP TỪ ĐÁY MÓNG
        // Đặt tâm hình vẽ nằm ở giữa Canvas
        Point p0 = new Point(rongCanvas / 2, daiCanvas / 2);

        // Xác định cao độ đáy móng (Mốc thấp nhất trên bản vẽ)
        //double yDayMong = p0.Y + daiCanvas / 2 - 150 / scale;
        double yDayMong = p0.Y + daiCanvas / 2 - 150 / scale;

        // Tính toán độc lập các tầng cao độ (Y) tính từ đáy móng đi lên (đã chia scale)
        double yDeMong = yDayMong - (chieuCaoDeMongMM / scaleMDung);
        double yVatMong = yDayMong - (chieuCaoVatMM / scaleMDung);
        double yCos00 = yDayMong - (chieuSauChonMongMM / scaleMDung);
        double yDinhCoMong = yCos00 - (chieuCaoDMM / scaleMDung); // Cổ móng nằm trên mặt đất 

        // 3. TÍNH TOÁN TỌA ĐỘ CÁC ĐIỂM ĐỘC LẬP để dễ bảo trì -> Vẽ Khung móng 
        // Các điểm bên TRÁI trục đối xứng (X âm so với p0.X)
        Point p1 = new Point(p0.X - (chieuRongMM / 2) / scale, yDayMong);
        Point p2 = new Point(p0.X - (chieuRongMM / 2) / scale, yVatMong);
        Point p3 = new Point(p0.X - (chieuRongCMMM / 2 + 100) / scale, yDeMong);
        Point p4 = new Point(p0.X - (chieuRongCMMM / 2) / scale, yDeMong);
        Point p5 = new Point(p0.X - (chieuRongCMMM / 2) / scale, yDinhCoMong);
        Point p6 = new Point(p0.X + (chieuRongCMMM / 2) / scale, yDinhCoMong);
        Point p7 = new Point(p0.X + (chieuRongCMMM / 2) / scale, yDeMong);
        Point p8 = new Point(p0.X + (chieuRongCMMM / 2 + 100) / scale, yDeMong);
        Point p9 = new Point(p0.X + (chieuRongMM / 2) / scale, yVatMong);
        Point p10 = new Point(p0.X + (chieuRongMM / 2) / scale, yDayMong);
        SolidColorBrush solidColor = Brushes.Black;
        CreatePolyLine(canvas, new List<Point> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p1 }, 2, solidColor);

        // 4. ĐƯỜNG MẶT ĐẤT TỰ NHIÊN (Tọa độ tính toán hoàn toàn độc lập)
        Point pmd1 = new Point(p5.X - chieuRongMM / 2 / scale, yCos00);
        Point pmd2 = new Point(p5.X, yCos00);
        Point pmd3 = new Point(p6.X, yCos00);
        Point pmd4 = new Point(p6.X + chieuRongMM / 2 / scale, yCos00);
        SolidColorBrush solidColorCos00 = Brushes.Gray;
        Polyline lineMatDat = new Polyline();
        lineMatDat.Stroke = solidColorCos00;
        lineMatDat.StrokeThickness = 0.75;
        lineMatDat.Points = new PointCollection { pmd1, pmd2, pmd3, pmd4 };
        lineMatDat.StrokeDashArray = new DoubleCollection() { 4, 3 };
        canvas.Children.Add(lineMatDat);

        #region Ký hiệu cao độ 
        // Cao độ mặt đất tự nhiên ±0.00
        Point pcdMatDat = pmd4;
        string txtMatDat = "±0.00";
        KiHieuCaoDo(canvas, pcdMatDat, txtMatDat, scaleMDung, scale);

        // Cao độ đỉnh cổ móng 
        Point pcdDinhCo = new Point(pcdMatDat.X, yDinhCoMong);
        string txtDinhCo = (chieuCaoD >= 0 ? "+" : "") + chieuCaoD.ToString("0.00");
        KiHieuCaoDo(canvas, pcdDinhCo, txtDinhCo, scaleMDung, scale);

        // Cao độ đáy móng 
        Point pcdDayMong = new Point(pcdMatDat.X, p10.Y);
        string txtDayMong = (-chieuSauChonMongMM / 1000).ToString("0.00");
        KiHieuCaoDo(canvas, pcdDayMong, txtDayMong, scaleMDung, scale);
        #endregion

        #region Dim
        // Lớp trong (sát móng) thể hiện: Hb (Đế móng) và Hv (Vát móng)
        double xDimTrong = p1.X - (chieuRongCMMM / 4) / scale;
        // Lớp ngoài (xê rộng ra thêm 300/scale) thể hiện: Hm (Chôn móng) và Bc (Cổ móng)
        double xDimNgoai = xDimTrong - (chieuRongCMMM / 4 + 300) / scale;
        // LỚP 1 (SÁT MÓNG): ĐẾ MÓNG RIÊNG VÀ VÁT MÓNG RIÊNG
        CreatePolyLine(canvas, new List<Point> { new Point(xDimTrong, yDayMong), new Point(xDimTrong, yDeMong) }, 0.75, solidColor);
        double[] mốc_LopTrong = { yDayMong, yVatMong, yDeMong };
        foreach (double yMoc in mốc_LopTrong)
        {
            // Vạch chéo 45 độ định vị mốc Dim
            CreatePolyLine(canvas, new List<Point> { new Point(xDimTrong - 40 / scale, yMoc + 40 / scale), new Point(xDimTrong + 40 / scale, yMoc - 40 / scale) }, 0.75, solidColor);
            // Đường gióng ngang phụ từ mép trái móng p1 ra đường DIM trong
            CreatePolyLine(canvas, new List<Point> { new Point(p1.X, yMoc), new Point(xDimTrong, yMoc) }, 0.5, Brushes.Gray);
        }
        // Ghi chữ số DIM Lớp Trong bằng hàm của bạn
        double hDeMong = (yDayMong - yVatMong) * scaleMDung;
        GhiChuDimVertical(canvas, new Point(xDimTrong, (yDayMong + yVatMong) / 2), "", hDeMong);
        double hVat = (yVatMong - yDeMong) * scaleMDung;
        GhiChuDimVertical(canvas, new Point(xDimTrong, (yVatMong + yDeMong) / 2), "", hVat);

        // LỚP 2 (NGOÀI CÙNG - RỘNG RÃI): CHIỀU SÂU CHÔN MÓNG & ĐOẠN LỘ THIÊN
        CreatePolyLine(canvas, new List<Point> { new Point(xDimNgoai, yDayMong), new Point(xDimNgoai, yDinhCoMong) }, 0.75, solidColor);
        double[] mốc_LopNgoai = { yDayMong, yCos00, yDinhCoMong };
        foreach (double yMoc in mốc_LopNgoai)
        {
            // Vạch chéo 45 độ định vị mốc Dim ngoài cùng
            CreatePolyLine(canvas, new List<Point> { new Point(xDimNgoai - 40 / scale, yMoc + 40 / scale), new Point(xDimNgoai + 40 / scale, yMoc - 40 / scale) }, 0.75, solidColor);
            // Đường gióng ngang kéo dài từ đường DIM trong ra đường DIM ngoài
            CreatePolyLine(canvas, new List<Point> { new Point(xDimTrong, yMoc), new Point(xDimNgoai, yMoc) }, 0.5, Brushes.Gray);
        }
        // Ghi chữ số DIM Lớp Ngoài
        // Hm = Chiều sâu chôn móng thực tế (từ đáy móng lên mặt đất tự nhiên)
        double hChonMong = (yDayMong - yCos00) * scaleMDung;
        GhiChuDimVertical(canvas, new Point(xDimNgoai, (yDayMong + yCos00) / 2), "Hm = ", hChonMong);
        // Hc = Chiều cao đoạn cổ móng lộ thiên (từ mặt đất tự nhiên lên đỉnh cổ)
        GhiChuDimVertical(canvas, new Point(xDimNgoai, (yCos00 + yDinhCoMong) / 2), "Bc = ", chieuCaoDMM);
        #endregion
    }
    public static void VeMatDungCoMongMoRong(Canvas canvas, double chieuDai, double chieuRong, double chieuRongCM,
   double chieuSauChonMong, double chieuCaoDeMong, double chieucaoVat, double caoDoCoMong, double chieucaoDaKieng)
    {
        double rongCanvas = 370;
        double daiCanvas = 280;
        double side = 80;
        double top = 30;

        // --- QUY ĐỔI TOÀN BỘ ĐẦU VÀO SANG MILIMET (MM) ---
        double chieuDaiMM = chieuDai * 1000;
        double chieuRongMM = chieuRong * 1000;
        double chieuRongCMMM = chieuRongCM * 1000;
        double chieuSauChonMongMM = chieuSauChonMong * 1000;
        double chieuCaoDeMongMM = chieuCaoDeMong * 1000;
        double chieucaoVatMM = chieucaoVat * 1000;
        double caoDoCoMongMM = caoDoCoMong * 1000;
        double chieucaoDaKiengMM = chieucaoDaKieng * 1000;

        // Tính toán chiều đứng tổng thể bằng đơn vị mm
        double chieuDungMM = chieuSauChonMongMM + caoDoCoMongMM + 250;

        // Tính scale dựa trên đơn vị mm đã đồng nhất
        double scale = ScaleCanvas(chieuDaiMM, chieuRongMM, side, top, rongCanvas, daiCanvas);
        double scaleMDung = ScaleCanvas(chieuDungMM, chieuRongMM, side, top, rongCanvas, daiCanvas);

        Point p0 = new Point(rongCanvas / 2, daiCanvas / 2);

        // --- TÍNH TOÁN TỌA ĐỘ DỰA TRÊN ĐƠN VỊ MM ---
        Point p1 = new Point(p0.X - chieuRongMM / 2 / scale, p0.Y + daiCanvas / 2 - 150 / scale);
        Point p2 = new Point(p1.X + chieuRongMM / scale, p1.Y);
        Point p3 = new Point(p2.X, p2.Y - chieuCaoDeMongMM / scaleMDung);
        Point p4 = new Point(p1.X + chieuRongCMMM / scale + 50 / scale, p3.Y - chieucaoVatMM / scaleMDung);

        Point Cos00 = new Point(p0.X, p1.Y - chieuSauChonMongMM / scaleMDung);
        Point p5 = new Point(p4.X - 50 / scale, p4.Y);
        Point p6 = new Point(p5.X, Cos00.Y - caoDoCoMongMM / scaleMDung + chieucaoDaKiengMM / scaleMDung);
        Point p7 = new Point(p3.X - 100 / scale, p6.Y);

        List<Point> points = new List<Point> { p1, p2, p3, p4, p5, p6, p7 };
        Polyline pl1 = VePolyline(points, 2);

        Point p8 = new Point(p7.X, p7.Y - chieucaoDaKiengMM / scaleMDung);
        Point p9 = new Point(p6.X, p8.Y);
        Point p10 = new Point(p9.X, p9.Y - 250 / scaleMDung);

        points = new List<Point> { p8, p9, p10 };
        Polyline pl2 = VePolyline(points, 2);

        Point p11 = new Point(p1.X, p10.Y);
        points = new List<Point> { p1, p11 };
        Polyline pl3 = VePolyline(points, 2);

        // Vẽ đường nét break    
        Point b7 = new Point(p11.X - 50 / scale, p11.Y);
        Point b8 = new Point(p11.X + chieuRongCMMM / scale / 3, p11.Y);
        Point b9 = new Point(b8.X, b8.Y + 75 / scaleMDung);
        Point b10 = new Point(b8.X + chieuRongCMMM / scale / 3, b8.Y - 75 / scaleMDung);
        Point b11 = new Point(b10.X, b8.Y);
        Point b12 = new Point(p10.X + 50 / scale, p10.Y);

        points = new List<Point> { b7, b8, b9, b10, b11, b12 };
        Polyline plbr2 = VePolyline(points, 1);

        Point b13 = new Point(p8.X, p8.Y - 50 / scaleMDung);
        Point b14 = new Point(p8.X, p8.Y + chieucaoDaKiengMM / scaleMDung / 3);
        Point b15 = new Point(p8.X - 75 / scale, b14.Y);
        Point b16 = new Point(b14.X + 75 / scale, b14.Y + chieucaoDaKiengMM / scaleMDung / 3);
        Point b17 = new Point(b13.X, b16.Y);
        Point b18 = new Point(b17.X, p7.Y + 50 / scaleMDung);

        points = new List<Point> { b13, b14, b15, b16, b17, b18 };
        Polyline plbr3 = VePolyline(points, 1);

        // Mặt đất tự nhiên
        Point pmd1 = new Point(p10.X, Cos00.Y);
        Point pmd2 = new Point(p7.X + 100 / scale, pmd1.Y);
        Point pmd3 = new Point(p11.X, pmd1.Y);
        Point pmd4 = new Point(p11.X - 200 / scale, pmd3.Y);

        Polyline plmd1 = new Polyline();
        plmd1.Points.Add(pmd1);
        plmd1.Points.Add(pmd2);
        plmd1.Stroke = Brushes.Brown;
        plmd1.StrokeThickness = 0.75;
        canvas.Children.Add(plmd1);

        plmd1 = new Polyline();
        plmd1.Points.Add(pmd3);
        plmd1.Points.Add(pmd4);
        plmd1.Stroke = Brushes.Brown;
        plmd1.StrokeThickness = 0.75;
        canvas.Children.Add(plmd1);

        // Đặt cao độ (Khi hiển thị text chữ, chia cho 1000 để trả lại đơn vị mét)
        Point pcd1 = new Point(p2.X + 150 / scale, p2.Y);
        string ghicaodo = (-chieuSauChonMongMM / 1000).ToString("0.00");
        KiHieuCaoDo(canvas, pcd1, ghicaodo, scaleMDung, scale);

        Point pcdmd = pmd2;
        ghicaodo = "±" + 0.ToString("0.00");
        KiHieuCaoDo(canvas, pcdmd, ghicaodo, scaleMDung, scale);

        Point pcdcomong = new Point(pcdmd.X, p8.Y);
        ghicaodo = "+" + (caoDoCoMongMM / 1000).ToString("0.00");
        KiHieuCaoDo(canvas, pcdcomong, ghicaodo, scaleMDung, scale);

        // Vẽ đường trục
        Point t1 = MidPoint(p10, p11);
        Point t2 = new Point(t1.X, p1.Y);
        PolylineTruc(canvas, new List<Point> { t1, t2 });

        // Dim kích thước
        Point d1 = new Point(p1.X - chieuRongCMMM / 3 / scale, p1.Y);
        Point d2 = new Point(d1.X, p9.Y);
        SolidColorBrush solidColor = Brushes.Black;
        CreatePolyLine(canvas, new List<Point> { d1, d2 }, 0.75, solidColor);

        Point e1 = new Point(d1.X - 50 / scale, d1.Y + 50 / scale);
        Point e2 = new Point(d1.X + 50 / scale, d1.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { e1, e2 }, 0.75, solidColor);

        Point e3 = new Point(e1.X, p3.Y + 50 / scale);
        Point e4 = new Point(e2.X, p3.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { e3, e4 }, 0.75, solidColor);

        Point e5 = new Point(e1.X, p4.Y + 50 / scale);
        Point e6 = new Point(e4.X, p4.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { e5, e6 }, 0.75, solidColor);

        Point e7 = new Point(e1.X, p6.Y + 50 / scale);
        Point e8 = new Point(e4.X, p6.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { e7, e8 }, 0.75, solidColor);

        Point e9 = new Point(e7.X, p9.Y + 50 / scale);
        Point e10 = new Point(e4.X, p9.Y - 50 / scale);
        CreatePolyLine(canvas, new List<Point> { e9, e10 }, 0.75, solidColor);

        // Line ngang của đầu gạch Dim
        Point n1 = new Point(e1.X, d1.Y);
        Point n2 = new Point(e2.X, d1.Y);
        CreatePolyLine(canvas, new List<Point> { n1, n2 }, 0.75, solidColor);

        n1 = new Point(e3.X, p3.Y);
        n2 = new Point(e4.X, p3.Y);
        CreatePolyLine(canvas, new List<Point> { n1, n2 }, 0.75, solidColor);

        n1 = new Point(e5.X, p4.Y);
        n2 = new Point(e6.X, p4.Y);
        CreatePolyLine(canvas, new List<Point> { n1, n2 }, 0.75, solidColor);

        n1 = new Point(e7.X, p6.Y);
        n2 = new Point(e8.X, p6.Y);
        CreatePolyLine(canvas, new List<Point> { n1, n2 }, 0.75, solidColor);

        n1 = new Point(e9.X, p9.Y);
        n2 = new Point(e10.X, p9.Y);
        CreatePolyLine(canvas, new List<Point> { n1, n2 }, 0.75, solidColor);

        // Ghi chú số liệu Dim (Đơn vị mm)
        Point pMid = MidPoint(d1, new Point(d1.X, p3.Y));
        GhiChuDimVertical(canvas, pMid, "Hdm = ", chieuCaoDeMongMM);

        pMid = MidPoint(new Point(d1.X, p3.Y), new Point(d1.X, p4.Y));
        GhiChuDimVertical(canvas, pMid, "Hvm = ", chieucaoVatMM);

        // Tính toán chiều cao cổ móng H0 (Toàn bộ dùng biến MM)
        double h0MM = chieuSauChonMongMM + caoDoCoMongMM - chieucaoDaKiengMM - chieuCaoDeMongMM - chieucaoVatMM;
        pMid = MidPoint(new Point(d1.X, Cos00.Y), new Point(d1.X, p4.Y));
        GhiChuDimVertical(canvas, pMid, "H0 = ", h0MM);

        pMid = MidPoint(new Point(d1.X, Cos00.Y), d2);
        GhiChuDimVertical(canvas, pMid, "Hgm = ", chieucaoDaKiengMM);

        // Đẩy đối tượng đồ họa lên Canvas
        canvas.Children.Add(pl1);
        canvas.Children.Add(pl2);
        canvas.Children.Add(pl3);
        canvas.Children.Add(plbr2);
        canvas.Children.Add(plbr3);
    }
    public static double ScaleCanvas(double chieuDaiMong, double chieuRongMong, double side, double top, double rongCanvas, double daiCanvas)
    {
        // Tính kích thước vùng vẽ hữu dụng thực tế của Canvas sau khi trừ viền (Margin)
        double vungVeRong = rongCanvas - (2 * side); // 370 - 160 = 210
        double vungVeDai = daiCanvas - (2 * top);   // 280 - 60 = 220
        // Tính tỷ lệ co giãn cho cả 2 chiều 
        double scaleWitdh = chieuRongMong / vungVeRong;
        double scaleHeight = chieuDaiMong / vungVeDai;
        // Trả về tỷ lệ lớn nhất để hình không bị tràn ở bất kỳ phương nào
        return Math.Max(scaleWitdh, scaleHeight);
    }
    public static void CreatePolyLine(Canvas canvas, List<Point> dsP, double strokeThickness, SolidColorBrush color)
    {
        Polyline polyline = new Polyline();
        for (int i = 0; i < dsP.Count; i++)
        {
            polyline.Points.Add(dsP[i]);
        }
        polyline.StrokeThickness = strokeThickness;
        polyline.Stroke = color;
        canvas.Children.Add(polyline);
    }
    public static void CreatePolyLine(Canvas canvas, List<Point> dsP, double strokeThickness, SolidColorBrush color, bool close)
    {
        Polyline poly = new Polyline();
        for (int i = 0; i < dsP.Count; i++)
        {
            poly.Points.Add(dsP[i]);
        }
        poly.StrokeThickness = strokeThickness;
        poly.Stroke = color;
        if (close)
        {
            List<Point> points = new List<Point>() { dsP[0], dsP[dsP.Count - 1] };
            CreatePolyLine(canvas, points, strokeThickness, color);
        }
        canvas.Children.Add(poly);
    }
    public static void PolylineTruc(Canvas canvas, List<Point> dsP)
    {
        Polyline duongtruc = new Polyline();
        for (int i = 0; i < dsP.Count; i++)
        {
            duongtruc.Points.Add(dsP[i]);
        }
        duongtruc.Stroke = Brushes.Blue;
        DoubleCollection dashes = new DoubleCollection { 4, 8 };
        duongtruc.StrokeThickness = 0.5;
        duongtruc.StrokeDashArray = dashes;
        canvas.Children.Add(duongtruc);
    }

    public static void GhiChuDimVertical(Canvas canvas, Point pIn, string prefix, double chieuCao)
    {
        TextBlock text = new TextBlock();
        text.Text = prefix + chieuCao.ToString();
        text.FontSize = 11;
        text.FontFamily = new FontFamily("Arial");
        text.Foreground = Brushes.Black;
        //Tính toán kích thước thực tế của bộ textblock trước khi vẽ lên màn hình, nếu không thì ActualHeight,Width sẽ bằng 0 khi vẽ lên. 
        text.Measure(new System.Windows.Size(System.Double.PositiveInfinity, System.Double.PositiveInfinity));
        text.Arrange(new System.Windows.Rect(text.DesiredSize));
        double textW = text.ActualWidth;
        double textH = text.ActualHeight;

        // --- XỬ LÝ XOAY CHỮ ĐỨNG TẠI CHỖ (ĐÃ SỬA LỖI) ---
        // Bước 1: Đặt tâm xoay vào CHÍNH GIỮA chữ (0.5, 0.5)
        // Nếu không có dòng này, chữ sẽ xoay quanh góc trái-trên và bị văng ra xa.
        text.RenderTransformOrigin = new Point(0.5, 0.5);
        // Bước 2: Sử dụng RenderTransform để xoay hình ảnh hiển thị
        // Xoay 270 độ để chữ nằm đứng.
        text.RenderTransform = new RotateTransform(270);
        Canvas.SetLeft(text, pIn.X - textW / 2 - 16);
        Canvas.SetTop(text, pIn.Y - textH / 2);
        canvas.Children.Add(text);
    }
    public static void GhiChuDimHorizontal(Canvas canvas, Point pIn, string prefix, double chieuCao)
    {
        TextBlock text = new TextBlock();
        text.Text = prefix + chieuCao.ToString();
        text.FontSize = 11;
        text.FontFamily = new FontFamily("Arial");
        text.Foreground = Brushes.Black;
        text.Measure(new System.Windows.Size(System.Double.PositiveInfinity, System.Double.PositiveInfinity));
        text.Arrange(new System.Windows.Rect(text.DesiredSize));
        Canvas.SetTop(text, pIn.Y - 1.5 * text.ActualHeight + 20);
        Canvas.SetLeft(text, pIn.X - text.ActualWidth / 2);
        canvas.Children.Add(text);
    }

    public static Point MidPoint(Point p1, Point p2)
    {
        return new Point(p1.X / 2 + p2.X / 2, p1.Y / 2 + p2.Y / 2);
    }
    public static Polyline VePolyline(List<Point> dsP, int strokeThickness)
    {
        Polyline pl = new Polyline();
        for (int i = 0; i < dsP.Count; i++)
        {
            pl.Points.Add(dsP[i]);
        }
        pl.Stroke = Brushes.Blue;
        pl.StrokeThickness = strokeThickness;
        pl.StrokeStartLineCap = PenLineCap.Flat;
        pl.StrokeEndLineCap = PenLineCap.Flat;
        return pl;
    }
    public static void KiHieuCaoDo(Canvas canvas, Point diemDat, string caodo, double scaleMD, double scaleMB)
    {
        Point c1 = new Point(diemDat.X + 100 / scaleMB, diemDat.Y - 100 / scaleMD);
        Point c2 = diemDat;
        Point c3 = new Point(diemDat.X - 100 / scaleMB, c1.Y);
        Point c4 = new Point(c1.X + 200 / scaleMB, c1.Y);
        List<Point> points = new List<Point>() { c1, c2, c3, c4 };
        Polyline pl = VePolyline(points, 1);
        TextBlock text = new TextBlock();
        text.Text = caodo;
        text.FontSize = 11;
        text.FontFamily = new FontFamily("Arial");
        text.Foreground = Brushes.Black;
        text.Measure(new System.Windows.Size(System.Double.PositiveInfinity, System.Double.PositiveInfinity));
        text.Arrange(new System.Windows.Rect(text.DesiredSize));
        Canvas.SetTop(text, c1.Y - text.ActualHeight - 5);
        Canvas.SetLeft(text, diemDat.X - text.ActualWidth / 2);
        canvas.Children.Add(pl);
        canvas.Children.Add(text);
        //
    }
}


