using Aspire.CircularReference.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddHttpServiceReference<ServiceClient>("https+http://aspire-circularreference-app2", healthRelativePath: "health");

// Add services to the container.

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/hello", async (ServiceClient remoteClient) =>
{
    var messageFromRemote = await remoteClient.GetStringAsync("message");
    return $"Hello from app 1, Fetched message from remote was '{messageFromRemote}' .";
});

app.MapGet("/message", () =>
{
    return $"Message from web app 1.";
});

app.Run();