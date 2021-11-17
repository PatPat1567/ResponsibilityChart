using System.Reflection;
using Microsoft.OpenApi.Models;
using ResponsibilityChart.Api.Interfaces;
using ResponsibilityChart.Api.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IResponsibilityService, ResponsibilityService>();
builder.Services.AddSingleton<IChildService, ChildService>();
builder.Services.AddSingleton<IChartService, ChartService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Responsibility Chart Api",
        Description = "A basic api to interact between responsibility chart UI and the database backend.",
        Contact = new OpenApiContact
        {
            Name = "Patrick Towle",
            Email = string.Empty,
            Url = new Uri("https://github.com/patpat1567"),
        },
        // License = new OpenApiLicense
        // {
        //     Name = "Use under MIT"
        // }
    });
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Responsibility Chart Api");
        c.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
