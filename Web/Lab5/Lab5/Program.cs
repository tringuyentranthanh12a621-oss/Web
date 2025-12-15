using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ====================================================
// 1. ĐĂNG KÝ DỊCH VỤ (SERVICES)
// (Phải thực hiện trước dòng builder.Build())
// ====================================================

// Thêm dịch vụ cho Controllers (nếu dùng kết hợp)
builder.Services.AddControllers();

// Cấu hình Swagger/OpenAPI để test API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký Database Context (Sử dụng In-Memory DB có tên "TodoList")
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ====================================================
// 2. XÂY DỰNG ỨNG DỤNG
// ====================================================
var app = builder.Build();

// ====================================================
// 3. CẤU HÌNH PIPELINE XỬ LÝ REQUEST
// ====================================================

// Nếu là môi trường phát triển (Development) thì bật Swagger lên để test
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// ====================================================
// 4. ĐỊNH NGHĨA CÁC MINIMAL API ENDPOINTS
// ====================================================

// GET: Lấy toàn bộ danh sách
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

// GET: Lấy chi tiết theo ID
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

// POST: Tạo mới một Todo
app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

// PUT: Cập nhật thông tin
app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// DELETE: Xóa theo ID
app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }
    return Results.NotFound();
});

// Map các Controller truyền thống (nếu có dùng)
app.MapControllers();

// ====================================================
// 5. CHẠY ỨNG DỤNG
// (Dòng này luôn phải nằm cuối cùng của logic xử lý)
// ====================================================
app.Run();

// ====================================================
// 6. CÁC CLASS MODEL VÀ DB CONTEXT
// ====================================================

// Model: Đại diện cho công việc cần làm
public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}

// Context: Quản lý kết nối DB
class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}