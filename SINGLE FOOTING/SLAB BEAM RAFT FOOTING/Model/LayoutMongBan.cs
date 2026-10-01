using System.Collections.ObjectModel;

namespace MONGDUONGDAY.MongBan.Model
{
    //ObservableCollection<T> là một dạng danh sách (list) đặc biệt trong C#/.NET. Điểm khác biệt lớn nhất giữa nó và List<T> thông thường là: nó có khả năng tự động thông báo khi dữ liệu bên trong bị thay đổi (khi thêm, xóa, sửa hoặc làm mới danh sách).
    //Cơ chế Binding MVVM (OnPropertyChanged): Khi người dùng chọn loại chống hoặc nhập tim cột trên UI, hàm set chạy, gán giá trị mới vào _field và gọi OnPropertyChanged để giao diện WPF/CAD tự động cập nhật theo.
    public class LayoutMongBanModel : BaseViewModel

    {
        private double _TimCot;
        public double TimCot
        {
            get { return _TimCot; }
            set
            {
                _TimCot = value;
                OnPropertyChanged(nameof(TimCot));
            }
        }
        private ObservableCollection<string> _MacBeTong;
        public ObservableCollection<string> MacBeTong
        {
            get { return _MacBeTong; }
            set
            {
                _MacBeTong = value;
                OnPropertyChanged(nameof(MacBeTong));
            }
        }
        private string _SelectedMacBeTong;
        public string SelectedMacBeTong
        {
            get { return _SelectedMacBeTong; }
            set
            {
                _SelectedMacBeTong = value;
                OnPropertyChanged(nameof(SelectedMacBeTong));
            }
        }
        private string _SelectedMacBTCoc;
        public string SelectedMacBTCoc
        {
            get { return _SelectedMacBTCoc; }
            set
            {
                _SelectedMacBTCoc = value;
                OnPropertyChanged(nameof(SelectedMacBTCoc));
            }
        }
        private int _SoThanCot;
        public int SoThanCot
        {
            get { return _SoThanCot; }
            set
            {
                _SoThanCot = value;
                OnPropertyChanged(nameof(SoThanCot));
            }
        }

        private ObservableCollection<string> _MacThep;
        public ObservableCollection<string> MacThep
        {
            get { return _MacThep; }
            set
            {
                _MacThep = value;
                OnPropertyChanged(nameof(MacThep));
            }
        }
        private string _SelectedMacThep;
        public string SelectedMacThep
        {
            get { return _SelectedMacThep; }
            set
            {
                _SelectedMacThep = value;
                OnPropertyChanged(nameof(SelectedMacThep));
            }
        }
        private ObservableCollection<int> _AllDuongKinh;
        public ObservableCollection<int> AllDuongKinh
        {
            get { return _AllDuongKinh; }
            set
            {
                _AllDuongKinh = value;
                OnPropertyChanged(nameof(AllDuongKinh));
            }
        }
        private ObservableCollection<string> _HuongTuyen;
        public ObservableCollection<string> HuongTuyen
        {
            get { return _HuongTuyen; }
            set
            {
                _HuongTuyen = value;
                OnPropertyChanged(nameof(HuongTuyen));
            }
        }
        private string _SelectedHuongTuyen;
        public string SelectedHuongTuyen
        {
            get { return _SelectedHuongTuyen; }
            set
            {
                _SelectedHuongTuyen = value;
                OnPropertyChanged(nameof(SelectedHuongTuyen));
            }
        }
        private ObservableCollection<string> _GocLai;
        public ObservableCollection<string> GocLai
        {
            get { return _GocLai; }
            set
            {
                _GocLai = value;
                OnPropertyChanged(nameof(GocLai));
            }
        }
        private string _SelectedGocLai;
        public string SelectedGocLai
        {
            get { return _SelectedGocLai; }
            set
            {
                _SelectedGocLai = value;
                OnPropertyChanged(nameof(SelectedGocLai));
            }
        }

        private double _KhoangHoCotThep;
        public double KhoangHoCotThep
        {
            get { return _KhoangHoCotThep; }
            set
            {
                _KhoangHoCotThep = value;
                OnPropertyChanged(nameof(KhoangHoCotThep));
            }
        }
        private ObservableCollection<double> _Scale;
        public ObservableCollection<double> Scale
        {
            get { return _Scale; }
            set
            {
                _Scale = value;
                OnPropertyChanged(nameof(Scale));
            }
        }
        private double _Selected_Scale_Layout;
        public double Selected_Scale_Layout
        {
            get { return _Selected_Scale_Layout; }
            set
            {
                _Selected_Scale_Layout = value;
                OnPropertyChanged(nameof(Selected_Scale_Layout));
            }
        }
        private double _Selected_Scale_MBThep;
        public double Selected_Scale_MBThep
        {
            get { return _Selected_Scale_MBThep; }
            set
            {
                _Selected_Scale_MBThep = value;
                OnPropertyChanged(nameof(Selected_Scale_MBThep));
            }
        }
        private double _SelectedScale_BangKhoiLuong;
        public double SelectedScale_BangKhoiLuong
        {
            get { return _SelectedScale_BangKhoiLuong; }
            set
            {
                _SelectedScale_BangKhoiLuong = value;
                OnPropertyChanged(nameof(SelectedScale_BangKhoiLuong));
            }
        }

