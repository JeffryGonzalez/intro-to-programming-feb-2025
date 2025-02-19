namespace Resources.Api.Resources;

public class ResourceListItemEntity
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Link { get; set; } = string.Empty;
  public string LinkText { get; set; } = string.Empty;
  public List<string> Tags { get; set; } = new();
}
