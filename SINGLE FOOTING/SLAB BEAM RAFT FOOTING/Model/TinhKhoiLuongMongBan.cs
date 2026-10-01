using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAD_API.SLAB_BEAM_RAFT_FOOTING.Model
{
    public class TinhKhoiLuongMongBan
    {
        public static double TinhKhoiLuongDemCat(double moRongDinh, double moRongDay, double chieuDaiMong, double chieuRongMong, double bedayDC)
        {
            double rong_DayDC = chieuRongMong + 2 * moRongDay;
            double dai_DayDC = chieuDaiMong + 2 * moRongDay;
            double rong_DinhDC = chieuRongMong + 2 * moRongDinh;
            double dai_DinhDC = chieuDaiMong + 2 * moRongDinh;
            double dienTichDay = Math.Pow(10, -6) * (rong_DayDC * dai_DayDC);
            double dienTichDinh = Math.Pow(10, -6) * (rong_DinhDC * dai_DinhDC);
            return Math.Pow(10, -3) * bedayDC / 3 * (dienTichDay + dienTichDinh + Math.Sqrt(dienTichDinh * dienTichDay));
        }
    }
}
