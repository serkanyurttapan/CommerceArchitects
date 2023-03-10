using Microsoft.AspNetCore.Mvc;

namespace Shared.ControllerBases
{
    public class CustomBaseController :ControllerBase
    {
        public IActionResult CreateActionResult<T>(Response<T> response)
        {

        }
    }
}
