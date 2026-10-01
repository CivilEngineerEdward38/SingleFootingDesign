

namespace SINGLE_FOOTING.SLAB_BEAM_RAFT_FOOTING.Model
{
    public class ThongSoMongBan
    {

        #region Bản móng     
        public double ChieuRongMong { get; set; }
        public double ChieuDaiMong { get; set; }
        public double ChieuCaoBan { get; set; }
        public double DucLoMong { get; set; }
        public int DKThep_Oban_1 { get; set; }
        public double KCThep_Oban_1 { get; set; }
        public int DKThep_Oban_2 { get; set; }
        public double KCThep_Oban_2 { get; set; }
        public int DKThepChong { get; set; }
        public double KCThepChong_Oban1 { get; set; }
        public double KCThepChong_Oban2 { get; set; }

        public double ChieuCaoDoiTrong { get; set; }
        #endregion
        #region Cổ móng
        public double ChieuSauChonMong { get; set; }
        public double ChieuCaoCoMong { get; set; }
        public double RongCoMong_Top { get; set; }
        public double RongCoMong_Bot { get; set; }
        public int DKThepChu_CM { get; set; }
        public int SLThepChu_CM { get; set; }
        public int DKThepDai_CM { get; set; }
        public double KCThepDai_CM { get; set; }
        public double KCRaiDai100 { get; set; }
        public int DKThep_ThangLeo { get; set; } = 25;

        #endregion
        #region Dầm móng
        public double ChieuCaoDam { get; set; }
        public double ChieuRongDam { get; set; }
        public int DKThepChu_Dam { get; set; }
        public int SLThepChu_Dam { get; set; }
        public int DKThepDai_Dam { get; set; }
        public double KCThepDai_Dam { get; set; }
        public int DKThepGia_Dam { get; set; }

        #endregion
        #region Tên móng
        public string TenMong { get; set; }
        public double TimMong { get; set; }
        #endregion
        public double H_DemCat { get; set; }
    }
}
