using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace _35_Mai_KTPM
{
    public class DungChung
    {
        // khai báo thuộc tính public để có thể dùng chung cho các UnitTest
        public IWebDriver driver = new ChromeDriver();

        public DungChung() { }

        // phương thức truy cập vào trang chủ Vanlang
        public void TruyCapWeb()
        {
            driver.Navigate().GoToUrl("https://vanlang.vn/");
        }

        public void TatQuangCao()
        {
            // tạo một hành động lướt xuống cuối trang web để xuất hiện quảng cáo
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            // dừng 3 giây đợi quảng cáo xuất hiện
            Thread.Sleep(5000);
            // tắt quảng cáo
            IWebElement quangcao = driver.FindElement(By.ClassName("btn-form-close"));
            quangcao.Click();
        }

        public void Login_35_Mai(string email, string password)
        {
            // 35_Mai
            // truy cập vào trang chủ trang web
            TruyCapWeb();
            // tắt quảng cáo
            TatQuangCao();
            // Tiến hành click Tài khoản
            IWebElement btntaikhoan = driver.FindElement(By.XPath("/html/body/header/div/div/div/div[4]/ul/li[2]/div/a"));
            btntaikhoan.Click();
            // Dừng 3 giây
            Thread.Sleep(3000);
            // Tiến hành nhập email
            IWebElement mail = driver.FindElement(By.Name("email"));
            mail.SendKeys(email);
            // Tiến hành nhập password
            IWebElement pass = driver.FindElement(By.Id("customer_password"));
            pass.SendKeys(password);
            // Tiến hành click nút Đăng nhập
            IWebElement btnlogin = driver.FindElement(By.ClassName("btn-login"));
            btnlogin.Click();
        }

        public void TimKiem(string input)
        {
            // tiến hành truy cập trang chủ
            TruyCapWeb();
            // Tắt đi quảng cáo
            TatQuangCao();
            // nhập dữ liệu tìm kiếm
            IWebElement input_search = driver.FindElement(By.Name("q"));
            input_search.SendKeys(input);
            // Dừng 3 giây
            Thread.Sleep(3000);
        }
        
        public string kiemTraEmail()
        {
            // tạo 1 mảng chứa các trường email không hợp lệ
            string[] invalid_emails = { "example.com", "user@", "@example.com", "user@example" };
            // lấy email trong ô email sau khi đã nhập email
            IWebElement mail = driver.FindElement(By.Name("email"));
            // chạy từng email không hợp lệ trong mảng
            foreach (string email in invalid_emails)
            {
                // kiểm tra mail đã lấy về có thuộc trong trường email không hợp lệ hay không
                bool isInvalid = mail.GetAttribute("class").Contains("is-invalid");
                // nếu isInvalid là false
                if (!isInvalid)
                {
                    // trả về cảnh báo email không hợp lệ
                    return "Trường email không hợp lệ cho email";
                }
            }
            return "Da Kiem Tra";
        }

        public string LayTen()
        {
            // lấy tên người dùng ở trang tài khoản người dùng
            IWebElement ten = driver.FindElement(By.CssSelector(".block-content strong"));
            string name = ten.Text;
            return name;
        }

        public string LayLoi()
        {
            // lấy lỗi cảnh báo từ trang web
            IWebElement loi = driver.FindElement(By.ClassName("form-signup"));
            return loi.Text;
        }

        public bool kiemtraSP()
        {
            // kiểm tra có sản phẩm hay không
            var ketqua = driver.FindElements(By.ClassName("ega-sm-item"));
            if (ketqua.Count() > 0) return true;
            else return false;
        }

        public bool tontai1SP()
        {
            // kiểm tra chỉ duy nhất có 1 sản phẩm
            var ketqua = driver.FindElements(By.ClassName("ega-sm-item"));
            if (ketqua.Count() == 1) return true;
            else return false;
        }

        public string layLoiKhongTimThay()
        {
            // lấy lỗi khi tìm kiếm
            IWebElement loi = driver.FindElement(By.ClassName("tw-text-center"));
            return loi.Text;
        }
    }
}