using News.Services.News.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services.News.Contracts
{
    public interface NewsService
    {
        Task Add(AddNewsDto dto);
        Task Delete(int id);
        Task Update(int id, UpdateNewsDto dto);
        Task<List<GetAllNewsDto>> GetAll();
        Task<GetNewsDto?> GetById(int id); // متد GetById
    }
}
