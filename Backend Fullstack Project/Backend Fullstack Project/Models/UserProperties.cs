using System.ComponentModel.DataAnnotations;

namespace Backend_Fullstack_Project.Models
{
    public class UserProperties
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
    }
}
