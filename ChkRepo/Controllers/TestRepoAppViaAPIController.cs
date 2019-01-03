using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModel;

namespace ChkRepo.Controllers
{
    public class TestRepoAppViaAPIController : Controller
    {
        private readonly string EndPoint = "http://localhost:53093/api/test/";
        public IActionResult Index()
        {
            List<TodoItemVM> listTodoItemVms = new List<TodoItemVM>();
            HttpResponseMessage response = GetResponse(EndPoint, HttpMethod.Get, null);
            string content = response.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrWhiteSpace(content))
            {
                listTodoItemVms = JsonConvert.DeserializeObject<List<TodoItemVM>>(content);
            }

            return View(listTodoItemVms);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpResponseMessage response = GetResponse(EndPoint + id, HttpMethod.Get, null);
            string content = response.Content.ReadAsStringAsync().Result;
            TodoItemVM vm = new TodoItemVM();
            if (!string.IsNullOrWhiteSpace(content))
            {
                vm = JsonConvert.DeserializeObject<TodoItemVM>(content);
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind()]TodoItemVM vm)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GetResponse(EndPoint + id, HttpMethod.Put, vm);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return View(vm);
        }


        private HttpResponseMessage GetResponse(string endpoint, HttpMethod type, TodoItemVM data)
        {
            HttpRequestMessage requestMessage = GetRequest(endpoint, type, data);
            HttpClient client = new HttpClient();
            var result = client.SendAsync(requestMessage).Result;
            return result;
        }

        private HttpRequestMessage GetRequest(string endpoint, HttpMethod type, TodoItemVM data)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.RequestUri = new Uri(endpoint);
            requestMessage.Method = type;
            if (type == HttpMethod.Post || type == HttpMethod.Put)
            {
                if (data != null)
                {
                    string dataJSON = JsonConvert.SerializeObject(data, Formatting.Indented);
                    requestMessage.Content = new StringContent(string.IsNullOrWhiteSpace(dataJSON) ? "" : dataJSON,
                        Encoding.UTF8, "application/json");
                }
            }

            return requestMessage;
        }
    }
}