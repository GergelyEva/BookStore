using BookStore;
using BookStore.Data.Abstractions;
using BookStore.Data.MongoDB;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyModel;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

internal class Program
{
    private static Assembly[] Assemblies;

    private static void Main(string[] args)
    {
        Assemblies = LoadApplicationDependencies();
        var builder = WebApplication.CreateBuilder(args);

        var config = builder.Configuration;

        builder.Services.AddFluentValidation(options =>
        {
            options.RegisterValidatorsFromAssemblies(Assemblies);
        });

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assemblies));

        var databaseSettings = new DatabaseConfiguration();
        config.Bind(nameof(DatabaseConfiguration), databaseSettings);
        builder.Services.AddSingleton<IDatabaseConfiguration>(databaseSettings);

        builder.Services.Scan(scan => scan.FromAssemblies(Assemblies)
            .AddClasses(type => type.AssignableTo(typeof(IRepository<>))).AsImplementedInterfaces().WithScopedLifetime()
            .AddClasses(type => type.AssignableTo(typeof(IDatabase))).AsImplementedInterfaces().WithSingletonLifetime());

        builder.Services.AddScoped<IUserService, UserService>();


        //added for JWT
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }

    private static Assembly[] LoadApplicationDependencies()
    {
        var context = DependencyContext.Default;
        return context.RuntimeLibraries.SelectMany(library =>
            library.GetDefaultAssemblyNames(context))
            .Where(assembly => assembly.FullName.Contains("BookStore"))
            .Select(Assembly.Load).ToArray();
    }
}
