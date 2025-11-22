# 📝 API de Gerenciamento de Tarefas

Uma API REST desenvolvida em **C# .NET** para gerenciamento de tarefas, aplicando conceitos de **arquitetura em camadas** e **boas práticas** de desenvolvimento.

## 🎯 Sobre o Projeto

Este projeto foi desenvolvido como parte dos estudos do curso da **Rocketseat**, com o objetivo de aplicar conceitos fundamentais de APIs REST, arquitetura em camadas e separação de responsabilidades. A API permite realizar operações CRUD (Create, Read, Update, Delete) em tarefas, com validações e tratamento de erros estruturado.

> **Nota:** Este é um projeto de estudos. Os dados são armazenados em memória (listas estáticas) para fins educacionais, sem persistência em banco de dados.

## ✨ Funcionalidades

- ✅ **Criar tarefa** - Cadastro de novas tarefas com validação de dados
- ✅ **Listar todas as tarefas** - Visualização de todas as tarefas cadastradas
- ✅ **Buscar tarefa por ID** - Consulta de tarefa específica
- ✅ **Atualizar tarefa** - Edição de tarefas existentes
- ✅ **Deletar tarefa** - Remoção de tarefas
- ✅ **Validações robustas** - Mensagens de erro detalhadas
- ✅ **Documentação Swagger** - Interface interativa para testes

## 🛠️ Tecnologias Utilizadas

- **C# / .NET** - Framework principal
- **ASP.NET Core Web API** - Construção da API REST
- **Swagger/OpenAPI** - Documentação e testes da API
- **Arquitetura em Camadas** - Separação de responsabilidades

## 📂 Estrutura do Projeto

```
Tarefas/
├── Tarefas.API/
│   └── Controllers/
│       └── TaskController.cs          # Endpoints da API
│
├── Tarefas.Application/
│   └── UseCases/
│       └── Task/
│           ├── CreateTask/            # Lógica de criação
│           ├── GetAll/                # Lógica de listagem
│           ├── GetById/               # Lógica de busca por ID
│           ├── Update/                # Lógica de atualização
│           └── DeleteById/            # Lógica de exclusão
│
└── Tarefas.Communication/
    ├── Enums/
    │   ├── PriorityType.cs           # Enum de prioridades
    │   └── StatusType.cs             # Enum de status
    ├── Requests/
    │   └── RequestTaskJson.cs        # Modelo de entrada
    └── Responses/
        ├── ResponseTaskJson.cs       # Modelo de resposta completo
        ├── ResponseShortTaskJson.cs  # Modelo de resposta resumido
        ├── ResponseCreatedTaskJson.cs # Modelo de resposta de criação
        ├── ResponseAllTaskJson.cs    # Modelo de lista de tarefas
        └── ResponseErrorsJson.cs     # Modelo de erros
```

## 🏗️ Arquitetura em Camadas

### **1. Camada de API (Tarefas.API)**
- Responsável pelos endpoints HTTP
- Recebe requisições e retorna respostas
- Valida status codes apropriados

### **2. Camada de Aplicação (Tarefas.Application)**
- Contém as regras de negócio (UseCases)
- Realiza validações de dados
- Processa a lógica de cada operação

### **3. Camada de Comunicação (Tarefas.Communication)**
- Define contratos de entrada (Requests)
- Define contratos de saída (Responses)
- Define enumeradores e modelos compartilhados

## 🚀 Como Executar o Projeto

