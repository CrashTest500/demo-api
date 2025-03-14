var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

#if !DEBUG
app.UseHttpsRedirection();
#endif

app.MapHealthChecks("/healthCheck").WithName("HealthCheck").WithOpenApi();

app.MapGet("/", () =>
{
    return "Hello, World!";
})
.WithName("Test")
.WithOpenApi();

app.MapGet("/Data", () =>
{
    return Guid.NewGuid().ToString();
})
.WithName("Data")
.WithOpenApi();

app.Run();
