using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDataBase.Models;
using System.Data.SqlClient;
using MvcDataBase.Code;
using System.Configuration;


namespace MvcDataBase.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DBHelperFactory HelperFactory = new DBHelperFactory();
        public ActionResult Index()
        {
            //string DBName = "LocalDB";
            //string test = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
            //Response.Write(test);


            Init();
            return View();
        }

        public void Init()
        {
            DBHelper helper = HelperFactory.GetHelperInstance("LocalDB");
            List<Table3> list = helper.GetAllRecord();
            ViewData["list"] = list;
        }
        public ActionResult Delete(int id)
        {
            DBHelper helper = HelperFactory.GetHelperInstance("LocalDB");
            Response.Write("成功删除"+ helper.DeleteRecord(id) +"条记录！");
            Init();
            return View("Index");
        }

        //两种方式新增记录
        public ActionResult Add()
        {
            //跳转页面新增
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            //表单提交新增，不跳转
            Table3 record = new Table3();
            //record.column1 = Request["column1"];
            //record.column2 = Request["column2"];
            record.column1 = form["column1"];
            record.column2 = form["column2"];

            DBHelper helper = HelperFactory.GetHelperInstance("LocalDB");
            int result = helper.AddRecord(record);
            Response.Write("成功添加" + result + "条记录！");
            Init();
            return View("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            DBHelper helper = HelperFactory.GetHelperInstance("LocalDB");

            ViewData["item"] = helper.SearchRecordByID(id);
            return View();
        }
        [HttpPost]
        public ActionResult Update(FormCollection form,string id)
        {
            Table3 record = new Table3();
            record.column1 = form["column1"];
            record.column2 = form["column2"];

            DBHelper helper = HelperFactory.GetHelperInstance("LocalDB");
            Response.Write("成功修改" + helper.UpdateRecord(record, Convert.ToInt32(id)) + "条记录");

            Init();

            return View("Index");
        }

    }
}
