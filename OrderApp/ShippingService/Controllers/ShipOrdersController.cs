﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderApp.Model;

namespace ShippingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShipOrdersController : ControllerBase
    {
        private string _daprPort;
        HttpClient _httpClient;

        public ShipOrdersController()
        {
            _daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
            _httpClient = new HttpClient();
        }


        // Post: ShipOrders
        [Topic("ShipOrders")]
        [HttpPost]
        public async Task<ActionResult> PostShipOrders(Order order)
        {
            Console.WriteLine($"Successfully received order with Id: {order.Id}, Customer {order.CustomerId}, Shipping date: {order.ShippingDate}");
            return Ok();
        }
    }
}