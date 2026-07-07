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
        #endregion


        public SettingViewModel(SingleFootingModel singleFootingModel)
        {
            SingleFootingModel = singleFootingModel;
            // Utility  class findchild 
            LoadSettingViewCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; } , (p) => {
                SettingView uc = FindChildClass.FindChild<SettingView>(p, "SettingUC");
                DrawSettingCanvasMB(uc);
            });
        }

        private void DrawSettingCanvasMB(SettingView uc)
        {
            DrawCanvas.DrawMatBang(uc.MatBangMong, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BmHm, SingleFootingModel.SettingModel.BcHc, SingleFootingModel.SettingModel.BcHc);
        }
    }
}

