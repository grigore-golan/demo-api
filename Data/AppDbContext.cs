using Microsoft.EntityFrameworkCore;
using DemoApi.Models;

namespace DemoApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos => Set<Todo>();
}