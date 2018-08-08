using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApI.Models;
using Newtonsoft.Json.Linq;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : Controller
	{
		public string path= @"E:\cloned\WEBAPI_PROJECT\WebApi\Data\Data.Json";
		[HttpPost]
		public void Create(TodoItem item)
		{
           
           
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(path);
            // De-serialize to object or create new list
            var list = JsonConvert.DeserializeObject<List<TodoItem>>(jsonData)
                                  ?? new List<TodoItem>();

            // Add any new employees
            list.Add(item);
           
            // Update json data string
            jsonData = JsonConvert.SerializeObject(list);
            System.IO.File.WriteAllText(path, jsonData);

        }
		
		[HttpGet]
		public string GetAll()
		{	
			string content = System.IO.File.ReadAllText(path);
			return content;

		}
	
		[HttpPut("{id}")]
		public void Update(long id, TodoItem item)
		{
			var jsonData = System.IO.File.ReadAllText(path);
			var list = JsonConvert.DeserializeObject<List<TodoItem>>(jsonData)
				  ?? new List<TodoItem>();

			var temp=list.Find(term => term.Id==id);
			if (temp != null)
			{
				temp.Name = item.Name;
				temp.Pass = item.Pass;
				temp.Email = item.Email;
				jsonData = JsonConvert.SerializeObject(list);
				System.IO.File.WriteAllText(path, jsonData);
			}
		}
	}
		[HttpGet("{id}")]
		public string GetbyId(int id)
		{
            var jsonData = System.IO.File.ReadAllText(path);
            // De-serialize to object or create new list
            var list = JsonConvert.DeserializeObject<List<TodoItem>>(jsonData)
                                  ?? new List<TodoItem>();

            if (list == null)
                return "No Object";

            var newJsonString = JsonConvert.SerializeObject(list.Where(i => i.Id == id));

            return newJsonString;

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var jsonData = System.IO.File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<TodoItem>>(jsonData);

            if (items==null) return;

            var newJsonString = JsonConvert.SerializeObject(items.Where(i => i.Id != id));

            System.IO.File.WriteAllText(path, newJsonString);


        }


    }
}
