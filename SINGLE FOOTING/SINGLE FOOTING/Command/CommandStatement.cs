using ACAD_API.SINGLE_FOOTING.View;
using ACAD_API.SINGLE_FOOTING.ViewModel;

using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandStatement
{
    [CommandMethod("DSF")]
    public void DSF()
    {
        // Tạo một đối tượng của lớp WinDowSingleFooting và hiển thị nó
        MongDonViewModel VMD = new MongDonViewModel();  
        WinDowSingleFooting window = new WinDowSingleFooting(VMD);   
        window.ShowDialog();
    }
}

