﻿var builder = WebApplication.CreateBuilder(args);
//Add thêm
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Cần sửa
//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();



