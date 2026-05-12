using Microsoft.AspNetCore.Mvc;
using TarefasApi.Models;

namespace TarefasApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefasController : ControllerBase
{
    private static List<Tarefa> _tarefas = new();
    private static int _proximoId = 1;

    // GET /tarefas
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_tarefas);
    }

    // GET /tarefas/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada." });
        return Ok(tarefa);
    }

    // GET /tarefas/pendentes
    [HttpGet("pendentes")]
    public IActionResult GetPendentes()
    {
        var pendentes = _tarefas.Where(t => !t.Concluida).ToList();
        return Ok(pendentes);
    }

    // GET /tarefas/concluidas
    [HttpGet("concluidas")]
    public IActionResult GetConcluidas()
    {
        var concluidas = _tarefas.Where(t => t.Concluida).ToList();
        return Ok(concluidas);
    }

    // POST /tarefas
    [HttpPost]
    public IActionResult Create(Tarefa tarefa)
    {
        if (string.IsNullOrWhiteSpace(tarefa.Titulo))
            return BadRequest(new { mensagem = "O título é obrigatório." });

        tarefa.Id = _proximoId++;
        tarefa.CriadaEm = DateTime.Now;
        _tarefas.Add(tarefa);

        return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
    }

    // PUT /tarefas/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarefa atualizada)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada." });

        if (string.IsNullOrWhiteSpace(atualizada.Titulo))
            return BadRequest(new { mensagem = "O título é obrigatório." });

        tarefa.Titulo = atualizada.Titulo;
        tarefa.Descricao = atualizada.Descricao;
        tarefa.Concluida = atualizada.Concluida;

        return Ok(tarefa);
    }

    // PATCH /tarefas/{id}/concluir
    [HttpPatch("{id}/concluir")]
    public IActionResult Concluir(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada." });

        tarefa.Concluida = true;
        return Ok(tarefa);
    }

    // DELETE /tarefas/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada." });

        _tarefas.Remove(tarefa);
        return NoContent();
    }
}