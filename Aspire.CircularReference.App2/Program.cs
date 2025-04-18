using Aspire.CircularReference.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddHttpServiceReference<ServiceClient>("https+http://aspire-circularreference-app1", healthRelativePath: "health");

// Add services to the container.

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/hello", async (ServiceClient remoteClient) =>
{
    var messageFromRemote = await remoteClient.GetStringAsync("message");
    return $"Hello from app 2, Fetched message from remote was '{messageFromRemote}' .";
});

app.MapGet("/message", () =>
{
    return $"Message from web app 2.";
});

app.Run();