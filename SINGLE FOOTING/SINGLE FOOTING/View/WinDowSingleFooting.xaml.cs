using ACAD_API.SINGLE_FOOTING.ViewModel;
using System;
using System.Collections.Generic;
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

namespace ACAD_API.SINGLE_FOOTING.View
{
    /// <summary>
    /// Interaction logic for WinDowSingleFooting.xaml
    /// </summary>
    
    public partial class WinDowSingleFooting : Window //window này từ đâu? Window là một lớp cơ sở trong WPF (Windows Presentation Foundation) dùng để tạo ra các cửa sổ giao diện người dùng. Khi bạn tạo một lớp mới kế thừa từ Window, bạn đang tạo ra một cửa sổ mới trong ứng dụng WPF của mình. Trong trường hợp này, WinDowSingleFooting là một cửa sổ được thiết kế để hiển thị giao diện người dùng cho tính năng "Single Footing" trong ứng dụng của bạn.
    {
        //_viewModel với kiểu dữ liệu MongDonViewModel, để lưu trữ 
        //Trong hàm constructor tạo một tham số VModel với MongDonViewModel là kiểu dữ liệu. 
        private MongDonViewModel _viewModel;
        public WinDowSingleFooting(MongDonViewModel VModel) 
        {
           
            InitializeComponent(); //khởi tạo giao diện
            _viewModel = VModel; //gán tham số VModel vào biến _viewModel
            DataContext = _viewModel;  
        }
    }
}
