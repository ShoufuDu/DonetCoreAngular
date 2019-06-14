using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGlossary.Models.BindingTargets
{
    public class EntryData
    {
        [Required]
        public string Name
        {
            get => Entry.Term;
            set => Entry.Term = value;
        }
        [Required]
        public string Category
        {
            set => Entry.Category = value;
            get => Entry.Category;
        }
        [Required]
        public string Definition
        {
            get => Entry.Definition;
            set => Entry.Definition = value;
        }

        public Entry Entry { set; get; } = new Entry();
    }
}
