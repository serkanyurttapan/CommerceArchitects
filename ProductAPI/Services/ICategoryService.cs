using ProductAPI.Dtos;
using Shared.Dtos;

namespace ProductAPI.Services
{
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllAsync();
        Task<ResponseDto<CategoryDto>> GetByIdAsync(string id);
    }
}
