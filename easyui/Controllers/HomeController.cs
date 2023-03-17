using easyui.Daoimpl;
using easyui.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace easyui.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult center()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult center1()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult center2()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult center3()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult center4()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult center5()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult center6()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
        public ActionResult main()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult getresult(string xu)
        {
            //String xu1 = ""xu;
            //ViewData["xu"] = xu;

            //解析图片并返回结果
            FileStream fs = new FileStream(xu, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            byte[] img = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            string url = "http://127.0.0.1:24401?threshold=0.1";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            Stream stream = request.GetRequestStream();
            stream.Write(img, 0, img.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            var strrr = sr.Read();
            //
            //String confidence=strrr.
            String str = sr.ReadLine();

            KeyValueHelper.matchKey = ":";
            KeyValueHelper.matchValue = ",";
            Bitmap bitmapSource = new Bitmap(xu);
            int width = bitmapSource.Width;
            int height = bitmapSource.Height;
            //Dictionary<object, object> conents = KeyValueHelper.GetConentByString(str);
            String st = "";


            int pos = str.IndexOf("confidence", 0);
            int pos1 = str.IndexOf("height", 0);
            int pos2 = str.IndexOf("}", 0);
            String s2 = str.Substring(pos + 12, 18);
            String s3 = str.Substring(pos1 - 1, pos2 - pos1 + 1);
            st += "confidence=";
            st += s2 + "\n";
            st += "location=";
            st += s3 + "\n";
            st += width;
            st += height;
            int x = width / 2;
            int y = height / 2;
            //int left="height":185,"left":18,"top":105,"width":181
            int height_demo = 0;
            int width_demo = 0;
            int top_demo = 0;
            int left_demo = 0;
            Dictionary<object, object> conents = KeyValueHelper.GetConentByString(s3);
            KeyValueHelper.matchKey = ":";
            KeyValueHelper.matchKey = ",";
            foreach (KeyValuePair<object, object> ee in conents)
            {
                Console.WriteLine(ee.Key + " " + ee.Value + "\n");
                //String s5=
                switch (ee.Key.ToString().Substring(1, ee.Key.ToString().Length - 2))
                {
                    case "height":
                        height_demo = int.Parse(ee.Value.ToString());
                        break;
                    case "left":
                        left_demo = int.Parse(ee.Value.ToString());
                        break;
                    case "top":
                        top_demo = int.Parse(ee.Value.ToString());
                        break;
                    case "width":
                        width_demo = int.Parse(ee.Value.ToString());
                        break;
                    default:
                        Console.WriteLine(ee.Key.ToString());
                        Console.WriteLine(ee.Key.ToString().Substring(1, ee.Key.ToString().Length - 2));
                        break;
                }
            }
            int x1 = left_demo + width_demo / 2;
            int y1 = top_demo + height_demo / 2;
            String strr = x + "," + y+"\n";
            String strr1 = x1 + "," + y1 + "\n";
            String strr2 = "";

            if (x < x1)
            {

                if (y < y1)
                {
                    strr2 = "pic right" + (x1 - x) + "pic up" + (y1 - y);
                }
                else
                {
                    strr2 = "pic right" + (x1 - x) + "pic down" + (y - y1);
                }
            }
            else
            {
                if (y < y1)
                {
                    strr2 = "pic left" + (x1 - x) + "pic up" + (y1 - y);
                }
                else
                {
                    strr2 = "pic left" + (x1 - x) + "pic down" + (y - y1);
                }

            }
            ViewData["xu1"] = strr1;
            ViewData["xu3"] = strr2;
            //ViewData["xu3"] = st;
            ViewData["xu2"] = strr;
            //ViewData["xu5"] = str;
            sr.Close();
            response.Close();
            return View();
           
        }
        public ActionResult Login1(FormCollection col)
        {
            username user = new username();
            user.userName = col["username"];
            user.passWord = col["password"];
            //user.phone = col["phone"];
            //ViewBag.Message = "Your application description page.";
            //数据库判断
            UserDaoimpl userimpl = new UserDaoimpl();
            if (userimpl.Query(user))
                return RedirectToAction("main");
            else
                return RedirectToAction("login");

            return View();
        }
        [HttpPost()]
        public ActionResult Contact()
        {
            JsonResult ajaxres = new JsonResult();
            ajaxres.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //ViewData["xu"] = xu;
            ajaxres.Data = new { message = "徐敬坤" ,data1="67"};
           // String data1 = "67876877778";
            return ajaxres;
        }
        [HttpPost]
        public ActionResult test1(String xu)
        {
            //json格式
            JsonResult ajaxres = new JsonResult();
            ajaxres.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            ajaxres.Data = new { message = "徐敬坤" };

            return ajaxres;
        }
        public ActionResult test1()
        {
            //json格式
            

            return View();
        }
    }
}