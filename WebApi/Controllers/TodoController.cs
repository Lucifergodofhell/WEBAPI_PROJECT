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
		public string path= @"C:\Users\rdhal\source\repos\WebApI\WebApI\Data\Data.json";
		[HttpPost]
		public void Create(TodoItem item)
		{
			List<TodoItem> todo = new List<TodoItem>();
			todo.Add(item);
			string json = JsonConvert.SerializeObject(todo.ToArray());
			System.IO.File.AppendAllText(path, json+ Environment.NewLine);

		}
		[HttpGet]
		public string GetAll()
		{	
			string content = System.IO.File.ReadAllText(path);
			return content;

		}
		[HttpGet("{id}")]
		public string GetbyId(long id)
		{
			string user="term";
			return user;
		}
	}
}
