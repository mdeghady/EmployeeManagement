using Microsoft.EntityFrameworkCore;
using MnagementAPI.Data;
using MnagementAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Database Connection String
builder.Services.AddDbContext<AppDbContext>(opt => 
            opt.UseNpgsql(builder.Configuration.GetConnectionString("postgresqlConnection")));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();
app.MapGet("api/employee", async (AppDbContext context) =>
{
    var items = await context.Employees.ToListAsync();
    return Results.Ok(items);
});

app.MapPost("api/employee", async (AppDbContext context , Employee employee) =>
{
    await context.Employees.AddAsync(employee);
    await context.SaveChangesAsync();

    return Results.Created($"api/employee/{employee.Id}" , employee);
});

app.MapGet("api/employee/{id}", async (AppDbContext context, int id) =>
{

    var employeeModel = await context.Employees
    .Where(c => c.Id == id)
    .Select(c => new Employee()
    {
        Id = c.Id,
        EmployeeName = c.EmployeeName,
        JobRole = c.JobRole
    })
    .FirstOrDefaultAsync();

    return Results.Ok(employeeModel);
});

app.MapPut("api/employee/{id}" , async(AppDbContext context, int id ,Employee employee) =>{
    var employeeModel = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);

    if (employeeModel == null)
    {
        return Results.NotFound();
    }

    employeeModel.EmployeeName = employee.EmployeeName;
    employeeModel.JobRole = employee.JobRole;

    await context.SaveChangesAsync();
    return Results.NoContent();


});

app.MapDelete("api/employee/{id}", async (AppDbContext context, int id) => {
    var employeeModel = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);

    if (employeeModel == null)
    {
        return Results.NotFound();
    }

    context.Employees.Remove(employeeModel);

    await context.SaveChangesAsync();
    return Results.NoContent();


});

app.MapGet("api/jobroles", async (AppDbContext context) =>
{
    var items = await context.JobRoles.ToListAsync();
    return Results.Ok(items);
});




app.Run();
