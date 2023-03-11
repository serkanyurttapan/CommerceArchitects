using AutoMapper;
using Azure;
using MongoDB.Driver;
using ProductAPI.Dtos;
using ProductAPI.Models;
using Shared.Settings;
using Shared.Dtos;
using System.Net;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            MongoClient client = new(databaseSettings.ConnectionStrings);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }


        public async Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            var newProduct = _mapper.Map<Product>(productCreateDto);
            newProduct.CreatedTime = DateTime.Now;
            await _productCollection.InsertOneAsync(newProduct);
            return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(newProduct), 200);
        }

        public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            List<Product> products = await _productCollection.Find(products => true).ToListAsync();
            foreach (var product in products)
            {
                product.Category = await _categoryCollection.Find(x => x.Id == product.Id).FirstOrDefaultAsync();
            }
            return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), (int)HttpStatusCode.OK);
        }

        public async Task<ResponseDto<ProductDto>> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (product is not null)
            {
                product.Category = await _categoryCollection.Find(x => x.Id == product.CategoryId).FirstOrDefaultAsync();
                return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), (int)HttpStatusCode.OK);
            }
            return ResponseDto<ProductDto>.Fail("product not found", (int)HttpStatusCode.OK);
        }
    }
}
