using ACAD_API.SINGLE_FOOTING;
using ACAD_API.SINGLE_FOOTING.Model;
using SINGLE_FOOTING.SINGLE_FOOTING.Model;
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
		//đưa con vào cha để binding 
		private RebarModel _reBarModel;

		public RebarModel RebarModel
        {
			get { return _reBarModel; }
			set { _reBarModel = value; OnPropertyChanged(); }
		}

		public SingleFootingModel()
		{
			SettingModel = new SettingModel(); //khởi tạo setting model 
            RebarModel = new RebarModel();  //khởi tạo rebarmodel 
			SettingModel.CreateLayer();
			SettingModel.CreateTextStyle(); // phải chạy trước
            SettingModel.CreateDimStyle(SettingModel.TyLeBV);// dùng chung 1 danh sách duy nhất
        }

    }
}
