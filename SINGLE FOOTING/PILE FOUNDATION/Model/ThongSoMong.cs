using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAD_API.PILE_FOUNDATION.Model
{
    public class ThongSoMong
    {
        //Tên móng
        public string TenMong { get; set; }
        // Tim móng
        public double BeRongChanCot { get; set; }
        // Kích thước móng
        public double ChieuRongDai { get; set; }
        public double ChieuDaiDai { get; set; }
        public double ChieuCaoDai { get; set; }
        // Lớp dưới
        public int DK_LopDuoi_X { get; set; }
        public double KC_LopDuoi_X { get; set; }
        public double KC_LopDuoi_Y { get; set; }
        // Lớp trên
        public int DK_LopTren_X { get; set; }
        public double KC_LopTren_X { get; set; }
        public double KC_LopTren_Y { get; set; }
        // Lớp giữa
        public int DK_LopGiua_X { get; set; }
        public double KC_LopGiua_X { get; set; }
        public double KC_LopGiua_Y { get; set; }
        // Thép chống
        public int DK_ThepChong { get; set; }
        public double KC_ThepChong_X { get; set; }
        public double KC_ThepChong_Y { get; set; }
        // Cổ móng
        public double ChieuSauChonMong { get; set; }
        public double ChieuCaoCoMong { get; set; }
        public double RongCM_Top { get; set; }
        public double RongCM_Bot { get; set; }
        public int DK_ThepChu_CM { get; set; }
        public int SL_ThepChu_CM { get; set; }
        public int DK_ThepDai_CM { get; set; }
        public double KC_ThepDai_CM { get; set; }
        // 
        #region Thông số cọc

        public double DK_Coc { get; set; }
        public double ChieuDaiCoc { get; set; }
        public int SL_Coc_X { get; set; }
        public int SL_Coc_Y { get; set; }
        public string SelectedLoaiCoc { get; set; }
        #endregion
        #region Thông số dầm
        public double ChieuRongDam { get; set; }
        public double ChieuCaoDam { get; set; }
        public int DK_ThepChu_Dam { get; set; }
        public int SL_ThepChu_Dam { get; set; }
        public int DK_ThepDai_Dam { get; set; }
        public double KC_ThepDai_Dam { get; set; }
        public int DK_ThepGia_Dam { get; set; }
        #endregion

    }

}
