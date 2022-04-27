using plumcourse.Data;
using plumcourse.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using plumcourse.Data.Repository;


var builder = WebApplication.CreateBuilder(args);

var confString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("dbsettings.json").Build();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ICourses,CourseRepository>();
builder.Services.AddTransient<IUsers, UserRepository>();
builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(confString.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBobjects.Initial(content);
}