using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace Shared.ControllerBases
{
    public class CustomBaseController :ControllerBase
    {
        public static IActionResult CreateActionResult<T>(ResponseDto<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
