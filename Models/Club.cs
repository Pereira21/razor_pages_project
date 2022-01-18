using System.ComponentModel.DataAnnotations;

namespace RazorPagesSoccer.Models
{
    public class Club
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Founding { get; set; }
    }
}
