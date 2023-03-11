using AutoMapper;
using MongoDB.Driver;
using ProductAPI.Dtos;
using ProductAPI.Models;
using Shared.Settings;
using Shared.Dtos;
using System.Net;

namespace ProductAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,
                               IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return ResponseDto<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), (int)HttpStatusCode.OK);
        }

        public async Task<ResponseDto<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            return category is null
                ? ResponseDto<CategoryDto>.Fail("Category not found", 404)
                : ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
