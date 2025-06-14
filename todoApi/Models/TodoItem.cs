// Schema created to table todoItem
namespace todoApi.Models  // Setting the schema on global access .Models
{
    public class todoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; } // ? Or = ""
        public bool IsCompleted { get; set; }
    }
}
