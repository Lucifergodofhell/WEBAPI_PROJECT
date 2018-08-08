using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApI.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : Controller
	{
		public string path= @"C:\Users\rdhal\source\repos\WebApI\WEBAPI_PROJECT\WebApI\Data\Data.json";
		[HttpPost]
		public void Create(TodoItem item)
		{
			var jsonData = System.IO.File.ReadAllText(path);
			// De-serialize to object or create new list
			var List = JsonConvert.DeserializeObject<List<TodoItem>>(jsonData)
					  ?? new List<TodoItem>();
			List.Add(item);
			jsonData = JsonConvert.SerializeObject(List);
			System.IO.File.WriteAllText(path, jsonData+Environment.NewLine);

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
}
