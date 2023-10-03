using System.ComponentModel.DataAnnotations;

namespace CCA_BE.Models
{
    public class User
    {
        [Key]
        public string ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public string Role{ get; set; }
    }
}
