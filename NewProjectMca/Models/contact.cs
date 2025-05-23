using System.ComponentModel.DataAnnotations;

namespace NewProjectMca.Models
{
    public class contact
    {
        [Key]
        public int c_id { get; set; }

        public string? name { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public bool ResponseStatus { get; set; } = false;
    }
}
