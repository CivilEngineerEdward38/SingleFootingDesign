using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAD_API.SINGLE_FOOTING.Model
{
    public class SettingModel : BaseViewModel
    {
        private double _bMhM;

        public double BmHm
        {
            get { return _bMhM; }
            set { _bMhM = value; OnPropertyChanged(); }
        }
        private double _hM;

        public double Hm
        {
            get { return _hM; }
            set { _hM = value; OnPropertyChanged(); }
        }
        private double _d;

        public double D
        {
            get { return _d; }
            set { _d = value; OnPropertyChanged(); }
        }
        private double _bChC;

        public double BcHc
        {
            get { return _bChC; }
            set { _bChC = value; OnPropertyChanged(); }
        }
        private double _hB;

        public double Hb
        {
            get { return _hB; }
            set { _hB = value; OnPropertyChanged(); }
        }
        private double _hV;

        public double Hv
        {
            get { return _hV; }
            set { _hV = value; OnPropertyChanged(); }
        }
        private double _btbvDay;

        public double BTBVDay
        {
            get { return _btbvDay; }
            set { _btbvDay = value; OnPropertyChanged(); }
        }
        private double _btbvConLai;

        public double BTBVConLai
        {
            get { return _btbvConLai; }
            set { _btbvConLai = value; OnPropertyChanged(); }
        }
        private List<int> _tyLeBV;

        public List<int> TyLeBV
        {
            get { return _tyLeBV; }
            set { _tyLeBV = value; OnPropertyChanged(); }
        }
        private int _chonTyLe;

        public int ChonTyLe
        {
            get { return _chonTyLe; }
            set { _chonTyLe = value; OnPropertyChanged(); }
        }
        private double _hatchScale;

        public double HatchScale
        {
            get { return _hatchScale; }
            set { _hatchScale = value; OnPropertyChanged(); }
        }
        #region RadioButton
        private bool _typeofA;

        public bool TypeOfA
        {
            get { return _typeofA; }
            set { _typeofA = value; OnPropertyChanged(); }
        }
        private bool _typeofB;
        public bool TypeOfB
        {
            get { return _typeofB; }
            set { _typeofB = value; OnPropertyChanged(); }
        }

        #endregion

        public SettingModel()
        {
            //Initialization : khởi tạo các giá trị đầu vào default trong constructor 
            BmHm = 4.0;
            Hm = 3.4;
            D = 0.5;
            BcHc = 0.8;
            Hb = 1.0;
            Hv = 0.4;
            BTBVDay = 50;
            BTBVConLai = 40;
            TyLeBV = new List<int> { 25, 50, 75, 100, 150, 200 };
            ChonTyLe = TyLeBV[3];
            HatchScale = 5;
            //initial type of Singlefooting
            TypeOfA = true;
            TypeOfB = false;
        }
    }
}
