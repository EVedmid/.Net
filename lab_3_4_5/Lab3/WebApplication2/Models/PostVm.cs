using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class PostVm
    {
        public int Id { get; set; }
        public string guestLogin { get; set; }
        public string NewsHeader { get; set; }
        public string NewsBody { get; set; }
        public string Tags { get; set; }
        public string Rubric { get; set; }
        public string Topic { get; set; }
        public DateTime DateTime { get; set; }

    }
}
