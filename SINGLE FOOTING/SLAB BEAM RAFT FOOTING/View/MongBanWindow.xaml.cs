using ACAD_API.SLAB_BEAM_RAFT_FOOTING.ViewModel;
using ACAD_API.SLAB_BEAM_RAFT_FOOTING.Model;
using ACAD_API.SLAB_BEAM_RAFT_FOOTING.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ACAD_API.SLAB_BEAM_RAFT_FOOTING.View
{
    /// <summary>
    /// Interaction logic for MongBanWindow.xaml
    /// </summary>
    public partial class MongBanWindow : Window
    {
        private MongBanViewModel _viewModel;
        public MongBanWindow(MongBanViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = viewModel;
            LoadData();
        }
        private void LoadData()
        {
            string filePath = "DataMongBanSaveEditF.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length > 17)
                {
                    //MongBanViewModel _viewModel = this.DataContext as MongBanViewModel;
                    _viewModel.LayoutMongBanModel.SelectedMacBeTong = lines[0];
                    _viewModel.LayoutMongBanModel.SelectedMacThep = lines[1];
                    _viewModel.LayoutMongBanModel.SelectedHuongTuyen = lines[2];
                    _viewModel.LayoutMongBanModel.SelectedGocLai = lines[3];
                    _viewModel.LayoutMongBanModel.Selected_GDTK = lines[4];
                    _viewModel.LayoutMongBanModel.SelectedMacBTCoc = lines[5];

                    _viewModel.LayoutMongBanModel.MaSoDuAn = lines[6];
                    _viewModel.LayoutMongBanModel.SoBanVe = lines[7];

                    if (double.TryParse(lines[8], out double btbvDay))
                        _viewModel.LayoutMongBanModel.BTBV_Day = btbvDay;
                    if (double.TryParse(lines[9], out double btbvKhac))
                        _viewModel.LayoutMongBanModel.BTBV_Khac = btbvKhac;
                    if (double.TryParse(lines[10], out double dutruBT))
                        _viewModel.LayoutMongBanModel.DuTruKL_BT = dutruBT;
                    if (double.TryParse(lines[11], out double dutruCT))
                        _viewModel.LayoutMongBanModel.DuTruKL_CotThep = dutruCT;
                    if (double.TryParse(lines[12], out double khHoCT))
                        _viewModel.LayoutMongBanModel.KhoangHoCotThep = khHoCT;
                    _viewModel.LayoutMongBanModel.SelectedLoaiChong = lines[13];
                    if (bool.TryParse(lines[14], out bool isKhungDoc))
                        _viewModel.IsKhungDoc = isKhungDoc;

                    if (bool.TryParse(lines[15], out bool isKhungNgang))
                        _viewModel.IsKhungNgang = isKhungNgang;

                    if (double.TryParse(lines[16], out double hsomai))
                        _viewModel.HeSoMai = hsomai;

                    if (int.TryParse(lines[17], out int sohang))
                        _viewModel.SoHangThepGia = sohang;

                    if (double.TryParse(lines[18], out double Scale_MBThep))
                        _viewModel.LayoutMongBanModel.Selected_Scale_MBThep = Scale_MBThep;

                    if (double.TryParse(lines[19], out double Scale_Layout))
                        _viewModel.LayoutMongBanModel.Selected_Scale_Layout = Scale_Layout;

                    if (double.TryParse(lines[20], out double Scale_SC_Column))
                        _viewModel.LayoutMongBanModel.Selected_Scale_SC_Column = Scale_SC_Column;

                    if (double.TryParse(lines[21], out double Scale_Dam))
                        _viewModel.LayoutMongBanModel.Selected_Scale_Dam = Scale_Dam;

                    if (double.TryParse(lines[22], out double Scale_MatDungThep))
                        _viewModel.LayoutMongBanModel.Selected_Scale_MatDungThep = Scale_MatDungThep;
                    if (double.TryParse(lines[23], out double kcmep))
                        _viewModel.KC_Mep_DamCot = kcmep;
                    if (double.TryParse(lines[24], out double lechtamco))
                        _viewModel.LechTamCoTop = lechtamco;

                    _viewModel.LayoutMongBanModel.MaSoDuAn_Detail = lines[25];
                    _viewModel.LayoutMongBanModel.SoBanVe_Detail = lines[26];
                    if (bool.TryParse(lines[27], out bool isDaiGia))
                        _viewModel.IsDaiGia = isDaiGia;
                    if (bool.TryParse(lines[28], out bool isInsert))
                        _viewModel.InSertDai = isInsert;

                    if (double.TryParse(lines[29], out double hatch))
                        _viewModel.LayoutMongBanModel.HacthScale = hatch;
                }
            }
        }

    }
}
