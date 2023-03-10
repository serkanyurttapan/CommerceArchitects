using ProductAPI.Dtos;
using Shared.Dtos;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        Task<ResponseDto<List<ProductDto>>> GetAllAsync();
        Task<ResponseDto<ProductDto>> GetByIdAsync(string id);
        Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto courseCreateDto);
    }
}
