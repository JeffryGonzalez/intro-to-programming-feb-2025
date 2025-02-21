using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api(IValidator<ResourceListItemCreateModel> validator, IDocumentSession session, ILogger<Api> _logger) : ControllerBase
{

  [HttpGet("/resources")]
  public async Task<ActionResult> GetAllResources(CancellationToken token)
  {
    
    var response = await session.Query<ResourceListItemEntity>()
     .ProjectToResponse()
       .OrderBy(r => r.CreatedOn)
       .ThenBy(r => r.CreatedBy)
       .ToListAsync(token);
   
    return Ok(response);
  }

  [HttpPost("/resources")]
  public async Task<ActionResult> AddResourceItem(
    [FromBody] ResourceListItemCreateModel request,
    [FromServices] UserInformationProvider userInfo)
  {

    await Task.Delay(3000);
    var validations = await validator.ValidateAsync(request);

    if (validations.IsValid == false)
    {
      return BadRequest(validations.ToDictionary()); // more on that later.
    }

    //var entityToSave = request.MapFromRequestModel();

    if (request.Tags.Any(t => t == "security"))
    {
      // send an HTTP request to an API that doesn't even exist yet, and take the code that doesn't exist yet, and store it in the database
      // and add a property to the response that says "pendingSecurityReview"
    }

    var entityToSave = request.MapFromRequestModel();

   
    entityToSave.CreatedBy = await userInfo.GetUserNameAsync();
   
    session.Store(entityToSave);
    await session.SaveChangesAsync();


    var response = entityToSave.MapToResponse();

 
    return Ok(response);
  }

  // GET /resources/3898398039=93898398983-39879839
  [HttpGet("/resources/{id:guid}")]
  public async Task<ActionResult> GetById(Guid id)
  {
    
    return Ok();
  }
}


public class UserInformationProvider
{
  public async Task<string> GetUserNameAsync()
  {
    return "babs@aol.com"; // for now.
  }
}

