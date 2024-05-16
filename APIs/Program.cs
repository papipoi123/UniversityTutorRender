using APIs;
using APIs.Middlewares;
using Infrastructures;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//builder.Services.AddControllers();
//.AddOData(opt=>opt.EnableQueryFeatures(null).AddRouteComponents("odata",modelBuilder.GetEdmModel()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.BuildServices(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddInfrastructuresService();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("https://localhost:5173", "https://zuni-tutor.io.vn")
        .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

//app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Seed DB
await AppDbContext.SeedDatabase();

app.Run();

