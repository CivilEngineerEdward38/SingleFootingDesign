using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using ACAD_API.PILE_FOUNDATION.Model;
using System;
using System.Collections.Generic;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Arc = Autodesk.AutoCAD.DatabaseServices.Arc;
using Line = Autodesk.AutoCAD.DatabaseServices.Line;

public class ClKiHieu
{
    public static void TrucMong(Point3d pMain, double timMong, double scale, string loaicot, double rongMong, string goclai)
    {
        Point3d p1 = new Point3d(pMain.X - timMong / 2, pMain.Y, 0);
        Point3d p2 = new Point3d(pMain.X + timMong / 2, pMain.Y, 0);
        Point3d p3 = new Point3d(pMain.X, pMain.Y + timMong / 2, 0);
        Point3d p4 = new Point3d(pMain.X, pMain.Y - timMong / 2, 0);
        ClCAD.SetLayerCurrent("DUONGTRUC");
        ClCAD.CreateLine(p1, p2);
        ClCAD.CreateLine(p3, p4);
        ClCAD.SetLayerCurrent("NETPHU");
        GhiChuTimMong(pMain, scale);
        ClCAD.SetLayerCurrent("DUONGTRUC");
        if (loaicot == "ĐỠ THẲNG" || loaicot == "NÉO THẲNG") DoThang_NeoThang(pMain, loaicot, scale, timMong, rongMong);
        else if (loaicot == "NÉO PHÂN GIÁC") PhanGiac(goclai, pMain, loaicot, scale, timMong, rongMong);
        else if (loaicot == "NÉO 90") NeoVuongGoc(pMain, loaicot, scale, timMong, rongMong);
        else NeoDung(pMain, loaicot, scale, timMong, rongMong);
    }
    public static void TrucMong_MB(Point3d pMain, double chieuDaiMong, double scale, string loaicot, string goclai)
    {
        Point3d p1 = new Point3d(pMain.X - chieuDaiMong / 2, pMain.Y, 0);
        Point3d p2 = new Point3d(pMain.X + chieuDaiMong / 2, pMain.Y, 0);
        Point3d p3 = new Point3d(pMain.X, pMain.Y + chieuDaiMong / 2, 0);
        Point3d p4 = new Point3d(pMain.X, pMain.Y - chieuDaiMong / 2, 0);
        ClCAD.SetLayerCurrent("DUONGTRUC");
        ClCAD.CreateLine(p1, p2);
        ClCAD.CreateLine(p3, p4);
        ClCAD.SetLayerCurrent("NETPHU");
        GhiChuTimMong(pMain, scale);
        ClCAD.SetLayerCurrent("DUONGTRUC");

        if (loaicot == "ĐỠ THẲNG" || loaicot == "NÉO THẲNG") DoThang_NeoThang_MB(pMain, loaicot, scale, chieuDaiMong);

        else if (loaicot == "NÉO PHÂN GIÁC") PhanGiac_MB(goclai, pMain, loaicot, scale, chieuDaiMong);
        else if (loaicot == "NÉO 90") NeoVuongGoc_MB(pMain, loaicot, scale, chieuDaiMong);
        else NeoDung_MB(pMain, loaicot, scale, chieuDaiMong);
    }
    public static void DoThang_NeoThang(Point3d pMain, string loaicot, double scale, double timMong, double rongMong)
    {
        double chieuDai = timMong + rongMong / 3;
        BlockHuongTuyen_MB(loaicot, scale, chieuDai, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDai.ToString() + scale.ToString();

        ClBlock.InsertBlock(NameBL, pMain, 1, 0);
        ClBlock.InsertBlock(NameBL, pMain, 1, Math.PI);
    }
    public static void DoThang_NeoThang_MB(Point3d pMain, string loaicot, double scale, double chieuDaiMong)
    {
        BlockHuongTuyen_MB(loaicot, scale, chieuDaiMong, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDaiMong.ToString() + scale.ToString();

        ClBlock.InsertBlock(NameBL, pMain, 1, 0);
        ClBlock.InsertBlock(NameBL, pMain, 1, Math.PI);
    }
    public static void PhanGiac(string goclai, Point3d pMain, string loaicot, double scale, double timMong, double rongMong)
    {
        double chieuDai = timMong + rongMong / 3;
        BlockHuongTuyen_MB(loaicot, scale, chieuDai, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDai.ToString() + scale.ToString();

        if (goclai == "BÊN TRÁI")
        {
            double[] angles = { 15, 165 };
            foreach (double angle in angles) ClBlock.InsertBlock(NameBL, pMain, 1, Math.PI * (angle / 180));
        }
        else
        {
            double[] angles = { 195, 345 };
            foreach (double angle in angles) ClBlock.InsertBlock(NameBL, pMain, 1, Math.PI * (angle / 180));
        }
    }
    public static void PhanGiac_MB(string goclai, Point3d pMain, string loaicot, double scale, double chieuDaiMong)
    {
        BlockHuongTuyen_MB(loaicot, scale, chieuDaiMong, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDaiMong.ToString() + scale.ToString();

        if (goclai == "BÊN TRÁI")
        {
            double[] angles = { 15, 165 };
            foreach (double angle in angles) ClBlock.InsertBlock(NameBL, pMain, 1, Math.PI * (angle / 180));
        }
        else
        {
            double[] angles = { 195, 345 };
            foreach (double angle in angles) ClBlock.InsertBlock(NameBL, pMain, 1, Math.PI * (angle / 180));
        }
    }
    public static void NeoDung(Point3d pMain, string loaicot, double scale, double timMong, double rongMong)
    {
        double chieuDai = timMong + rongMong / 3;
        BlockHuongTuyen_MB(loaicot, scale, chieuDai, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDai.ToString() + scale.ToString();

        ClBlock.InsertBlock(NameBL, pMain, 1, 0);
    }
    public static void NeoDung_MB(Point3d pMain, string loaicot, double scale, double chieuDaiMong)
    {
        BlockHuongTuyen_MB(loaicot, scale, chieuDaiMong, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDaiMong.ToString() + scale.ToString();
        ClBlock.InsertBlock(NameBL, pMain, 1, 0);
    }
    public static void NeoVuongGoc(Point3d pMain, string loaicot, double scale, double timMong, double rongMong)
    {
        double chieuDai = timMong + rongMong / 3;

        BlockHuongTuyen_MB(loaicot, scale, chieuDai, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDai.ToString() + scale.ToString();

        ClBlock.InsertBlock(NameBL, pMain, 1, -Math.PI / 2);
        ClBlock.InsertBlock(NameBL, pMain, 1, 0);
    }
    public static void NeoVuongGoc_MB(Point3d pMain, string loaicot, double scale, double chieuDaiMong)
    {
        BlockHuongTuyen_MB(loaicot, scale, chieuDaiMong, "CHUTHUONG", 200, 4, TextHorizontalMode.TextRight);
        string NameBL = loaicot.ToString() + chieuDaiMong.ToString() + scale.ToString();
        ClBlock.InsertBlock(NameBL, pMain, 1, -Math.PI / 2);
        ClBlock.InsertBlock(NameBL, pMain, 1, 0);
    }
    public static void TenMatCat(Point3d pDiemDat, string tenMatCat, double scale, TextHorizontalMode canle, double rotation)
    {
        ClCAD.CreateDText(tenMatCat, pDiemDat, "CHUTHUONG", 400 * scale * 0.01, 4, canle, rotation);
        Point3d pScale = new Point3d(pDiemDat.X, pDiemDat.Y - 400 * scale * 0.01, 0);
        string sTile = string.Format("TL-1:{0}", scale);
        ClCAD.CreateDText(sTile, pScale, "CHUTHUONG", 200 * scale * 0.01, 4, TextHorizontalMode.TextCenter, 0);
    }
    public static void KihieuCaoDo(Point3d ptChen, string caodo, int sh, double scale)// 0: Left, 1: Right
    {
        double hsScale = 0.01 * scale;
        Point3d p1 = new Point3d(ptChen.X, ptChen.Y + 500 * hsScale, 0);
        Point3d p2;
        if (sh == 0)
        {
            p2 = new Point3d(ptChen.X - 1000 * hsScale, ptChen.Y + 500 * hsScale, 0);
        }
        else
        {
            p2 = new Point3d(ptChen.X + 1000 * hsScale, ptChen.Y + 500 * hsScale, 0);
        }
        ClCAD.CreatePolylineFromListPointsReturnPolyline(new List<Point3d> { ptChen, p1, p2 }, false);
        Point3d p3 = new Point3d(ptChen.X + 250 * hsScale, ptChen.Y + 250 * hsScale, 0);
        Point3d p4 = new Point3d(ptChen.X, ptChen.Y + 250 * hsScale, 0);
        Point3d p5 = new Point3d(ptChen.X - 250 * hsScale, ptChen.Y + 250 * hsScale, 0);
        ClCAD.CreatePolylineFromListPointsReturnPolyline(new List<Point3d> { ptChen, p3, p5 }, true);
        ClCAD.CreateHatchFromListPointP(new List<Point3d> { ptChen, p3, p4, ptChen }, "SOLID", 1);
        if (sh == 0)
        {
            ClCAD.CreateDText(caodo, new Point3d(ptChen.X - 500 * hsScale, ptChen.Y + 650 * hsScale, 0), "CHUTHUONG", 200 * hsScale, 4, TextHorizontalMode.TextCenter, 0);

        }
        else
        {
            ClCAD.CreateDText(caodo, new Point3d(ptChen.X, ptChen.Y + 650 * hsScale, 0), "CHUTHUONG", 200 * hsScale, 4, TextHorizontalMode.TextLeft, 0);
        }

    }
    public static void BlockHuongTuyen(string huongtuyen, double scale, double timMong, double rongCM,
        string nameTextStyle, double heigh, int color, TextHorizontalMode canLe)
    {
        string NameBL = huongtuyen.ToString();
        double tile = scale * 0.01;
        Database db = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Database;
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
            if (!acBlkTbl.Has(NameBL))
            {
                using (BlockTableRecord acBlkTblRec = new BlockTableRecord())
                {
                    acBlkTblRec.Name = NameBL;
                    Point3d pMain = new Point3d();
                    Point3d pIn = new Point3d(pMain.X - 150 * scale * 0.01, pMain.Y + 500 * scale * 0.01, 0);
                    Point3d p1 = new Point3d(pMain.X, pMain.Y + timMong / 2 + rongCM / 2, 0);
                    Point3d p2 = new Point3d(p1.X - 300 * 0.01 * scale, p1.Y - 700 * scale * 0.01, 0);
                    Point3d p3 = new Point3d(p1.X + 300 * 0.01 * scale, p1.Y - 700 * scale * 0.01, 0);
                    ClCAD.SetLayerCurrent("DUONGTRUC");
                    Line l1 = new Line(pMain, p1);
                    Line l2 = new Line(p1, p2);
                    Line l3 = new Line(p1, p3);

                    DBText newText = new DBText();
                    newText.SetDatabaseDefaults();
                    TextStyleTable acTextStyleTable1 = tr.GetObject(db.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;
                    newText.TextStyleId = acTextStyleTable1[nameTextStyle];
                    string text = string.Format("TRỤC ĐƯỜNG DÂY-{0}", huongtuyen);
                    newText.TextString = text;
                    newText.Height = heigh;
                    newText.ColorIndex = color;
                    newText.Position = pIn;
                    newText.Rotation = Math.PI / 2;
                    newText.HorizontalMode = canLe;
                    newText.VerticalMode = TextVerticalMode.TextVerticalMid;
                    //newText.HorizontalMode = TextHorizontalMode.TextCenter;
                    newText.AlignmentPoint = pIn;

                    acBlkTblRec.Origin = pMain;
                    acBlkTblRec.AppendEntity(l1);
                    acBlkTblRec.AppendEntity(l2);
                    acBlkTblRec.AppendEntity(l3);
                    acBlkTblRec.AppendEntity(newText);

                    acBlkTbl.UpgradeOpen();
                    acBlkTbl.Add(acBlkTblRec);
                    tr.AddNewlyCreatedDBObject(acBlkTblRec, true);
                }
                tr.Commit();
            }
        }

    }

    public static void BlockHuongTuyen_MB(string huongtuyen, double scale, double chieuDaiMong,
      string nameTextStyle, double heigh, int color, TextHorizontalMode canLe)
    {
        string NameBL = huongtuyen.ToString() + chieuDaiMong.ToString() + scale.ToString();
        double tile = scale * 0.01;
        Database db = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Database;
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
            if (!acBlkTbl.Has(NameBL))
            {
                using (BlockTableRecord acBlkTblRec = new BlockTableRecord())
                {
                    acBlkTblRec.Name = NameBL;
                    Point3d pMain = new Point3d();
                    Point3d pIn = new Point3d(pMain.X - 150 * scale * 0.01, pMain.Y + chieuDaiMong / 2 - 500 * scale * 0.01, 0);
                    Point3d p1 = new Point3d(pMain.X, pMain.Y + chieuDaiMong / 2, 0);
                    Point3d p2 = new Point3d(p1.X - 300 * 0.01 * scale, p1.Y - 700 * scale * 0.01, 0);
                    Point3d p3 = new Point3d(p1.X + 300 * 0.01 * scale, p1.Y - 700 * scale * 0.01, 0);
                    ClCAD.SetLayerCurrent("DUONGTRUC");
                    Line l1 = new Line(pMain, p1);
                    Line l2 = new Line(p1, p2);
                    Line l3 = new Line(p1, p3);

                    DBText newText = new DBText();
                    newText.SetDatabaseDefaults();
                    TextStyleTable acTextStyleTable1 = tr.GetObject(db.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;
                    newText.TextStyleId = acTextStyleTable1[nameTextStyle];
                    //string text = string.Format("TRỤC ĐƯỜNG DÂY-{0}", huongtuyen);
                    string text = string.Format("TRỤC ĐƯỜNG DÂY");

                    newText.TextString = text;
                    newText.Height = heigh * tile;
                    newText.ColorIndex = color;
                    newText.Position = pIn;
                    newText.Rotation = Math.PI / 2;
                    newText.HorizontalMode = canLe;
                    newText.VerticalMode = TextVerticalMode.TextVerticalMid;
                    //newText.HorizontalMode = TextHorizontalMode.TextCenter;
                    newText.AlignmentPoint = pIn;

                    acBlkTblRec.Origin = pMain;
                    acBlkTblRec.AppendEntity(l1);
                    acBlkTblRec.AppendEntity(l2);
                    acBlkTblRec.AppendEntity(l3);
                    acBlkTblRec.AppendEntity(newText);

                    acBlkTbl.UpgradeOpen();
                    acBlkTbl.Add(acBlkTblRec);
                    tr.AddNewlyCreatedDBObject(acBlkTblRec, true);
                }
                tr.Commit();
            }
        }

    }
    public static void GhiChuTimMong(Point3d ptVe, double scale)
    {
        KyHieuGocPhanTu_1(ptVe, scale);
        KyHieuGocPhanTu_2(ptVe, scale);
        // Tạo đường trong
        ClCAD.CreateCircle(ptVe, 150 * 0.01 * scale);
        // Tạo pline
        Point3d p1 = ptVe;
        Point3d p2 = new Point3d(p1.X + 300 * 0.01 * scale, p1.Y + 300 * 0.01 * scale, 0);
        Point3d p3 = new Point3d(p2.X + 1500 * 0.01 * scale, p2.Y, 0);
        ClCAD.CreatePolylineFromListPointsReturnPolyline(new List<Point3d> { p1, p2, p3 }, false);
        ClCAD.CreateDText("TIM MÓNG", new Point3d(p2.X + 50 * 0.01 * scale, p2.Y + 150 * 0.01 * scale, 0), "CHUTHUONG", 200 * scale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
    }
    public static void KyHieuGocPhanTu_1(Point3d ptve, double scale)
    {
        // Get the current document and database
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        Database acCurDb = acDoc.Database;
        // Start a transaction
        using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
        {
            // Open the Block table for read           
            BlockTable acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
            // Open the Block table record Model space for write           
            BlockTableRecord acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
            // Create an arc object for the closed boundary to hatch
            Point3d p1 = ptve;
            Arc acArc = new Arc(p1, 150 * 0.01 * scale, 0, Math.PI / 2);
            acArc.SetDatabaseDefaults();
            acBlkTblRec.AppendEntity(acArc);
            acTrans.AddNewlyCreatedDBObject(acArc, true);
            // Create an line object for the closed boundary to hatch
            //Line acLine = new Line(acArc.StartPoint, acArc.EndPoint);
            Line l1 = new Line(acArc.StartPoint, p1);
            Line l2 = new Line(acArc.EndPoint, p1);
            l1.SetDatabaseDefaults();
            l2.SetDatabaseDefaults();
            acBlkTblRec.AppendEntity(l1);
            acBlkTblRec.AppendEntity(l2);
            acTrans.AddNewlyCreatedDBObject(l1, true);
            acTrans.AddNewlyCreatedDBObject(l2, true);
            ObjectIdCollection acObjIdColl = new ObjectIdCollection();
            acObjIdColl.Add(acArc.ObjectId);
            acObjIdColl.Add(l1.ObjectId);
            acObjIdColl.Add(l2.ObjectId);
            Hatch acHatch = new Hatch();
            acBlkTblRec.AppendEntity(acHatch);
            acTrans.AddNewlyCreatedDBObject(acHatch, true);
            // Set the properties of the hatch object
            acHatch.SetDatabaseDefaults();
            acHatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID");
            acHatch.Associative = true;
            acHatch.AppendLoop(HatchLoopTypes.Outermost, acObjIdColl);
            acHatch.EvaluateHatch(true);
            acTrans.Commit();
        }
    }
    public static void KyHieuGocPhanTu_2(Point3d ptve, double scale)
    {
        // Get the current document and database
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        Database acCurDb = acDoc.Database;
        // Start a transaction
        using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
            Point3d p1 = ptve;
            Arc acArc2 = new Arc(p1, 150 * 0.01 * scale, Math.PI, 1.5 * Math.PI);
            acArc2.SetDatabaseDefaults();
            acBlkTblRec.AppendEntity(acArc2);
            acTrans.AddNewlyCreatedDBObject(acArc2, true);
            Line l3 = new Line(acArc2.StartPoint, p1);
            Line l4 = new Line(acArc2.EndPoint, p1);
            l3.SetDatabaseDefaults();
            l4.SetDatabaseDefaults();
            acBlkTblRec.AppendEntity(l3);
            acBlkTblRec.AppendEntity(l4);
            acTrans.AddNewlyCreatedDBObject(l3, true);
            acTrans.AddNewlyCreatedDBObject(l4, true);
            ObjectIdCollection acObjIdColl = new ObjectIdCollection();
            acObjIdColl.Add(acArc2.ObjectId);
            acObjIdColl.Add(l3.ObjectId);
            acObjIdColl.Add(l4.ObjectId);
            Hatch acHatch = new Hatch();
            acBlkTblRec.AppendEntity(acHatch);
            acTrans.AddNewlyCreatedDBObject(acHatch, true);
            acHatch.SetDatabaseDefaults();
            acHatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID");
            acHatch.Associative = true;
            acHatch.AppendLoop(HatchLoopTypes.Outermost, acObjIdColl);
            acHatch.EvaluateHatch(true);
            acTrans.Commit();
        }
    }

    public static void KiHieuMatCat(Point3d pStart, Point3d pEnd, string tenMc, double scale)// khoangcach1 =600. khoangcach2 =200, khoangcach3 =150
    {
        double tile = 0.01 * scale;
        Vector3d vt = pEnd - pStart;
        Vector3d vtdv = vt.GetNormal();
        Vector3d vtdv_vuonggoc = vtdv.CrossProduct(Vector3d.ZAxis).GetNormal();
        Point3d p1 = pStart + vtdv.MultiplyBy(600 * tile);
        Point3d p1a = pStart + vtdv.MultiplyBy(600 * tile / 2);
        Point3d p2 = p1 + vtdv.MultiplyBy(200 * tile);
        Point3d p3 = pEnd - vtdv.MultiplyBy(600 * tile);
        Point3d p3a = pEnd - vtdv.MultiplyBy(600 * tile / 2);
        Point3d p4 = p3 - vtdv.MultiplyBy(200 * tile);
        Point3d p5 = p1a - vtdv_vuonggoc.MultiplyBy(150 * tile);
        Point3d p6 = p3a - vtdv_vuonggoc.MultiplyBy(150 * tile);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, pStart, p5, p1 }, false);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p4, pEnd, p6, p3 }, false);
        ClCAD.CreateHatchFromListPointP(new List<Point3d> { pStart, p5, p1, pStart }, "SOLID", 1);
        ClCAD.CreateHatchFromListPointP(new List<Point3d> { p3, pEnd, p6, p3 }, "SOLID", 1);
        // Chèn tên Mặt cắt
        Point3d pchen = p5 + vtdv_vuonggoc.MultiplyBy(500 * tile);//khoangcach4 = 500
        ClCAD.CreateDText(tenMc, pchen, "CHUTHUONG", 400 * tile, 4, TextHorizontalMode.TextCenter, 0);
        pchen = p6 + vtdv_vuonggoc.MultiplyBy(500 * tile);
        ClCAD.CreateDText(tenMc, pchen, "CHUTHUONG", 400 * tile, 4, TextHorizontalMode.TextCenter, 0);
    }
    public static void TaoDuongCheoGhiChuTag(List<Point3d> dsP, double scale)
    {
        double tile = scale * 0.01;
        foreach (Point3d point in dsP)
        {
            Point3d p1 = new Point3d(point.X + 50 * tile, point.Y + 50 * tile, 0);
            Point3d p2 = new Point3d(point.X - 50 * tile, point.Y - 50 * tile, 0);
            ClCAD.CreateLine(p1, p2);
        }
        if (dsP.Count > 1)
        {
            ClCAD.CreateLine(dsP[0], dsP[dsP.Count - 1]);
        }
    }
    public static void TaoDuongCheoGhiChuTag2(List<Point3d> dsP, double scale)
    {
        double tile = scale * 0.01;
        foreach (Point3d point in dsP)
        {
            Point3d p1 = new Point3d(point.X + 42 * tile, point.Y + 58 * tile, 0);
            Point3d p2 = new Point3d(point.X - 42 * tile, point.Y - 58 * tile, 0);
            ClCAD.CreateLine(p1, p2);
        }
        if (dsP.Count > 1)
        {
            ClCAD.CreateLine(dsP[0], dsP[dsP.Count - 1]);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dsPoints"></param>
    /// <param name="scale"></param>
    /// <param name="dy"></param>
    /// <param name="pTag"></param>
    /// <param name="dkThepVe"></param>
    /// <param name="dkThep"></param>
    /// <param name="kcThep"></param>
    /// <param name="loai"></param> loại tag là trên hay dưới
    public static void KiHieuTagType1_A(List<Point3d> dsPoints, ThongSoMong thongSoMong, double SelectedScale, Point3d pTag, int dkThepVe, int dkThep, double kcThep, int loai, string sohieu)
    {
        bool checkChieuDaiMong = thongSoMong.ChieuRongDai == thongSoMong.ChieuDaiDai;

        string nameBlock = "TagThep";
        Point3d pNs2 = new Point3d(dsPoints[0].X - kcThep / 2, dsPoints[0].Y - dkThepVe / 2, 0);  // type 2
        Point3d pNs4 = new Point3d(dsPoints[0].X - kcThep / 2, dsPoints[0].Y - dkThepVe / 2, 0);  // type 4
        Point3d pNoi2 = new Point3d(dsPoints[0].X, pTag.Y, 0);
        Point3d pNoi4 = new Point3d(dsPoints[0].X, pTag.Y, 0);
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        for (int i = 0; i < dsPoints.Count; i++)
        {
            Point3d pt = new Point3d(dsPoints[i].X, pTag.Y, 0);
            ClCAD.CreateLine(pt, dsPoints[i]);
        }
        if (loai == 0)
        {
            if (checkChieuDaiMong)
            {
                ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pNs2, pNoi2, pTag }, false);
                TaoDuongCheoGhiChuTag(new List<Point3d> { pNs2 }, SelectedScale);
            }
            else ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[0], pNoi2, pTag }, false);
        }
        else
        {
            if (checkChieuDaiMong)
            {
                ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pNs4, pNoi4, pTag }, false);
                TaoDuongCheoGhiChuTag(new List<Point3d> { pNs4 }, SelectedScale);
            }
            else ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[0], pNoi4, pTag }, false);
        }
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
    }
    public static void KiHieuTagType1_B(List<Point3d> dsPoints, ThongSoMong thongSoMong, double SelectedScale, Point3d pTag, int dkThepVe, int dkThep, double kcThep, int loai, string sohieu)
    {
        bool checkChieuDaiMong = thongSoMong.ChieuRongDai == thongSoMong.ChieuDaiDai;
        Point3d pNs1 = new Point3d(dsPoints[dsPoints.Count - 1].X + kcThep / 2, dsPoints[dsPoints.Count - 1].Y - dkThepVe / 2, 0);  // type 1
        Point3d pNs3 = new Point3d(dsPoints[dsPoints.Count - 1].X + kcThep / 2, dsPoints[dsPoints.Count - 1].Y - dkThepVe / 2, 0);  // type 3
        Point3d pNoi1 = new Point3d(dsPoints[dsPoints.Count - 1].X, pTag.Y, 0);
        Point3d pNoi3 = new Point3d(dsPoints[dsPoints.Count - 1].X, pTag.Y, 0);
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        string nameBlock = "TagThepType2";
        for (int i = 0; i < dsPoints.Count; i++)
        {
            Point3d pt = new Point3d(dsPoints[i].X, pTag.Y, 0);
            ClCAD.CreateLine(pt, dsPoints[i]);
        }
        if (loai == 0)
        {
            //if (checkChieuDaiMong)
            //{
            //    TaoDuongCheoGhiChuTag(new List<Point3d> { pNs1 }, SelectedScale);
            //    ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pNs1, pNoi1, pTag }, false);
            //}
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[dsPoints.Count - 1], pNoi1, pTag }, false);
        }
        else
        {
            //if (checkChieuDaiMong)
            //{
            //    TaoDuongCheoGhiChuTag(new List<Point3d> { pNs3 }, SelectedScale);
            //    ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pNs3, pNoi3, pTag }, false);
            //}
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[dsPoints.Count - 1], pNoi3, pTag }, false);
        }
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
    }
    //public static void KiHieuTagType2_A1(List<Point3d> dsPoints, ThongSoMong thongSoMong, double SelectedScale, Point3d pTag, int dkThepVe, int dkThep, double kcThep, int sohieu)
    //{
    //    bool checkChieuDaiMong = thongSoMong.ChieuDaiDai == thongSoMong.ChieuRongDai;
    //    string nameBlock = "TagThep";
    //    Point3d pNs2 = new Point3d(dsPoints[dsPoints.Count - 1].X + kcThep / 2, dsPoints[0].Y - dkThepVe / 2, 0);  // type 2
    //    Point3d pNoi2 = new Point3d(dsPoints[0].X + kcThep / 2, pTag.Y, 0);
    //    ClCAD.SetLayerCurrent("NETTAGTHEP");
    //    for (int i = 0; i < dsPoints.Count; i++)
    //    {
    //        Point3d pt = new Point3d(dsPoints[i].X + kcThep / 2, pTag.Y, 0);
    //        ClCAD.CreateLine(pt, dsPoints[i]);
    //    }
    //    ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[0], pNoi2, pTag }, false);
    //    if (checkChieuDaiMong)
    //    {
    //        Point3d pTem = new Point3d(dsPoints[dsPoints.Count - 1].X + kcThep / 2, pTag.Y, 0);
    //        TaoDuongCheoGhiChuTag(new List<Point3d> { pNs2 }, SelectedScale);
    //        ClCAD.CreateLine(pTem, pNs2);
    //    }

    //    ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
    //}
    public static void KiHieuTagType2_A(List<List<Point3d>> ListdsPoints, ThongSoMong thongSoMong, double SelectedScale, Point3d pTag, int dkThepVe, int dkThep, double kcThep, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        bool checkChieuDaiMong = thongSoMong.ChieuDaiDai == thongSoMong.ChieuRongDai;
        string nameBlock = "TagThep";
        List<Point3d> dsPoints0 = ListdsPoints[0];
        Point3d pNoi2 = new Point3d(dsPoints0[0].X + kcThep / 2, pTag.Y, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints0[0], pNoi2, pTag }, false);
        foreach (List<Point3d> dsPoints in ListdsPoints)
        {
            Point3d pNs2 = new Point3d(dsPoints[dsPoints.Count - 1].X + kcThep / 2, dsPoints[0].Y - dkThepVe / 2, 0);  // type 2           
            for (int i = 0; i < dsPoints.Count; i++)
            {
                Point3d pt = new Point3d(dsPoints[i].X + kcThep / 2, pTag.Y, 0);
                ClCAD.CreateLine(pt, dsPoints[i]);
            }
            //if (checkChieuDaiMong)
            //{
            //    Point3d pTem = new Point3d(dsPoints[dsPoints.Count - 1].X + kcThep / 2, pTag.Y, 0);
            //    TaoDuongCheoGhiChuTag(new List<Point3d> { pNs2 }, SelectedScale);
            //    ClCAD.CreateLine(pTem, pNs2);
            //}
        }
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
    }
    public static void KiHieuTagType2_B(List<Point3d> dsPoints, double SelectedScale, Point3d pTag, int dkThepVe, int dkThep, double kcThep, string sohieu)
    {
        string nameBlock = "TagThepType2";
        Point3d pNs2 = new Point3d(dsPoints[0].X - kcThep / 2, dsPoints[0].Y - dkThepVe / 2, 0);  // type 2
        Point3d pNoi2 = new Point3d(dsPoints[dsPoints.Count - 1].X - kcThep / 2, pTag.Y, 0);
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        for (int i = 0; i < dsPoints.Count; i++)
        {
            Point3d pt = new Point3d(dsPoints[i].X - kcThep / 2, pTag.Y, 0);
            ClCAD.CreateLine(pt, dsPoints[i]);
        }
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[0], pNoi2, pTag }, false);
        TaoDuongCheoGhiChuTag(new List<Point3d> { pNs2 }, SelectedScale);
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
    }
    public static void KiHieuTagType3(List<Point3d> dsPoints, double SelectedScale, Point3d pTag, int dkThep, double kcThep, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        Point3d pNoi1 = new Point3d(dsPoints[0].X, pTag.Y, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[0], pNoi1, pTag }, false);
        TaoDuongCheoGhiChuTag(dsPoints, SelectedScale);
        string nameBlock = "TagThepType2";
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
    }
    public static void KiHieuTagType3_A(List<Point3d> dsPoints, double SelectedScale, Point3d pTag, int dkThep, int SLThanh, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        Point3d pNoi1 = new Point3d(dsPoints[0].X, pTag.Y, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[0], pNoi1, pTag }, false);
        TaoDuongCheoGhiChuTag(dsPoints, SelectedScale);
        string nameBlock = "TagThep";
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, SLThanh, dkThep, 0, SelectedScale * 0.01, 0);
    }
    public static void KiHieuTagType3_B(List<Point3d> dsPoints, double SelectedScale, Point3d pTag, int dkThep, double kcThep, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        Point3d pNoi1 = new Point3d(dsPoints[0].X, pTag.Y, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { dsPoints[0], pNoi1, pTag }, false);
        TaoDuongCheoGhiChuTag(dsPoints, SelectedScale);
        string nameBlock = "TagThep";
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
    }
    public static void KiHieuTagType4(List<Point3d> dsPoints, double SelectedScale, Point3d pTag, int dkThep, double kcThep, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        TaoDuongCheoGhiChuTag(dsPoints, SelectedScale);
        string nameBlock = "TagThep";
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
        ClCAD.CreateLine(dsPoints[0], pTag);
    }
    public static void KiHieuTagType4_A(List<Point3d> dsPoints, double SelectedScale, Point3d pTag, int dkThep, int SLThanh, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        TaoDuongCheoGhiChuTag(dsPoints, SelectedScale);
        string nameBlock = "TagThep";
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, SLThanh, dkThep, 0, SelectedScale * 0.01, 0);
        ClCAD.CreateLine(dsPoints[0], pTag);
    }
    public static void KiHieuTagType5(List<Point3d> dsPoints, double SelectedScale, Point3d pTag, int dkThep, double kcThep, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        TaoDuongCheoGhiChuTag(dsPoints, SelectedScale);
        string nameBlock = "TagThep";
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
        Point3d ptd = ClCAD.MiddlePoint(dsPoints[0], dsPoints[dsPoints.Count - 1]);
        Point3d ptd2 = new Point3d(ptd.X - kcThep / 2, ptd.Y, 0);
        Point3d pNoi = new Point3d(ptd2.X, pTag.Y, 0);

        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { ptd2, pNoi, pTag }, false);
    }
    public static void KiHieuTagType5_A(Point3d pIn, double SelectedScale, Point3d pTag, int dkThep, int soluong, string sohieu)
    {
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        TaoDuongCheoGhiChuTag(new List<Point3d> { pIn }, SelectedScale);
        string nameBlock = "TagThep";
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, soluong, dkThep, 0, SelectedScale * 0.01, 0);

        Point3d pNoi = new Point3d(pIn.X, pTag.Y, 0);

        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pIn, pNoi, pTag }, false);
    }
    public static void KiHieuDanhSoThepBan_X(Point3d p1, Point3d p4, Line lineThep, string sohieu, int dkThep, double kcThep
        , double SelectedScale, string lop, TextHorizontalMode mode, int type)
    {
        ClCAD.SetLayerCurrent("NETPHU");
        Line line = ClCAD.CreateReturnLine(p1, p4);
        Point3d p2 = new Point3d(p1.X + 100, p1.Y + 50, 0);
        Point3d p3 = new Point3d(p2.X, p1.Y - 50, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, p1, p3 }, false);
        Point3d p5 = new Point3d(p4.X - 100, p4.Y + 50, 0);
        Point3d p6 = new Point3d(p4.X - 100, p4.Y - 50, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5, p4, p6 }, false);
        Point3d pin = ClCAD.IntersectPoint(line, lineThep);
        ClCAD.CreateCircleReturn(pin, 50);
        string nameBlock = "TagThep";
        bool checkType = type == 0;
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        Point3d pTag = new Point3d(checkType ? pin.X + 50 : pin.X - 1600 * SelectedScale * 0.01, checkType ? pin.Y + 200 : pin.Y - 200, 0);
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
        ClCAD.CreateDText(lop, new Point3d(pin.X, checkType ? pin.Y - 150 : pin.Y + 150, 0), "CHUTHUONG", 200 * SelectedScale * 0.01, 4, mode, 0);
    }

    public static void KiHieuDanhSoThepBan_Y(Point3d p1, Point3d p4, Line lineThep, string sohieu, int dkThep, double kcThep
       , double SelectedScale, string lop, TextHorizontalMode mode, int type)
    {
        ClCAD.SetLayerCurrent("NETPHU");
        Line line = ClCAD.CreateReturnLine(p1, p4);
        Point3d p2 = new Point3d(p1.X + 50, p1.Y - 100, 0);
        Point3d p3 = new Point3d(p1.X - 50, p2.Y, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, p1, p3 }, false);
        Point3d p5 = new Point3d(p4.X + 50, p4.Y + 100, 0);
        Point3d p6 = new Point3d(p4.X - 50, p4.Y + 100, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5, p4, p6 }, false);
        Point3d pin = ClCAD.IntersectPoint(line, lineThep);
        ClCAD.CreateCircleReturn(pin, 50);
        string nameBlock = "TagThep";
        bool checkType = type == 0;
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        Point3d pTag = new Point3d(checkType ? pin.X - 1600 * SelectedScale * 0.01 : pin.X + 100 * SelectedScale * 0.01, checkType ? pin.Y + 200 : pin.Y - 200, 0);
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
        ClCAD.CreateDText(lop, new Point3d(pin.X, checkType ? pin.Y - 150 : pin.Y + 150, 0), "CHUTHUONG", 200 * SelectedScale * 0.01, 4, mode, 0);
    }

    public static void KiHieuDoiXung(string TrucDoiXung, double scale)
    {
        double tile = scale * 0.01;
        string NameBL = TrucDoiXung + scale.ToString();
        Database db = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Database;
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
            if (!acBlkTbl.Has(NameBL))
            {
                using (BlockTableRecord acBlkTblRec = new BlockTableRecord())
                {
                    acBlkTblRec.Name = NameBL;
                    Point3d pIn = new Point3d();
                    Point3d p1 = new Point3d(pIn.X, pIn.Y + 666.67 * tile, 0);
                    Point3d p2 = new Point3d(p1.X + 100 * tile, p1.Y - 36 * tile, 0);
                    Point3d p3 = new Point3d(p2.X + 100 * tile, p2.Y - 83.3 * tile, 0);
                    Point3d p4 = new Point3d(p1.X - 200 * tile, p3.Y, 0);
                    Point3d p5 = new Point3d(p1.X - 100 * tile, p2.Y, 0);
                    Point3d p6 = new Point3d(p1.X - 63.33 * tile, p4.Y - 52.67 * tile, 0);
                    Point3d p7 = new Point3d(p1.X + 63.33 * tile, p6.Y, 0);
                    Line l1 = new Line(p1, pIn);
                    Line l2 = new Line(p4, p3);
                    Line l3 = new Line(p4, p5);
                    Line l4 = new Line(p2, p3);
                    Line l5 = new Line(p2, p6);
                    Line l6 = new Line(p5, p7);
                    acBlkTblRec.Origin = pIn;
                    acBlkTblRec.AppendEntity(l1);
                    acBlkTblRec.AppendEntity(l2);
                    acBlkTblRec.AppendEntity(l3);
                    acBlkTblRec.AppendEntity(l4);
                    acBlkTblRec.AppendEntity(l5);
                    acBlkTblRec.AppendEntity(l6);
                    acBlkTbl.UpgradeOpen();
                    acBlkTbl.Add(acBlkTblRec);
                    tr.AddNewlyCreatedDBObject(acBlkTblRec, true);
                }
                tr.Commit();
            }
        }
    }
    public static void GhiChuDatDap(Point3d p1, double SelectedScale)
    {
        Point3d p2 = new Point3d(p1.X + 450 * SelectedScale * 0.01, p1.Y + 720 * SelectedScale * 0.01, 0);
        Point3d p3 = new Point3d(p2.X + 2850 * SelectedScale * 0.01, p2.Y, 0);
        ClCAD.SetLayerCurrent("NETPHU");
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3 }, false);
        Point3d ptext = new Point3d(p2.X + 50 * SelectedScale * 0.01, p2.Y + 130 * SelectedScale * 0.01, 0);
        ClCAD.CreateDText("ĐẤT ĐẮP ĐẦM CHẶT", ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
    }
    public static void GhiChuDatThuaDapLai(Point3d p1, double SelectedScale)
    {
        Point3d p2 = new Point3d(p1.X + 300 * SelectedScale * 0.01, p1.Y + 500 * SelectedScale * 0.01, 0);
        Point3d p3 = new Point3d(p2.X + 2850 * SelectedScale * 0.01, p2.Y, 0);
        ClCAD.SetLayerCurrent("NETPHU");
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3 }, false);
        Point3d ptext = new Point3d(p2.X + 50 * SelectedScale * 0.01, p2.Y + 130 * SelectedScale * 0.01, 0);
        ClCAD.CreateDText("ĐẤT THỪA ĐẮP LẠI", ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
    }
    public static void GhiChuVaiDia(Point3d p1, double SelectedScale, double S_vaidia, int soThanCot)
    {
        Point3d p2 = new Point3d(p1.X + 450 * SelectedScale * 0.01, p1.Y - 400 * SelectedScale * 0.01, 0);
        Point3d p3 = new Point3d(p2.X + 2442 * SelectedScale * 0.01, p2.Y, 0);
        ClCAD.SetLayerCurrent("NETPHU");
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3 }, false);
        Point3d ptext = new Point3d(p2.X + 50 * SelectedScale * 0.01, p2.Y + 130 * SelectedScale * 0.01, 0);
        ClCAD.CreateDText("VẢI ĐỊA KỸ THUẬT >= R9", ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
        ptext = new Point3d(p2.X + 50 * SelectedScale * 0.01, p2.Y - 130 * SelectedScale * 0.01, 0);

        string textVaiDia = "";
        if (soThanCot > 1) textVaiDia = string.Format("S = {0}x{1} m²", soThanCot, S_vaidia);
        else textVaiDia = string.Format("S = {0} m²", S_vaidia);
        ClCAD.CreateDText(textVaiDia.ToString(), ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
    }
    public static void GhiChuCatDem(Point3d p1, double SelectedScale, double V_demcat, int soThanCot)
    {
        Point3d p2 = new Point3d(p1.X + 450 * SelectedScale * 0.01, p1.Y - 400 * SelectedScale * 0.01, 0);
        Point3d p3 = new Point3d(p2.X + 1860 * SelectedScale * 0.01, p2.Y, 0);
        Point3d p4 = new Point3d(p1.X - 200 * SelectedScale * 0.01, p1.Y + 200 * SelectedScale * 0.01, 0);
        ClCAD.SetLayerCurrent("NETPHU");
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p4, p2, p3 }, false);
        Point3d ptext = new Point3d(p2.X + 50 * SelectedScale * 0.01, p2.Y + 130 * SelectedScale * 0.01, 0);
        ClCAD.CreateDText("ĐỆM CÁT", ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
        ptext = new Point3d(p2.X + 50 * SelectedScale * 0.01, p2.Y - 130 * SelectedScale * 0.01, 0);
        string textDemcat = "";
        if (soThanCot > 1) textDemcat = string.Format("V = {0}x{1} m³", soThanCot, V_demcat);
        else textDemcat = string.Format("V = {0} m³", V_demcat);
        ClCAD.CreateDText(textDemcat.ToString(), ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
    }
    public static void GhiChuDoiTrong(Point3d p1, Point3d p2, double SelectedScale, double h_doitrong)
    {
        Point3d p3 = new Point3d(p2.X - 3000 * SelectedScale * 0.01, p2.Y, 0);
        ClCAD.SetLayerCurrent("NETPHU");
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3 }, false);
        Point3d ptext = new Point3d(p3.X + 50 * SelectedScale * 0.01, p2.Y + 130 * SelectedScale * 0.01, 0);
        ClCAD.CreateDText("BÊ TÔNG ĐỐI TRỌNG", ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
        ptext = new Point3d(p2.X - 1500 * SelectedScale * 0.01, p2.Y - 130 * SelectedScale * 0.01, 0);
        string doitrong = string.Format("M100(B7.5)-H={0}mm", h_doitrong);
        ClCAD.CreateDText(doitrong, ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextCenter, 0);
    }
    public static int GhiChuThangLeo(Point3d p1, Point3d p2, int Left_Right, double SelectedScale)
    {
        // 0 là bên tai trái, 1 là bên tay trái
        bool checkLeft_Right = Left_Right == 0;
        double kcLe = 300;
        double khoangCach = p1.DistanceTo(p2);
        int sl = (int)(khoangCach / kcLe) + 1;
        List<Line> dsLine = new List<Line>();
        List<Point3d> dsP = new List<Point3d>();
        for (int i = 1; i < sl; i++)
        {
            Point3d px = new Point3d(p1.X, p1.Y + kcLe * i, 0);
            Point3d px1 = new Point3d(px.X + (checkLeft_Right ? kcLe : -kcLe), px.Y, 0);
            Point3d pc = new Point3d(px.X + (checkLeft_Right ? kcLe / 2 : -kcLe / 2), px.Y, 0);
            ClCAD.SetLayerCurrent("NETTHEPCHU");
            Line line = ClCAD.CreateReturnLine(px, px1);
            dsP.Add(pc);
            dsLine.Add(line);
        }
        if (Left_Right == 0)
        {
            ClCAD.SetLayerCurrent("NETPHU");
            TaoDuongCheoGhiChuTag(dsP, SelectedScale);
            Point3d pthang1 = new Point3d(dsP[0].X, dsP[dsP.Count - 1].Y - kcLe / 2, 0);
            Point3d pthang2 = new Point3d(pthang1.X + 1850 * SelectedScale * 0.01, pthang1.Y, 0);
            ClCAD.CreateLine(pthang1, pthang2);
            Point3d ptext = new Point3d(pthang1.X + 150 * SelectedScale * 0.01, pthang1.Y + 130 * SelectedScale * 0.01, 0);
            ClCAD.CreateDText("THANG LEO", ptext, "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);
        }
        return dsLine.Count;
    }
    public static void GhiChuThangLeo_TagThep(Point3d p1, Point3d p2, int Left_Right, double SelectedScale, int SoHieuThanh, int SoLuong, int dkThep)
    {
        // 0 là bên tai trái, 1 là bên tay trái
        bool checkLeft_Right = Left_Right == 0;
        double kcLe = 300;
        double khoangCach = p1.DistanceTo(p2);
        int sl = (int)(khoangCach / kcLe) + 1;
        List<Line> dsLine = new List<Line>();
        List<Point3d> dsP = new List<Point3d>();
        for (int i = 1; i < sl; i++)
        {
            Point3d px = new Point3d(p1.X, p1.Y + kcLe * i, 0);
            Point3d px1 = new Point3d(px.X + (checkLeft_Right ? kcLe : -kcLe), px.Y, 0);
            Point3d pc = new Point3d(px.X + (checkLeft_Right ? kcLe / 2 : -kcLe / 2), px.Y, 0);
            ClCAD.SetLayerCurrent("NETTHEPCHU");
            Line line = ClCAD.CreateReturnLine(px, px1);
            dsP.Add(pc);
            dsLine.Add(line);
        }
        if (Left_Right == 0)
        {
            ClCAD.SetLayerCurrent("NETPHU");
            TaoDuongCheoGhiChuTag(dsP, SelectedScale);
            ClCAD.SetLayerCurrent("NETTAGTHEP");
            Point3d pthang1 = new Point3d(dsP[0].X, dsP[dsP.Count - 1].Y - kcLe / 2, 0);
            Point3d pthang2 = new Point3d(pthang1.X + 400 * SelectedScale * 0.01, pthang1.Y, 0);
            ClCAD.CreateLine(pthang1, pthang2);
            ClCAD.SetLayerCurrent("NETTAGTHEP");
            string nameBlock = "TagThepX1";
            TaoDuongCheoGhiChuTag(new List<Point3d> { pthang1 }, SelectedScale);
            //ClBlock.InsertBlockTagThep2(nameBlock, pthang2, SoHieuThanh, SoLuong, dkThep, 0, SelectedScale * 0.01, 0);
        }
    }
    public static void KiHieuDanhSoThep_MongBan_X_Type1(Point3d p1, Point3d p4, Line lineThep, Line lineThep2,
        string sohieu, int dkThep, double kcThep, double SelectedScale, int slThanh)
    {
        ClCAD.SetLayerCurrent("NETPHU");
        Line line = ClCAD.CreateReturnLine(p1, p4);
        Point3d p2 = new Point3d(p1.X + 100, p1.Y + 50, 0);
        Point3d p3 = new Point3d(p2.X, p1.Y - 50, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, p1, p3 }, false);
        Point3d p5 = new Point3d(p4.X - 100, p4.Y + 50, 0);
        Point3d p6 = new Point3d(p4.X - 100, p4.Y - 50, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5, p4, p6 }, false);
        Point3d pin = ClCAD.IntersectPoint(line, lineThep);
        Point3d pin2 = ClCAD.IntersectPoint(line, lineThep2);
        ClCAD.CreateCircleReturn(pin, 80);
        ClCAD.CreateCircleReturn(pin2, 80);
        string nameBlock = "TagThep";
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        double kcText = 100 * SelectedScale * 0.01;
        Point3d pTag = new Point3d(pin2.X + 50 * SelectedScale * 0.01, pin.Y + 2.5 * kcText, 0);
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, 0);
        string textSL = string.Format("{0}Ø{1}-2 LỚP", slThanh, dkThep);
        ClCAD.CreateDText(textSL, new Point3d(pin2.X + 50 * SelectedScale * 0.01, pin2.Y - 1.8 * kcText, 0), "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, 0);

    }

    public static void KiHieuDanhSoThep_MongBan_Y_Type1(Point3d p1, Point3d p4, Line lineThep, Line lineThep2,
       string sohieu, int dkThep, double kcThep, double SelectedScale, int slThanh)
    {

        ClCAD.SetLayerCurrent("NETPHU");
        Line line = ClCAD.CreateReturnLine(p1, p4);
        Point3d p2 = new Point3d(p1.X + 50, p1.Y - 100, 0);
        Point3d p3 = new Point3d(p1.X - 50, p2.Y, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, p1, p3 }, false);
        Point3d p5 = new Point3d(p4.X + 50, p4.Y + 100, 0);
        Point3d p6 = new Point3d(p4.X - 50, p4.Y + 100, 0);
        ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5, p4, p6 }, false);
        Point3d pin = ClCAD.IntersectPoint(line, lineThep);
        Point3d pin2 = ClCAD.IntersectPoint(line, lineThep2);
        ClCAD.CreateCircleReturn(pin, 80);
        ClCAD.CreateCircleReturn(pin2, 80);

        string nameBlock = "TagThep";
        ClCAD.SetLayerCurrent("NETTAGTHEP");
        double kcText = 100 * SelectedScale * 0.01;
        Point3d pTag = new Point3d(pin.X - 2.5 * kcText, pin.Y + 2.5 * kcText, 0);
        ClBlock.InsertBlockTagThep2(nameBlock, pTag, sohieu, 0, dkThep, kcThep, SelectedScale * 0.01, Math.PI / 2);
        string textSL = string.Format("{0}Ø{1}-2 LỚP", slThanh, dkThep);
        ClCAD.CreateDText(textSL, new Point3d(pin.X + 2.5 * kcText, pin.Y + 2 * kcText, 0), "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, Math.PI / 2);

    }
}

