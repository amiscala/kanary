using k8s;
using Kanary.Config;
using Kanary.Domain.Interfaces.Services;
using Kanary.HostedServices;
using Kanary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IKubernetes>(sp =>
{
    var config = KubernetesClientConfiguration.BuildConfigFromConfigFile();
    return new Kubernetes(config);
})
.AddLogging(x=>x.AddConsole())
.AddSingleton<IKanaryClient,KanaryClient>()
.AddHostedService<KanaryHostedService>();
builder.Services.AddControllers();
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiConfig"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
