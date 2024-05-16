using APIs.Services;
using APIs.Validations.CourseMajorValidations;
using APIs.Validations.OrderValidations;
using APIs.Validations.ReportValidations;
using APIs.Validations.StudentValidations;
using APIs.Validations.TransactionValidations;
using APIs.Validations.TutorValidations;
using APIs.Validations.UniversityValidations;
using APIs.Validations.UserValidations;
using Applications.Commons;
using Applications.Interfaces;
using Applications.Utils.FireBase;
using Applications.ViewModels;
using Domain.Entities;
using FluentValidation;
using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace APIs
{
    public static class DependencyInjection
    {
        public static IServiceCollection BuildServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            var connectionString = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            services.AddSingleton(configuration);
            services.AddSingleton(connectionString ?? throw new Exception($"ConnectionStrings not found in appsettings.json");
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString.SQLServerDB));
            services.AddScoped<IClaimsServices, ClaimsService>();
            var jwtSection = configuration.GetSection("JWTSection").Get<JWTSection>();
            services.AddSingleton(jwtSection);
            //Validation
            //services.AddScoped<IValidator<UserViewModel>, UserValidation>();
            //services.AddScoped<IValidator<LoginViewModel>, LoginValidation>();
            //services.AddScoped<IValidator<TutorViewModel>, TutorValidation>();
            //services.AddScoped<IValidator<StudentViewModel>, StudentValidation>();
            //services.AddScoped<IValidator<ReportViewModel>, ReportValidation>();
            //services.AddScoped<IValidator<UniversityViewModel>, UniversityValidation>();
            //services.AddScoped<IValidator<OrderViewModel>, OrderValidation>();
            //services.AddScoped<IValidator<CourseMajorViewModel>, CourseMajorValidation>();
            //services.AddScoped<IValidator<TransactionViewModel>, TransactionValidation>();
            //services.AddScoped<IValidator<WeeklyTimeViewModel>, WeeklyTimeValidation>();

            var list = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name.EndsWith("Validation") && x.IsClass).ToList();
            foreach (var item in list)
            {
                var @interface = item.GetInterface("IValidator`1");
                services.AddScoped(@interface, item);
            }
            IMvcBuilder controller = services.AddControllers();
            controller.AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            //controller.AddOData(opt => opt.EnableQueryFeatures(null).AddRouteComponents("odata", GetEdmModel()));

            #region SwaggerConfig
            services.AddSwaggerGen(
                    c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "Zuni Tutor",
                            Version = "v1",
                            Description = "This is Our API",
                            Contact = new OpenApiContact
                            {
                                Url = new Uri("https://google.com")
                            }
                        });
                        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.Http,
                            In = ParameterLocation.Header,
                            BearerFormat = "JWT",
                            Scheme = "Bearer",
                            Description = "Please input your token"
                        });
                        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference=new OpenApiReference
                                    {
                                        Type=ReferenceType.SecurityScheme,
                                        Id="Bearer"
                                    }
                                },
                                new string[]{}
                            }
                        });

                    });
            #endregion
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            });
            // Firebase
            services.AddSingleton<FirebaseStorageHelper>();
            var firebaseConfig = configuration.GetSection("FirebaseConfig").Get<FirebaseConfig>();
            services.AddSingleton(firebaseConfig ?? throw new Exception($"FirebaseConfig not found in appsettings.json"));
            return services;
        }
        // xin chuc mung return = ResponseModel<TEntity> ko dung duoc odata
        //private static IEdmModel GetEdmModel()
        //{
        //    // Add Odata Support
        //    var modelBuilder = new ODataConventionModelBuilder();

        //    modelBuilder.EntityType<Order>();
        //    modelBuilder.EntityType<Student>();
        //    modelBuilder.EntityType<TeachingCourse>();
        //    modelBuilder.EntityType<Tutor>();
        //    modelBuilder.EntityType<University>();
        //    modelBuilder.EntityType<CourseMajor>();
        //    modelBuilder.EntityType<OrderDetail>();
        //    modelBuilder.EntityType<Report>();
        //    modelBuilder.EntityType<User>();
        //    modelBuilder.EntitySet<Report>("Reports");
        //    modelBuilder.EntityType<ReportViewModel>();
        //    modelBuilder.EntityType<ResponseModel<object>>();
        //    return modelBuilder.GetEdmModel();
        //}
    }
}
