using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
//using System.Windows.Shapes;   //không thêm thư viện này, CAD sẽ không biết lấy polyline hay line của cái thư viện nào

public class ClCAD
{
    public static void CreateLayer(string layerName, short color, string lineTypeName, LineWeight lineWeight, bool canPrint)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument; //lấy document và database đang mở
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            try
            {
                LayerTable acLyrTbl = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                LinetypeTable acLineTypTbl = tr.GetObject(db.LinetypeTableId, OpenMode.ForRead) as LinetypeTable;
                try
                {
                    if (!acLineTypTbl.Has(lineTypeName)) db.LoadLineTypeFile(lineTypeName, "acad.lin"); //kiểm tra nếu lineType chưa tồn tại trong bản vẽ -> đọc từ file acad.lin
                    if (!acLineTypTbl.Has(lineTypeName)) lineTypeName = "Continuous"; //nếu vẫn không có thì continuous để tránh lỗi 
                }
                catch
                {
                    lineTypeName = "Continuous";
                }
                if (!acLyrTbl.Has(layerName))  // ktra layer có chưa, nếu chưa có tạo mới, ngược lại cập nhật layer cũ 
                {
                    LayerTableRecord newLayer = new LayerTableRecord
                    {
                        Color = Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByAci, color),
                        Name = layerName,
                        LinetypeObjectId = acLineTypTbl[lineTypeName],
                        LineWeight = lineWeight,
                        IsPlottable = canPrint
                    };
                    acLyrTbl.UpgradeOpen();
                    acLyrTbl.Add(newLayer);
                    tr.AddNewlyCreatedDBObject(newLayer, true);
                }
                else
                {
                    LayerTableRecord acLyrTblRec = tr.GetObject(acLyrTbl[layerName], OpenMode.ForWrite) as LayerTableRecord; // lấy layer với quyền forwrite để sửa
                    //Những cái này là cập nhật thuộc tính 
                    acLyrTblRec.Color = Color.FromColorIndex(ColorMethod.ByAci, color);
                    acLyrTblRec.Name = layerName;
                    acLyrTblRec.LinetypeObjectId = acLineTypTbl[lineTypeName];
                    acLyrTblRec.LineWeight = lineWeight;
                    acLyrTblRec.IsPlottable = canPrint;
                }
                tr.Commit();
            }
            catch { }
        }
    }
    public static void SetLayerCurrent(string nameLayer)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            LayerTable acLyrTbl = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
            if (acLyrTbl.Has(nameLayer))
            {
                db.Clayer = acLyrTbl[nameLayer];
                tr.Commit();
            }
        }
    }
    public static void CreateTextStyle(string nameTextStyle, string nameFont, double textSize, double xScale, bool isSHX, bool isBold)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            //Mở table quản lý kiểu chữ 
            TextStyleTable textStyleTable = tr.GetObject(db.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;
            //kiểm tra tên kiểu chữ có tồn tại chưa 
            if (!textStyleTable.Has(nameTextStyle))
            {
                //chưa có -> tạo mới 
                TextStyleTableRecord newTextStyle = new TextStyleTableRecord()
                {
                    Name = nameTextStyle, //gán tên kiểu chữ 
                    ObliquingAngle = 0,   //góc nghiêng = 0 (chữ đứng)
                    XScale = xScale,      //tỷ lệ rộng (width factor)
                    TextSize = textSize,  //chiều cao chữ 
                    IsVertical = false,   //chữ nằm ngang(không viết dọc)
                    IsShapeFile = false,  //không phải file shape
                };
                //thiết lập font chữ tùy thuộc vào tham số isSHX
                if (isSHX)
                {
                    //nếu dùng phông SHX (VD: txt.shx)
                    newTextStyle.FileName = nameFont;
                    newTextStyle.BigFontFileName = default;
                    newTextStyle.Font = default;
                }
                else
                {
                    //nếu dùng phông TrueType (VD: Arial, Times New Roman) 
                    newTextStyle.Font = new Autodesk.AutoCAD.GraphicsInterface.FontDescriptor(nameFont, isBold, false, default, default);
                }
                // Đổi quyền trùy cập bảng danh sách sang "ForWrite" để chuẩn bị thêm đối tượng mới 
                textStyleTable.UpgradeOpen();
                textStyleTable.Add(newTextStyle); //thêm Textstyle mới vào bảng quản lý kiểu chữ của autocad 
                tr.AddNewlyCreatedDBObject(newTextStyle, true); //báo với phiên làm việc (transaction) rằng đã tạo xong một đối tượng mới 
            }
            else //kiểu chữ đã có rồi 
            {   //mở kiểu chữ cũ ra bằng quyền forwrite để chỉnh sửa thông số 
                TextStyleTableRecord newTextStyle = (TextStyleTableRecord)tr.GetObject(textStyleTable[nameTextStyle], OpenMode.ForWrite, false);
                //Cập nhật lại các thông số mới đè lên cái cũ 
                newTextStyle.Name = nameTextStyle;
                newTextStyle.FileName = nameFont;
                if (isSHX)
                {
                    newTextStyle.FileName = nameFont;
                    newTextStyle.BigFontFileName = default;
                    newTextStyle.Font = default;

                }
                else
                {
                    newTextStyle.Font = new Autodesk.AutoCAD.GraphicsInterface.FontDescriptor(nameFont, isBold, false, default, default);
                }
                newTextStyle.ObliquingAngle = 0;
                newTextStyle.XScale = xScale;
                newTextStyle.TextSize = textSize;
                newTextStyle.IsVertical = false;
                newTextStyle.IsShapeFile = false;
            }
            //Lư thay đổi vào autocad 
            tr.Commit();
        }
        // Ví dụ 1: Tạo kiểu chữ "CHUTHUONG" dùng phông Arial, cao 200, rộng 1.0, không in đậm
        //CreateTextStyle("CHUTHUONG", "Arial", 200, 1.0, false, false);
    }

    //Hàm pline cho autocad behind
    public static Polyline CreatePolylineFromListPoints(List<Point3d> lstPoint, bool IsClosed)
    {
        Polyline pline = null;
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord acBlkTblRec = tr.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
            pline = new Autodesk.AutoCAD.DatabaseServices.Polyline();
            for (int i = 0; i < lstPoint.Count; i++)
            {
                pline.AddVertexAt(i, new Point2d(lstPoint[i].X, lstPoint[i].Y), 0, 0, 0);
            }
            pline.Closed = IsClosed;
            pline.SetDatabaseDefaults();
            acBlkTblRec.AppendEntity(pline);
            tr.AddNewlyCreatedDBObject(pline, true);
            tr.Commit();
        }
        return pline;
    }
    public static void CreateLine(Point3d P1, Point3d P2)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord acBlkTblRec = tr.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
            Line acLine = new Line(P1, P2);
            acLine.SetDatabaseDefaults();
            acLine.ColorIndex = 256;
            acBlkTblRec.AppendEntity(acLine);
            tr.AddNewlyCreatedDBObject(acLine, true);
            tr.Commit();
        }
    }
    #region Thiết lập cho Leader
    //Hàm lấy trung điểm trên đoạn thẳng từ P1 đến P2 với t là tỷ lệ bất kì thể hiện kích thước
    public static Point3d GetPointOnSegment(Point3d p1, Point3d p2, double t)
    {
        return new Point3d(
            p1.X + (p2.X - p1.X) * t,
            p1.Y + (p2.Y - p1.Y) * t,
            0);
    }
    public static ObjectId CreateLeader(List<Point3d> points)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;

        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
            BlockTableRecord ms =
                (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

            Leader leader = new Leader();

            foreach (Point3d p in points)
            {
                leader.AppendVertex(p);
            }

            leader.HasArrowHead = true;
            leader.SetDatabaseDefaults();

            ms.AppendEntity(leader);
            tr.AddNewlyCreatedDBObject(leader, true);

            tr.Commit();

            return leader.ObjectId;
        }
    }
    #endregion
    public static Point3d GetPointsFromUser(string ThongBao)
    {
        PromptPointResult chonDiem = Application.DocumentManager.MdiActiveDocument.Editor.GetPoint(new PromptPointOptions(ThongBao));
        if (chonDiem.Status != PromptStatus.OK) return new Point3d(-111, -123, -147);
        return chonDiem.Value;
    }
    public class DimStyleSettings
    {
        public string Name { get; set; } = "DTL";
        //Line
        public double ExtendBeyondTicks { get; set; } = 1.0; //Đoạn nhô ra ngoài vạch chéo/ tick mark
        public double ExtendBeyondDimLine { get; set; } = 1.0; // Đoạn nhô ra ngoài đường kích thước (Dimension Line)
        public double OffsetFromOrigin { get; set; } = 1.0; //Khoảng cách từ điểm đo đến chân đường gióng 
        public short ColorDimLine { get; set; } = 4;  //Mã màu cho AutoCad ACI (Màu 4 là màu Xanh Cyan) 
        public short ColorExtendLine { get; set; } = 4;
        //Sysbols
        public double Arrow_Size { get; set; } = 1.0; //kích thước mũi tên/ vạch chéo
        public string ArrowBlockName { get; set; } = "_OBLIQUE"; // tên block mũi tên hệ thống
        //Text
        public string nameTextStyle { get; set; } = "PECC3_Tahoma"; //Tên kiểu chữ (Text Style) đang sử dụng 
        public double TextHeight { get; set; } = 2;
        public short colorText { get; set; } = 3; //Green
        public double OffsetFromDimLine { get; set; } = 0.5; //khoảng các từ chữ đến đường kích thước 
        //Fit
        public double fit { get; set; } = 1;
        //Primary Units
        public double scaleFactor { get; set; } = 1; //tỷ lệ đo 
        public int Precision { get; set; } = 0;
        public double LamTron { get; set; } = 0.1;
    }
    private static ObjectId GetArrowBlockId(Document doc, Database db, string arrowSysVarName)
    {
        object oldVal = Application.GetSystemVariable("DIMBLK1");

        // Dùng Editor.Command thay vì Application.SetSystemVariable
        // để AutoCAD tự tạo block ẩn hệ thống (vd "_OBLIQUE") nếu chưa tồn tại
        doc.Editor.Command("_.SETVAR", "DIMBLK1", arrowSysVarName);

        ObjectId id = db.Dimblk1;

        doc.Editor.Command("_.SETVAR", "DIMBLK1", oldVal);
        return id;
    }
    public static void CreateDimStyles(DimStyleSettings dimStyleSetting)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        // Lấy ObjectId của block mũi tên TRƯỚC, ngoài Transaction chính
        ObjectId obliqueId;
        using (doc.LockDocument())
        {
            obliqueId = GetArrowBlockId(doc, db, dimStyleSetting.ArrowBlockName);
        }
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            //Autodesk.AutoCAD.ApplicationServices.Application.SetSystemVariable("DIMBLK", "_ARCHTICK");
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord acBlkTblRec = tr.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;
            DimStyleTable acDimStyleTbl = tr.GetObject(db.DimStyleTableId, OpenMode.ForRead) as DimStyleTable;
            if (!acDimStyleTbl.Has(dimStyleSetting.Name))
            {
                if (acDimStyleTbl.IsWriteEnabled == false) acDimStyleTbl.UpgradeOpen();
                DimStyleTableRecord acDimStyleTblRec = new DimStyleTableRecord { Name = dimStyleSetting.Name };
                //Lines:
                acDimStyleTblRec.Dimdle = dimStyleSetting.ExtendBeyondTicks; //Độ nhô ra của đường dim so với gạch chéo đầu mũi tên: 0.1
                acDimStyleTblRec.Dimdli = 0.38; //38 Khoảng cách giữa các đường dim khi đánh kích thước phân cấp: 38
                acDimStyleTblRec.Dimexe = dimStyleSetting.ExtendBeyondDimLine; //Độ nhô của đường gióng ra khỏi đường kích thước : 0.1
                acDimStyleTblRec.Dimexo = dimStyleSetting.OffsetFromOrigin; //Khoảng hở từ điểm bấm đo trên vật thể đến chân đường gióng: 0.2
                acDimStyleTblRec.Dimclrd = Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByColor, dimStyleSetting.ColorDimLine); //cMàu sắc của đường kích thước:5
                acDimStyleTblRec.Dimclre = Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByColor, dimStyleSetting.ColorExtendLine); //Màu sắc của đường gióng chân: 5

                //Symbols - mũi tên Oblique
                acDimStyleTblRec.Dimcen = 0.09;   //Kích thước tâm đường tròn: 0.25---9
                acDimStyleTblRec.Dimasz = dimStyleSetting.Arrow_Size; //Kích thước mũi tên:0.05
                acDimStyleTblRec.Dimtsz = 0; //Buộc = 0 để block oblique phát huy tác dụng, không bị tick đè 
                acDimStyleTblRec.Dimblk1 = obliqueId;
                acDimStyleTblRec.Dimblk2 = obliqueId;
                acDimStyleTblRec.Dimblk = obliqueId; // fallback, không bắt buộc nếu đã có Dimsah=true
                acDimStyleTblRec.Dimsah = true;
                // <-- BẮT BUỘC phải có dòng này
                // để Dimblk1/Dimblk2 được áp dụng
                //text:
                TextStyleTable tst = tr.GetObject(db.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;
                if (tst.Has(dimStyleSetting.nameTextStyle))
                    acDimStyleTblRec.Dimtxsty = tst[dimStyleSetting.nameTextStyle];
                else
                    throw new Exception($"Text style '{dimStyleSetting.nameTextStyle}' chưa tồn tại trong bản vẽ.");
                acDimStyleTblRec.Dimtxt = dimStyleSetting.TextHeight; //Chiều cao chữ (Text height: 0.15
                acDimStyleTblRec.Dimtfac = 1; //fraction heigh scale : 1
                acDimStyleTblRec.Dimclrt = Color.FromColorIndex(ColorMethod.ByAci, dimStyleSetting.colorText); //màu cho text: 7
                acDimStyleTblRec.Dimtad = 1; // Bằng 1 nghĩa là chữ nằm phía trên đường dim (Above) = 1
                acDimStyleTblRec.Dimgap = dimStyleSetting.OffsetFromDimLine; //Khoảng cách hở giữa chân chữ và đường kích thước.
                acDimStyleTblRec.Dimfrac = 0;
                acDimStyleTblRec.Dimtmove = 2;
                acDimStyleTblRec.Dimtih = false; //false: nghĩa là chữ luôn nằm song song với đường dim (kể cả dim nghiêng hay đứng).
                //Fit: 
                acDimStyleTblRec.Dimatfit = 0;   //Chọn 0   //0:Places both text and arows outside extension lines; 1: Moves arows first, then text;   2:Moves text first, then arrows; 3: Moves either text or arrows, whichever fits best
                acDimStyleTblRec.Dimscale = dimStyleSetting.fit;// Tỷ lệ nhân tổng thể cho toàn bộ kích thước hình học của Dim (giúp phóng to/thu nhỏ Dim theo tỷ lệ bản vẽ).
                acDimStyleTblRec.Dimtofl = true; // Luôn vẽ đường kích thước nằm giữa 2 đường gióng dù chữ có bị đẩy ra ngoài.
                acDimStyleTblRec.Dimtix = true; //Always keep text between ext line: true
                //Primary Units
                acDimStyleTblRec.Dimdec = dimStyleSetting.Precision;     // Precision: 0
                acDimStyleTblRec.Dimrnd = dimStyleSetting.LamTron;   // Round off: 10
                acDimStyleTblRec.Dimlfac = dimStyleSetting.scaleFactor;    // Scale factor: 1000
                //Alternmate Units 
                acDimStyleTblRec.Dimaltf = 25.4;   //Multiplier for alt units: 25.4
                acDimStyleTblRec.Dimaltrnd = 0.0; //Round distances to :0
                //Tolerances
                acDimStyleTblRec.Dimtp = 0.0; // Round distances to: 0
                acDimStyleTblRec.Dimtm = 0.0;    // Lower value: 0
                acDimStyleTbl.Add(acDimStyleTblRec);
                tr.AddNewlyCreatedDBObject(acDimStyleTblRec, true);
                tr.Commit();
            }
        }
    }
    public static void SetDimStyleCurrent(string nameDimStyle)
    {
        // BƯỚC 1: Tìm xem bản vẽ nào đang mở trên màn hình AutoCAD
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;

        // BƯỚC 2: Khóa bản vẽ và Mở một "Phiên làm việc" (Transaction).
        // Giống như việc bạn mở cửa bước vào kho dữ liệu của AutoCAD để chuẩn bị sửa đổi.
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            // BƯỚC 3: Mở "Bảng danh sách chứa tất cả các DimStyle" đang có trong file CAD
            DimStyleTable acDimStyleTbl = tr.GetObject(db.DimStyleTableId, OpenMode.ForRead) as DimStyleTable;

            // BƯỚC 4: Kiểm tra xem trong bảng đó CÓ tên DimStyle bạn truyền vào (nameDimStyle) hay không?
            if (acDimStyleTbl.Has(nameDimStyle))
            {
                // Nếu CÓ: Mở file thông tin của DimStyle đó ra
                DimStyleTableRecord acDimStyleTblRec = (DimStyleTableRecord)tr.GetObject(acDimStyleTbl[nameDimStyle], OpenMode.ForWrite);

                // BƯỚC 5: Lệnh chính - Đặt DimStyle này làm hiện hành (Set Current)
                db.Dimstyle = acDimStyleTblRec.ObjectId; // Gán ID của Dim mới
                db.SetDimstyleData(acDimStyleTblRec);    // Cập nhật lại các thông số kỹ thuật (chữ, mũi tên...)
            }

            // BƯỚC 6: Lưu (Commit) lại tất cả những thay đổi vừa làm vào AutoCAD
            tr.Commit();
        }
    }
    public static void DimX(Point3d P1, Point3d P2, double Denta_Y)
    {
        if (P1.X == P2.X) return;
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord acBlkTblRec = tr.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
            RotatedDimension acRotDim = new RotatedDimension();
            acRotDim.SetDatabaseDefaults();
            acRotDim.XLine1Point = P1;
            acRotDim.XLine2Point = P2;
            acRotDim.Rotation = 0;
            double Y;
            if (Denta_Y > 0) Y = Math.Max(P1.Y, P2.Y);
            else Y = Math.Min(P1.Y, P2.Y);
            acRotDim.DimLinePoint = new Point3d((P1.X + P2.X) / 2, Y + Denta_Y, 0);
            acRotDim.DimensionStyle = db.Dimstyle;
            acBlkTblRec.AppendEntity(acRotDim);
            tr.AddNewlyCreatedDBObject(acRotDim, true);
            tr.Commit();
        }
    }
    public static void CreateDimension_X(List<Point3d> dsX, double chonTyLe, int ihang, double textHeight, bool phiaTren = true)
    {
        double kcDim = textHeight * 3;
        double huong = phiaTren ? 1 : -1;
        for (int i = 0; i < dsX.Count - 1; i++)
        {
            DimX(dsX[i], dsX[i + 1], huong * ihang * kcDim);
        }
    }
    public static void DimY(Point3d P1, Point3d P2, double Denta_X)
    {
        if (P1.Y == P2.Y) return;
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord acBlkTblRec = tr.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
            RotatedDimension acRotDim = new RotatedDimension();
            acRotDim.SetDatabaseDefaults();
            acRotDim.XLine1Point = P1;
            acRotDim.XLine2Point = P2;
            acRotDim.Rotation = Math.PI / 2;
            double X;
            if (Denta_X > 0) X = Math.Max(P1.X, P2.X);
            else X = Math.Min(P1.X, P2.X);
            acRotDim.DimLinePoint = new Point3d(X + Denta_X, (P1.Y + P2.Y) / 2, 0);
            acRotDim.DimensionStyle = db.Dimstyle;
            acBlkTblRec.AppendEntity(acRotDim);
            tr.AddNewlyCreatedDBObject(acRotDim, true);
            tr.Commit();
        }
    }
    public static void CreateDimension_Y(List<Point3d> dsX, double chonTyLe, int ihang, double textHeight, bool benPhai = true)
    {
        double kcDim = textHeight * 3;
        double huong = benPhai ? 1 : -1;
        for (int i = 0; i < dsX.Count - 1; i++)
        {
            DimY(dsX[i], dsX[i + 1], huong * ihang * kcDim);
        }
    }
    public static void CreateDimension_Y1(List<Point3d> dsX, double chonTyLe, int ihang, double textHeight, bool benPhai = true)
    {
        //Hàm này tương tự Dimcontinue tránh bị nhảy Dim
        double kcDim = textHeight * 3;
        double huong = benPhai ? 1 : -1;
        // Mốc X biên của toàn bộ điểm (max nếu dim bên phải, min nếu dim bên trái)
        double xBien = benPhai ? dsX.Max(p => p.X) : dsX.Min(p => p.X);
        double xDim = xBien + huong * ihang * kcDim;
        for (int i = 0; i < dsX.Count - 1; i++)
        {
            // X cục bộ mà hàm DimY sẽ tự tính bên trong (max hoặc min của P1,P2)
            double xLocal = benPhai
                ? Math.Max(dsX[i].X, dsX[i + 1].X)
                : Math.Min(dsX[i].X, dsX[i + 1].X);
            double dentaX = xDim - xLocal;
            DimY(dsX[i], dsX[i + 1], dentaX);
        }
    }
    public static void DimY_WithLabel(Point3d P1,Point3d P2,double Denta_X,string label, string tenTextStyle, double huong,  string layerDim = "DIM", string layerText = "CHU")
    {
        if (P1.Y == P2.Y) return;
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable bt =
                (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
            BlockTableRecord ms =
                (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
            //==========================
            // Tạo DIM
            //==========================
            RotatedDimension dim = new RotatedDimension();
            dim.SetDatabaseDefaults();
            dim.XLine1Point = P1;
            dim.XLine2Point = P2;
            dim.Rotation = Math.PI / 2;
            double x =
                Denta_X > 0
                ? Math.Max(P1.X, P2.X)
                : Math.Min(P1.X, P2.X);
            Point3d pDimLine = new Point3d(
                x + Denta_X,
                (P1.Y + P2.Y) / 2.0,
                0);
            dim.DimLinePoint = pDimLine;
            dim.DimensionStyle = db.Dimstyle;
            dim.Layer = layerDim;
            ms.AppendEntity(dim);
            tr.AddNewlyCreatedDBObject(dim, true);
            //==========================
            // Tạo LABEL
            //==========================
            if (!string.IsNullOrWhiteSpace(label))
            {
                DimStyleTableRecord dimStyle =
                    (DimStyleTableRecord)tr.GetObject(db.Dimstyle, OpenMode.ForRead);

                // Khoảng cách đúng bằng khoảng cách text DIM (giống cách số dim cách extension line)
                double offset = dimStyle.Dimtxt / 2.0 + dimStyle.Dimgap;

                // SỬA: cộng thay vì trừ, để label đi tiếp ra xa CÙNG HƯỚNG với dim line, không mirror ngược lại
                Point3d pLabel = new Point3d(
                    pDimLine.X + huong * offset,
                    pDimLine.Y,
                    0);

                TextStyleTable tst =
                    (TextStyleTable)tr.GetObject(db.TextStyleTableId, OpenMode.ForRead);

                if (!tst.Has(tenTextStyle))
                    throw new Exception($"Không tồn tại TextStyle: {tenTextStyle}");

                ObjectId styleId = tst[tenTextStyle];

                TextStyleTableRecord ts =
                    (TextStyleTableRecord)tr.GetObject(styleId, OpenMode.ForRead);

                DBText txt = new DBText();
                txt.SetDatabaseDefaults();
                txt.TextString = label;
                txt.Position = pLabel;
                txt.AlignmentPoint = pLabel;
                txt.HorizontalMode = TextHorizontalMode.TextCenter;
                txt.VerticalMode = TextVerticalMode.TextVerticalMid;
                txt.Rotation = Math.PI / 2;
                txt.Layer = layerText;
                txt.TextStyleId = styleId;
                txt.Height = ts.TextSize > 0
                    ? ts.TextSize
                    : dimStyle.Dimtxt;

                ms.AppendEntity(txt);
                tr.AddNewlyCreatedDBObject(txt, true);
            }
            tr.Commit();
        }
    }
    public static void CreateDimension_Y1_WithLabel( List<Point3d> dsX,  List<string> labels,string tenTextStyle,   double chonTyLe,  int ihang, double textHeight,  bool benPhai = true)
    {
        if (dsX == null || dsX.Count < 2)
            return;
        if (labels == null || labels.Count != dsX.Count - 1)
            throw new ArgumentException(
                "labels.Count phải bằng dsX.Count - 1");
        double kcDim = textHeight * 3;
        double huong = benPhai ? 1 : -1;
        double xBien = benPhai
            ? dsX.Max(p => p.X)
            : dsX.Min(p => p.X);
        double xDim = xBien + huong * ihang * kcDim;
        for (int i = 0; i < dsX.Count - 1; i++)
        {
            double xLocal =
                benPhai
                ? Math.Max(dsX[i].X, dsX[i + 1].X)
                : Math.Min(dsX[i].X, dsX[i + 1].X);
            double dentaX = xDim - xLocal;
            DimY_WithLabel(
                dsX[i],
                dsX[i + 1],
                dentaX,
                labels[i],
                tenTextStyle,
                huong);
        }
    }
    #region Block
    public static Circle CreateCircleReturnCircle(Point3d pCenter, double radius)
    {
        Circle DT = new Autodesk.AutoCAD.DatabaseServices.Circle();
        DT.SetDatabaseDefaults();
        DT.Center = pCenter;
        DT.Radius = radius;
        return DT;
    }
    #endregion

}