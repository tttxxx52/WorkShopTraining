using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkShopTraining.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            ModelService.OrderService orderService = new ModelService.OrderService();

            //員工List
            List<Models.Order> dataList = orderService.GetEmployeeData();
            ViewBag.empData = new SelectList(dataList, "EmployeeID", "EmployeeName");

            //供應商List
            dataList = orderService.GetShipperData();
            ViewBag.shipperData = new SelectList(dataList, "ShipperID", "ShipperName");
       
            return View();
        }


        /// <summary>
        /// 回傳訂單資料
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost()]
        public JsonResult GetData(Models.Order order)
        {
            ModelService.OrderService orderService = new ModelService.OrderService();
            List<Models.Order> list = orderService.SearchOrder(order);
            return this.Json(list);
        }

    }
}