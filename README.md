📝 To-Do List API
API RESTful desenvolvida em C# com .NET 10, como projeto de estudo para aplicação de conceitos de desenvolvimento web back-end.
🚀 Tecnologias Utilizadas

.NET 10
C# — linguagem principal
ASP.NET Core Web API
Padrão REST com retorno em JSON

📋 Funcionalidades

✅ Listar todas as tarefas
✅ Buscar tarefa por ID
✅ Listar tarefas pendentes
✅ Listar tarefas concluídas
✅ Criar nova tarefa (com validação)
✅ Atualizar tarefa existente
✅ Marcar tarefa como concluída
✅ Deletar tarefa

🔗 Endpoints
MétodoRotaDescriçãoGET/tarefasLista todas as tarefasGET/tarefas/{id}Busca tarefa por IDGET/tarefas/pendentesLista tarefas pendentesGET/tarefas/concluidasLista tarefas concluídasPOST/tarefasCria uma nova tarefaPUT/tarefas/{id}Atualiza uma tarefaPATCH/tarefas/{id}/concluirMarca tarefa como concluídaDELETE/tarefas/{id}Remove uma tarefa
📦 Modelo de Dados
json{
  "id": 1,
  "titulo": "Estudar C#",
  "descricao": "Revisar conceitos de WebApi e REST",
  "concluida": false,
  "criadaEm": "2026-05-11T20:00:00"
}
▶️ Como Executar
Pré-requisitos

.NET 10 SDK

Passos
bash# Clone o repositório
git clone https://github.com/Kawan-marcus/TarefasApi.git

# Entre na pasta do projeto
cd TarefasApi

# Execute a aplicação
dotnet run
A API estará disponível em: http://localhost:5211
🧪 Exemplos de Uso
Criar uma tarefa
jsonPOST /tarefas
{
  "titulo": "Estudar C#",
  "descricao": "Revisar conceitos de WebApi",
  "concluida": false
}
Atualizar uma tarefa
jsonPUT /tarefas/1
{
  "titulo": "Estudar C#",
  "descricao": "Revisar conceitos de WebApi",
  "concluida": true
}
Marcar como concluída
PATCH /tarefas/1/concluir
📁 Estrutura do Projeto
TarefasApi/
├── Controllers/
│   └── TarefasController.cs   # Endpoints da API
├── Models/
│   └── Tarefa.cs              # Modelo de dados
├── Program.cs                 # Configuração da aplicação
└── TarefasApi.csproj          # Configuração do projeto
👨‍💻 Autor
Desenvolvido como projeto de estudo de desenvolvimento web com C# e ASP.NET Core.