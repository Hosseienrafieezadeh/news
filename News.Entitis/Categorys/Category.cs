using News.Entitis.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entitis.Categorys
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Newss> Newsses { get; set; } = new();
    }
}
