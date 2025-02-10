namespace Todos.Api.Todos;

public static class Endpoints
{

    // An "Extension Method"
    // this will add a method to the Endpoint Route Builder called "MapTodos"
    public static IEndpointRouteBuilder MapTodos(this IEndpointRouteBuilder builder)
    {
        // GET /todos
        builder.MapGet("/todos", () =>
        {
            var fakeData = new List<TodoListItem>()
            {
                new TodoListItem() { Id = Guid.NewGuid(), Description = "Clean Garage", Completed = false, CreatedOn = DateTimeOffset.UtcNow
            } };

            return Results.Ok(fakeData);
        });
        // POST /todos


        builder.MapPost("/todos", (TodoListCreateItem request) =>
        {

            var response = new TodoListItem
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Completed = false,
                CreatedOn = DateTimeOffset.UtcNow
            };
            return Results.Ok(response);
        });
        return builder;
    }
}

public record TodoListItem
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public bool Completed { get; set; }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
}

public record TodoListCreateItem
{
    public string Description { get; set; } = string.Empty;
}
