using Microsoft.AspNetCore.Mvc;
using todoApi.Models;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        // Simple memory list to test (no database)
        // Here we create an array type (List) whith the todoItem inteface 
        private static readonly List<todoItem> todoItems = new List<todoItem>();
        // Here we define an ID every time we create an item by putting nextId++
        private static int nextId = 1;

        // [GET] Route to get any data
        [HttpGet]
        public ActionResult<List<todoItem>> Get() => todoItems;

        // [POST] Route to create a data in the database
        [HttpPost]
        public ActionResult<todoItem> Post(todoItem item)
        {
            item.Id = nextId++;
            todoItems.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id}, item);
        }

        // [GET] Route to find a data by Id
        [HttpGet("{id}")]
        public ActionResult<todoItem> GetById(int id)
        {
            var item = todoItems.Find(x => x.Id == id);
            if (item == null) return NotFound();
            return item;
        }

        // [PUT] Route to change data by Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, todoItem updatedItem)
        {
            var index = todoItems.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound();

            todoItems[index] = updatedItem;
            return NoContent();
        }

        // [DELETE] Route to delete data by Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = todoItems.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound();

            todoItems.RemoveAt(index);
            return NoContent();
        }
    }
}