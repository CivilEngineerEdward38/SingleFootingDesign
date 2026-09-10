using ACAD_API.SLAB_BEAM_RAFT_FOOTING.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ACAD_API.SLAB_BEAM_RAFT_FOOTING.ViewModel
{
    public class TaskBarControlViewModel : BaseViewModel
    {
        #region ICommand 
        public ICommand GotoWebCommand { get; set; }
        public ICommand MouseLeftButtonDownCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        #endregion
        public TaskBarControlViewModel()
        {
            GotoWebCommand = new RelayCommand<MongBanWindow>((p) => { return true; }, (p) =>
            {
                string navigateUri = "https://pecc2.com/vn/trang-chu.html";
                Process.Start(navigateUri);
            });
            MouseLeftButtonDownCommand = new RelayCommand<MongBanWindow>((p) => { return true; }, (p) =>
            {
                p.DragMove();
            });
            ClosedWindowCommand = new RelayCommand<MongBanWindow>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
        }
    }
}
