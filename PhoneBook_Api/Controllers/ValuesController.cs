using Db;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<PhoneBookEntity>> Get()
		{
			var context = new PhoneBookContext();
			var list = context.PhoneBookEntities.ToArray();
			return list;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<PhoneBookEntity> Get(int id)
		{
			var context = new PhoneBookContext();
			var entity = context.PhoneBookEntities.FirstOrDefault(x => x.Id == id);
			return entity;
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] PhoneBookEntity value)
		{
			using (var context = new PhoneBookContext())
			{
				context.PhoneBookEntities.Add(value);
				context.SaveChanges();
			}
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] PhoneBookEntity value)
		{
			using (var context = new PhoneBookContext())
			{
				var a = context.PhoneBookEntities.Where(x => x.Id == id);
				if (a != null)
					context.PhoneBookEntities.Update(value);
				else
					context.PhoneBookEntities.Add(value);
				context.SaveChanges();
			}
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			using (var context = new PhoneBookContext())
			{
				var entity = context.PhoneBookEntities.Remove(new PhoneBookEntity() { Id = id });
				context.SaveChanges();
			}
		}
	}
}
