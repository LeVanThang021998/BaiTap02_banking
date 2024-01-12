using System.Security.Cryptography;

namespace BaiTap02_banking
{
    class SanPham
    {
        private string _ten;
        private double _giamua;
        public SanPham() { }
        public SanPham(string ten, double giamua)
        {
            this._ten = ten;
            this._giamua = giamua;
        }
        public string ten
        {
            set { this._ten = value; }
            get { return _ten; }
        }
        public double giamua
        {
            set
            {
                if (value >= 0)
                    this._giamua = value;
            }
            get { return _giamua; }
        }
        public virtual double TinhGiaBan()
        { return 0; }
        public virtual string InChiTiet()
        {
            return _ten;
        }
        public virtual void Nhap()
        {
            Console.Write("Cho biet ten san pham: ");
            _ten = Console.ReadLine();
            Console.Write("Cho biet gia mua: ");
            _giamua = double.Parse(Console.ReadLine());
        }
    }
    class Socola : SanPham
    {
        private double _loinhuan;
        public Socola() { }
        public Socola(string ten, double giamua) : base(ten, giamua)
        {
            _loinhuan = giamua * 0.20;
        }
        public override double TinhGiaBan()
        {
            return giamua + _loinhuan;
        }
        public override string InChiTiet()
        {
            return ten + " - " + giamua;
        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuan = giamua * 0.2;
        }
    }
    class NuocUong: SanPham
    {
        private double _loinhuan;
        private double _ChiPhiGiuLanh;
        public NuocUong() { }
        public NuocUong(string ten, double giamua) : base(ten, giamua)
        {
            _loinhuan = giamua * 0.15;
            _ChiPhiGiuLanh = giamua * 0.1;
        }
        public override double TinhGiaBan()
        {                
            return giamua + _loinhuan + _ChiPhiGiuLanh;
        }
        public override string InChiTiet()
        {
            return ten + " - " + TinhGiaBan;
        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuan = giamua * 0.2;
        }
    }
    class QuanLySanPham
    {
        private string _ten;
        private SanPham[] dssp;
        private int n;
        public QuanLySanPham()
        {
            _ten = "Cua hang ban le";
            dssp = new SanPham[100];
            n = 0;
        }

        public QuanLySanPham(int size)
        {
            _ten = "Cua hang ban le";
            dssp = new SanPham[size];
            n = 0;
        }
        public void Nhap()
        {
            int chon;
            SanPham sp;
            while (true)
            {
                Console.Write("Ban muon them san pham loai nao(1.Socola - 2.Nuoc uong: ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        sp = new SanPham();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                    case 2:
                        sp = new NuocUong();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                }
                Console.Write("Ban co tiep tuc khong? (0. Thoat):");
                chon = int.Parse(Console.ReadLine());
                if (chon == 0)
                    break;
            }
        }
        public void InDanhSachSP()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(dssp[i].InChiTiet());
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            QuanLySanPham q1 = new QuanLySanPham();
            q1.Nhap();
            q1.InDanhSachSP();
            Console.ReadLine();
        }
    }
}
