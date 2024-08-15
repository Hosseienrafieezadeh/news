using News.Entitis.Categorys;
using News.Services.News.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newstests.Tools.News
{

   public static class AddNewsDtoFactory
    {
        public static AddNewsDto Create()
        {
            return new AddNewsDto
            {
                Title = "Sample News Title",
                Content = "This is a sample news content.",
                Image = "sample-image.jpg",
                NewsType = Category.Sports,
               
            };
        }
    }
}

