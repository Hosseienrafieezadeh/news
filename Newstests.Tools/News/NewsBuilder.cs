using News.Entitis.Categorys;
using News.Entitis.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newstests.Tools.News
{
    public class NewsBuilder
    {
        private readonly Newss _news;

        public NewsBuilder()
        {
            _news = new Newss
            {
                Title = "Sample News Title",
                Content = "This is a sample news content.",
                Image = "sample-image.jpg",
                NewsType = Category.Politics,
                
                Views = 0
            };
        }

        public Newss Build()
        {
            return _news;
        }
    }
}
