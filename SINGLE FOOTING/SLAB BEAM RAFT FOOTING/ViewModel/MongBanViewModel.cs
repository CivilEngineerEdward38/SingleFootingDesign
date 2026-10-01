using ACAD_API.SLAB_BEAM_RAFT_FOOTING.Model;
using ACAD_API.SLAB_BEAM_RAFT_FOOTING.View;
using Autodesk.AutoCAD.Geometry;
using MONGDUONGDAY.MongBan.Model;
using SINGLE_FOOTING.SLAB_BEAM_RAFT_FOOTING.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ACAD_API.SLAB_BEAM_RAFT_FOOTING.ViewModel
{
    public class MongBanViewModel : BaseViewModel
    {
        private TaskBarControlViewModel _taskBarControlViewModel;
        public TaskBarControlViewModel TaskBarControlViewModel
        {
            get { return _taskBarControlViewModel; }
            set
            {
                _taskBarControlViewModel = value;
                OnPropertyChanged(nameof(TaskBarControlViewModel));
            }
        }
        private LayoutMongBanModel _LayoutMongBanModel;
        public LayoutMongBanModel LayoutMongBanModel
        {
            get { return _LayoutMongBanModel; }
            set
            {
                _LayoutMongBanModel = value;
                OnPropertyChanged(nameof(LayoutMongBanModel));
            }
        }
        private ThongSoMongBan _ThongSoMongBan;
        public ThongSoMongBan ThongSoMongBan
        {
            get { return _ThongSoMongBan; }
            set
            {
                _ThongSoMongBan = value;
                OnPropertyChanged(nameof(ThongSoMongBan));
            }
        }
        private MongBanModel _MongBanModel;
        public MongBanModel MongBanModel
        {
            get { return _MongBanModel; }
            set
            {
                _MongBanModel = value;
                OnPropertyChanged(nameof(MongBanModel));
            }
        }
        private int _SLThanhGhepCM;
        public int SLThanhGhepCM
        {
            get { return _SLThanhGhepCM; }
            set
            {
                _SLThanhGhepCM = value;
                OnPropertyChanged(nameof(SLThanhGhepCM));
                //ThongBaoKhoangHoThepCM();
            }
        }
        private double _KCRaiDai100;
        public double KCRaiDai100
        {
            get { return _KCRaiDai100; }
            set
            {
                _KCRaiDai100 = value;
                OnPropertyChanged(nameof(KCRaiDai100));
            }
        }
        private Point3d _MainPoint;
        public Point3d MainPoint
        {
            get { return _MainPoint; }
            set
            {
                _MainPoint = value;
                OnPropertyChanged(nameof(MainPoint));
            }
        }
        public static PointsLayoutModel PointsLayout = new PointsLayoutModel();
        public static GetInforMongBan InforMongBan = new GetInforMongBan();
        private bool _HaveDoiTrong;
        public bool HaveDoiTrong
        {
            get { return _HaveDoiTrong; }
            set
            {
                _HaveDoiTrong = value;
                OnPropertyChanged(nameof(HaveDoiTrong));
            }
        }
        private bool _IsEnableDoiTrong;
        public bool IsEnableDoiTrong
        {
            get { return _IsEnableDoiTrong; }
            set
            {
                _IsEnableDoiTrong = value;
                OnPropertyChanged(nameof(IsEnableDoiTrong));
            }
        }

        private double _BeDayDemCat;
        public double BeDayDemCat
        {
            get { return _BeDayDemCat; }
            set
            {
                _BeDayDemCat = value;
                OnPropertyChanged(nameof(BeDayDemCat));
            }
        }
        private double _HeSoMai;
        public double HeSoMai
        {
            get { return _HeSoMai; }
            set
            {
                _HeSoMai = value;
                OnPropertyChanged(nameof(HeSoMai));
            }
        }
        private bool _HaveThangLeo;
        public bool HaveThangLeo
        {
            get { return _HaveThangLeo; }
            set
            {
                _HaveThangLeo = value;
                OnPropertyChanged(nameof(HaveThangLeo));
            }
        }

        private bool _IsEnableThangLeo;
        public bool IsEnableThangLeo
        {
            get { return _IsEnableThangLeo; }
            set
            {
                _IsEnableThangLeo = value;
                OnPropertyChanged(nameof(IsEnableThangLeo));
            }
        }
        private bool _HaveCutThep_Oban1;
        public bool HaveCutThep_Oban1
        {
            get { return _HaveCutThep_Oban1; }
            set
            {
                _HaveCutThep_Oban1 = value;
                OnPropertyChanged(nameof(HaveCutThep_Oban1));
            }
        }

        private bool _IsEnableCut_Oban1;
        public bool IsEnableCut_Oban1
        {
            get { return _IsEnableCut_Oban1; }
            set
            {
                _IsEnableCut_Oban1 = value;
                OnPropertyChanged(nameof(IsEnableCut_Oban1));
            }
        }
        private bool _HaveCutThep_Oban2;
        public bool HaveCutThep_Oban2
        {
            get { return _HaveCutThep_Oban2; }
            set
            {
                _HaveCutThep_Oban2 = value;
                OnPropertyChanged(nameof(HaveCutThep_Oban2));
            }
        }
        private bool _IsEnableCut_Oban2;
        public bool IsEnableCut_Oban2
        {
            get { return _IsEnableCut_Oban2; }
            set
            {
                _IsEnableCut_Oban2 = value;
                OnPropertyChanged(nameof(IsEnableCut_Oban2));
            }
        }
        private bool _IsKhungNgang;
        public bool IsKhungNgang
        {
            get { return _IsKhungNgang; }
            set
            {
                _IsKhungNgang = value;
                OnPropertyChanged(nameof(IsKhungNgang));
            }
        }
        private bool _IsKhungDoc;
        public bool IsKhungDoc
        {
            get { return _IsKhungDoc; }
            set
            {
                _IsKhungDoc = value;
                OnPropertyChanged(nameof(IsKhungDoc));
            }
        }

        private bool _Is1Hang;
        public bool Is1Hang
        {
            get { return _Is1Hang; }
            set
            {
                _Is1Hang = value;
                OnPropertyChanged(nameof(Is1Hang));
            }
        }
        private bool _Is2Hang;
        public bool Is2Hang
        {
            get { return _Is2Hang; }
            set
            {
                _Is2Hang = value;
                OnPropertyChanged(nameof(Is2Hang));
            }
        }
        private bool _IsDeuNhau;
        public bool IsDeuNhau
        {
            get { return _IsDeuNhau; }
            set
            {
                _IsDeuNhau = value;
                OnPropertyChanged(nameof(IsDeuNhau));
            }
        }
        private bool _IsEnable_SLThanhHang2;
        public bool IsEnable_SLThanhHang2
        {
            get { return _IsEnable_SLThanhHang2; }
            set
            {
                _IsEnable_SLThanhHang2 = value;
                OnPropertyChanged(nameof(IsEnable_SLThanhHang2));
            }
        }

        private int _SLThanhHang2;
        public int SLThanhHang2
        {
            get { return _SLThanhHang2; }
            set
            {
                if (value % 2 == 0)
                {
                    _SLThanhHang2 = value;
                    OnPropertyChanged(nameof(SLThanhHang2));
                    //ThongBaoKhoangHoDam();
                }
                else
                {
                    MessageBox.Show("Số lượng thanh phải là số chẵn !");
                    return;
                }


            }
        }
        private string _ThongBaoKhoangHo;
        public string ThongBaoKhoangHo
        {
            get { return _ThongBaoKhoangHo; }
            set
            {
                _ThongBaoKhoangHo = value;
                OnPropertyChanged(nameof(ThongBaoKhoangHo));
            }
        }

        private int _SoHangThepGia;
        public int SoHangThepGia
        {
            get { return _SoHangThepGia; }
            set
            {
                _SoHangThepGia = value;
                OnPropertyChanged(nameof(SoHangThepGia));
            }
        }

        private bool _HaveRai100;
        public bool HaveRai100
        {
            get { return _HaveRai100; }
            set
            {
                _HaveRai100 = value;
                OnPropertyChanged(nameof(HaveRai100));
            }
        }

        private bool _IsEnable_Rai100;
        public bool IsEnable_Rai100
        {
            get { return _IsEnable_Rai100; }
            set
            {
                _IsEnable_Rai100 = value;
                OnPropertyChanged(nameof(IsEnable_Rai100));
            }
        }

        private string _KhoangHoThepCM;
        public string KhoangHoThepCM
        {
            get { return _KhoangHoThepCM; }
            set
            {
                _KhoangHoThepCM = value;
                OnPropertyChanged(nameof(KhoangHoThepCM));
            }
        }

        private string _TenMongLayOut;
        public string TenMongLayOut
        {
            get { return _TenMongLayOut; }
            set
            {
                _TenMongLayOut = value;
                OnPropertyChanged(nameof(TenMongLayOut));
            }
        }
        static ObservableCollection<ThongSoMongBan> lastListThongSoMong = null;
        private ObservableCollection<ThongSoMongBan> _ListThongSoMong;
        public ObservableCollection<ThongSoMongBan> ListThongSoMong
        {
            get { return _ListThongSoMong; }
            set
            {
                _ListThongSoMong = value;
                OnPropertyChanged(nameof(ListThongSoMong));
            }
        }
        private int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        private string _TenLayOut;
        public string TenLayOut
        {
            get { return _TenLayOut; }
            set
            {
                _TenLayOut = value;
                OnPropertyChanged(nameof(TenLayOut));
            }
        }
        private string _CurrentImageSource;

        public string CurrentImageSource
        {
            get { return _CurrentImageSource; }
            set { _CurrentImageSource = value; OnPropertyChanged(nameof(CurrentImageSource)); }
        }
        private string _ImgDam;
        public string ImgDam
        {
            get { return _ImgDam; }
            set
            {
                _ImgDam = value;
                OnPropertyChanged(nameof(ImgDam));
            }
        }
        private bool _IsEnableKhungDoc;
        public bool IsEnableKhungDoc
        {
            get { return _IsEnableKhungDoc; }
            set
            {
                _IsEnableKhungDoc = value;
                OnPropertyChanged(nameof(IsEnableKhungDoc));
            }
        }
        private bool _IsEnableKhungNgang;
        public bool IsEnableKhungNgang
        {
            get { return _IsEnableKhungNgang; }
            set
            {
                _IsEnableKhungNgang = value;
                OnPropertyChanged(nameof(IsEnableKhungNgang));
            }
        }

        private double _KC_Mep_DamCot;
        public double KC_Mep_DamCot
        {
            get { return _KC_Mep_DamCot; }
            set
            {
                _KC_Mep_DamCot = value;
                OnPropertyChanged(nameof(KC_Mep_DamCot));
            }
        }
        private bool _IsSturb;
        public bool IsSturb
        {
            get { return _IsSturb; }
            set
            {
                _IsSturb = value;
                OnPropertyChanged(nameof(IsSturb));
            }
        }

        private string _baseDir;
        private List<string> _imagePaths;

        private bool _IsDaiGia;
        public bool IsDaiGia
        {
            get { return _IsDaiGia; }
            set
            {
                _IsDaiGia = value;
                OnPropertyChanged(nameof(IsDaiGia));
            }
        }

        private bool _InSertDai;
        public bool InSertDai
        {
            get { return _InSertDai; }
            set
            {
                _InSertDai = value;
                OnPropertyChanged(nameof(InSertDai));
            }
        }
        private double _LechTamCoTop;
        public double LechTamCoTop
        {
            get { return _LechTamCoTop; }
            set
            {
                _LechTamCoTop = value;
                OnPropertyChanged(nameof(LechTamCoTop));
            }
        }

        private double _HDapMax;
        public double HDapMax
        {
            get { return _HDapMax; }
            set
            {
                _HDapMax = value;
                OnPropertyChanged(nameof(HDapMax));
            }
        }
        #region ICommand
        public ICommand VeAcadCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }
        public ICommand LoadKhungTenCommand { get; set; }
        public ICommand HaveBeamCommand { get; set; }
        public ICommand HaveLoiThepCommand { get; set; }
        public ICommand HaveCuTramCommand { get; set; }
        public ICommand HaveRai100Command { get; set; }
        public ICommand HaveDoiTrongCommand { get; set; }
        public ICommand HaveThangLeoCommand { get; set; }
        public ICommand HaveCutThepOban1Command { get; set; }

        public ICommand HaveCutThepOban2Command { get; set; }
        public ICommand BoTriThepDam1HangCommand { get; set; }
        public ICommand BoTriThepDam2HangCommand { get; set; }
        public ICommand HaveBoTriDeuNhauCommand { get; set; }
        public ICommand KhungA3DocCommand { get; set; }
        public ICommand KhungA3NgangCommand { get; set; }
        public ICommand HaveDaiDoThepGiaCommand { get; set; }

        #endregion
        public MongBanViewModel()
        {
            MongBanModel = new MongBanModel();
            TaskBarControlViewModel = new TaskBarControlViewModel();
            if (lastListThongSoMong != null)
            {
                ListThongSoMong = lastListThongSoMong;
            }
            else
            {
                ThongSoMongBan thongsoMongDefault = new ThongSoMongBan()
                {
                    #region Bản móng
                    TimMong = 4800,
                    TenMong = "MB4.82-10.5x11.5",
                    ChieuRongMong = 11500,
                    ChieuDaiMong = 10500,
                    ChieuCaoBan = 400,
                    DucLoMong = 1500,
                    DKThep_Oban_1 = 16,
                    KCThep_Oban_1 = 200,
                    DKThep_Oban_2 = 16,
                    KCThep_Oban_2 = 200,
                    DKThepChong = 12,
                    KCThepChong_Oban1 = 400,
                    KCThepChong_Oban2 = 400,
                    ChieuCaoDoiTrong = 500,
                    #endregion
                    #region Cổ móng
                    ChieuSauChonMong = 2000,
                    ChieuCaoCoMong = 1000,
                    RongCoMong_Top = 600,
                    RongCoMong_Bot = 600,
                    DKThepChu_CM = 18,
                    SLThepChu_CM = 5,
                    DKThepDai_CM = 8,
                    KCThepDai_CM = 250,
                    //KCRaiDai100 =1000,
                    DKThep_ThangLeo = 25,
                    #endregion
                    #region Dầm móng
                    ChieuCaoDam = 800,
                    ChieuRongDam = 500,
                    DKThepChu_Dam = 22,
                    SLThepChu_Dam = 6,
                    DKThepDai_Dam = 8,
                    KCThepDai_Dam = 300,
                    DKThepGia_Dam = 14,
                    #endregion
                    H_DemCat = 0,
                };
                _ListThongSoMong = new ObservableCollection<ThongSoMongBan> { thongsoMongDefault };
                _ThongSoMongBan = _ListThongSoMong[0];
            }
            _LayoutMongBanModel = new LayoutMongBanModel
            {
                SelectedMacBeTong = "B20",
                SelectedMacBTCoc = "B30",
                SelectedMacThep = "CB-400V",
                SelectedHuongTuyen = "ĐỠ THẲNG",
                SelectedGocLai = "BÊN TRÁI",
                KhoangHoCotThep = 50,
                SelectedScale_BangKhoiLuong = 100,
                Selected_Scale_Layout = 150,
                Selected_Scale_MBThep = 100,
                Selected_Scale_SC_Column = 25,
                Selected_Scale_Dam = 50,
                Selected_Scale_MatDungThep = 75,
                SelectedScaleNameDrawing = 100,
                BTBV_Day = 75,
                BTBV_Khac = 75,
                HacthScale = 30,
                Selected_GDTK = "TKKT",
                DuTruKL_BT = 0,
                DuTruKL_CotThep = 0,
                MaSoDuAn = "ĐD5-12-001D.XD.02A",
                SoBanVe = "1",
                MaSoDuAn_Detail = "ĐD5-12-001D.XD.04A",
                SoBanVe_Detail = "1",
                PathDwg = "",
                KhungA3 = "Khung ten",
                KhoangHo = 50,
                SelectedLoaiChong = "Thanh thẳng",
                SoThanCot = 1
            };
            #region image
            _baseDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ////LoadImages();
            //if (_imagePaths.Any())
            //{
            //    CurrentImageSource = _imagePaths[0];
            //    ImgDam = _imagePaths[1];

            //}
            #endregion
            //SetLayOutDefault();
            _HaveDoiTrong = false;
            VeAcadCommand = new RelayCommand<MongBanWindow>((p) => { return true; }, (p) =>
            {
                p.Hide();
                MainPoint = ClCAD.GetPointsFromUser("Chọn 1 điểm trên màn hình");
                TenLayOut = string.Format("{0}-{1}", "SĐM", ThongSoMongBan.TenMong);
                if (SetLayout.IsLayoutExist(TenLayOut))
                {
                    string thongbao = string.Format("Tên bản vẽ {0} đã tồn tại, hãy đặt 1 tên khác \nbằng cách đổi tên móng hoặc \nthay đổi chiều dài hoặc chiều rộng", TenLayOut);
                    MessageBox.Show(thongbao, "Thông báo");
                    return;
                }
                VeMatDung();
                VeMatBang();
                //BoTriThep();
                //ChenBangThongKeThep();
                //DienGiaiKhoiLuong();
                //SetLayoutBanVe();
                //ResetData();
            });

        }
        private void VeMatDung()
        {
            //Point3d pMd = new Point3d(MainPoint.X, PointsLayout.MaxMatBang.Y + 4000 * LayoutMongBanModel.Selected_Scale_Layout * 0.01, 0);
            Point3d pMd = new Point3d(MainPoint.X, MainPoint.Y + ThongSoMongBan.ChieuRongMong / 2 + 4000 * LayoutMongBanModel.Selected_Scale_Layout * 0.01, 0);

            if (ThongSoMongBan.RongCoMong_Top == ThongSoMongBan.RongCoMong_Bot) DrawMongBan.DrawMatDung_MongDungTam(pMd, ThongSoMongBan, LayoutMongBanModel,
                HaveDoiTrong, HeSoMai, HaveThangLeo, LayoutMongBanModel.SoThanCot, HDapMax);
            else DrawMongBan.DrawMatDung_MongLechTam(pMd, ThongSoMongBan, LayoutMongBanModel, HaveDoiTrong, HeSoMai,
                HaveThangLeo, KC_Mep_DamCot, LayoutMongBanModel.SoThanCot, LechTamCoTop, HDapMax);
        }

        private void VeMatBang()
        {
            if (ThongSoMongBan.RongCoMong_Top == ThongSoMongBan.RongCoMong_Bot) DrawMongBan.DrawMatBangMongDungTam(MainPoint, ThongSoMongBan, LayoutMongBanModel, HaveDoiTrong);
            else DrawMongBan.DrawMatBangMongLechTam(MainPoint, ThongSoMongBan, LayoutMongBanModel, HaveDoiTrong, KC_Mep_DamCot, LechTamCoTop);
        }
    }
}
