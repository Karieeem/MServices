var builder = WebApplication.CreateBuilder(args);

//Add services to container

var app = builder.Build();

// Configure the Http request pipline

app.Run();
