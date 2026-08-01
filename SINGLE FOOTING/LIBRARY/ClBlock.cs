using Autodesk.AutoCAD.ApplicationServices;
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
}