        private double _Selected_Scale_SC_Column;
        public double Selected_Scale_SC_Column
        {
            get { return _Selected_Scale_SC_Column; }
            set
            {
                _Selected_Scale_SC_Column = value;
                OnPropertyChanged(nameof(Selected_Scale_SC_Column));
            }
        }
        private double _Selected_Scale_Dam;
        public double Selected_Scale_Dam
        {
            get { return _Selected_Scale_Dam; }
            set
            {
                _Selected_Scale_Dam = value;
                OnPropertyChanged(nameof(Selected_Scale_Dam));
            }
        }
        private double _Selected_Scale_MatDungThep;
        public double Selected_Scale_MatDungThep
        {
            get { return _Selected_Scale_MatDungThep; }
            set
            {
                _Selected_Scale_MatDungThep = value;
                OnPropertyChanged(nameof(Selected_Scale_MatDungThep));
            }
        }

        private double _BTBV_Day;
        public double BTBV_Day
        {
            get { return _BTBV_Day; }
            set
            {
                _BTBV_Day = value;
                OnPropertyChanged(nameof(BTBV_Day));
            }
        }
        private double _BTBV_Khac;
        public double BTBV_Khac
        {
            get { return _BTBV_Khac; }
            set
            {
                _BTBV_Khac = value;
                OnPropertyChanged(nameof(BTBV_Khac));
            }
        }
        private double _HacthScale;
        public double HacthScale
        {
            get { return _HacthScale; }
            set
            {
                _HacthScale = value;
                OnPropertyChanged(nameof(HacthScale));
            }
        }
        private ObservableCollection<string> _GDTK;
        public ObservableCollection<string> GDTK
        {
            get { return _GDTK; }
            set
            {
                _GDTK = value;
                OnPropertyChanged(nameof(GDTK));
            }
        }
        private string _Selected_GDTK;
        public string Selected_GDTK
        {
            get { return _Selected_GDTK; }
            set
            {
                _Selected_GDTK = value;
                OnPropertyChanged(nameof(Selected_GDTK));
            }
        }
        private double _DuTruKL_BT;
        public double DuTruKL_BT
        {
            get { return _DuTruKL_BT; }
            set
            {
                _DuTruKL_BT = value;
                OnPropertyChanged(nameof(DuTruKL_BT));
            }
        }
        private double _DuTruKL_CotThep;
        public double DuTruKL_CotThep
        {
            get { return _DuTruKL_CotThep; }
            set
            {
                _DuTruKL_CotThep = value;
                OnPropertyChanged(nameof(DuTruKL_CotThep));
            }
        }

        private string _MaSoDuAn;
        public string MaSoDuAn
        {
            get { return _MaSoDuAn; }
            set
            {
                _MaSoDuAn = value;
                OnPropertyChanged(nameof(MaSoDuAn));
            }
        }
        private string _MaSoDuAn_Detail;
        public string MaSoDuAn_Detail
        {
            get { return _MaSoDuAn_Detail; }
            set
            {
                _MaSoDuAn_Detail = value;
                OnPropertyChanged(nameof(MaSoDuAn_Detail));
            }
        }
        private string _SoBanVe;
        public string SoBanVe
        {
            get { return _SoBanVe; }
            set
            {
                _SoBanVe = value;
                OnPropertyChanged(nameof(SoBanVe));
            }
        }

        private string _SoBanVe_Detail;
        public string SoBanVe_Detail
        {
            get { return _SoBanVe_Detail; }
            set
            {
                _SoBanVe_Detail = value;
                OnPropertyChanged(nameof(SoBanVe_Detail));
            }
        }

        private string _PathDwg;

        public string PathDwg
        {
            get { return _PathDwg; }
            set { _PathDwg = value; OnPropertyChanged(); }
        }
        private string _KhungA3;

        public string KhungA3
        {
            get { return _KhungA3; }
            set { _KhungA3 = value; OnPropertyChanged(); }
        }
        private double _SelectedScaleNameDrawing;
        public double SelectedScaleNameDrawing
        {
            get { return _SelectedScaleNameDrawing; }
            set
            {
                _SelectedScaleNameDrawing = value;
                OnPropertyChanged(nameof(SelectedScaleNameDrawing));
            }
        }
        private ObservableCollection<string> _ListThanhThepChong;
        public ObservableCollection<string> ListThanhThepChong
        {
            get { return _ListThanhThepChong; }
            set
            {
                _ListThanhThepChong = value;
                OnPropertyChanged(nameof(ListThanhThepChong));
            }
        }
        private double _KhoangHo;
        public double KhoangHo
        {
            get { return _KhoangHo; }
            set
            {
                _KhoangHo = value;
                OnPropertyChanged(nameof(KhoangHo));
            }
        }
        private string _SelectedLoaiChong;
        public string SelectedLoaiChong
        {
            get { return _SelectedLoaiChong; }
            set
            {
                _SelectedLoaiChong = value;
                OnPropertyChanged(nameof(SelectedLoaiChong));
            }
        }

        public LayoutMongBanModel()
        {
            MacBeTong = new ObservableCollection<string> { "B15", "B20", "B22.5", "B25", "B30", "B35" };
            MacThep = new ObservableCollection<string> { "CB-300V", "CB-400V" };
            HuongTuyen = new ObservableCollection<string>() { "NÉO THẲNG", "ĐỠ THẲNG", "NÉO PHÂN GIÁC", "NÉO DỪNG", "NÉO 90" };
            GDTK = new ObservableCollection<string> { "TKCS", "TKKT", "TKBVTC" };
            GocLai = new ObservableCollection<string>() { "BÊN TRÁI", "BÊN PHẢI" };
            KhoangHoCotThep = 50;
            Scale = new ObservableCollection<double> { 10, 20, 25, 50, 75, 100, 150, 200, 250 };
            AllDuongKinh = new ObservableCollection<int> { 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32 };
            ListThanhThepChong = new ObservableCollection<string> { "Chân chó", "Thanh thẳng" };
            SelectedLoaiChong = ListThanhThepChong[0];
        }
    }
}
