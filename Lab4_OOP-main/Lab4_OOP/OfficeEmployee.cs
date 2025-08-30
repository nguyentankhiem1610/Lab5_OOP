using System;
namespace Lab4_OOP
{
    public class OfficeEmployee : INhanVien
    {
        private string nhanVien;
        private double luongCoBan;
        private double heSoLuong;
        private double phuCapUuDai;
        private int soGioNgoaiHanhChinh;

        public OfficeEmployee(string nhanVien, double luongCoBan, double heSoLuong, double phuCapUuDai, int soGioNgoaiHanhChinh)
        {
            this.nhanVien = nhanVien;
            this.luongCoBan = luongCoBan;
            this.heSoLuong = heSoLuong;
            this.phuCapUuDai = phuCapUuDai;
            this.soGioNgoaiHanhChinh = soGioNgoaiHanhChinh;
        }
        public double TinhLuong()
        {
            return luongCoBan * (heSoLuong + phuCapUuDai);
        }

        public double TinhThuong()
        {
            return soGioNgoaiHanhChinh * 100000;
        }

        public double TinhThue()
        {
            double luong = TinhLuong();
            double thue = 0;
            if (luong > 10000000)
            {
                if (luong <= 20000000)
                {
                    // Đóng thuế 10% cho phần vượt 10 triệu
                    thue = (luong - 10000000) * 0.1;
                }
                else
                {
                    // Đóng thuế 10% cho phần từ 10-20 triệu và 15% cho phần vượt 20 triệu
                    thue = (20000000 - 10000000) * 0.1 + (luong - 20000000) * 0.15;
                }
            }
            return thue;
        }

        public string Print()
        {
            return $"Nhân Viên: {nhanVien}\n" +
            $" Hệ số lương: {heSoLuong}, lương cơ bản : {luongCoBan:N0} VNĐ, phụ cấp Ưu đãi: {phuCapUuDai*100}% \n" +
            $" (Số giờ làm ngoài giờ hành chính: {soGioNgoaiHanhChinh})\n " +
            $"-Lương: {TinhLuong():N0} VNĐ\n -Thưởng: {TinhThuong():N0} VNĐ\n -Thuế: {TinhThue():N0} VNĐ \n" +
            $"  => Tổng nhận: {(TinhLuong() + TinhThuong() - TinhThue()):N0} VNĐ \n " +
            $"-----------------------------------------------------";

        }
    }
}