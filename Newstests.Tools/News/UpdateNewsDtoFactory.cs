using News.Entitis.Categorys;
using News.Services.News.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newstests.Tools.News
{
    public class UpdateNewsDtoFactory
    {
        public static UpdateNewsDto Create()
        {
            return new UpdateNewsDto
            {
                Title = "Updated News Title",
                Content = "This is updated news content.",
                Image = "updated-image.jpg",
                NewsType = Category.Sports,
            
            };
        }
    }
}
