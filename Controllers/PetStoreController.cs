using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Pet_Store_Example.Model;

namespace Online_Pet_Store_Example.Controllers;

public class PetStoreController : Controller
{
    PetStoreExampleContext Db = new PetStoreExampleContext();

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        try
        {
            var results = await Db.Items.ToListAsync();
            return GetOkResult(results);
        }
        catch (Exception e)
        {
            return InternalError(e);
        }
    }

    private ObjectResult InternalError(Exception e)
    {
        return StatusCode((int) HttpStatusCode.InternalServerError, GetResultError(e));
    }
    
    private ApiResult GetResultError(Exception e)
    {
#if DEBUG
        Logger.Log(e.ToString());
        var result = new ApiResult
        {
            Message = e.ToString(),
            Success = false,
            HttpStatusCode = HttpStatusCode.InternalServerError,
        };  
        return result;
        
#else
        var guid = Logger.LogInternalServerError(e);
        var result = new ApiResult
        {
            Message = $"Internal Server Error - {guid}",
            Success = false,
            HttpStatusCode = HttpStatusCode.InternalServerError,
        };
        return result;
#endif
    }

    private OkObjectResult GetOkResult<T>(IEnumerable<T> results, string message = null)
    {
        return Ok(GetResult(results, message));

    }
    private ApiResult<T> GetResult<T>(IEnumerable<T> resultList, string message = null, HttpStatusCode code = HttpStatusCode.OK)
    {
        var result = new ApiResult<T>
        {
            Message = message,
            Success = true,
            HttpStatusCode = code,
            Result = resultList
        };
        return result;
    }
}