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
    public static void DrawMatBang(Canvas canvas, double chieuDai, double chieuRong, double chieuDaiCM, double chieuRongCm)
    {
        double rongCanvas = 370;
        double daiCanvas = 280;
        double side = 80;
        double top = 30;
        double chieuDaiMM = chieuDai * 1000;   // Ví dụ: 1.5m -> 1500mm
        double chieuRongMM = chieuRong * 1000; // Ví dụ: 1.2m -> 1200mm
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
        SolidColorBrush solidColor = Brushes.Blue;
        var danhSachDiem = new List<Point> { pCV1, pCV2, pCV3, pCV4, pCV1 };
        CreatePolyLine(canvas, danhSachDiem, 2, solidColor);
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
 
}

