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
    #region Vẽ trục 
    //Polyline pline = new Polyline();
    //Point pCVCenter = new Point(rongCanvas / 2, daiCanvas / 2);
    //Point pCV1 = new Point(pCVCenter.X - rongCanvas / 2, pCVCenter.Y);
    //Point pCV2 = new Point(pCVCenter.X + rongCanvas / 2, pCVCenter.Y);
    //pline.Points.Add(pCV1);
    //pline.Points.Add(pCV2);
    //pline.Stroke = Brushes.Black;  //màu cho polyline 
    //DoubleCollection hiddenLine = new DoubleCollection { 4, 8 };  //danh sách (mảng) chuyên dụng chỉ chứa các số thực kiểu double
    //pline.StrokeThickness = 0.5;
    //pline.StrokeDashArray = hiddenLine;   //thuoc tinh quy dinh cau truc của thư viện System.Windows.Shapes.Polyline)
    //Polyline pline2 = new Polyline();
    //Point pCV3 = new Point(pCVCenter.X, pCVCenter.Y - daiCanvas / 2);
    //Point pCV4 = new Point(pCVCenter.X, pCVCenter.Y + daiCanvas / 2);
    //pline2.Points.Add(pCV3);
    //pline2.Points.Add(pCV4);
    //pline2.Stroke = Brushes.Black;
    //pline2.StrokeThickness = 0.5;
    //pline2.StrokeDashArray = hiddenLine;
    //canvas.Children.Add(pline);
    //canvas.Children.Add(pline2);
    #endregion
    public static void DrawMatBang(Canvas canvas, double chieuDai, double chieuRong, double chieuDaiCM, double chieuRongCM)
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
}


