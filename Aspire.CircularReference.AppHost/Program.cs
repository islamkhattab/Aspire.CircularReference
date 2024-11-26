var builder = DistributedApplication.CreateBuilder(args);

var app1 = builder.AddProject<Projects.Aspire_CircularReference_App1>("aspire-circularreference-app1")
    .WithExternalHttpEndpoints();

var app2 = builder.AddProject<Projects.Aspire_CircularReference_App2>("aspire-circularreference-app2")
    .WithReference(app1)
    .WithExternalHttpEndpoints();

app1.WithReference(app2);

builder.Build().Run();
