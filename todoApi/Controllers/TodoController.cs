using Microsoft.AspNetCore.Mvc;
using todoApi.Models;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        // Simples lista em memoria para teste (sem banco)
        private static readonly List<todoItem> todoItems = new List<todoItem>();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<List<todoItem>> Get() => todoItems;

        [HttpPost]
        public ActionResult<todoItem> Post(todoItem item)
        {
            item.Id = nextId++;
            todoItems.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id}, item);
        }

        [HttpGet("{id}")]
        public ActionResult<todoItem> GetById(int id)
        {
            var item = todoItems.Find(x => x.Id == id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, todoItem updatedItem)
        {
            var index = todoItems.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound();

            todoItems[index] = updatedItem;
            return NoContent();
        }

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