

using Alba;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Resources.Api.Resources;

namespace Resources.Tests.Resources;

public class AddingAnItem
{
  [Fact]
  public async Task AddingAnItemWithASecurityTagNotifiesTheSoftwareApi()
  {
    var host = await AlbaHost.For<Program>(config=>
    {
      config.ConfigureServices(services =>
      {
        var fakeSecurityTeam = Substitute.For<INotifytheSecurityReviewTeam>();
        fakeSecurityTeam.NotifyForSecurityReview(Arg.Any<Guid>()).Returns(Task.FromResult("999888777"));
        services.AddScoped<INotifytheSecurityReviewTeam>(_ => fakeSecurityTeam);
      });
    });
    var itemToPost = new ResourceListItemCreateModel
    {
      Description = "description",
      Title = "title",
      Link = "https://test-doubles.hypertheory.com",
      LinkText = "Hypertheory",
      Tags = ["dog", "cat", "security", "tacos"]
    };

    var postResponse = await host.Scenario(api =>
    {
      api.Post.Json(itemToPost).ToUrl("/resources");
    });

    var entityReturned = postResponse.ReadAsJson<ResourceListItemModel>();

    Assert.NotNull(entityReturned);

    Assert.True(entityReturned.IsBeingReviewedForSecurity);


  }

  [Fact]
  public async Task AddingAnItemWithoutASecurityTagDoesNotNotifyTheSoftwareApi()
  {
    var fakeSecurityTeam = Substitute.For<INotifytheSecurityReviewTeam>();
    var host = await AlbaHost.For<Program>(config =>
    {
      config.ConfigureServices(services =>
      {
        
        services.AddScoped<INotifytheSecurityReviewTeam>(_ => fakeSecurityTeam);
      });
    });
    var itemToPost = new ResourceListItemCreateModel
    {
      Description = "description",
      Title = "title",
      Link = "https://test-doubles.hypertheory.com",
      LinkText = "Hypertheory",
      Tags = ["dog", "cat", "tacos"]
    };

    var postResponse = await host.Scenario(api =>
    {
      api.Post.Json(itemToPost).ToUrl("/resources");
    });

    var entityReturned = postResponse.ReadAsJson<ResourceListItemModel>();

    Assert.NotNull(entityReturned);

    Assert.False(entityReturned.IsBeingReviewedForSecurity);
    fakeSecurityTeam.DidNotReceive().NotifyForSecurityReview(Arg.Any<Guid>());
  }

}

//public class StubbedSecurityTeam : INotifytheSecurityReviewTeam
//{
//  public Task<string> NotifyForSecurityReview(Guid id)
//  {
//    return Task.FromResult("tacos-id-from-the-team");
//  }
//}
