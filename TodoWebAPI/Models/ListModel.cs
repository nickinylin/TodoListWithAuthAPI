using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI.Models
{
    public class ListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ElementModel> Elements { get; set; }
    }
}
