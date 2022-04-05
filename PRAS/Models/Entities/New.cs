using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRAS.Models.Entities
{
    public class New
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string Text { get; set; }
    }
}
