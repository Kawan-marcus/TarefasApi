using TarefasApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TarefasApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefasController : ControllerBase
{
    private static List<Tarefa> _tarefas = new();
    private static int _proximoId = 1;

    [HttpGet]
    public IActionResult GetAll() => Ok(_tarefas);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public IActionResult Create(Tarefa tarefa)
    {
        tarefa.Id = _proximoId++;
        _tarefas.Add(tarefa);
        return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarefa atualizada)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound();
        tarefa.Titulo = atualizada.Titulo;
        tarefa.Descricao = atualizada.Descricao;
        tarefa.Concluida = atualizada.Concluida;
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound();
        _tarefas.Remove(tarefa);
        return NoContent();
    }
}
