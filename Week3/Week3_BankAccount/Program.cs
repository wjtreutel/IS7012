using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Week3_BankAccount.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext") ?? throw new InvalidOperationException("Connection string 'DBContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//builder.Services.AddDbContext<Week3Context>(options => options.UseSqlServer("Server=desktop-bl2t5q4\sqlexpress01;Database=Week3_BankAccountContext-9760c846-8495-4e72-9986-7baf107c1dd3;Trusted_Connection=True;MultipleActiveResultSets=true"));
//builder.Services.AddScoped<IMyDbContext, MyDbContext>();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
