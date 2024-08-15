
using FluentAssertions;
using News.persistence.EF;
using News.Services.News;
using News.Services.News.Execptions;
using NewspaperManangement.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using Newstests.Tools.Instructure.DataBaseConfig;
using Newstests.Tools.News;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace News.Service.UnitTests
{
    public class NewsAppServiceTests
    {
        private readonly NewsAppService _sut;
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;

        public NewsAppServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = NewsServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Add_News_Properly()
        {
            var dto = AddNewsDtoFactory.Create();

            await _sut.Add(dto);
            var actual = _readContext.News.Single();
            object value = actual.Title.Should().Be(dto.Title);
            actual.Content.Should().Be(dto.Content);
            actual.Image.Should().Be(dto.Image);
            actual.NewsType.Should().Be(dto.NewsType);
        }

        [Fact]
        public async Task Update_Existing_News_Successfully()
        {
            var news = new NewsBuilder().Build();
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            var updateDto = UpdateNewsDtoFactory.Create();
            await _sut.Update(news.Id, updateDto);

            var actual = _readContext.News.First(_ => _.Id == news.Id);
            actual.Title.Should().Be(updateDto.Title);
            actual.Content.Should().Be(updateDto.Content);
            actual.Image.Should().Be(updateDto.Image);
            actual.NewsType.Should().Be(updateDto.NewsType);
        }

        [Fact]
        public async Task Get_All_News_Successfully()
        {
            var news1 = new NewsBuilder().Build();
            var news2 = new NewsBuilder().Build();
            _context.News.Add(news1);
            _context.News.Add(news2);
            await _context.SaveChangesAsync();

            var actual = await _sut.GetAll();
            actual.Count.Should().Be(2);
        }

        [Fact]
        public async Task Remove_News_Successfully()
        {
            var news = new NewsBuilder().Build();
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            await _sut.Delete(news.Id);

            var actual = _readContext.News.Any();
            actual.Should().BeFalse();
        }

        [Fact]
        public async Task Update_Throws_NewsNotFoundException()
        {
            var id = 999; // Non-existent ID
            var updateDto = UpdateNewsDtoFactory.Create();

            var actual = async () => await _sut.Update(id, updateDto);
            await actual.Should().ThrowAsync<NewsNotFoundException>();
        }

        [Fact]
        public async Task Add_Throws_NewsAlreadyExistsException()
        {
            var dto1 = AddNewsDtoFactory.Create();
            await _sut.Add(dto1);

            var dto2 = AddNewsDtoFactory.Create();
            var actual = async () => await _sut.Add(dto2);
            await actual.Should().ThrowAsync<NewsAlreadyExistsException>();
        }
    }
}
