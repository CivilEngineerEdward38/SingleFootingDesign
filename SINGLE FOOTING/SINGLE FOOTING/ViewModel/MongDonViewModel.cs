using ACAD.SINGLE_FOOTING.Model;
using ACAD_API.SINGLE_FOOTING;
using ACAD_API.SINGLE_FOOTING.Model;
using ACAD_API.SINGLE_FOOTING.View;
using ACAD_API.SINGLE_FOOTING.ViewModel;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace ACAD_API.SINGLE_FOOTING.ViewModel
{
    public class MongDonViewModel : BaseViewModel
    {
        // lấy hết class con qua 
        private TaskBarControlViewModel _taskBarControlViewModel;

        public TaskBarControlViewModel TaskBarControlViewModel
        {
            get { return _taskBarControlViewModel; }
            set { _taskBarControlViewModel = value; OnPropertyChanged(); }
        }
        private RebarViewModel _rebarViewModel;

        public RebarViewModel RebarViewModel
        {
            get { return _rebarViewModel; }
            set { _rebarViewModel = value; OnPropertyChanged(); }
        }

        private GhiChuViewModel _ghiChuViewModel;

        public GhiChuViewModel GhiChuViewModel
        {
            get { return _ghiChuViewModel; }
            set { _ghiChuViewModel = value; OnPropertyChanged(); }
        }
        private SettingViewModel _settingViewModel;

        public SettingViewModel SettingViewModel
        {
            get { return _settingViewModel; }
            set { _settingViewModel = value; OnPropertyChanged(); }
        }

        private BaseViewModel _menuCacUserControl;    //user control 

        public BaseViewModel MenuCacUserControl
        {
            get { return _menuCacUserControl; }
            set { _menuCacUserControl = value; OnPropertyChanged(); }
        }

        //reusability các variable class SingleFootingModel
        private SingleFootingModel _singleFootingModel;

        public SingleFootingModel SingleFootingModel
        {
            get { return _singleFootingModel; }
            set { _singleFootingModel = value; OnPropertyChanged(); }
        }

        //điểm đặt vẽ 
        private Point3d _mainPoint;

        public Point3d MainPoint
        {
            get { return _mainPoint; }
            set { _mainPoint = value; OnPropertyChanged(); }
        }



        #region Icommand
        public ICommand ChuyenManHinhCommand { get; set; }
        public ICommand VeMongCommand { get; set; }
        
        #endregion
        public MongDonViewModel()
        {
            SingleFootingModel = new SingleFootingModel();
            SettingViewModel = new SettingViewModel(SingleFootingModel); //khởi tạo một object SettingViewModel và gàn vào biến SettingViewModel
            GhiChuViewModel = new GhiChuViewModel();
            RebarViewModel = new RebarViewModel(SingleFootingModel);
            TaskBarControlViewModel = new TaskBarControlViewModel();
            MenuCacUserControl = SettingViewModel;
            // khởi tạo lệnh ChuyenManHinhCommand với một RelayCommand, trong đó có hai tham số: một hàm kiểm tra điều kiện thực thi và một hàm thực thi lệnh. Hàm kiểm tra điều kiện thực thi luôn trả về true, có nghĩa là lệnh luôn có thể được thực thi. Hàm thực thi lệnh sẽ kiểm tra giá trị của SelectedIndex của MenuSelectionChanged trong đối tượng p (có kiểu WinDowSingleFooting) và gán MenuCacUserControl tương ứng với giá trị đó. 
            
            ChuyenManHinhCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p) =>
            {
                switch (p.MenuSelectionChanged.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("Bạn đang ở SettingViewModel");
                        MenuCacUserControl = SettingViewModel;
                        break;
                    case 1:
                        MessageBox.Show("Bạn đang ở RebarViewModel");
                        MenuCacUserControl = RebarViewModel;
                        break;

                }
            });
            VeMongCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p) =>
            {
                p.Hide();
                MainPoint = ClCAD.GetPointsFromUser("Chọn 1 điểm bất kì trên màn hình");
                VeMongDon();
            });
        }

        private void VeMongDon()
        {
            double heSo = 1000.0 / SingleFootingModel.SettingModel.ChonTyLe;

            double khoangCach = 1.5;      // cách mặt bằng 1.5m thực

            double maxKT = Math.Max(
                SingleFootingModel.SettingModel.BmHm,
                SingleFootingModel.SettingModel.BmHm);

            Point3d pMatBang = MainPoint;

            Point3d pMatDung = new Point3d(
                MainPoint.X,
                MainPoint.Y + (maxKT + khoangCach) * heSo,
                0);

            SingleFootingModel.SettingModel.VeMatBangMongCoThang(pMatBang);
            SingleFootingModel.SettingModel.VeMatDungMongCoThang(pMatDung);
            SingleFootingModel.RebarModel.VeThepMatDungMongCoThang(pMatDung, SingleFootingModel.SettingModel.BTBVDay, SingleFootingModel.SettingModel.BTBVConLai, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BcHc, SingleFootingModel.SettingModel.Hb, SingleFootingModel.SettingModel.Hv, SingleFootingModel.SettingModel.Hm, SingleFootingModel.SettingModel.D, SingleFootingModel.RebarModel.DuongKinhThepBan, SingleFootingModel.RebarModel.KhoangCachThepBan, SingleFootingModel.SettingModel.ChonTyLe);

        }
    }

}


