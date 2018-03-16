using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI.Models
{
    public class ElementModel
    {
        public int Id { get; set; }
        public int ListModelId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Text { get; set; }
        public bool IsDone { get; set; }
    }
}