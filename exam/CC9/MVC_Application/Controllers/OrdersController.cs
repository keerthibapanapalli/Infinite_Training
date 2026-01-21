using MVC_Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

public class OrdersController : Controller
{
    public async Task<ActionResult> Index()
    {
        List<OrderVM> list = new List<OrderVM>();

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new System.Uri("http://localhost:44358/");
            var response = await client.GetAsync("api/orders/employee/5");

            var json = await response.Content.ReadAsStringAsync();
            list = JsonConvert.DeserializeObject<List<OrderVM>>(json);
        }

        return View(list);
    }
}
