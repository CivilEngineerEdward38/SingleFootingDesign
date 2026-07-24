using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
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
    public static void CreateTextSyle(string nameTextStyle, string nameFont, double textSize, double xScale, bool isSHX, bool isBold)
    {
        //....
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

    public static Point3d GetPointsFromUser(string ThongBao)
    {
        PromptPointResult chonDiem = Application.DocumentManager.MdiActiveDocument.Editor.GetPoint(new PromptPointOptions(ThongBao));
        if (chonDiem.Status != PromptStatus.OK) return new Point3d(-111, -123, -147);
        return chonDiem.Value;
    }
}