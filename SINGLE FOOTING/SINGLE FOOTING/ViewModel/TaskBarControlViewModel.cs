using ACAD_API.SINGLE_FOOTING.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ACAD_API.SINGLE_FOOTING.ViewModel
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
            GotoWebCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p)=>{

                string navigateUri = "https://www.youtube.com/@luongluongofficial5256";
                Process.Start(navigateUri);
            });
            MouseLeftButtonDownCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p) => {
                p.DragMove();
            });
            ClosedWindowCommand = new RelayCommand<WinDowSingleFooting>((p) => { return true; }, (p) => {
               p.Close();
            });
        }
    }
}
