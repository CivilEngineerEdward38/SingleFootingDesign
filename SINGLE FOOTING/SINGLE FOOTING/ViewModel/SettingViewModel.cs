using ACAD.SINGLE_FOOTING.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public SettingViewModel(SingleFootingModel singleFootingModel)
        {
            SingleFootingModel = singleFootingModel;
        }
    }
}

