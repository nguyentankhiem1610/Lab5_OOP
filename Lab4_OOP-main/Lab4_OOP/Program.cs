/*1 interface INhanVien có các phương thức sau:
 * - TinhLuong(): Tính lương của nhân viên 
 * - TinhThuong(): Tính khoảng tiền thưởng (trong tháng) của nhân viên 
 * - TinhThue(): Tính thuế tạm thu trong tháng 
 * 1 lớp OfficeEmployee thực thi interface INhanVien và thực thi các phương thức của interface đó:
 * - Lương = lương cơ bản * (hệ số lương + phụ cấp ưu đãi)
 * - Tính thưởng dựa trên số giờ làm (ngoài giờ hành chính) với mức thưởng 100.000 đồng/giờ
 * - Tính thuế : Nếu lương > 10.000.000 đồng và < 20.000.000 đồng thì thuế suất 10% số dư vượt 10.000.000 đồng,
 * từ mức trên đến 20.000.000 đồng thì thuế suất 15% số dư vượt 20.000.000 đồng (phần nằm giữa 10.000.000 và 20.000.000 đồng vẫn đóng thế 10%)
 * 1 Lớp TempEmployee thực thi interface IEmployee :
 * - Lương = Số ngày thực làm * đơn giá, 
 * - Tính thưởng: Nếu số giờ thực làm vượt 200 giờ và thưởng 50.000 đồng/giờ vượt. 
 * - Tính thuế: lương áp dụng mức 15% với số tiền vượt 10.000.000 đồng
 * Trong hàm Main()
 * - Tạo một mảng IEmloyee để chứa đồng thời 2 nhóm đối tượng officeEmployee và TempEmployee.
 * Test thử các phương thức nói trên. 
 */
using System;
namespace Lab4_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            INhanVien[] nhanViens = new INhanVien[5];

            Random rand = new Random();
            for (int i = 0; i < nhanViens.Length; i++)
            {
                int chonNhanVien = rand.Next(0, 2);
                if (chonNhanVien == 0) 
                {
                    string ten = $"Chính Thức {i + 1}";
                    double luongCoBan = rand.Next(5000,15000)*1000;
                    double heSoLuong = Math.Round(rand.NextDouble() * (10.0 - 3.0) + 1.5, 2);
                    double phuCapUuDai = Math.Round(rand.NextDouble() * (0.9 - 0.1) + 0.1, 2);
                    int soGioNgoaiHanhChinh = rand.Next(0, 100);
                    nhanViens[i] = new OfficeEmployee(ten, luongCoBan, heSoLuong, phuCapUuDai, soGioNgoaiHanhChinh);
                }
                else  
                {
                    string ten = $"Thời Vụ {i + 1}";
                    int soNgayLam = rand.Next(20, 90);
                    double donGia = rand.Next(100, 900)*1000;
                    int soGioCanLam = rand.Next(100, 500);
                    nhanViens[i] = new TempEmployee(ten, soNgayLam, donGia, soGioCanLam);
                }
            }

            foreach (INhanVien nv in nhanViens)
            {
                Console.WriteLine(nv.Print());
            }
        }
    }
}