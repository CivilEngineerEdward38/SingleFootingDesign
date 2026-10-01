using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAD_API.SLAB_BEAM_RAFT_FOOTING.Model
{
    public class PointsLayoutModel
    {
        public Point3d MinMatBang { get; set; } = new Point3d();
        public Point3d MaxMatBang { get; set; } = new Point3d();

        public Point3d MinMatDung { get; set; } = new Point3d();
        public Point3d MaxMatDung { get; set; } = new Point3d();

        public Point3d MinMatDung_ThepDam_Cot { get; set; } = new Point3d();
        public Point3d MaxMatDung_ThepDam_Cot { get; set; } = new Point3d();

        public Point3d MinMatDung_ThepBan_X { get; set; } = new Point3d();
        public Point3d MaxMatDung_ThepBan_X { get; set; } = new Point3d();

        public Point3d MinMatDung_ThepBan_Y { get; set; } = new Point3d();
        public Point3d MaxMatDung_ThepBan_Y { get; set; } = new Point3d();

        public Point3d MinMatBang_BoTriThep { get; set; } = new Point3d();
        public Point3d MaxMatBang_BoTriThep { get; set; } = new Point3d();
        public Point3d MinMatCat3_3 { get; set; } = new Point3d();
        public Point3d MaxMatCat3_3 { get; set; } = new Point3d();
        public Point3d MinMatCat2_2 { get; set; } = new Point3d();
        public Point3d MaxMatCat2_2 { get; set; } = new Point3d();
        public Point3d MinMatCat1_1 { get; set; } = new Point3d();
        public Point3d MaxMatCat1_1 { get; set; } = new Point3d();
        public Point3d MinLuoiThep { get; set; } = new Point3d();
        public Point3d MaxLuoiThep { get; set; } = new Point3d();
        public Point3d MinBTHKL { get; set; } = new Point3d();
        public Point3d MaxBTHKL { get; set; } = new Point3d();
        public int DanhSachDKKL { get; set; }

        public Point3d MinTenMong { get; set; } = new Point3d();
        public Point3d MaxTenMong { get; set; } = new Point3d();
        public Point3d MinTenMong_ChiTiet { get; set; } = new Point3d();
        public Point3d MaxTenMong_ChiTiet { get; set; } = new Point3d();
        public Point3d MinMSBV { get; set; } = new Point3d();
        public Point3d MaxMSBV { get; set; } = new Point3d();
        public Point3d MinMSBV_Detail { get; set; } = new Point3d();
        public Point3d MaxMSBV_Detail { get; set; } = new Point3d();
        public Point3d MinSLThanhChong { get; set; } = new Point3d();
        public Point3d MaxSLThanhChong { get; set; } = new Point3d();
        public Point3d MinBTK_Thep { get; set; } = new Point3d();
        public Point3d MaxBTK_Thep { get; set; } = new Point3d();
        public Point3d MinBTK_Thep_Sturb { get; set; } = new Point3d();
        public Point3d MaxBTK_Thep_Sturb { get; set; } = new Point3d();
        public Point3d MinBTK_Thep_CM { get; set; } = new Point3d();
        public Point3d MaxBTK_Thep_CM { get; set; } = new Point3d();
        public Point3d MinBTK_Thep_Dai4 { get; set; } = new Point3d();
        public Point3d MaxBTK_Thep_Dai4 { get; set; } = new Point3d();
        public Point3d MinBTK_Thep_Dai8 { get; set; } = new Point3d();
        public Point3d MaxBTK_Thep_Dai8 { get; set; } = new Point3d();
        public Point3d MinBTK_Thep_DaiMoc { get; set; } = new Point3d();
        public Point3d MaxBTK_Thep_DaiMoc { get; set; } = new Point3d();
        public Point3d MinBTK_Thep_ThangLeo { get; set; } = new Point3d();
        public Point3d MaxBTK_Thep_ThangLeo { get; set; } = new Point3d();
        public Point3d MinKhungBao_Auxi1 { get; set; } = new Point3d();
        public Point3d MinKhungBao_Auxi2 { get; set; } = new Point3d();
        public Point3d MaxKhungBao { get; set; } = new Point3d();
        public Point3d MinKhungBao { get; set; } = new Point3d();
    }
}
