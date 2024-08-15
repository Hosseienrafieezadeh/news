using Microsoft.EntityFrameworkCore;
using News.Entitis.Categorys;
using News.Entitis.News;
using News.persistence.EF;
using News.Services.News.Contracts;
using News.Services.News.Contracts.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Persistence.EF.News
{
    public class EFNewsRepository : NewsRepozitory // تغییر به نام صحیح interface
    {
        private readonly EFDataContext _context;

        public EFNewsRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Newss news) // تغییر به نام صحیح مدل
        {
            _context.News.Add(news);
        }

        public void Delete(Newss news) // تغییر به نام صحیح مدل
        {
            _context.News.Remove(news);
        }

        public void Update(Newss news) // تغییر به نام صحیح مدل
        {
            _context.News.Update(news);
        }

        public async Task<Newss?> FindAsync(int id) // تغییر به متد غیرهمزمان
        {
            return await _context.News
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Newss?> FindByNameAsync(string name) // تغییر به متد غیرهمزمان
        {
            return await _context.News
                .FirstOrDefaultAsync(n => n.Title == name);
        }

        public async Task<List<GetAllNewsDto>> GetAllAsync() // تغییر به متد غیرهمزمان
        {
            return await _context.News
                .Include(n => n.Categorys) // بارگذاری Category
                .Select(news => new GetAllNewsDto
                {
                    Id = news.Id,
                    Title = news.Title,
                    Content = news.Content,
                    Image = news.Image,
                    categoryId = news.CategoryId // استفاده از CategoryId
                })
                .ToListAsync();
        }

        public async Task<GetNewsDto?> GetByIdAsync(int id) // تغییر به متد غیرهمزمان
        {
            return await _context.News
                .Include(n => n.Categorys) // بارگذاری Category
                .Where(n => n.Id == id)
                .Select(n => new GetNewsDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Image = n.Image,
                    categoryId = n.CategoryId, // استفاده از CategoryId
                    Views = n.Views
                })
                .FirstOrDefaultAsync();
        }
    }
}
