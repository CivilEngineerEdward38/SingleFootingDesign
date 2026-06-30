using ACAD_API.SINGLE_FOOTING;
using ACAD_API.SINGLE_FOOTING.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAD.SINGLE_FOOTING.Model
{
    public class SingleFootingModel : BaseViewModel
    {
		private SettingModel _settingModel;   //reusability các variable class SettingModel

        public SettingModel SettingModel
		{
			get { return _settingModel; }
			set { _settingModel = value; OnPropertyChanged(); }
		}
		public SingleFootingModel()
		{
			SettingModel = new SettingModel();
		}

	}
}
