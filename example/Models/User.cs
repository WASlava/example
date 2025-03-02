using Microsoft.EntityFrameworkCore;

namespace example.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

}
