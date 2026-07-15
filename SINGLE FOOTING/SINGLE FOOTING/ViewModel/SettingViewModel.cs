using ACAD.SINGLE_FOOTING.Model;
using ACAD_API.SINGLE_FOOTING.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ACAD_API.SINGLE_FOOTING.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        private SingleFootingModel _singleFootingModel;

        public SingleFootingModel SingleFootingModel
        {
            get { return _singleFootingModel; }
            set { _singleFootingModel = value; OnPropertyChanged(); }
        }
        #region Command
        public ICommand LoadSettingViewCommand { get; set; }  //load sự kiện 
        public ICommand MongTruCoThangClickCommand { get; set; }  //sự kiện click đổi canvas 
        public ICommand MongTruCoMoRongClickCommand { get; set; }  //sự kiện click đổi canvas 

        public RelayCommand<WinDowSingleFooting> MongLechTam2PhuongCommand { get; }
        #endregion


        public SettingViewModel(SingleFootingModel singleFootingModel)
        {
            SingleFootingModel = singleFootingModel;
            // Utility  class findchild 
            LoadSettingViewCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p) =>
            {
                SettingView uc = FindChildClass.FindChild<SettingView>(p, "SettingUC");
                DrawSettingCanvasMB(uc);
                DrawSettingCanvasMD(uc);
            });
            MongTruCoThangClickCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p) =>
            {
                SettingView uc = FindChildClass.FindChild<SettingView>(p, "SettingUC");
                uc.MatBangMong.Children.Clear(); // x:name trong settingView Canvas 
                uc.MatDungMong.Children.Clear();
                DrawSettingCanvasMB(uc);
                DrawSettingCanvasMD(uc);

            });
            MongTruCoMoRongClickCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p) =>
            {
                SettingView uc = FindChildClass.FindChild<SettingView>(p, "SettingUC");
                uc.MatBangMong.Children.Clear();
                uc.MatDungMong.Children.Clear();
                DrawSettingCanvasMB(uc);
                DrawSettingCanvasMD(uc);

            });
        }
        private void DrawSettingCanvasMD(SettingView uc)
        {
            if (SingleFootingModel.SettingModel.TypeOfA)
            {
                DrawCanvas.VeMatDungMongCoThang(uc.MatDungMong, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BcHc, SingleFootingModel.SettingModel.Hm, SingleFootingModel.SettingModel.Hb, SingleFootingModel.SettingModel.Hv, SingleFootingModel.SettingModel.D);
            }
            else
            {
                DrawCanvas.VeMatDungCoMongMoRong(uc.MatDungMong, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BcHc, SingleFootingModel.SettingModel.Hm, SingleFootingModel.SettingModel.Hb, SingleFootingModel.SettingModel.Hv, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BmHm);
            }

        }
        private void DrawSettingCanvasMB(SettingView uc)
        {
            if (SingleFootingModel.SettingModel.TypeOfA)
            {
                DrawCanvas.VeMatBangMongCoThang(uc.MatBangMong, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BcHc, SingleFootingModel.SettingModel.BcHc);
            }
            else if (SingleFootingModel.SettingModel.TypeOfB)
            {

                DrawCanvas.VeMatBangMongCoMoRong(uc.MatBangMong, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BcHc, SingleFootingModel.SettingModel.BcHc);
            }

        }

    }
}