### **Pré-requisitos**
- [.NET SDK](https://dotnet.microsoft.com/download) instalado
- IDE de sua preferência (Visual Studio, VS Code, Rider)

### **Passo a passo**

1. **Clone o repositório**
```bash
git clone https://github.com/seu-usuario/tarefas-api.git
cd tarefas-api
```

2. **Restaure as dependências**
```bash
dotnet restore
```

3. **Execute o projeto**
```bash
dotnet run --project Tarefas.API
```

4. **Acesse a documentação Swagger**
```
https://localhost:5001/swagger
```

## 📡 Endpoints da API

### **Base URL:** `/api/task`

| Método | Endpoint | Descrição | Status Code |
|--------|----------|-----------|-------------|
| `POST` | `/api/task` | Criar nova tarefa | 201, 400 |
| `GET` | `/api/task` | Listar todas as tarefas | 200, 204 |
| `GET` | `/api/task/{id}` | Buscar tarefa por ID | 200, 404 |
| `PUT` | `/api/task/{id}` | Atualizar tarefa | 204, 404 |
| `DELETE` | `/api/task/{id}` | Deletar tarefa | 204, 404 |

## 📝 Exemplos de Uso

### **Criar Tarefa (POST)**

**Request:**
```json
POST /api/task
Content-Type: application/json

{
  "name": "Estudar C#",
  "description": "Revisar conceitos de APIs REST",
  "priority": 1,
  "dueDate": "2025-12-31T23:59:59",
  "status": 0
}
```

**Response (201 Created):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "Estudar C#",
  "description": "Revisar conceitos de APIs REST",
  "priority": 1,
  "dueDate": "2025-12-31T23:59:59",
  "status": 0
}
```

**Response (400 Bad Request - Validação):**
```json
{
  "errors": [
    "O nome não pode ser vazio.",
    "A data não pode estar no passado."
  ]
}
```

### **Listar Tarefas (GET)**

**Request:**
```
GET /api/task
```

**Response (200 OK):**
```json
{
  "tasks": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "name": "Estudar C#",
      "description": "Revisar conceitos de APIs REST"
    },
    {
      "id": "8cb92384-7394-4930-a2c5-1f847bc9e512",
      "name": "Fazer exercícios",
      "description": "Praticar LINQ"
    }
  ]
}
```

### **Buscar por ID (GET)**

**Request:**
```
GET /api/task/1
```

**Response (200 OK):**
```json
{
  "id": 1,
  "name": "Jefferson",
  "description": "Arrumar a casa",
  "priority": 1,
  "dueDate": "2025-12-25T00:00:00",
  "status": 1
}
```

**Response (404 Not Found):**
```json
{
  "errors": [
    "Tarefa com ID 999 não foi encontrada."
  ]
}
```

### **Atualizar Tarefa (PUT)**

**Request:**
```json
PUT /api/task/1
Content-Type: application/json

{
  "name": "Estudar C# Avançado",
  "description": "Estudar async/await",
  "priority": 2,
  "dueDate": "2025-12-31T23:59:59",
  "status": 1
}
```

**Response:**
- `204 No Content` - Atualizado com sucesso
- `404 Not Found` - Tarefa não encontrada

### **Deletar Tarefa (DELETE)**

**Request:**
```
DELETE /api/task/1
```

**Response:**
- `204 No Content` - Deletado com sucesso
- `404 Not Found` - Tarefa não encontrada

## 🔍 Enumeradores

### **Priority (Prioridade)**
```csharp
0 - Low (Baixa)
1 - Medium (Média)
2 - High (Alta)
```

### **Status**
```csharp
0 - Pending (Pendente)
1 - InProgress (Em Progresso)
2 - Completed (Concluída)
```

## ✅ Validações Implementadas

- ✅ Nome obrigatório
- ✅ Nome com máximo de 100 caracteres
- ✅ Descrição com máximo de 500 caracteres
- ✅ Data de vencimento deve ser futura
- ✅ Prioridade válida (0, 1 ou 2)
- ✅ Status válido (0, 1 ou 2)

## 📚 Conceitos Aplicados

- **REST API** - Padrões e convenções
- **HTTP Status Codes** - Uso correto dos códigos
- **Separação em Camadas** - API, Application, Communication
- **Use Cases** - Padrão para lógica de negócio
- **DTOs (Data Transfer Objects)** - Requests e Responses
- **Validações** - Tratamento de erros estruturado
- **Enumeradores** - Tipagem forte para valores fixos

## 🎓 Aprendizados

Este projeto foi desenvolvido para consolidar conhecimentos em:
- Criação de APIs REST com .NET
- Organização de código em camadas
- Boas práticas de desenvolvimento
- Documentação de APIs
- Tratamento de erros e validações
