using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
public class ClBlock
{
    public static void CreateBlock_Thep(double duongkinh)
    {
        string NameBL = "COTTHEP" + duongkinh.ToString();
        Database db = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Database;
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;// lấy bảng block trong bản vẽ 
            if (!acBlkTbl.Has(NameBL))
            {
                using (BlockTableRecord acBlkTblRec = new BlockTableRecord())
                {
                    acBlkTblRec.Name = NameBL;
                    Point3d p1 = new Point3d(0, 0, 0);
                    Circle C1 = ClCAD.CreateCircleReturnCircle(p1, duongkinh / 2); //vẽ hình tròn thép
                    acBlkTblRec.Origin = p1;
                    acBlkTblRec.AppendEntity(C1); //đưa hình tròn vào block
                    acBlkTbl.UpgradeOpen();
                    acBlkTbl.Add(acBlkTblRec);
                    tr.AddNewlyCreatedDBObject(acBlkTblRec, true); //thêm block vào bản vẽ
                    //Adds the arc and line to an object id collection
                    ObjectIdCollection acObjIdColl = new ObjectIdCollection(); //tạo hactch màu đen
                    acObjIdColl.Add(C1.ObjectId);
                    //Create the hatch object and append it to the block table record
                    Hatch acHatch = new Hatch();  //hatch : vùng tô
                    acBlkTblRec.AppendEntity(acHatch);
                    tr.AddNewlyCreatedDBObject(acHatch, true);
                    //Set the properties of the hatch object 
                    //Associative must be set after the hatch object is append to the 
                    //Block table record and before AppendLoop
                    acHatch.SetDatabaseDefaults();
                    acHatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID"); //kiểu hatch là solid 
                    acHatch.Associative = true;
                    acHatch.AppendLoop(HatchLoopTypes.Outermost, acObjIdColl); //gắn hatch với hình tròn 
                    //Evaluate the hatch 
                    acHatch.EvaluateHatch(true); //finish 
                    //Increase the pattern scale by 2 and re-evelate the hatch 
                    acHatch.PatternScale = acHatch.PatternScale + 2;
                    acHatch.SetHatchPattern(acHatch.PatternType, acHatch.PatternName);
                    acHatch.EvaluateHatch(true);
                }
                tr.Commit(); //finish and save 
            }
        }
    }
    public static void InsertBlock(string NameBL, Point3d ptInsert, double scale, double rotation)
    {
        Autodesk.AutoCAD.DatabaseServices.Database db = Application.DocumentManager.MdiActiveDocument.Database;   //đang làm việc trên bản vẽ hiện tại 
        using (Transaction tr = db.TransactionManager.StartTransaction())    //bắt đầu một lượt chỉnh sửa bản vẽ 
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
            ObjectId blkRecId = ObjectId.Null;
            try
            {
                blkRecId = acBlkTbl[NameBL];  //kiểm tra trong bảng block có block tên là namebl không
            }
            catch { }
            if (blkRecId == ObjectId.Null) return;
            BlockTableRecord acBlkTblRec = tr.GetObject(blkRecId, OpenMode.ForWrite) as BlockTableRecord;
            using (BlockReference acBlkRef = new BlockReference(ptInsert, acBlkTblRec.Id)) //important, điểm đặt của block{Ơ
            {
                BlockTableRecord acCurSpaceBlkTblRec = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                acBlkRef.ScaleFactors = new Scale3d(scale); //phóng to
                acBlkRef.Rotation = rotation; //xoay
                acCurSpaceBlkTblRec.AppendEntity(acBlkRef); //đặt block này lên bản vẽ
                tr.AddNewlyCreatedDBObject(acBlkRef, true);
            }
            tr.Commit();
        }
    }

    public static void CreateTagThep(Point3d ptInsert, int dk, double kcach,
    double textHeight = 2, double widthFactor = 0.9, string textStyleName = "PECC3_Tahoma")
    {
        ClCAD.CreateTextStyle(textStyleName, "Tahoma", 0, 1, false, false);

        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;

        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTableRecord btr = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
            TextStyleTable tst = tr.GetObject(db.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;
            ObjectId styleId = tst.Has(textStyleName) ? tst[textStyleName] : db.Textstyle;

            LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
            string textLayer = lt.Has("CHU") ? "CHU" : "0";

            string noidung = "%%C" + dk.ToString();
            if (kcach > 0) noidung += "@" + kcach.ToString();

            using (DBText dkText = new DBText())
            {
                dkText.SetDatabaseDefaults();
                dkText.Position = ptInsert;
                dkText.Height = textHeight;
                dkText.WidthFactor = widthFactor;
                dkText.TextString = noidung;
                dkText.TextStyleId = styleId;
                dkText.Layer = textLayer;
                dkText.HorizontalMode = TextHorizontalMode.TextLeft;
                dkText.VerticalMode = TextVerticalMode.TextBase;
                btr.AppendEntity(dkText);
                tr.AddNewlyCreatedDBObject(dkText, true);
            }

            tr.Commit();
        }
    }
    public static void EnsureBlockSoThepMong(double circleRadius = 2.5)
    {
        string blockName = "SO-THEP MONG V2";
        string attTag = "SO";

        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;

        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            if (bt.Has(blockName))
            {
                tr.Commit();
                return; // đã có rồi, không tạo lại
            }

            // Đảm bảo style tồn tại trước
            ClCAD.CreateTextStyle("PECC3_Tahoma", "Tahoma", 0, 1, false, false);
            TextStyleTable tst = tr.GetObject(db.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;
            ObjectId styleId = tst.Has("PECC3_Tahoma") ? tst["PECC3_Tahoma"] : db.Textstyle;

            bt.UpgradeOpen();
            using (BlockTableRecord newBtr = new BlockTableRecord())
            {
                newBtr.Name = blockName;
                newBtr.Origin = Point3d.Origin;

                bt.Add(newBtr);
                tr.AddNewlyCreatedDBObject(newBtr, true);

                // --- Circle tại gốc block (0,0,0) ---
                using (Circle circle = new Circle())
                {
                    circle.SetDatabaseDefaults();
                    circle.Center = Point3d.Origin;
                    circle.Radius = circleRadius;
                    newBtr.AppendEntity(circle);
                    tr.AddNewlyCreatedDBObject(circle, true);
                }

                // --- AttributeDefinition "SO", căn giữa tại gốc block ---
                using (AttributeDefinition attDef = new AttributeDefinition())
                {
                    attDef.SetDatabaseDefaults();
                    attDef.Position = Point3d.Origin;
                    attDef.Tag = attTag;
                    attDef.Prompt = "Nhap so hieu";
                    attDef.TextString = "1";
                    attDef.Height = 4;
                    attDef.WidthFactor = 1;
                    attDef.Color = Color.FromColorIndex(ColorMethod.ByAci, 3); // green
                    attDef.TextStyleId = styleId;
                    attDef.Justify = AttachmentPoint.MiddleCenter;
                    attDef.AlignmentPoint = Point3d.Origin;
                    attDef.Constant = false;
                    attDef.Verifiable = false;
                    attDef.Preset = false;

                    newBtr.AppendEntity(attDef);
                    tr.AddNewlyCreatedDBObject(attDef, true);
                }
            }

            tr.Commit();
        }
    }

    public enum TagSide { Left, Right }

    public static void InsertBlockSoThepMong(Point3d pQuadrantPt, int sh, TagSide side = TagSide.Right,
        double scale = 1.0, double rotation = 0)
    {
        string blockName = "SO-THEP MONG V2";
        string attTag = "SO";

        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;

        using (doc.LockDocument())
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            if (!acBlkTbl.Has(blockName))
            {
                MessageBox.Show("Block \"" + blockName + "\" chưa tồn tại trong bản vẽ này.");
                return;
            }

            ObjectId blkRecId = acBlkTbl[blockName];
            BlockTableRecord acBlkTblRec = tr.GetObject(blkRecId, OpenMode.ForRead) as BlockTableRecord;

            // --- Đọc bán kính thật của Circle trong block definition ---
            double circleRadius = 0;
            foreach (ObjectId objId in acBlkTblRec)
            {
                DBObject dbObj = tr.GetObject(objId, OpenMode.ForRead);
                if (dbObj is Circle circ)
                {
                    circleRadius = circ.Radius;
                    break;
                }
            }

            // --- Tính điểm chèn thật (tâm block) từ điểm quadrant mong muốn ---
            double offset = circleRadius * scale;
            Point3d ptInsert;
            if (side == TagSide.Right)
            {
                // Circle nằm bên phải pQuadrantPt -> tâm lùi sang phải, quadrant trái chạm pQuadrantPt
                ptInsert = new Point3d(pQuadrantPt.X + offset, pQuadrantPt.Y, pQuadrantPt.Z);
            }
            else
            {
                // Circle nằm bên trái pQuadrantPt -> tâm lùi sang trái, quadrant phải chạm pQuadrantPt
                ptInsert = new Point3d(pQuadrantPt.X - offset, pQuadrantPt.Y, pQuadrantPt.Z);
            }

            using (BlockReference acBlkRef = new BlockReference(ptInsert, blkRecId))
            {
                acBlkRef.ScaleFactors = new Scale3d(scale, scale, scale);
                acBlkRef.Rotation = rotation;

                BlockTableRecord acCurSpaceBlkTblRec = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                acCurSpaceBlkTblRec.AppendEntity(acBlkRef);
                tr.AddNewlyCreatedDBObject(acBlkRef, true);

                if (acBlkTblRec.HasAttributeDefinitions)
                {
                    foreach (ObjectId objId in acBlkTblRec)
                    {
                        DBObject dbObj = tr.GetObject(objId, OpenMode.ForRead);
                        if (dbObj is AttributeDefinition acAtt && !acAtt.Constant)
                        {
                            if (acAtt.Tag == attTag)
                            {
                                using (AttributeReference acAttRef = new AttributeReference())
                                {
                                    acAttRef.SetAttributeFromBlock(acAtt, acBlkRef.BlockTransform);
                                    acAttRef.Position = acAtt.Position.TransformBy(acBlkRef.BlockTransform);
                                    acAttRef.TextString = sh.ToString();
                                    acBlkRef.AttributeCollection.AppendAttribute(acAttRef);
                                    tr.AddNewlyCreatedDBObject(acAttRef, true);
                                }
                            }
                        }
                    }
                }
            }
            tr.Commit();
        }
    }
}


