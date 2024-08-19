using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _35_Mai_KTPM
{
    [TestClass]
    public class ChucNang2_TimKiem_35_Mai
    {
        public DungChung method = new DungChung();

        [TestMethod]
        public void TC_1_35_Mai_Tim_Kiem_Thanh_Cong()
        {
            // tìm kiếm sách có tựa đề bắt đầu bằng "Mẹ dạy"
            method.TimKiem("Mẹ dạy");
            // kiểm tra có sản phẩm 
            bool actualKT = method.kiemtraSP();
            // kiểm tra mong muốn là có
            bool expectKT = true;
            // so sánh kết quả kiểm tra
            Assert.AreEqual(expectKT, actualKT);
            // dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }

        [TestMethod]
        public void TC_2_35_Mai_Tim_Kiem_Nhap_Chu_Cai_Dau()
        {
            // tìm kiếm bằng 1 ký tự là a
            method.TimKiem("a");
            // kiểm tra có sản phẩm có chữ a trong tên hoặc tác giả
            bool actualKT = method.kiemtraSP();
            // kiểm tra mong muốn là có
            bool expectKT = true;
            // so sánh kết quả kiểm tra
            Assert.AreEqual(expectKT, actualKT);
            // dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }

        [TestMethod]
        public void TC_3_35_Mai_Tim_Kiem_Theo_Ma_SP()
        {
            // tìm kiếm theo mã sản phẩm
            method.TimKiem("8935074128195");
            // kết quả chỉ ra 1 sản phẩm
            bool actualSL = method.tontai1SP();
            // kết quả mong muốn là đúng
            bool expectSL = true;
            // So sánh kết quả
            Assert.AreEqual(expectSL, actualSL);
            // Dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }

        [TestMethod]
        public void TC_4_35_Mai_Tim_Kiem_Nhap_Ky_Tu_Dac_Biet()
        {
            // tìm kiếm bằng ký hiệu đặc biệt
            method.TimKiem("!!!!!");
            // lấy lỗi không tìm thấy thực tế
            string actualLoi = method.layLoiKhongTimThay();
            // lỗi mong muốn
            string expectLoi = "Không tìm thấy kết quả nào";
            // So sánh lỗi
            Assert.AreEqual(actualLoi, expectLoi);
            // Dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }
        
        [TestMethod]
        public void TC_5_35_Mai_Tim_Kiem_SP_Khác()
        {
            method.TimKiem("sandal");
            // lấy lỗi không tìm thấy thực tế
            string actualLoi = method.layLoiKhongTimThay();
            // lỗi mong muốn
            string expectLoi = "Không tìm thấy kết quả nào";
            // So sánh lỗi
            Assert.AreEqual(actualLoi, expectLoi);
            // Dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }

        [TestMethod]
        public void TC_6_35_Mai_Tim_Kiem_Khong_Nhap_Du_Lieu()
        {
            // tìm kiếm mà không nhập dữ liệu
            method.TimKiem("");
            // trả về kết quả có sản phẩm
            bool actualKT = method.kiemtraSP();
            // kết quả mong muốn là không có
            bool expectKT = false;
            // So sánh kết quả với nhau
            Assert.AreEqual(expectKT, actualKT);
            // Dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }
    }
}
