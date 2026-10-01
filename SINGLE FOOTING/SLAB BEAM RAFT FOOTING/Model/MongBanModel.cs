using MONGDUONGDAY.MongBan.Model;
using SINGLE_FOOTING.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAD_API.SLAB_BEAM_RAFT_FOOTING.Model
{
    public class MongBanModel: BaseViewModel
    {
        private LayoutMongBanModel _layoutMongBanModel;
        public LayoutMongBanModel LayoutMongBanModel
        {
            get { return _layoutMongBanModel; }
            set
            {
                _layoutMongBanModel = value;
                OnPropertyChanged(nameof(LayoutMongBanModel));
            }
        }
        public MongBanModel()
        {
            LayoutMongBanModel = new LayoutMongBanModel();
            ClMain.SetDefault();
        }
    }
}
