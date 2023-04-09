using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class EventDto
    {
        public int Id { get; set; }
        public string? Theme { get; set; }
        public string? Description { get; set; }
        public string? Plan { get; set; }
        public string? Organizer { get; set; }
        public string? Speaker { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
    }
}
