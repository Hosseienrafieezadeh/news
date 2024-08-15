using News.Contracts.Interface;
using News.Entitis.News;
using News.Services.News.Contracts;
using News.Services.News.Contracts.Dtos;

using News.Services.News.Execptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Services.News
{
    public class NewsAppService : NewsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly NewsRepozitory _repository;

        public NewsAppService(NewsRepozitory repository, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Add(AddNewsDto dto)
        {
         

            var news = new Newss
            {
                Title = dto.Title,
                Content = dto.Content,
                Image = dto.Image,
                CategoryId = dto.CategoryID
            };

            _repository.Add(news);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var news =await _repository.FindAsync(id);
            if (news == null)
            {
                throw new NewsNotFoundException();
            }

            _repository.Delete(news);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateNewsDto dto)
        {
            var news = await _repository.FindAsync(id);
            if (news == null)
            {
                throw new NewsNotFoundException();
            }

            news.Title = dto.Title;
            news.Content = dto.Content;
            news.Image = dto.Image;
            news.CategoryId = dto.CategoryId;

            _repository.Update(news);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetAllNewsDto>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GetNewsDto> GetById(int id)
        {
            var news =await _repository.FindAsync(id);
            if (news == null)
            {
                throw new NewsNotFoundException();
            }

            // افزایش تعداد بازدید
            news.Views += 1;
            _repository.Update(news);
            await _unitOfWork.Complete();

            return new GetNewsDto
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Image = news.Image,
                categoryId = news.CategoryId,
                Views = news.Views
            };
        }
    }
}
