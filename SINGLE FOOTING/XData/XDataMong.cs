using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;

namespace ACAD_API.XData
{
    public class XDataMong
    {
        public string TenMong { get; set; }
        public string MacBTKC { get; set; }
        public double KhoiLuongBTKC { get; set; }
        public double KhoiLuongBTL { get; set; }
        public static readonly string nameXData_BangTHThep = "BangTHThep";
        public static XDataMong Get_XData_Mong(Entity entity)
        {
            ResultBuffer rb = entity.XData;
            if (rb == null) return null;
            TypedValue[] data = rb.AsArray();
            return new XDataMong()
            {
                TenMong = data[1].Value.ToString(),
                MacBTKC = data[2].Value.ToString(),
                KhoiLuongBTKC = double.Parse(data[3].Value.ToString()),
                KhoiLuongBTL = double.Parse(data[4].Value.ToString()),
            };
        }
        public static void Set_XData_Mong(Entity entity, XDataMong data)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (doc.LockDocument())
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                var regAppTable = (RegAppTable)tr.GetObject(db.RegAppTableId, OpenMode.ForRead);
                if (!regAppTable.Has(nameXData_BangTHThep))
                {
                    var regApp = new RegAppTableRecord();
                    regApp.Name = nameXData_BangTHThep;
                    tr.GetObject(db.RegAppTableId, OpenMode.ForWrite);
                    regAppTable.Add(regApp);
                }
                ResultBuffer buffer = new ResultBuffer
                {
                new TypedValue((int)DxfCode.ExtendedDataRegAppName, nameXData_BangTHThep),
                new TypedValue((int)DxfCode.ExtendedDataAsciiString, data.TenMong),
                new TypedValue((int)DxfCode.ExtendedDataAsciiString, data.MacBTKC),
                new TypedValue((int)DxfCode.ExtendedDataAsciiString, data.KhoiLuongBTKC.ToString()),
                new TypedValue((int)DxfCode.ExtendedDataAsciiString, data.KhoiLuongBTL.ToString()),
                };
                entity.XData = buffer;
                tr.Commit();
            }
        }
    }
}
