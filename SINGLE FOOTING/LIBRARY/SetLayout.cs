using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;


public class SetLayout
{
    public static void CreateLayoutAndViewport(string nameLayout, Point3d ptMinModel, Point3d ptMaxModel, Point3d ptChenViewPort, double customScale)
    {
        nameLayout = nameLayout.Replace(',', '.').Replace('?', '.').Replace(':', '.').Replace(';', '.').Replace('<', '.').Replace('>', '.').Replace('\\', '.').Replace('/', '.').Replace('=', '.').Replace('`', '.').Replace('|', '.').Replace('\"', '.');
        ObjectId layoutId = LayoutManager.Current.GetLayoutId(nameLayout);
        if (layoutId == ObjectId.Null) layoutId = LayoutManager.Current.CreateLayout(nameLayout);
        LayoutManager.Current.CurrentLayout = nameLayout;
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            Layout lay = tr.GetObject(layoutId, OpenMode.ForRead) as Layout;
            BlockTableRecord btr = tr.GetObject(lay.BlockTableRecordId, OpenMode.ForWrite) as BlockTableRecord;
            Viewport vp = new Viewport
            {
                //CenterPoint = centerPointInLayout,
                Width = Math.Abs((ptMaxModel.X - ptMinModel.X)) * customScale,
                Height = Math.Abs((ptMaxModel.Y - ptMinModel.Y)) * customScale,
                CustomScale = customScale,
                Locked = true,
                ViewCenter = new Point2d((ptMinModel.X + ptMaxModel.X) / 2, (ptMinModel.Y + ptMaxModel.Y) / 2)
            };
            vp.CenterPoint = ptChenViewPort; // new Point3d(ptChenKhungTen.X + vp.Width / 2, ptChenKhungTen.Y + vp.Height / 2, 0);
            vp.Layer = "Defpoints";
            btr.AppendEntity(vp);
            tr.AddNewlyCreatedDBObject(vp, true);
            vp.On = true;
            vp.GridOn = false;
            tr.Commit();
        }
    }
    public static bool IsLayoutExist(string nameLayout)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;

        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            LayoutManager lm = LayoutManager.Current;
            ObjectId layoutId = lm.GetLayoutId(nameLayout);

            tr.Commit();

            return layoutId.IsValid;
        }
    }


    public static void CheckLayout(string layoutNameToCheck)
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        Editor editor = doc.Editor;

        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            // Kiểm tra xem layout đã tồn tại trong bản vẽ hay chưa
            ObjectId layoutId = GetLayoutId(bt, layoutNameToCheck, tr);
            if (layoutId.IsValid)
            {
                editor.WriteMessage("Layout '{0}' already exists.\n", layoutNameToCheck);
                return;
            }
            //else
            //{
            //    // Nếu layout chưa tồn tại, thực hiện các bước để thêm layout
            //    CreateLayout(bt, layoutNameToCheck, tr);
            //    editor.WriteMessage("Layout '{0}' created.\n", layoutNameToCheck);
            //}
            tr.Commit();
        }
    }
    private static ObjectId GetLayoutId(BlockTable bt, string layoutName, Transaction tr)
    {
        foreach (ObjectId layoutId in bt)
        {
            BlockTableRecord layout = tr.GetObject(layoutId, OpenMode.ForRead) as BlockTableRecord;

            if (layout.IsLayout && layout.Name == layoutName)
            {
                return layoutId; // Trả về ObjectId của layout nếu nó tồn tại
            }
        }

        return ObjectId.Null; // Trả về ObjectId.Null nếu layout không tồn tại
    }
}

