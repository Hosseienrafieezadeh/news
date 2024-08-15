﻿using News.Entitis.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services.News.Contracts.Dtos
{
   public class GetNewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int categoryId { get; set; }
        public int Views { get; set; }
    }
}
