using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Data;
using System.Windows.Media;
namespace MONGDUONGDAY.Library.WPF.Converter
{
    public class StringContentToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string content = value.ToString();
                return content.Contains("OK") ? "#00FF00" : "#ff0000";
            }
            return "#000000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        /*Hàm StringContentToColor trong đoạn mã trên là một WPF Value Converter(trình chuyển đổi giá trị trong giao diện WPF).
        Nó được dùng để tự động đổi màu sắc của giao diện dựa trên nội dung dạng chữ(chuỗi) được truyền vào.
        Cách hoạt động cụ thể:
        Trả về màu Xanh lá(#00FF00): Nếu chuỗi truyền vào có chứa từ "OK".
        Trả về màu Đỏ (#ff0000): Nếu chuỗi truyền vào không chứa từ "OK" (ví dụ: chữ "Error", "Fail", hoặc bất kỳ chữ nào khác).
        Trả về màu Đen (#000000): Nếu giá trị truyền vào là null (rỗng/không có dữ liệu).
        ConvertBack: Bị ném lỗi NotImplementedException vì đây là chuyển đổi một chiều (chỉ dùng để hiển thị lên giao diện, không cần chuyển ngược lại từ màu sang chữ).
        Ứng dụng thực tế:
        Hàm này thường được gắn vào thuộc tính Foreground(màu chữ) hoặc Background(màu nền) của một thẻ WPF(như TextBlock, Label) thông qua Binding để làm nổi bật trạng thái:
        Hiển thị màu xanh khi thiết bị / hệ thống báo trạng thái "OK".
        Hiển thị màu đỏ khi gặp sự cố hoặc báo lỗi.*/
    }
}