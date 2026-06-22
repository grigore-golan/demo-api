using DemoApi.Data;
using DemoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(AppDbContext context) : ControllerBase
{
    [HttpGet] 
    public IActionResult Get() =>
        Ok(context.Todos.ToList());
    
    [HttpGet("{id:int}")] 
    public IActionResult Get(int id) =>
        Ok(context.Todos.Find(id));

    [HttpPost]
    public IActionResult Post(Todo todo)
    {
        context.Todos.Add(todo);
        context.SaveChanges();
        return Ok(todo);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Todo todo)
    {
        var existing = context.Todos.Find(id);
        if (existing == null) return NotFound();
        existing.Title = todo.Title;
        existing.IsComplete = todo.IsComplete;
        context.SaveChanges(); 
        return Ok(existing);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    { 
        var todo = context.Todos.Find(id);
        if (todo == null) return NotFound();
        context.Todos.Remove(todo);
        context.SaveChanges();
        return Ok(); }
}