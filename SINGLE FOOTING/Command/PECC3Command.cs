using ACAD_API.SINGLE_FOOTING.View;
using ACAD_API.SINGLE_FOOTING.View;
using ACAD_API.SINGLE_FOOTING.ViewModel;
using ACAD_API.SINGLE_FOOTING.ViewModel;
using ACAD_API.SLAB_BEAM_RAFT_FOOTING.View;
using ACAD_API.SLAB_BEAM_RAFT_FOOTING.ViewModel;
using ACAD_API.XData;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PECC3Command
{
    [CommandMethod("S1")]
    public void VeMongBan()
    {
        ClCAD.AddRegAppTableRecord(XDataMong.nameXData_BangTHThep);
        MongBanViewModel viewModel = new MongBanViewModel();
        MongBanWindow mongBanWindow = new MongBanWindow(viewModel);
        mongBanWindow.ShowDialog();
        //LicenseGuard.Run(() =>
        //{
        //ClCAD.AddRegAppTableRecord(XDataMong.nameXData_BangTHThep);
        //MongBanViewModel viewModel = new MongBanViewModel();
        //MongBanWindow mongBanWindow = new MongBanWindow(viewModel);
        //mongBanWindow.ShowDialog();
        //});
        //new MongBanWindow() { DataContext = new MongBanViewModel() }.ShowDialog();
    }
}

