using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGlossary.Models
{
    public class Entry
    {
        public long Id { get; set; }
        public string Term { get; set; }
        public string Category { set; get; }

        public string Definition { get; set; }
    }
}
