var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

// Middleware 1: Terminates request if path starts with "/end"
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/end"))
    {
        await context.Response.WriteAsync("Request terminated here.");
        return; // Ends the request pipeline.
    }
    await next();
});

// Middleware 2: Writes "Hello1" if path starts with "/hello"
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/hello"))
    {
        await context.Response.WriteAsync("Hello1 ");
    }
    await next();
});

// Middleware 3: Writes "Hello2" if path starts with "/hello"
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/hello"))
    {
        await context.Response.WriteAsync("Hello2 ");
    }
    await next();
});

// Ensures Authorization Middleware is applied
app.UseAuthorization();

// ✅ Ensure MVC Routing is reached before final middleware
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Add}/{id?}");

// 🚀 Move `app.Run()` to the end
app.Run();
