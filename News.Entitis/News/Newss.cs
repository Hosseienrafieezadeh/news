using News.Entitis.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entitis.News
{
   
        public class Newss
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Image { get; set; }
        public int CategoryId { get; set; } // ذخیره دسته‌بندی به عنوان ID
        public Category Categorys { get; set; } 
     



        public int Views { get; set; } // تعداد بازدید
        }
    }


