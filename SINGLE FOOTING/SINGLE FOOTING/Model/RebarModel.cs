using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINGLE_FOOTING.SINGLE_FOOTING.Model
{
    public class RebarModel : BaseViewModel
    {
        private List<int> _allDuongKinhThep;

        public List<int> AllDuongKinhThep
        {
            get { return _allDuongKinhThep; }
            set { _allDuongKinhThep = value; OnPropertyChanged(); }
        }
        private int _duongKinhThepBan;

        public int DuongKinhThepBan
        {
            get { return _duongKinhThepBan; }
            set { _duongKinhThepBan = value; OnPropertyChanged(); }
        }
        private double _khoangCachThepBan;

        public double KhoangCachThepBan
        {
            get { return _khoangCachThepBan; }
            set { _khoangCachThepBan = value; OnPropertyChanged(); }
        }

        private int _duongKinhThepCoMong;

        public int DuongKinhThepCoMong
        {
            get { return _duongKinhThepCoMong; }
            set { _duongKinhThepCoMong = value; OnPropertyChanged(); }
        }
        private int _slThepCoMong;

        public int SLThepCoMong
        {
            get { return _slThepCoMong; }
            set { _slThepCoMong = value; OnPropertyChanged(); }
        }
        private int _duongKinhThepDai;

        public int DuongKinhThepDai
        {
            get { return _duongKinhThepDai; }
            set { _duongKinhThepDai = value; OnPropertyChanged(); }
        }
        private double _khoangCachRaiDai;

        public double KhoangCachRaiDai
        {
            get { return _khoangCachRaiDai; }
            set { _khoangCachRaiDai = value; OnPropertyChanged(); }
        }
        private string _ghiChuSLThepCm;

        public string GhiChuSLThepCm
        {
            get { return _ghiChuSLThepCm; }
            set { _ghiChuSLThepCm = value; OnPropertyChanged(); }
        }
        public RebarModel()
        {
            AllDuongKinhThep = new List<int> { 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32 };
            DuongKinhThepBan = AllDuongKinhThep[2];
            KhoangCachThepBan = 200;
            DuongKinhThepCoMong = AllDuongKinhThep[6];
            SLThepCoMong = 24;
            DuongKinhThepDai = AllDuongKinhThep[0];
            KhoangCachRaiDai = 200;
        }


    }
}
