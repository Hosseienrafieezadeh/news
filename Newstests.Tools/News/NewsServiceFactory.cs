using News.persistence.EF;
using News.persistence.EF.News;
using News.Services.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newstests.Tools.News
{
    public static class NewsServiceFactory
    {
        public static NewsAppService Create(EFDataContext context)
        {
            return new NewsAppService(new EFNewsRepository(context), new EFUnitOfWork(context));
        }
    }
}
