
using News.Entitis.Categorys;
using News.Entitis.News;
using News.Services.News.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Services.News.Contracts
{
    public interface NewsRepozitory // تغییر نام به استفاده از نام استاندارد
    {
        void Add(Newss news); // تغییر نام مدل به News
        void Delete(Newss news); // تغییر نام مدل به News
        void Update(Newss news); // تغییر نام مدل به News

        Task<Newss?> FindAsync(int id); // تغییر نام متد و نوع بازگشتی به Task<News?>
        Task<Newss?> FindByNameAsync(string name); // تغییر نام متد و نوع بازگشتی به Task<News?>

        Task<List<GetAllNewsDto>> GetAllAsync(); // تغییر نام متد به GetAllAsync
        Task<GetNewsDto?> GetByIdAsync(int id); // تغییر نام متد به GetByIdAsync
    }
}
