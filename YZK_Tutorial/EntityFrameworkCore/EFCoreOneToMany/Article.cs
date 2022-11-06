using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreOneToMany
{
    public class Article
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();


        public bool IsDeleted { get; set; }

    }
}
