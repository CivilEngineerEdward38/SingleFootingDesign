using ACAD_API.SLAB_BEAM_RAFT_FOOTING.ViewModel;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using MONGDUONGDAY.MongBan.Model;
using SINGLE_FOOTING.SLAB_BEAM_RAFT_FOOTING.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAD_API.SLAB_BEAM_RAFT_FOOTING.Model
{
    public class DrawMongBan: MongBanViewModel
    {
        public static void DrawMatBangMongDungTam(Point3d pointMain, ThongSoMongBan thongSoMongBan, LayoutMongBanModel layoutMongBanModel, bool HaveDoiTrong)
        {
            #region Variable
            double chieuDai = thongSoMongBan.ChieuDaiMong;
            double chieuRong = thongSoMongBan.ChieuRongMong;
            double chieuRongCM = thongSoMongBan.RongCoMong_Top;
            double timMong = thongSoMongBan.TimMong;
            double ducLo = thongSoMongBan.DucLoMong;
            double dBTL = 100;
            double chieuRongDam = thongSoMongBan.ChieuRongDam;
            double doanVat = chieuRongCM / 2;
            double SelectedScale = layoutMongBanModel.Selected_Scale_Layout;
            string huongTuyen = layoutMongBanModel.SelectedHuongTuyen;
            string gocLai = layoutMongBanModel.SelectedGocLai;
            double h_doitrong = thongSoMongBan.ChieuCaoDoiTrong;
            double BTBV = layoutMongBanModel.BTBV_Day;
            double kcRai_Oban_1 = thongSoMongBan.KCThep_Oban_1;
            int dkThep_Oban_1 = thongSoMongBan.DKThep_Oban_1;
            #endregion
            #region Point
            Point3d p1 = new Point3d(pointMain.X - chieuRong / 2, pointMain.Y + chieuDai / 2, 0);
            Point3d p2 = new Point3d(p1.X + chieuRong, p1.Y, 0);
            Point3d p3 = new Point3d(p2.X, p2.Y - chieuDai, 0);
            Point3d p4 = new Point3d(p1.X, p3.Y, 0);
            Point3d pC1 = new Point3d(pointMain.X - timMong / 2, pointMain.Y + timMong / 2, 0);
            Point3d pC2 = new Point3d(pC1.X + timMong, pC1.Y, 0);
            Point3d pC3 = new Point3d(pC2.X, pC2.Y - timMong, 0);
            Point3d pC4 = new Point3d(pC1.X, pC3.Y, 0);
            Point3d pl1 = new Point3d(p1.X - dBTL, p1.Y + dBTL, 0);
            Point3d pl2 = new Point3d(p2.X + dBTL, p2.Y + dBTL, 0);
            Point3d pl3 = new Point3d(p3.X + dBTL, p3.Y - dBTL, 0);
            Point3d pl4 = new Point3d(pl1.X, pl3.Y, 0);
            Point3d py1 = new Point3d(pC1.X, p1.Y, 0);
            Point3d py2 = new Point3d(pC1.X, p3.Y, 0);
            Point3d py3 = new Point3d(pC2.X, p1.Y, 0);
            Point3d py4 = new Point3d(pC2.X, p3.Y, 0);
            Point3d px1 = new Point3d(p1.X, pC1.Y, 0);
            Point3d px2 = new Point3d(p2.X, pC1.Y, 0);
            Point3d px3 = new Point3d(p1.X, pC4.Y, 0);
            Point3d px4 = new Point3d(p2.X, pC3.Y, 0);
            Point3d pd1 = new Point3d(pointMain.X - ducLo / 2 + dBTL, pointMain.Y + ducLo / 2 - dBTL, 0);
            Point3d pd2 = new Point3d(pointMain.X + ducLo / 2 - dBTL, pointMain.Y + ducLo / 2 - dBTL, 0);
            Point3d pd3 = new Point3d(pd2.X, pointMain.Y - ducLo / 2 + dBTL, 0);
            Point3d pd4 = new Point3d(pd1.X, pd3.Y, 0);
            Point3d pd5 = new Point3d(pd1.X - dBTL, pd1.Y + dBTL, 0);
            Point3d pd6 = new Point3d(pd2.X + dBTL, pd2.Y + dBTL, 0);
            Point3d pd7 = new Point3d(pd3.X + dBTL, pd3.Y - dBTL, 0);
            Point3d pd8 = new Point3d(pd5.X, pd7.Y, 0);
            Point3d p5 = new Point3d(p1.X, px1.Y + chieuRongDam / 2, 0);
            Point3d p6 = new Point3d(py1.X - chieuRongDam / 2 - doanVat, p5.Y, 0);
            Point3d p7 = new Point3d(py1.X - chieuRongDam / 2, p6.Y + doanVat, 0);
            Point3d p8 = new Point3d(p7.X, p1.Y, 0);
            Point3d p9 = new Point3d(p5.X, p5.Y - chieuRongDam, 0);
            Point3d p10 = new Point3d(p6.X, p9.Y, 0);
            Point3d p11 = new Point3d(p7.X, p10.Y - doanVat, 0);
            Point3d p12 = new Point3d(p11.X, px3.Y + chieuRongDam / 2 + doanVat, 0);
            Point3d p13 = new Point3d(p10.X, px3.Y + chieuRongDam / 2, 0);
            Point3d p14 = new Point3d(p1.X, p13.Y, 0);
            Point3d p15 = new Point3d(p14.X, p14.Y - chieuRongDam, 0);
            Point3d p16 = new Point3d(p13.X, p15.Y, 0);
            Point3d p17 = new Point3d(p12.X, p16.Y - doanVat, 0);
            Point3d p18 = new Point3d(p17.X, p4.Y, 0);
            Point3d p19 = new Point3d(p18.X + chieuRongDam, p4.Y, 0);
            Point3d p20 = new Point3d(p19.X, p17.Y, 0);
            Point3d p21 = new Point3d(p20.X + doanVat, p16.Y, 0);
            Point3d p22 = new Point3d(py4.X - chieuRongDam / 2 - doanVat, p21.Y, 0);
            Point3d p23 = new Point3d(py4.X - chieuRongDam / 2, p22.Y - doanVat, 0);
            Point3d p24 = new Point3d(p23.X, py4.Y, 0);
            Point3d p25 = new Point3d(p21.X, p13.Y, 0);
            Point3d p26 = new Point3d(p20.X, p12.Y, 0);
            Point3d p27 = new Point3d(p26.X, p11.Y, 0);
            Point3d p28 = new Point3d(p25.X, p10.Y, 0);
            Point3d p29 = new Point3d(p22.X, p28.Y, 0);
            Point3d p30 = new Point3d(p23.X, p27.Y, 0);
            Point3d p31 = new Point3d(p30.X, p26.Y, 0);
            Point3d p32 = new Point3d(p29.X, p25.Y, 0);
            Point3d p33 = new Point3d(p28.X, p6.Y, 0);
            Point3d p34 = new Point3d(p27.X, p7.Y, 0);
            Point3d p35 = new Point3d(p34.X, p8.Y, 0);
            Point3d p36 = new Point3d(p30.X, p35.Y, 0);
            Point3d p37 = new Point3d(p36.X, p34.Y, 0);
            Point3d p38 = new Point3d(p29.X, p33.Y, 0);
            Point3d p39 = new Point3d(py3.X + chieuRongDam / 2, p1.Y, 0);
            Point3d p40 = new Point3d(p39.X, p37.Y, 0);
            Point3d p41 = new Point3d(p40.X + doanVat, p38.Y, 0);
            Point3d p42 = new Point3d(p2.X, p41.Y, 0);
            Point3d p43 = new Point3d(px2.X, p29.Y, 0);
            Point3d p44 = new Point3d(p41.X, p29.Y, 0);
            Point3d p45 = new Point3d(p40.X, p30.Y, 0);
            Point3d p46 = new Point3d(p45.X, p31.Y, 0);
            Point3d p47 = new Point3d(p44.X, p32.Y, 0);
            Point3d p48 = new Point3d(p2.X, p47.Y, 0);
            Point3d p49 = new Point3d(p2.X, p22.Y, 0);
            Point3d p50 = new Point3d(p47.X, p22.Y, 0);
            Point3d p51 = new Point3d(p46.X, p23.Y, 0);
            Point3d p52 = new Point3d(p51.X, p24.Y, 0);
            #endregion
            #region Vẽ polyline
            ClCAD.SetLayerCurrent("DUONGTRUC");
            ClCAD.CreateLine(px1, px2);
            ClCAD.CreateLine(px3, px4);
            ClCAD.CreateLine(py1, py2);
            ClCAD.CreateLine(py3, py4);
            ClCAD.SetLayerCurrent("NETPHU");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pl1, pl2, pl3, pl4 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pd1, pd2, pd3, pd4 }, true);
            ClCAD.SetLayerCurrent("NETCHINH");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5, p6, p7, p8, p1 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3, p4 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p9, p10, p11, p12, p13, p14 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p4, p15, p16, p17, p18 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p19, p20, p21, p22, p23, p24 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p25, p26, p27, p28, p29, p30, p31, p32 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p33, p34, p35, p36, p37, p38 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p39, p40, p41, p42, p2 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p43, p44, p45, p46, p47, p48 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p49, p50, p51, p52, p3 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pd5, pd6, pd7, pd8 }, true);
            VeCoMong(pC1, chieuRongCM, true, SelectedScale);
            VeCoMong(pC2, chieuRongCM, false, SelectedScale);
            VeCoMong(pC3, chieuRongCM, false, SelectedScale);
            VeCoMong(pC4, chieuRongCM, false, SelectedScale);
            #endregion
            #region Dim
            ClCAD.SetLayerCurrent("NETDIM");
            string strScale = string.Format("TL1-{0}", SelectedScale.ToString());
            ClCAD.SetDimStyleCurrent(strScale);
            List<Point3d> dsX = new List<Point3d>() { pl4, new Point3d(p4.X, pl4.Y, 0), new Point3d(py2.X, pl4.Y, 0), new Point3d(py4.X, pl4.Y, 0), new Point3d(p3.X, pl4.Y, 0), pl3 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 1);
            dsX = new List<Point3d>() { new Point3d(p4.X, pl4.Y, 0), new Point3d(p3.X, pl4.Y, 0) };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 2);
            dsX = new List<Point3d>() { p17, p20 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
            dsX = new List<Point3d>() { p29, p30 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
            dsX = new List<Point3d>() { p45, p44 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
            dsX = new List<Point3d> { pd5, new Point3d(pd4.X, pd5.Y, 0), new Point3d(pd3.X, pd5.Y, 0), pd6 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, -0.5);


            List<Point3d> dsY = new List<Point3d> { pl4, new Point3d(pl4.X, p4.Y, 0), new Point3d(pl4.X, px3.Y, 0), new Point3d(pl4.X, px1.Y, 0), new Point3d(pl4.X, p1.Y, 0), pl1 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
            dsY = new List<Point3d> { new Point3d(pl4.X, p4.Y, 0), new Point3d(pl4.X, p1.Y, 0) };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 2);
            dsY = new List<Point3d> { p13, p16 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 0.5);
            dsY = new List<Point3d> { p37, p38 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 0.5);
            dsY = new List<Point3d> { p29, p30 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 0.5);
            dsY = new List<Point3d> { pd8, new Point3d(pd8.X, pd4.Y, 0), new Point3d(pd8.X, pd1.Y, 0), pd5 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 0.5);
            #endregion
            #region Ghi chú tên mặt cắt
            ClKiHieu.TenMatCat(new Point3d(pointMain.X, pointMain.Y - chieuDai / 2 - 2 * 1000 * layoutMongBanModel.Selected_Scale_Layout * 0.01, 0), "SƠ ĐỒ TOÀN THỂ MÓNG",
                layoutMongBanModel.Selected_Scale_Layout, Autodesk.AutoCAD.DatabaseServices.TextHorizontalMode.TextCenter, 0);
            #endregion
            #region Chèn Section
            Point3d pmc1 = new Point3d(px3.X - 2200 * 0.01 * layoutMongBanModel.Selected_Scale_Layout, px3.Y, 0);
            Point3d pmc2 = new Point3d(px4.X + 800 * 0.01 * layoutMongBanModel.Selected_Scale_Layout, px3.Y, 0);
            ClKiHieu.KiHieuMatCat(pmc1, pmc2, "A", layoutMongBanModel.Selected_Scale_Layout);
            #endregion
            #region Points Layout
            PointsLayout.MinMatBang = new Point3d(p4.X - 2530 * SelectedScale * 0.01, p3.Y - 2660 * SelectedScale * 0.01, 0);
            PointsLayout.MaxMatBang = new Point3d(p2.X + 1200 * SelectedScale * 0.01, p2.Y + (HaveDoiTrong ? 1000 : 500) * SelectedScale * 0.01, 0);
            ClCAD.SetLayerCurrent("NETHIDDEN");
            ClCAD.VeHinhChuNhat(PointsLayout.MinMatBang, PointsLayout.MaxMatBang);
            #endregion
            #region Chèn hướng tuyến, tim móng
            ClKiHieu.TrucMong_MB(pointMain, chieuDai, SelectedScale, huongTuyen, gocLai);
            #endregion
            #region Hatch đối trọng
            if (HaveDoiTrong)
            {
                Point3d pTr1 = new Point3d(pointMain.X, p35.Y, 0);
                Point3d pTr2 = new Point3d(pointMain.X, p33.Y, 0);
                Point3d pTr3 = new Point3d(pointMain.X, p28.Y, 0);
                Point3d pTr4 = new Point3d(pointMain.X, pd5.Y, 0);
                Point3d pTr5 = new Point3d(pointMain.X, pd8.Y, 0);
                Point3d pTr6 = new Point3d(pointMain.X, p25.Y, 0);
                Point3d pTr7 = new Point3d(pointMain.X, p21.Y, 0);
                Point3d pTr8 = new Point3d(pointMain.X, p19.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "ANSI31";
                double douHatch = 2500;
                double s1 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p1, p5, p6, p7, p8, p1 }, nameHatch, douHatch);
                double s2 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p35, p34, p33, pTr2, pTr1, p35 }, nameHatch, douHatch);
                double s3 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { pTr4, pTr3, p28, p27, p26, p25, pTr6, pTr5, pd8, pd5, pTr4 }, nameHatch, douHatch); ;
                double s4 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p19, pTr8, pTr7, p21, p20, p19 }, nameHatch, douHatch);
                double s5 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p4, p15, p16, p17, p18, p4 }, nameHatch, douHatch);
                double s6 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p9, p10, p11, p12, p13, p14, p9 }, nameHatch, douHatch);
                InforMongBan.DienTichDoiTrong = Math.Pow(10, -6) * (s1 + s2 + s3 + s4 + s5 + s6);
                Point3d pIn1 = new Point3d(p8.X - 300 * SelectedScale * 0.01, p8.Y - 750 * SelectedScale * 0.01, 0);
                Point3d pIn2 = new Point3d(pIn1.X, p8.Y + 550 * SelectedScale * 0.01, 0);
                ClKiHieu.GhiChuDoiTrong(pIn1, pIn2, SelectedScale, h_doitrong);
            }
            #endregion
        }
        public static void DrawMatBangMongLechTam(Point3d pointMain, ThongSoMongBan thongSoMongBan,
            LayoutMongBanModel layoutMongBanModel, bool haveDoiTrong, double kcMepDamCot, double lechTamCoTop)
        {
            #region Variable
            double chieuDai = thongSoMongBan.ChieuDaiMong;
            double chieuRong = thongSoMongBan.ChieuRongMong;
            double rongCM_Top = thongSoMongBan.RongCoMong_Top;
            double rongCM_Bot = thongSoMongBan.RongCoMong_Bot;
            double timMong = thongSoMongBan.TimMong;
            double ducLo = thongSoMongBan.DucLoMong;
            double dBTL = 100;
            double chieuRongDam = thongSoMongBan.ChieuRongDam;
            double SelectedScale = layoutMongBanModel.Selected_Scale_Layout;
            double doanXienDam = InforMongBan.DoanXienDam;
            //MessageBox.Show(doanXienDam.ToString());
            string huongTuyen = layoutMongBanModel.SelectedHuongTuyen;
            string gocLai = layoutMongBanModel.SelectedGocLai;
            double h_doitrong = thongSoMongBan.ChieuCaoDoiTrong;
            #endregion
            #region Point
            Point3d p1 = new Point3d(pointMain.X - chieuRong / 2, pointMain.Y + chieuDai / 2, 0);
            Point3d p2 = new Point3d(p1.X + chieuRong, p1.Y, 0);
            Point3d p3 = new Point3d(p2.X, p2.Y - chieuDai, 0);
            Point3d p4 = new Point3d(p1.X, p3.Y, 0);
            Point3d pC1 = new Point3d(pointMain.X - timMong / 2, pointMain.Y + timMong / 2, 0);
            Point3d pC2 = new Point3d(pC1.X + timMong, pC1.Y, 0);
            Point3d pC3 = new Point3d(pC2.X, pC2.Y - timMong, 0);
            Point3d pC4 = new Point3d(pC1.X, pC3.Y, 0);
            Point3d pl1 = new Point3d(p1.X - dBTL, p1.Y + dBTL, 0);
            Point3d pl2 = new Point3d(p2.X + dBTL, p2.Y + dBTL, 0);
            Point3d pl3 = new Point3d(p3.X + dBTL, p3.Y - dBTL, 0);
            Point3d pl4 = new Point3d(pl1.X, pl3.Y, 0);
            Point3d py1 = new Point3d(pC1.X - chieuRongDam / 2, p1.Y, 0);
            Point3d py2 = new Point3d(pC1.X - chieuRongDam / 2, p3.Y, 0);
            Point3d py3 = new Point3d(pC2.X + chieuRongDam / 2, p1.Y, 0);
            Point3d py4 = new Point3d(pC2.X + chieuRongDam / 2, p3.Y, 0);
            Point3d px1 = new Point3d(p1.X, pC1.Y + chieuRongDam / 2, 0);
            Point3d px2 = new Point3d(p2.X, pC1.Y + chieuRongDam / 2, 0);
            Point3d px3 = new Point3d(p1.X, pC4.Y - chieuRongDam / 2, 0);
            Point3d px4 = new Point3d(p2.X, pC3.Y - chieuRongDam / 2, 0);
            Point3d pd1 = new Point3d(pointMain.X - ducLo / 2 + dBTL, pointMain.Y + ducLo / 2 - dBTL, 0);
            Point3d pd2 = new Point3d(pointMain.X + ducLo / 2 - dBTL, pointMain.Y + ducLo / 2 - dBTL, 0);
            Point3d pd3 = new Point3d(pd2.X, pointMain.Y - ducLo / 2 + dBTL, 0);
            Point3d pd4 = new Point3d(pd1.X, pd3.Y, 0);
            Point3d pd5 = new Point3d(pd1.X - dBTL, pd1.Y + dBTL, 0);
            Point3d pd6 = new Point3d(pd2.X + dBTL, pd2.Y + dBTL, 0);
            Point3d pd7 = new Point3d(pd3.X + dBTL, pd3.Y - dBTL, 0);
            Point3d pd8 = new Point3d(pd5.X, pd7.Y, 0);

            Point3d p5 = new Point3d(pC1.X + rongCM_Top / 2 + lechTamCoTop, pC1.Y - rongCM_Top / 2 - lechTamCoTop, 0);
            Point3d p6 = new Point3d(p5.X, p5.Y + rongCM_Bot, 0);

            Point3d p7 = new Point3d(p6.X - rongCM_Bot, p6.Y, 0);
            Point3d p8 = new Point3d(p7.X, p5.Y, 0);





            Point3d p13 = new Point3d(p5.X - rongCM_Top, p5.Y + rongCM_Top, 0);
            Point3d p13a = new Point3d(p5.X, p13.Y, 0);
            Point3d p13b = new Point3d(p13.X, p5.Y, 0);
            Point3d p13c = new Point3d(px1.X, p8.Y + kcMepDamCot, 0);

            Point3d p9 = new Point3d(px1.X, p13c.Y + chieuRongDam, 0);
            Point3d p10 = new Point3d(p7.X, p9.Y, 0);

            Point3d p14 = new Point3d(p10.X, p13c.Y, 0);
            Point3d p15 = new Point3d(p14.X + doanXienDam, p14.Y, 0);

            Point3d p16 = new Point3d(p15.X, p10.Y, 0);

            Point3d p6a = new Point3d(p6.X - kcMepDamCot, p6.Y, 0);
            Point3d p18 = new Point3d(p6.X - kcMepDamCot, p6a.Y - doanXienDam, 0);
            Point3d p19 = new Point3d(p18.X, py1.Y, 0);
            Point3d p11 = new Point3d(p19.X - chieuRongDam, p7.Y, 0);
            Point3d p12 = new Point3d(p11.X, p1.Y, 0);
            Point3d p17 = new Point3d(p11.X, p11.Y - doanXienDam, 0);


            Point3d p32 = new Point3d(p5.X, pC4.Y + rongCM_Top / 2 + lechTamCoTop, 0);
            Point3d p33 = new Point3d(p6a.X, p32.Y, 0);
            Point3d p34 = new Point3d(p33.X - chieuRongDam, p33.Y, 0);
            Point3d p35 = new Point3d(p32.X - rongCM_Bot, p32.Y, 0);
            Point3d p30 = new Point3d(p32.X, p32.Y - rongCM_Bot, 0);

            Point3d p20 = new Point3d(px3.X, p35.Y - kcMepDamCot, 0);
            Point3d p21 = new Point3d(p14.X, p20.Y, 0);
            Point3d p22 = new Point3d(p15.X, p21.Y, 0);
            Point3d p23 = new Point3d(p22.X, p22.Y - chieuRongDam, 0);
            Point3d p24 = new Point3d(p21.X, p23.Y, 0);
            Point3d p25 = new Point3d(p20.X, p24.Y, 0);




            Point3d p26 = new Point3d(p35.X, p30.Y, 0);

            Point3d p29 = new Point3d(p32.X - kcMepDamCot, p30.Y + doanXienDam, 0);
            Point3d p30a = new Point3d(p29.X, p30.Y, 0);
            Point3d p28a = new Point3d(p29.X - chieuRongDam, p4.Y, 0);
            Point3d p27 = new Point3d(p29.X - chieuRongDam, p26.Y, 0);
            Point3d p28 = new Point3d(p27.X, p29.Y, 0);

            Point3d p29a = new Point3d(p29.X, p4.Y, 0);
            Point3d p36 = new Point3d(p13.X, p33.Y, 0);
            Point3d p37 = new Point3d(p36.X, p36.Y - rongCM_Top, 0);
            Point3d p38 = new Point3d(p33.X, p5.Y, 0);
            Point3d p38a = new Point3d(p34.X, p5.Y, 0);
            Point3d p31 = new Point3d(p32.X, p37.Y, 0);
            Point3d p39 = new Point3d(p31.X, p20.Y, 0);
            Point3d p40 = new Point3d(p39.X, p39.Y - chieuRongDam, 0);
            Point3d p41 = new Point3d(pC3.X - rongCM_Top / 2 - lechTamCoTop, p40.Y, 0);
            Point3d p42 = new Point3d(p41.X, p39.Y, 0);
            Point3d p43 = new Point3d(pC3.X - rongCM_Top / 2 - lechTamCoTop, pC3.Y + rongCM_Top / 2 + lechTamCoTop, 0);
            Point3d p44 = new Point3d(p43.X + kcMepDamCot, p43.Y, 0);
            Point3d p45 = new Point3d(p43.X + rongCM_Top, p43.Y, 0);
            Point3d p46 = new Point3d(p44.X + chieuRongDam, p44.Y, 0);
            Point3d p47 = new Point3d(p43.X + rongCM_Bot, p44.Y, 0);
            Point3d p48 = new Point3d(p47.X, p47.Y - kcMepDamCot, 0);
            Point3d p49 = new Point3d(p48.X - doanXienDam, p48.Y, 0);
            Point3d p50 = new Point3d(p49.X, p49.Y - chieuRongDam, 0);
            Point3d p51 = new Point3d(p48.X, p48.Y - chieuRongDam, 0);
            Point3d p52 = new Point3d(p51.X, p47.Y - rongCM_Bot, 0);

            Point3d p55 = new Point3d(p43.X + kcMepDamCot, p52.Y + doanXienDam, 0);
            Point3d p56 = new Point3d(p55.X, p52.Y, 0);
            Point3d p56a = new Point3d(p56.X, p3.Y, 0);

            Point3d p53 = new Point3d(p55.X + chieuRongDam, p52.Y, 0);
            Point3d p53a = new Point3d(p53.X, p3.Y, 0);
            Point3d p54 = new Point3d(p53.X, p53.Y + doanXienDam, 0);

            Point3d p57 = new Point3d(p41.X, p56.Y, 0);
            Point3d p58 = new Point3d(p43.X, p43.Y - rongCM_Top, 0);
            Point3d p59 = new Point3d(p45.X, p58.Y, 0);
            Point3d p60 = new Point3d(p2.X, p48.Y, 0);
            Point3d p61 = new Point3d(p60.X, p51.Y, 0);
            Point3d p62 = new Point3d(p44.X, pC2.Y - rongCM_Top / 2 - lechTamCoTop, 0);
            Point3d p63 = new Point3d(p45.X, p62.Y, 0);
            Point3d p64 = new Point3d(p46.X, p62.Y, 0);
            Point3d p65 = new Point3d(p47.X, p64.Y, 0);

            Point3d p66 = new Point3d(p65.X, p5.Y + kcMepDamCot, 0);
            Point3d p67 = new Point3d(p49.X, p66.Y, 0);
            Point3d p68 = new Point3d(p67.X, p67.Y + chieuRongDam, 0);
            Point3d p69 = new Point3d(p65.X, p68.Y, 0);
            Point3d p70 = new Point3d(px2.X, p69.Y, 0);
            Point3d p71 = new Point3d(p70.X, p70.Y - chieuRongDam, 0);

            Point3d p72 = new Point3d(p69.X, p65.Y + rongCM_Bot, 0);


            Point3d p75 = new Point3d(p43.X + kcMepDamCot, p17.Y, 0);
            Point3d p76 = new Point3d(p43.X + kcMepDamCot, p11.Y, 0);

            Point3d p73 = new Point3d(p75.X + chieuRongDam, p72.Y, 0);
            Point3d p74 = new Point3d(p73.X, p73.Y - doanXienDam, 0);

            Point3d p77 = new Point3d(p43.X, p6.Y, 0);
            Point3d p78 = new Point3d(p77.X, p10.Y, 0);
            Point3d p79 = new Point3d(p78.X, pC2.Y + rongCM_Top / 2 - lechTamCoTop, 0);
            Point3d p80 = new Point3d(p78.X, p78.Y - chieuRongDam, 0);
            Point3d p81 = new Point3d(p80.X, p62.Y, 0);
            Point3d p82 = new Point3d(p63.X, p79.Y, 0);
            Point3d p83 = new Point3d(p5.X, p78.Y, 0);
            Point3d p84 = new Point3d(p5.X, p80.Y, 0);
            Point3d p85 = new Point3d(p76.X, py3.Y, 0);
            Point3d p86 = new Point3d(p73.X, py3.Y, 0);
            #endregion
            #region Vẽ polyline
            ClCAD.SetLayerCurrent("DUONGTRUC");
            Point3d pt1 = new Point3d(pointMain.X - timMong / 2, p12.Y, 0);
            Point3d pt2 = new Point3d(pt1.X, p28a.Y, 0);
            Point3d pt3 = new Point3d(pointMain.X + timMong / 2, p12.Y, 0);
            Point3d pt4 = new Point3d(pt3.X, p28a.Y, 0);

            Point3d pt5 = new Point3d(p4.X, pointMain.Y - timMong / 2, 0);
            Point3d pt6 = new Point3d(p3.X, pt5.Y, 0);
            Point3d pt7 = new Point3d(p4.X, pointMain.Y + timMong / 2, 0);
            Point3d pt8 = new Point3d(p3.X, pt7.Y, 0);

            ClCAD.CreateLine(pt1, pt2);
            ClCAD.CreateLine(pt3, pt4);
            ClCAD.CreateLine(pt5, pt6);
            ClCAD.CreateLine(pt7, pt8);

            ClCAD.SetLayerCurrent("NETPHU");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pl1, pl2, pl3, pl4 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pd1, pd2, pd3, pd4 }, true);
            ClCAD.SetLayerCurrent("NETCHINH");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { pd5, pd6, pd7, pd8 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3, p4 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p9, p16, p15, p13c }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p12, p17, p18, p19 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p13b, p13, p13a, p5 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p14, p8, p5, p6, p6a }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p10, p7, p11 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p7, p13 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p20, p22, p23, p25 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p28, p28a, p29a, p29 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p31, p32, p36, p37 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p21, p35, p32, p30, p30a }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p24, p26, p27 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p26, p37 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p55, p54, p53a, p56a }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p49, p50, p61, p60 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p56, p57, p43, p47, p48 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p43, p58, p59, p45 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p51, p52, p53 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p59, p52 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p85, p75, p74, p86 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p68, p67, p71, p70 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p79, p82, p63, p81 }, true);

            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p76, p77, p81, p65, p66 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p69, p72, p73 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p82, p72 }, false);

            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p83, p84, p80, p78 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p38a, p38, p33, p34 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p39, p40, p41, p42 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p62, p64, p46, p44 }, true);
            #endregion
            #region Dim
            ClCAD.SetLayerCurrent("NETDIM");
            string strScale = string.Format("TL1-{0}", SelectedScale.ToString());
            ClCAD.SetDimStyleCurrent(strScale);
            List<Point3d> dsX = new List<Point3d>() { pl4, new Point3d(p4.X, pl4.Y, 0), new Point3d(pt1.X, pl4.Y, 0),
                new Point3d(p29a.X, pl4.Y, 0), new Point3d(p56a.X, pl4.Y, 0),new Point3d(pt3.X, pl4.Y, 0), new Point3d(p3.X, pl4.Y, 0), pl3 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 1);
            dsX = new List<Point3d>() { new Point3d(p4.X, pl4.Y, 0), new Point3d(p3.X, pl4.Y, 0) };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 2);

            dsX = new List<Point3d>() { p35, p32 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, -0.5);
            dsX = new List<Point3d>() { p38, p38a };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
            dsX = new List<Point3d>() { p81, p63 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.6);

            dsX = new List<Point3d> { p57, p56 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
            dsX = new List<Point3d> { p53, p52 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);

            dsX = new List<Point3d> { pd5, new Point3d(pd4.X, pd5.Y, 0), new Point3d(pd3.X, pd5.Y, 0), pd6 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, -0.5);


            List<Point3d> dsY = new List<Point3d> { pl4, new Point3d(pl4.X, p4.Y, 0), new Point3d(pl4.X, pt5.Y, 0),
                new Point3d(pl4.X, p20.Y, 0), new Point3d(pl4.X, p13c.Y, 0),new Point3d(pl4.X, pt7.Y, 0), new Point3d(pl4.X, p1.Y, 0), pl1 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
            dsY = new List<Point3d> { new Point3d(pl4.X, p4.Y, 0), new Point3d(pl4.X, p1.Y, 0) };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 2);
            dsY = new List<Point3d> { p10, p14 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 0.5);
            dsY = new List<Point3d> { p30, p32 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, -0.5);

            dsY = new List<Point3d> { p79, p81 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 0.5);
            dsY = new List<Point3d> { p52, p51 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, -0.5);
            dsY = new List<Point3d> { p48, p47 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, -0.5);

            dsY = new List<Point3d> { pd8, new Point3d(pd8.X, pd4.Y, 0), new Point3d(pd8.X, pd1.Y, 0), pd5 };
            ClCAD.CreateDimension_Y2(dsY, SelectedScale, 0.5);
            #endregion
            #region Ghi chú tên mặt cắt
            ClKiHieu.TenMatCat(new Point3d(pointMain.X, pointMain.Y - chieuDai / 2 - 2 * 1000 * layoutMongBanModel.Selected_Scale_Layout * 0.01, 0), "SƠ ĐỒ TOÀN THỂ MÓNG",
                layoutMongBanModel.Selected_Scale_Layout, Autodesk.AutoCAD.DatabaseServices.TextHorizontalMode.TextCenter, 0);
            #endregion
            #region Chèn Section
            Point3d pmc1 = new Point3d(px3.X - 2200 * 0.01 * layoutMongBanModel.Selected_Scale_Layout, px3.Y, 0);
            Point3d pmc2 = new Point3d(px4.X + 800 * 0.01 * layoutMongBanModel.Selected_Scale_Layout, px3.Y, 0);
            ClKiHieu.KiHieuMatCat(pmc1, pmc2, "A", layoutMongBanModel.Selected_Scale_Layout);
            #endregion
            #region Points Layout
            PointsLayout.MinMatBang = new Point3d(p4.X - 2530 * SelectedScale * 0.01, p3.Y - 2660 * SelectedScale * 0.01, 0);
            PointsLayout.MaxMatBang = new Point3d(p2.X + 1200 * SelectedScale * 0.01, p2.Y + (haveDoiTrong ? 1000 : 500) * SelectedScale * 0.01, 0);
            ClCAD.SetLayerCurrent("NETHIDDEN");
            ClCAD.VeHinhChuNhat(PointsLayout.MinMatBang, PointsLayout.MaxMatBang);
            #endregion
            #region Chèn hướng tuyến, tim móng
            ClKiHieu.TrucMong_MB(pointMain, chieuDai, SelectedScale, huongTuyen, gocLai);
            #endregion
            #region Hatch đối trọng
            if (haveDoiTrong)
            {
                Point3d pTr1 = new Point3d(pointMain.X, p19.Y, 0);
                Point3d pTr2 = new Point3d(pointMain.X, p83.Y, 0);
                Point3d pTr3 = new Point3d(pointMain.X, p84.Y, 0);
                Point3d pTr4 = new Point3d(pointMain.X, pd5.Y, 0);
                Point3d pTr5 = new Point3d(pointMain.X, pd8.Y, 0);
                Point3d pTr6 = new Point3d(pointMain.X, p39.Y, 0);
                Point3d pTr7 = new Point3d(pointMain.X, p40.Y, 0);
                Point3d pTr8 = new Point3d(pointMain.X, p29a.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "ANSI31";
                double douHatch = 2500;
                double s1 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p1, p9, p10, p7, p11, p12, p1 }, nameHatch, douHatch);
                double s2 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p19, p6a, p6, p83, pTr2, pTr1, p19 }, nameHatch, douHatch);
                double s3 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { pTr4, pTr3, p84, p5, p38, p33, p32, p39, pTr6, pTr5, pd8, pd5, pTr4 }, nameHatch, douHatch); ;
                double s4 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p29a, pTr8, pTr7, p40, p30, p30a, p29a }, nameHatch, douHatch);
                double s5 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p28a, p27, p26, p24, p25, p4, p28a }, nameHatch, douHatch);
                double s6 = ClCAD.CreateHatchFromListPointP(new List<Point3d> { p20, p21, p35, p34, p38a, p8, p14, p13c, p20 }, nameHatch, douHatch);
                Point3d pIn1 = new Point3d(p12.X - 300 * SelectedScale * 0.01, p12.Y - 750 * SelectedScale * 0.01, 0);
                Point3d pIn2 = new Point3d(pIn1.X, p12.Y + 550 * SelectedScale * 0.01, 0);
                ClKiHieu.GhiChuDoiTrong(pIn1, pIn2, SelectedScale, h_doitrong);
                InforMongBan.DienTichDoiTrong = Math.Pow(10, -6) * (s1 + s2 + s3 + s4 + s5 + s6);

            }
            #endregion

        }
        public static void DrawMatDung_MongDungTam(Point3d pointMain, ThongSoMongBan thongSoMongBan, LayoutMongBanModel layoutMongBanModel,
            bool haveDoiTrong, double heSoMai, bool HaveThangLeo, int soThanCot, double HDapMax)
        {
            #region Variable
            double chieuRong = thongSoMongBan.ChieuRongMong;
            double chieuDai = thongSoMongBan.ChieuDaiMong;
            double rongCM_Top = thongSoMongBan.RongCoMong_Top;
            double rongCM_Bot = thongSoMongBan.RongCoMong_Bot;
            double timMong = thongSoMongBan.TimMong;
            double ducLo = thongSoMongBan.DucLoMong;
            double dBTL = 100;
            double chieuRongDam = thongSoMongBan.ChieuRongDam;
            double SelectedScale = layoutMongBanModel.Selected_Scale_Layout;
            double doanXienDam = chieuRongDam / 3;
            double chieuCaoBan = thongSoMongBan.ChieuCaoBan;
            double chieuSauChonMong = thongSoMongBan.ChieuSauChonMong;
            double chieuCaoCM = thongSoMongBan.ChieuCaoCoMong;
            double chieucaoDam = thongSoMongBan.ChieuCaoDam;
            double doanVat = rongCM_Top / 2;
            double h_doitrong = thongSoMongBan.ChieuCaoDoiTrong;
            double chieuDayDC = thongSoMongBan.H_DemCat;
            #endregion
            #region Point
            Point3d ptr1 = new Point3d(pointMain.X - timMong / 2, pointMain.Y + chieuSauChonMong + chieuCaoCM, 0);
            Point3d ptr2 = new Point3d(pointMain.X - timMong / 2, pointMain.Y - 300, 0);
            Point3d ptr3 = new Point3d(pointMain.X + timMong / 2, pointMain.Y + chieuSauChonMong + chieuCaoCM, 0);
            Point3d ptr4 = new Point3d(pointMain.X + timMong / 2, pointMain.Y - 300, 0);
            Point3d p1 = new Point3d(pointMain.X - chieuRong / 2, pointMain.Y, 0);
            Point3d p2 = new Point3d(p1.X, p1.Y + chieuCaoBan, 0);
            Point3d p3 = new Point3d(p2.X, p1.Y + chieucaoDam, 0);
            Point3d p6 = new Point3d(ptr1.X - chieuRongDam / 2, p3.Y, 0);
            Point3d p7 = new Point3d(p6.X, p6.Y - chieucaoDam + chieuCaoBan, 0);
            Point3d p8 = new Point3d(p7.X - doanVat, p7.Y, 0);
            Point3d p5 = new Point3d(ptr1.X - rongCM_Top / 2, p6.Y, 0);
            Point3d p4 = new Point3d(p8.X, p5.Y, 0);
            Point3d p9 = new Point3d(p5.X, ptr1.Y, 0);
            Point3d p10 = new Point3d(ptr1.X + rongCM_Top / 2, p9.Y, 0);
            Point3d p11 = new Point3d(p6.X + chieuRongDam, p6.Y, 0);
            Point3d p12 = new Point3d(p10.X, p4.Y, 0);
            Point3d p13 = new Point3d(p12.X + doanVat, p12.Y, 0);
            Point3d p14 = new Point3d(p13.X, p8.Y, 0);
            Point3d p15 = new Point3d(p11.X, p14.Y, 0);
            Point3d p16 = new Point3d(pointMain.X - ducLo / 2, p14.Y, 0);
            Point3d p17 = new Point3d(p16.X, p1.Y, 0);
            Point3d p18 = new Point3d(p17.X + dBTL, p17.Y, 0);
            Point3d p19 = new Point3d(p18.X, p18.Y - dBTL, 0);
            Point3d p20 = new Point3d(p1.X - dBTL, p19.Y, 0);
            Point3d p21 = new Point3d(p20.X, p1.Y, 0);
            Point3d p22 = new Point3d(pointMain.X + ducLo / 2, p16.Y, 0);
            Point3d p23 = new Point3d(p22.X, p18.Y, 0);
            Point3d p24 = new Point3d(p23.X - dBTL, p23.Y, 0);
            Point3d p25 = new Point3d(p24.X, p19.Y, 0);
            Point3d p36 = new Point3d(ptr3.X - chieuRongDam / 2, p22.Y, 0);
            Point3d p37 = new Point3d(p36.X - doanVat, p36.Y, 0);
            Point3d p38 = new Point3d(p37.X, p13.Y, 0);
            Point3d p39 = new Point3d(ptr3.X - rongCM_Top / 2, p38.Y, 0);
            Point3d p40 = new Point3d(p36.X, p39.Y, 0);
            Point3d p41 = new Point3d(p39.X, p10.Y, 0);
            Point3d p42 = new Point3d(p41.X + rongCM_Top, p41.Y, 0);
            Point3d p35 = new Point3d(p40.X + chieuRongDam, p40.Y, 0);
            Point3d p34 = new Point3d(p42.X, p35.Y, 0);
            Point3d p32 = new Point3d(p35.X + doanVat, p34.Y, 0);
            Point3d p31 = new Point3d(p32.X, p36.Y, 0);
            Point3d p33 = new Point3d(p35.X, p31.Y, 0);
            Point3d p30 = new Point3d(pointMain.X + chieuRong / 2, p32.Y, 0);
            Point3d p29 = new Point3d(p30.X, p31.Y, 0);
            Point3d p28 = new Point3d(p29.X, p1.Y, 0);
            Point3d p27 = new Point3d(p28.X + dBTL, p28.Y, 0);
            Point3d p26 = new Point3d(p27.X, p27.Y - dBTL, 0);
            // point đào đắp           
            #endregion
            #region Vẽ Polyline
            ClCAD.SetLayerCurrent("DUONGTRUC");
            ClCAD.CreateLine(ptr1, ptr2);
            ClCAD.CreateLine(ptr3, ptr4);
            ClCAD.SetLayerCurrent("NETPHU");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p21, p20, p19, p18, p17 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p18, p19, p25, p24 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p23, p24, p25, p26, p27, p28 }, true);
            ClCAD.SetLayerCurrent("NETCHINH");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p7, p6, p11, p15, p16, p17 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p23, p22, p36, p40, p35, p33, p29, p28 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p16, p17, p23, p22 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, p3, p6, p7 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p11, p15, p36, p40 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p33, p35, p30, p29 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p5, p9, p10, p12 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p39, p41, p42, p34 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p4, p8 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p13, p14 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p37, p38 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p31, p32 }, false);
            #endregion
            #region Dim
            ClCAD.SetLayerCurrent("NETDIM");
            string strScale = string.Format("TL1-{0}", SelectedScale.ToString());
            ClCAD.SetDimStyleCurrent(strScale);
            List<Point3d> dsX = new List<Point3d>() { new Point3d(p3.X, ptr1.Y, 0), ptr1, ptr3, new Point3d(p30.X, ptr3.Y, 0) };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, -1);

            #endregion
            #region Đệm cát
            Point3d pdc1 = new Point3d();
            Point3d pdc4 = new Point3d();
            Point3d pdc2, pdc3, pd1, pd2, pd3, pd4, pd5, pd6, ps1, ps2;
            double moRongR = MoRongHoDao(chieuDayDC);
            InforMongBan.MoRongDay = moRongR;
            if (chieuDayDC != 0)
            {
                pdc1 = new Point3d(p1.X - moRongR, p20.Y - chieuDayDC, 0);
                pdc2 = new Point3d(pdc1.X - heSoMai * chieuDayDC, p20.Y, 0);
                pdc4 = new Point3d(p28.X + moRongR, pdc1.Y, 0);
                pdc3 = new Point3d(pdc4.X + heSoMai * chieuDayDC, p26.Y, 0);
                pd1 = new Point3d(pdc2.X - heSoMai * (chieuSauChonMong + dBTL), p1.Y + chieuSauChonMong, 0);
                pd2 = new Point3d(p5.X, pd1.Y, 0);
                pd3 = new Point3d(p10.X, pd2.Y, 0);
                pd4 = new Point3d(p41.X, pd2.Y, 0);
                pd5 = new Point3d(p42.X, pd2.Y, 0);
                pd6 = new Point3d(pdc3.X + heSoMai * (chieuSauChonMong + dBTL), pd2.Y, 0);
                ps1 = new Point3d(pd1.X - 300, pd1.Y, 0);
                ps2 = new Point3d(pd6.X + 300, pd1.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "AR-SAND";
                double douHatch = layoutMongBanModel.HacthScale;
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pdc1, pdc2, pdc3, pdc4 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { p20, pdc2, pd1, pd2, p5, p3, p1, p21, p20 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd3, p12, p39, pd4 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd5, pd6, pdc3, p26, p27, p28, p30, p34, pd5 }, nameHatch, douHatch);
                ClCAD.SetLayerCurrent("NETPHU");
                ClCAD.CreateLine(ps1, pd2);
                ClCAD.CreateLine(ps2, pd5);
                ClCAD.CreateLine(pd3, pd4);
                List<Point3d> dsY = new List<Point3d>() { new Point3d(pdc2.X, pdc1.Y, 0), pdc2 };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d>() { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p2.Y, 0), new Point3d(pd1.X, p3.Y, 0), pd1, new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { p20, p21 };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 2);

                dsX = new List<Point3d> { pdc1, new Point3d(p1.X, pdc1.Y, 0), new Point3d(p28.X, pdc1.Y, 0), pdc4 };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 1);

                // vẽ nét vải địa
                ClCAD.SetLayerCurrent("NETVAIDIA");
                Polyline plRongVaiDia = ClCAD.CreatePolylineFromListPoints(new List<Point3d> { new Point3d(p1.X + 500, p20.Y, 0), pdc2, pdc1, pdc4, pdc3, new Point3d(p28.X - 500, p26.Y, 0) }, false);
                InforMongBan.ChieuRongVaiDia = Math.Round(plRongVaiDia.Length, 2) * Math.Pow(10, -3);
                InforMongBan.ChieuDaiVaiDia = Math.Round(plRongVaiDia.Length, 2) * Math.Pow(10, -3) - (chieuRong - chieuDai) * Math.Pow(10, -3);
                dsX = new List<Point3d> { new Point3d(p1.X + 500, p20.Y, 0), p1 };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
                dsX = new List<Point3d> { p28, new Point3d(p28.X - 500, p26.Y, 0) };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
            }
            else
            {
                pdc2 = new Point3d(p1.X - 300, p20.Y, 0);
                pdc3 = new Point3d(p28.X + 300, p20.Y, 0);
                pd1 = new Point3d(pdc2.X - heSoMai * (chieuSauChonMong + dBTL), p1.Y + chieuSauChonMong, 0);
                pd2 = new Point3d(p5.X, pd1.Y, 0);
                pd3 = new Point3d(p10.X, pd2.Y, 0);
                pd4 = new Point3d(p41.X, pd2.Y, 0);
                pd5 = new Point3d(p42.X, pd2.Y, 0);
                pd6 = new Point3d(pdc3.X + heSoMai * (chieuSauChonMong + dBTL), pd2.Y, 0);
                ps1 = new Point3d(pd1.X - 300, pd1.Y, 0);
                ps2 = new Point3d(pd6.X + 300, pd1.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "AR-SAND";
                double douHatch = layoutMongBanModel.HacthScale;
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { p20, pdc2, pd1, pd2, p5, p3, p1, p21, p20 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd3, p12, p39, pd4 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd5, pd6, pdc3, p26, p27, p28, p30, p34, pd5 }, nameHatch, douHatch);
                ClCAD.SetLayerCurrent("NETPHU");
                ClCAD.CreateLine(ps1, pd2);
                ClCAD.CreateLine(ps2, pd5);
                ClCAD.CreateLine(pd3, pd4);

                List<Point3d> dsY = new List<Point3d>();
                dsY = new List<Point3d>() { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p2.Y, 0), new Point3d(pd1.X, p3.Y, 0), pd1, new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { p20, p21 };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 2);

                dsX = new List<Point3d> { pdc2, new Point3d(p1.X, pdc2.Y, 0), new Point3d(p28.X, pdc2.Y, 0), pdc3 };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 1);
            }

            #endregion
            #region Chèn cao độ
            ClCAD.SetLayerCurrent("NETPHU");
            string caodo1 = "+" + (chieuCaoCM / 1000).ToString("0.0") + "m";
            string caodo2 = "-" + (chieuSauChonMong / 1000).ToString("0.0") + "m";
            string caodo3 = "-" + (chieuSauChonMong / 1000 + dBTL / 1000 + chieuDayDC / 1000).ToString("0.0") + "m";
            Point3d pcd1 = new Point3d(ps2.X + 100, ps2.Y, 0);
            Point3d pcd2 = new Point3d(ps2.X + 100, p42.Y, 0);
            Point3d pcd3 = new Point3d(ps2.X + 100, p27.Y, 0);
            Point3d pcd4 = new Point3d(pdc3.X + 400, p27.Y - dBTL - chieuDayDC, 0);
            ClKiHieu.KihieuCaoDo(pcd1, "± 0.0 m", 1, SelectedScale);
            ClKiHieu.KihieuCaoDo(pcd2, caodo1, 1, SelectedScale);
            ClKiHieu.KihieuCaoDo(pcd3, caodo2, 1, SelectedScale);
            if (chieuDayDC != 0) ClKiHieu.KihieuCaoDo(pcd4, caodo3, 1, SelectedScale);
            #endregion
            #region Chèn ghi chú đất đắp
            Point3d pdatdap = new Point3d(pd5.X + 500 * SelectedScale * 0.01, pd5.Y, 0);
            ClKiHieu.GhiChuDatDap(pdatdap, SelectedScale);
            #endregion
            #region Ghi chú đệm cát, vải địa
            if (chieuDayDC != 0)
            {
                double moRongDinh = pdc2.DistanceTo(new Point3d(p1.X, p20.Y, 0));
                InforMongBan.MoRongDinh = moRongDinh;
                double doanXien = pdc1.DistanceTo(pdc2);
                double V_DC = Math.Round(TinhKhoiLuongMongBan.TinhKhoiLuongDemCat(moRongDinh, moRongR, chieuDai, chieuRong, chieuDayDC), 2);
                double S_VD = Math.Round(InforMongBan.ChieuRongVaiDia * InforMongBan.ChieuDaiVaiDia, 2);
                Point3d pVaidia = new Point3d(ptr2.X, pdc1.Y, 0);
                Point3d pDemCat = new Point3d(p22.X + 1000 * SelectedScale * 0.01, pdc1.Y, 0);
                ClKiHieu.GhiChuVaiDia(pVaidia, SelectedScale, S_VD, soThanCot);
                ClKiHieu.GhiChuCatDem(pDemCat, SelectedScale, V_DC, soThanCot);
                InforMongBan.V_DemCat = V_DC;
            }
            #endregion
            #region Ghi chú tên mặt cắt
            bool checkDC = chieuDayDC != 0;
            ClKiHieu.TenMatCat(new Point3d(pointMain.X, (checkDC ? pdc1.Y : pdc2.Y) - 1350 * SelectedScale * 0.01, 0), "MẶT CẮT A-A",
                SelectedScale, Autodesk.AutoCAD.DatabaseServices.TextHorizontalMode.TextCenter, 0);
            #endregion
            #region Points layout
            PointsLayout.MinMatDung = new Point3d(pd1.X - 2130 * SelectedScale * 0.01, (checkDC ? pdc1.Y : p1.Y) - 2000 * SelectedScale * 0.01, 0);
            PointsLayout.MaxMatDung = new Point3d(pd6.X + 1400 * SelectedScale * 0.01, ptr3.Y + 1330 * SelectedScale * 0.01, 0);
            ClCAD.SetLayerCurrent("NETHIDDEN");
            ClCAD.VeHinhChuNhat(PointsLayout.MinMatDung, PointsLayout.MaxMatDung);
            #endregion
            #region Vẽ đối trọng
            if (haveDoiTrong)
            {
                Point3d pdt1 = new Point3d(p2.X, p2.Y + h_doitrong, 0);
                Point3d pdt2 = new Point3d(p7.X, pdt1.Y, 0);
                Point3d pdt3 = new Point3d(p11.X, pdt2.Y, 0);
                Point3d pdt4 = new Point3d(pointMain.X, pdt3.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "ANSI31";
                double douHatch = layoutMongBanModel.HacthScale * 2;
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { p2, pdt1, pdt2, p7, p2 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pdt3, pdt4, new Point3d(pdt4.X, p14.Y, 0), p15, pdt3 }, nameHatch, douHatch);

                Point3d pIn1 = new Point3d(pdt2.X - 500 * SelectedScale * 0.01, pdt2.Y - h_doitrong / 2, 0);
                Point3d pIn2 = new Point3d(pIn1.X, pd1.Y + 550 * SelectedScale * 0.01, 0);
                ClKiHieu.GhiChuDoiTrong(pIn1, pIn2, SelectedScale, h_doitrong);
            }
            #endregion
            #region Đất thừa đắp lại
            Point3d pDap1 = new Point3d(p3.X, pd2.Y, 0);
            Point3d pDap2 = new Point3d(pDap1.X + HDapMax, pDap1.Y + HDapMax, 0);
            Point3d ptem01 = new Point3d(pDap2.X + 15500, pDap2.Y, 0);
            //Line l = ClCAD.CreateReturnLine(pDap2, ptem01);
            Point3d pDap3 = new Point3d(pd2.X, pDap2.Y, 0);
            Point3d pDap4 = new Point3d(pd3.X, pDap2.Y, 0);
            Point3d pDap5 = new Point3d(pd4.X, pDap2.Y, 0);
            Point3d ptem2 = new Point3d(pDap5.X + 30000, pDap5.Y, 0);
            //Line l2 = ClCAD.CreateReturnLine(pDap5, ptem2);
            Point3d pDap6 = new Point3d(pd5.X, pDap2.Y, 0);
            Point3d pDap8 = new Point3d(p30.X, pd5.Y, 0);
            Point3d pDap7 = new Point3d(pDap8.X - HDapMax, pDap6.Y, 0);

            ClCAD.SetLayerCurrent("NETHATCH");
            string HatchDapDat = "AR-SAND";
            double scaleHatch = layoutMongBanModel.HacthScale;
            ClCAD.CreateHatchFromListPointP(new List<Point3d> { pDap1, pDap2, pDap3, pd2, pDap1 }, HatchDapDat, scaleHatch);
            ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd3, pd4, pDap5, pDap4, pd3 }, HatchDapDat, scaleHatch);
            ClCAD.CreateHatchFromListPointP(new List<Point3d> { pDap6, pd5, pDap8, pDap7, pDap6 }, HatchDapDat, scaleHatch);
            ClKiHieu.GhiChuDatThuaDapLai(new Point3d(pDap4.X + 1000, pDap4.Y - 100, 0), SelectedScale);
            string hmax = $"Hmax = {HDapMax}";
            ClCAD.CreateDText("1:1", new Point3d(pDap1.X - 200, pDap1.Y + 100, 0), "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, Math.PI / 4);
            ClCAD.DimY2(pDap1, new Point3d(pDap1.X, pDap2.Y, 0), -300, hmax);
            #endregion

            #region Chèn đối xứng móng
            ClCAD.SetLayerCurrent("DUONGTRUC");
            ClCAD.CreateLine(pointMain, new Point3d(pointMain.X, p10.Y - 500, 0));
            string nblock = "TrucDoiXung" + SelectedScale.ToString();
            ClKiHieu.KiHieuDoiXung("TrucDoiXung", SelectedScale);
            ClBlock.InsertBlock(nblock, new Point3d(pointMain.X, p10.Y - 500, 0), 1, 0);
            #endregion
            #region Thang leo
            if (HaveThangLeo)
            {
                int nThangLeo = ClKiHieu.GhiChuThangLeo(pd3, p10, 0, SelectedScale);
                ClKiHieu.GhiChuThangLeo(pd4, p41, 1, SelectedScale);
                InforMongBan.SLThanhThepThangLeo = nThangLeo;
            }
            #endregion
        }
        public static void DrawMatDung_MongLechTam(Point3d pointMain, ThongSoMongBan thongSoMongBan, LayoutMongBanModel layoutMongBanModel,
            bool haveDoiTrong, double heSoMai, bool HaveThangLeo, double kcMep_DamCot, int soThanCot, double lechTamCoMong, double HDapMax)
        {
            #region Variable
            double chieuRong = thongSoMongBan.ChieuRongMong;
            double chieuDai = thongSoMongBan.ChieuDaiMong;
            double rongCM_Top = thongSoMongBan.RongCoMong_Top;
            double rongCM_Bot = thongSoMongBan.RongCoMong_Bot;
            double timMong = thongSoMongBan.TimMong;
            double ducLo = thongSoMongBan.DucLoMong;
            double dBTL = 100;
            double chieuRongDam = thongSoMongBan.ChieuRongDam;
            double SelectedScale = layoutMongBanModel.Selected_Scale_Layout;
            double doanXienDam = chieuRongDam / 3;
            double chieuCaoBan = thongSoMongBan.ChieuCaoBan;
            double chieuSauChonMong = thongSoMongBan.ChieuSauChonMong;
            double chieuCaoCM = thongSoMongBan.ChieuCaoCoMong;
            double chieucaoDam = thongSoMongBan.ChieuCaoDam;
            double doanVat = chieuRongDam / 2;
            double h_doitrong = thongSoMongBan.ChieuCaoDoiTrong;
            double chieuDayDC = thongSoMongBan.H_DemCat;
            #endregion
            #region Point
            Point3d ptr1 = new Point3d(pointMain.X - timMong / 2, pointMain.Y + chieuSauChonMong + chieuCaoCM, 0);
            Point3d ptr2 = new Point3d(pointMain.X - timMong / 2, pointMain.Y - 300, 0);
            Point3d ptr3 = new Point3d(pointMain.X + timMong / 2, pointMain.Y + chieuSauChonMong + chieuCaoCM, 0);
            Point3d ptr4 = new Point3d(pointMain.X + timMong / 2, pointMain.Y - 300, 0);
            Point3d p1 = new Point3d(pointMain.X - chieuRong / 2, pointMain.Y, 0);
            Point3d p2 = new Point3d(p1.X, p1.Y + chieuCaoBan, 0);
            Point3d p3 = new Point3d(p2.X, p1.Y + chieucaoDam, 0);
            Point3d p10 = new Point3d(ptr1.X + rongCM_Top / 2 + lechTamCoMong, ptr1.Y, 0);
            Point3d p14 = new Point3d(p10.X, pointMain.Y + chieuCaoBan, 0);
            Point3d p9 = new Point3d(p10.X - rongCM_Top, ptr1.Y, 0);
            Point3d p8 = new Point3d(p14.X - rongCM_Bot, p14.Y, 0);
            Point3d p11 = new Point3d(p10.X - kcMep_DamCot, p3.Y, 0);
            Point3d p6 = new Point3d(p11.X - chieuRongDam, p11.Y, 0);
            Point3d p7 = new Point3d(p6.X, p14.Y, 0);
            Point3d p15 = new Point3d(p11.X, p7.Y, 0);
            Point3d p12 = new Point3d(p14.X, p11.Y, 0);
            Point3d p16 = new Point3d(pointMain.X - ducLo / 2, p14.Y, 0);
            Point3d p17 = new Point3d(p16.X, pointMain.Y, 0);
            Point3d p18 = new Point3d(p17.X + dBTL, p17.Y, 0);
            Point3d p19 = new Point3d(p18.X, p18.Y - dBTL, 0);
            Point3d p20 = new Point3d(p1.X - dBTL, p1.Y - dBTL, 0);
            Point3d p21 = new Point3d(p20.X, p1.Y, 0);
            Point3d p22 = new Point3d(pointMain.X + ducLo / 2, pointMain.Y + chieuCaoBan, 0);
            Point3d p23 = new Point3d(p22.X, p1.Y, 0);
            Point3d p24 = new Point3d(p23.X - dBTL, p23.Y, 0);
            Point3d p25 = new Point3d(p24.X, p24.Y - dBTL, 0);
            Point3d p26 = new Point3d(pointMain.X + chieuRong / 2 + dBTL, p1.Y - dBTL, 0);
            Point3d p27 = new Point3d(p26.X, p1.Y, 0);
            Point3d p28 = new Point3d(p27.X - dBTL, p27.Y, 0);
            Point3d p29 = new Point3d(p28.X, p28.Y + chieuCaoBan, 0);
            Point3d p30 = new Point3d(p29.X, p1.Y + chieucaoDam, 0);
            Point3d p41 = new Point3d(ptr3.X - rongCM_Top / 2 - lechTamCoMong, ptr3.Y, 0);
            Point3d p42 = new Point3d(p41.X + rongCM_Top, p41.Y, 0);
            Point3d p37 = new Point3d(p41.X, p29.Y, 0);
            Point3d p31 = new Point3d(p37.X + rongCM_Bot, p29.Y, 0);
            Point3d p36 = new Point3d(p41.X + kcMep_DamCot, p37.Y, 0);
            Point3d p40 = new Point3d(p41.X + kcMep_DamCot, p30.Y, 0);
            Point3d p35 = new Point3d(p40.X + chieuRongDam, p40.Y, 0);
            Point3d p33 = new Point3d(p35.X, p29.Y, 0);
            Point3d p39 = new Point3d(p41.X, p40.Y, 0);
            Line line36 = ClCAD.CreateReturnLine(p3, p6);
            Line line89 = ClCAD.CreateReturnLine(p8, p9);
            Line line36_1 = ClCAD.CreateReturnLine(p3, p6);
            Line line3142 = ClCAD.CreateReturnLine(p42, p31);
            Point3d p5 = ClCAD.IntersectPoint(line89, line36);
            Point3d p34 = ClCAD.IntersectPoint(line3142, line36_1);
            // point đào đắp
            // 
            #endregion
            #region Vẽ Polyline
            ClCAD.SetLayerCurrent("DUONGTRUC");
            ClCAD.CreateLine(ptr1, ptr2);
            ClCAD.CreateLine(ptr3, ptr4);
            ClCAD.SetLayerCurrent("NETPHU");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p21, p20, p19, p18, p17 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p18, p19, p25, p24 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p23, p24, p25, p26, p27, p28 }, true);
            ClCAD.SetLayerCurrent("NETCHINH");
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p7, p6, p11, p15, p16, p17 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p23, p22, p36, p40, p35, p33, p29, p28 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p16, p17, p23, p22 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, p3, p5, p8 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p12, p14, p37, p39 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p34, p31, p29, p30 }, true);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p7, p8, p9, p10, p14, p15 }, false);
            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p36, p37, p41, p42, p31, p33 }, false);
            InforMongBan.DoanXienDam = p3.DistanceTo(p5) - p8.DistanceTo(p2);
            InforMongBan.RongBoTriStub = p5.DistanceTo(p12);
            //ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p4, p8 }, false);
            //ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p13, p14 }, false);
            //ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p37, p38 }, false);
            //ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p31, p32 }, false);
            #endregion
            #region Dim
            ClCAD.SetLayerCurrent("NETDIM");
            string strScale = string.Format("TL1-{0}", SelectedScale.ToString());
            ClCAD.SetDimStyleCurrent(strScale);
            List<Point3d> dsX = new List<Point3d>() { new Point3d(p3.X, ptr1.Y, 0), ptr1, ptr3, new Point3d(p30.X, ptr3.Y, 0) };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, -1.3);
            dsX = new List<Point3d>() { p9, ptr1, p10 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, -0.6);
            dsX = new List<Point3d>() { p41, ptr3, p42 };
            ClCAD.CreateDimension_X2(dsX, SelectedScale, -0.6);
            #endregion
            #region Đệm cát
            Point3d pdc1 = new Point3d();
            Point3d pdc4 = new Point3d();
            Point3d pdc2, pdc3, pd1, pd2, pd3, pd4, pd5, pd6, ps1, ps2;
            double moRongR = MoRongHoDao(chieuDayDC);
            InforMongBan.MoRongDay = moRongR;

            if (chieuDayDC != 0)
            {
                pdc1 = new Point3d(p1.X - moRongR, p20.Y - chieuDayDC, 0);
                pdc2 = new Point3d(pdc1.X - heSoMai * chieuDayDC, p20.Y, 0);
                pdc4 = new Point3d(p28.X + moRongR, pdc1.Y, 0);
                pdc3 = new Point3d(pdc4.X + heSoMai * chieuDayDC, p26.Y, 0);
                pd1 = new Point3d(pdc2.X - heSoMai * (chieuSauChonMong + dBTL), p1.Y + chieuSauChonMong, 0);
                Line Aux1 = ClCAD.CreateReturnLine(pd1, new Point3d(pd1.X + 150000, pd1.Y, 0));
                pd2 = ClCAD.IntersectPoint(line89, Aux1);
                pd3 = new Point3d(p10.X, pd2.Y, 0);
                pd4 = new Point3d(p41.X, pd2.Y, 0);
                pd5 = ClCAD.IntersectPoint(line3142, Aux1);
                pd6 = new Point3d(pdc3.X + heSoMai * (chieuSauChonMong + dBTL), pd2.Y, 0);
                ps1 = new Point3d(pd1.X - 300, pd1.Y, 0);
                ps2 = new Point3d(pd6.X + 300, pd1.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "AR-SAND";
                double douHatch = layoutMongBanModel.HacthScale;
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pdc1, pdc2, pdc3, pdc4 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { p20, pdc2, pd1, pd2, p5, p3, p1, p21, p20 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd3, p12, p39, pd4 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd5, pd6, pdc3, p26, p27, p28, p30, p34, pd5 }, nameHatch, douHatch);
                ClCAD.SetLayerCurrent("NETPHU");
                ClCAD.CreateLine(ps1, pd2);
                ClCAD.CreateLine(ps2, pd5);
                ClCAD.CreateLine(pd3, pd4);
                List<Point3d> dsY = new List<Point3d>() { new Point3d(pdc2.X, pdc1.Y, 0), pdc2 };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d>() { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p2.Y, 0), new Point3d(pd1.X, p3.Y, 0), pd1, new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { p20, p21 };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 2);

                dsX = new List<Point3d> { pdc1, new Point3d(p1.X, pdc1.Y, 0), new Point3d(p28.X, pdc1.Y, 0), pdc4 };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 1);


                ClCAD.DeleteObject(Aux1.Id);

                // vẽ nét vải địa
                ClCAD.SetLayerCurrent("NETVAIDIA");
                Polyline plRongVaiDia = ClCAD.CreatePolylineFromListPoints(new List<Point3d> { new Point3d(p1.X + 500, p20.Y, 0), pdc2, pdc1, pdc4, pdc3, new Point3d(p28.X - 500, p26.Y, 0) }, false);
                InforMongBan.ChieuRongVaiDia = Math.Round(plRongVaiDia.Length, 2) * Math.Pow(10, -3);
                InforMongBan.ChieuDaiVaiDia = Math.Round(plRongVaiDia.Length, 2) * Math.Pow(10, -3) - (chieuRong - chieuDai) * Math.Pow(10, -3);
                dsX = new List<Point3d> { new Point3d(p1.X + 500, p20.Y, 0), p1 };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
                dsX = new List<Point3d> { p28, new Point3d(p28.X - 500, p26.Y, 0) };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 0.5);
            }
            else
            {
                pdc2 = new Point3d(p1.X - 300, p20.Y, 0);
                pdc3 = new Point3d(p28.X + 300, p20.Y, 0);
                pd1 = new Point3d(pdc2.X - heSoMai * (chieuSauChonMong + dBTL), p1.Y + chieuSauChonMong, 0);
                Line Aux1 = ClCAD.CreateReturnLine(pd1, new Point3d(pd1.X + 150000, pd1.Y, 0));
                pd2 = ClCAD.IntersectPoint(line89, Aux1);
                pd3 = new Point3d(p10.X, pd2.Y, 0);
                pd4 = new Point3d(p41.X, pd2.Y, 0);
                pd5 = ClCAD.IntersectPoint(line3142, Aux1);
                pd6 = new Point3d(pdc3.X + heSoMai * (chieuSauChonMong + dBTL), pd2.Y, 0);
                ps1 = new Point3d(pd1.X - 300, pd1.Y, 0);
                ps2 = new Point3d(pd6.X + 300, pd1.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "AR-SAND";
                double douHatch = layoutMongBanModel.HacthScale;
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { p20, pdc2, pd1, pd2, p5, p3, p1, p21, p20 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd3, p12, p39, pd4 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd5, pd6, pdc3, p26, p27, p28, p30, p34, pd5 }, nameHatch, douHatch);
                ClCAD.SetLayerCurrent("NETPHU");
                ClCAD.CreateLine(ps1, pd2);
                ClCAD.CreateLine(ps2, pd5);
                ClCAD.CreateLine(pd3, pd4);

                List<Point3d> dsY = new List<Point3d>();
                dsY = new List<Point3d>() { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p2.Y, 0), new Point3d(pd1.X, p3.Y, 0), pd1, new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { p20, p21 };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 1);
                dsY = new List<Point3d> { new Point3d(pd1.X, p1.Y, 0), new Point3d(pd1.X, p9.Y, 0) };
                ClCAD.CreateDimension_Y2(dsY, SelectedScale, 2);

                dsX = new List<Point3d> { pdc2, new Point3d(p1.X, pdc2.Y, 0), new Point3d(p28.X, pdc2.Y, 0), pdc3 };
                ClCAD.CreateDimension_X2(dsX, SelectedScale, 1);

                ClCAD.DeleteObject(Aux1.Id);

            }

            #endregion
            #region Chèn cao độ
            ClCAD.SetLayerCurrent("NETPHU");

            string caodo1 = "+" + (chieuCaoCM / 1000).ToString("0.0") + "m";
            string caodo2 = "-" + (chieuSauChonMong / 1000).ToString("0.0") + "m";
            string caodo3 = "-" + (chieuSauChonMong / 1000 + dBTL / 1000 + chieuDayDC / 1000).ToString("0.0") + "m";
            Point3d pcd1 = new Point3d(ps2.X + 100, ps2.Y, 0);
            Point3d pcd2 = new Point3d(ps2.X + 100, p42.Y, 0);
            Point3d pcd3 = new Point3d(ps2.X + 100, p27.Y, 0);
            Point3d pcd4 = new Point3d(pdc3.X + 400, p27.Y - dBTL - chieuDayDC, 0);
            ClKiHieu.KihieuCaoDo(pcd1, "± 0.0 m", 1, SelectedScale);
            ClKiHieu.KihieuCaoDo(pcd2, caodo1, 1, SelectedScale);
            ClKiHieu.KihieuCaoDo(pcd3, caodo2, 1, SelectedScale);
            if (chieuDayDC != 0) ClKiHieu.KihieuCaoDo(pcd4, caodo3, 1, SelectedScale);
            #endregion
            #region Chèn ghi chú đất đắp
            Point3d pdatdap = new Point3d(pd5.X + 500 * SelectedScale * 0.01, pd5.Y, 0);
            ClKiHieu.GhiChuDatDap(pdatdap, SelectedScale);
            #endregion
            #region Ghi chú đệm cát, vải địa
            if (chieuDayDC != 0)
            {
                double moRongDinh = pdc2.DistanceTo(new Point3d(p1.X, p20.Y, 0));
                InforMongBan.MoRongDinh = moRongDinh;
                double V_DC = Math.Round(TinhKhoiLuongMongBan.TinhKhoiLuongDemCat(moRongDinh, moRongR, chieuDai, chieuRong, chieuDayDC), 2);
                double S_VD = Math.Round(InforMongBan.ChieuRongVaiDia * InforMongBan.ChieuDaiVaiDia, 2);
                Point3d pVaidia = new Point3d(ptr2.X, pdc1.Y, 0);
                Point3d pDemCat = new Point3d(p22.X + 1000 * SelectedScale * 0.01, pdc1.Y, 0);
                ClKiHieu.GhiChuVaiDia(pVaidia, SelectedScale, S_VD, soThanCot);
                ClKiHieu.GhiChuCatDem(pDemCat, SelectedScale, V_DC, soThanCot);
                InforMongBan.V_DemCat = V_DC;
            }
            #endregion      
            #region Ghi chú tên mặt cắt
            bool checkDC = chieuDayDC != 0;
            ClKiHieu.TenMatCat(new Point3d(pointMain.X, (checkDC ? pdc1.Y : pdc2.Y) - 1350 * SelectedScale * 0.01, 0), "MẶT CẮT A-A",
                SelectedScale, Autodesk.AutoCAD.DatabaseServices.TextHorizontalMode.TextCenter, 0);
            #endregion
            #region Points layout
            PointsLayout.MinMatDung = new Point3d(pd1.X - 2130 * SelectedScale * 0.01, (checkDC ? pdc1.Y : p1.Y) - 2000 * SelectedScale * 0.01, 0);
            PointsLayout.MaxMatDung = new Point3d(pd6.X + 1400 * SelectedScale * 0.01, ptr3.Y + 1330 * SelectedScale * 0.01, 0);
            ClCAD.SetLayerCurrent("NETHIDDEN");
            ClCAD.VeHinhChuNhat(PointsLayout.MinMatDung, PointsLayout.MaxMatDung);
            #endregion
            #region Vẽ đối trọng
            if (haveDoiTrong)
            {
                Point3d pdt1 = new Point3d(p2.X, p2.Y + h_doitrong, 0);
                Line ln = ClCAD.CreateReturnLine(pdt1, new Point3d(pdt1.X + 150000, pdt1.Y, 0));
                Point3d pdt2 = ClCAD.IntersectPoint(line89, ln);
                Point3d pdt3 = new Point3d(p10.X, pdt2.Y, 0);
                Point3d pdt4 = new Point3d(pointMain.X, pdt3.Y, 0);
                ClCAD.SetLayerCurrent("NETHATCH");
                string nameHatch = "ANSI31";
                double douHatch = layoutMongBanModel.HacthScale * 2;
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { p2, pdt1, pdt2, p8, p2 }, nameHatch, douHatch);
                ClCAD.CreateHatchFromListPointP(new List<Point3d> { pdt3, pdt4, new Point3d(pdt4.X, p14.Y, 0), p14, pdt3 }, nameHatch, douHatch);
                ClCAD.DeleteObject(ln.Id);
                Point3d pIn1 = new Point3d(pdt2.X - 500 * SelectedScale * 0.01, pdt2.Y - h_doitrong / 2, 0);
                Point3d pIn2 = new Point3d(pIn1.X, pd1.Y + 550 * SelectedScale * 0.01, 0);
                ClKiHieu.GhiChuDoiTrong(pIn1, pIn2, SelectedScale, h_doitrong);
            }
            #endregion
            #region Chèn đối xứng móng
            ClCAD.SetLayerCurrent("DUONGTRUC");
            ClCAD.CreateLine(pointMain, new Point3d(pointMain.X, p10.Y - 500, 0));
            string nblock = "TrucDoiXung" + SelectedScale.ToString();
            ClKiHieu.KiHieuDoiXung("TrucDoiXung", SelectedScale);
            ClBlock.InsertBlock(nblock, new Point3d(pointMain.X, p10.Y - 500, 0), 1, 0);
            #endregion
            #region Thang leo
            if (HaveThangLeo)
            {
                int nThangLeo = ClKiHieu.GhiChuThangLeo(pd3, p10, 0, SelectedScale);
                ClKiHieu.GhiChuThangLeo(pd4, p41, 1, SelectedScale);
                InforMongBan.SLThanhThepThangLeo = nThangLeo;
            }
            #endregion
            #region Đất thừa đắp lại
            Point3d pDap1 = new Point3d(p3.X, pd2.Y, 0);
            Point3d pDap2 = new Point3d(pDap1.X + HDapMax, pDap1.Y + HDapMax, 0);
            Point3d ptem01 = new Point3d(pDap2.X + 15500, pDap2.Y, 0);
            Line l = ClCAD.CreateReturnLine(pDap2, ptem01);
            Point3d pDap3 = ClCAD.IntersectPoint(l, line89);
            Point3d pDap4 = new Point3d(pd3.X, pDap2.Y, 0);
            Point3d pDap5 = new Point3d(pd4.X, pDap2.Y, 0);
            Point3d ptem2 = new Point3d(pDap5.X + 30000, pDap5.Y, 0);
            Line l2 = ClCAD.CreateReturnLine(pDap5, ptem2);
            Point3d pDap6 = ClCAD.IntersectPoint(l2, line3142);
            Point3d pDap8 = new Point3d(p30.X, pd5.Y, 0);
            Point3d pDap7 = new Point3d(pDap8.X - HDapMax, pDap6.Y, 0);

            ClCAD.SetLayerCurrent("NETHATCH");
            string HatchDapDat = "AR-SAND";
            double scaleHatch = layoutMongBanModel.HacthScale;
            ClCAD.CreateHatchFromListPointP(new List<Point3d> { pDap1, pDap2, pDap3, pd2, pDap1 }, HatchDapDat, scaleHatch);
            ClCAD.CreateHatchFromListPointP(new List<Point3d> { pd3, pd4, pDap5, pDap4, pd3 }, HatchDapDat, scaleHatch);
            ClCAD.CreateHatchFromListPointP(new List<Point3d> { pDap6, pd5, pDap8, pDap7, pDap6 }, HatchDapDat, scaleHatch);
            ClKiHieu.GhiChuDatThuaDapLai(new Point3d(pDap4.X + 1000, pDap4.Y - 100, 0), SelectedScale);
            string hmax = $"Hmax = {HDapMax}";
            ClCAD.CreateDText("1:1", new Point3d(pDap1.X - 200, pDap1.Y + 100, 0), "CHUTHUONG", 200 * SelectedScale * 0.01, 4, TextHorizontalMode.TextLeft, Math.PI / 4);
            ClCAD.DimY2(pDap1, new Point3d(pDap1.X, pDap2.Y, 0), -300, hmax);
            #endregion
            #region Lây diện tích mặt đứng dầm để tính V dầm
            Polyline pS1 = ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2, p3, p5, p8 }, true);
            InforMongBan.DienTichMatDung_X = Math.Round(Math.Pow(10, -6) * pS1.Area, 2);
            double delta = p3.DistanceTo(p5) - (chieuDai - p5.DistanceTo(p34)) / 2;
            Point3d p3Au = new Point3d(p3.X + delta, p3.Y, 0);
            Point3d p2Au = new Point3d(p2.X + delta, p2.Y, 0);
            Polyline pS2 = ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p2Au, p3Au, p5, p8 }, true);
            InforMongBan.DienTichMatDung_Y = Math.Round(Math.Pow(10, -6) * pS2.Area, 2);
            Polyline pS3 = ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p14, p12, p39, p37 }, true);
            InforMongBan.DienTichMatDung_KhongVat = Math.Round(Math.Pow(10, -6) * pS3.Area, 2);

            #endregion
            #region Xóa
            ClCAD.DeleteObject(line36_1.Id);
            ClCAD.DeleteObject(line36.Id);
            ClCAD.DeleteObject(line89.Id);
            ClCAD.DeleteObject(line3142.Id);
            ClCAD.DeleteObject(pS1.Id);
            ClCAD.DeleteObject(pS2.Id);
            ClCAD.DeleteObject(pS3.Id);
            ClCAD.DeleteObject(l.Id);
            ClCAD.DeleteObject(l2.Id);

            #endregion
        }
        private static readonly Dictionary<double, double> MoRongHoDaoMappings = new Dictionary<double, double>
        {
            { 500, 400},
            { 600, 500 },
            { 700, 500 },
            { 800, 600 },
            { 900, 700 },
            { 1000, 700 },
            { 1100, 800 },
            { 1200, 800 },
            { 1300, 900 },
            { 1400, 900 },
            { 1500, 1000 },
            { 1600, 1000 },
            { 1700, 1200 },
            { 1800, 1200 },
            { 1900, 1300 },
            { 2000, 1300 }
        };
        private static double MoRongHoDao(double beDayDC)
        {
            return MoRongHoDaoMappings.TryGetValue(beDayDC, out double R) ? R : 400;
        }
        private static void VeCoMong(Point3d pC1, double chieuRongCM, bool haveDim, double SelectedScale)
        {
            Point3d p1 = new Point3d(pC1.X - chieuRongCM / 2, pC1.Y + chieuRongCM / 2, 0);
            Point3d p2 = new Point3d(p1.X + chieuRongCM, p1.Y, 0);
            Point3d p3 = new Point3d(p2.X, p2.Y - chieuRongCM, 0);
            Point3d p4 = new Point3d(p1.X, p3.Y, 0);
            ClCAD.SetLayerCurrent("NETCHINH");

            ClCAD.CreatePolylineFromListPoints(new List<Point3d> { p1, p2, p3, p4 }, true);
            ClCAD.SetLayerCurrent("NETDIM");
            string strScale = string.Format("TL1-{0}", SelectedScale.ToString());
            ClCAD.SetDimStyleCurrent(strScale);
            if (haveDim)
            {
                ClCAD.CreateDimension_Y2(new List<Point3d> { p1, p4 }, SelectedScale, 0.5);
                ClCAD.CreateDimension_X2(new List<Point3d> { p1, p2 }, SelectedScale, -0.5);
            }


        }
    }
}
