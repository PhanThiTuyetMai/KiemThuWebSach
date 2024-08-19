using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _35_Mai_KTPM
{
    [TestClass]
    public class ChucNang1_Login_35_Mai
    {
        public DungChung method = new DungChung();

        // Tạo đối tượng TestConText và khai báo phương thức get, set
        public TestContext TestContext { get; set; }

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\35_Mai_Data_Test_DN\35_Mai_TC_1.csv", "35_Mai_TC_1#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void TC_1_35_Mai_Login_Thanh_Cong()
        {
            // đọc dữ liệu đầu vào và tiến hành truyền dữ liệu vào phương thức Login_35_Mai
            method.Login_35_Mai(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString());
            // lấy url thực tế
            string actualUrl = method.driver.Url;
            // url mong đợi là 'https://vanlang.vn/account'
            string expectedUrl = "https://vanlang.vn/account";
            // So sánh URL kỳ vọng và URL thực tế
            Assert.AreEqual(expectedUrl, actualUrl);
            // lấy tên người dùng ở trang tài khoản người dùng
            string ten = method.LayTen();
            // Kiểm tra xem có tồn tại Họ tên là "MAI PHAN" không
            Assert.IsTrue(ten.Contains("Phan Tuyết Mai!"));
            // Dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\35_Mai_Data_Test_DN\35_Mai_TC_2.csv", "35_Mai_TC_2#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC_2_35_Mai_Login_That_Bai_Khong_Nhap_Email()
        {
            // đọc dữ liệu đầu vào và tiến hành truyền dữ liệu vào phương thức Login_35_Mai
            method.Login_35_Mai(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString());
            // URL mong đợi
            string expectURL = "https://vanlang.vn/account/login";
            // So sánh URL thực tế và URL mong đợi
            Assert.AreEqual(expectURL, method.driver.Url);
            Thread.Sleep(3000);  // Dừng 3 giây
            method.driver.Quit(); // Đóng Chorme
        }

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\35_Mai_Data_Test_DN\35_Mai_TC_3.csv", "35_Mai_TC_3#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC_3_35_Mai_Login_That_Bai_Khong_Nhap_Password()
        {
            // đọc dữ liệu đầu vào và tiến hành truyền dữ liệu vào phương thức Login_35_Mai
            method.Login_35_Mai(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString());
            // URL mong đợi
            string expectURL = "https://vanlang.vn/account/login";
            // So sánh URL thực tế và URL mong đợi
            Assert.AreEqual(expectURL, method.driver.Url);
            // Dừng 3 giây
            Thread.Sleep(3000);
            // Đóng Chorme
            method.driver.Quit();
        }

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\35_Mai_Data_Test_DN\35_Mai_TC_4.csv", "35_Mai_TC_4#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC_4_35_Mai_Login_That_Bai_EmailSai_PassDung()
        {
            // đọc dữ liệu đầu vào và tiến hành truyền dữ liệu vào phương thức Login_35_Mai
            method.Login_35_Mai(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString());
            // lấy cảnh báo thực tế
            string actualloi = method.LayLoi();
            // cảnh báo mong đợi 1
            string expectloi = "Thông tin đăng nhập không hợp lệ.";
            // cảnh báo mong đợi 2
            string expectloi1 = "Yêu cầu không hợp lệ, hoặc quá hạn, phiền bạn thử lại";
            // Nếu cảnh báo mong đợi 1 khác cảnh váo thực tế
            if (expectloi != actualloi)
            {
                // So sánh cảnh báo mong đợi 2 với cảnh báo thực tế
                Assert.AreEqual(expectloi1, actualloi);
            }
            else // Ngược lại
            {
                // So sánh cảnh báo mong đợi 1 với cảnh báo thực tế
                Assert.AreEqual(expectloi, actualloi);
            }
            Thread.Sleep(3000); // dừng 3 giây
            method.driver.Quit(); // Đóng Chorme
        }

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\35_Mai_Data_Test_DN\35_Mai_TC_5.csv", "35_Mai_TC_5#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC_5_35_Mai_Login_That_Bai_EmailDung_PassSai()
        {
            // đọc dữ liệu đầu vào và tiến hành truyền dữ liệu vào phương thức Login_35_Mai
            method.Login_35_Mai(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString());
            // lấy cảnh báo thực tế
            string actualloi = method.LayLoi();
            // cảnh báo mong đợi 1
            string expectloi = "Thông tin đăng nhập không hợp lệ.";
            // cảnh báo mong đợi 2
            string expectloi1 = "Yêu cầu không hợp lệ, hoặc quá hạn, phiền bạn thử lại";
            // Nếu cảnh báo mong đợi 1 khác cảnh váo thực tế
            if (expectloi != actualloi)
            {
                // So sánh cảnh báo mong đợi 2 với cảnh báo thực tế
                Assert.AreEqual(expectloi1, actualloi);
            }
            else // Ngược lại
            {
                // So sánh cảnh báo mong đợi 1 với cảnh báo thực tế
                Assert.AreEqual(expectloi, actualloi);
            }
            Thread.Sleep(3000); // dừng 3 giây
            method.driver.Quit(); // Đóng Chorme
        }

        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\35_Mai_Data_Test_DN\35_Mai_TC_6.csv", "35_Mai_TC_6#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC_6_35_Mai_Login_That_Bai_Tai_Khoan_Chua_Dang_Ky()
        {
            // đọc dữ liệu đầu vào và tiến hành truyền dữ liệu vào phương thức Login_35_Mai
            method.Login_35_Mai(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString());
            // lấy cảnh báo thực tế
            string actualloi = method.LayLoi();
            // cảnh báo mong đợi 1
            string expectloi = "Thông tin đăng nhập không hợp lệ.";
            // cảnh báo mong đợi 2
            string expectloi1 = "Yêu cầu không hợp lệ, hoặc quá hạn, phiền bạn thử lại";
            // Nếu cảnh báo mong đợi 1 khác cảnh váo thực tế
            if (expectloi != actualloi)
            {
                // So sánh cảnh báo mong đợi 2 với cảnh báo thực tế
                Assert.AreEqual(expectloi1, actualloi);
            }
            else // Ngược lại
            {
                // So sánh cảnh báo mong đợi 1 với cảnh báo thực tế
                Assert.AreEqual(expectloi, actualloi);
            }
            Thread.Sleep(3000); //dừng 3 giây
            method.driver.Quit(); // Đóng Chorme
        }


        // Liên kết TestData với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\35_Mai_Data_Test_DN\35_Mai_TC_7.csv", "35_Mai_TC_7#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC_7_35_Mai_Login_That_Bai_Truong_Email_Khong_Hop_Le()
        {
            // đọc dữ liệu đầu vào và tiến hành truyền dữ liệu vào phương thức Login_35_Mai
            method.Login_35_Mai(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString());

            // lấy cảnh báo trường email đã qua kiểm tra
            string actualerror = method.kiemTraEmail();
            // cảnh báo mong đợi
            string expecterror = "Trường email không hợp lệ cho email";
            // So sánh cảnh báo
            Assert.AreEqual(expecterror, actualerror);
            // URL thực tế sau khi click Đăng nhập
            string actualUrl = method.driver.Url;
            // URL mong đợi sau khi click Đăng nhập
            string expectedUrl = "https://vanlang.vn/account/login";
            // So sánh URL 
            Assert.AreEqual(expectedUrl, actualUrl);
            Thread.Sleep(3000); // Dừng 3 giây
            method.driver.Quit(); // Đóng Chorme
        }
    }
}
