﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderApp.Model;

namespace OrderGenerator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenerateOrdersController : ControllerBase
    {
        private string _daprPort;
        private string _invokeServiceUrl;
        HttpClient _serviceInvokeClient;

        public GenerateOrdersController()
        {
            _daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
            _invokeServiceUrl = $"http://localhost:3500/v1.0/invoke/orderapi/method/Orders";

            _serviceInvokeClient = new HttpClient();
        }

        [HttpGet("{number}")]
        public async Task<IEnumerable<Order>> Get(int number)
        {
            List<Order> orders = new List<Order>();

            for (int i = 1; i <= number; i++)
            {
                Order order = new Order() { Id = i, CustomerId = "Dapr", ShippingDate = DateTime.Now };
                var result = await _serviceInvokeClient.PostAsJsonAsync($"{_invokeServiceUrl}", order);
                Console.WriteLine($"Created order. status: {result.StatusCode}");
                orders.Add(order);
            }

            return orders;
        }
    }
}