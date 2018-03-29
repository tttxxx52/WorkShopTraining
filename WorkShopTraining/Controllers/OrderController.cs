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
            List<Models.Order> dataList = orderService.GetEmployeeData();
            List<SelectListItem> employeeList = new List<SelectListItem>();
            List<SelectListItem> shipperList = new List<SelectListItem>();

            //員工List
            foreach (var item in dataList)
            {
                employeeList.Add(new SelectListItem()
                {
                    Text = item.EmployeeName,
                    Value = item.EmployeeID.ToString(),
                });
            }
            ViewBag.empData = employeeList;

            //供應商List
            dataList = orderService.GetShipperData();
            foreach (var item in dataList)
            {
                shipperList.Add(new SelectListItem()
                {
                    Text = item.ShipperName,
                    Value = item.ShipperID.ToString()
                });
            }

            ViewBag.shipperData = shipperList;
            return View();
        }

        [HttpPost()]
        public ActionResult GetData(Models.Order order)
        {
            return RedirectToAction("Index");
        }

    }
}