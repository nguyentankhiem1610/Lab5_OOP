using System.Dynamic;

namespace Lab4_OOP
{
    public class TempEmployee : INhanVien
    {
        private string nhanVien;
        private int soNgayLam;
        private double donGia;
        private int soGioThucLam;

        public TempEmployee(string nhanVien, int soNgayLam, double donGia, int soGioThucLam)
        {
            this.nhanVien = nhanVien;
            this.soNgayLam = soNgayLam;
            this.donGia = donGia;
            this.soGioThucLam = soGioThucLam;
        }
        public double TinhLuong()
        {
            return soNgayLam * donGia;
        }

        public double TinhThue()
        {
            double luong = TinhLuong();
            double thue = 0;

            if (luong > 10000000)
            {
                thue = (luong - 10000000) * 0.15;
            }
            return thue;
        }

        public double TinhThuong()
        {
            double thuong = 0;
            if (soGioThucLam > 200)
            {
                thuong = (soGioThucLam - 200) * 50000;
            }
            return thuong;
        }

        public string Print()
        {
            return $"Nhân Viên: {nhanVien}\n" +
            $" Số ngày làm: {soNgayLam}, Đơn giá :{donGia:N0} VNĐ \n" +
            $" (Số giờ Thực làm: {soGioThucLam})\n " +
            $"-Lương: {TinhLuong():N0} VNĐ\n -Thưởng: {TinhThuong():N0} VNĐ\n -Thuế: {TinhThue():N0} VNĐ \n " +
            $"  => Tổng nhận: {(TinhLuong() + TinhThuong() - TinhThue()):N0} VNĐ\n " +
            $"-----------------------------------------------------";

        }
    }
}