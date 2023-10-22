# CadastrosEmpresasAPI

![.NET](https://img.shields.io/badge/.NET-%23512BD4.svg?style=for-the-badge&logo=.net&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=for-the-badge&logo=postgresql&logoColor=white)

Este projeto é uma API construída usando **.NET, Entity Framework para o mapeamento do banco de dados, e PostgreSQL como o banco de dados.**

## Índice

- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Database](#database)
- [Contributing](#contributing)

## Installation

1. Clone o repositório:

```bash
git clone https://github.com/IamDaniloP/CadastroEmpresasAPI.git
```

2. Instale [PostgresSQL](https://www.postgresql.org/)

## Uso

1. Inicie a aplicação com o Visual Studio ou usando o comando dotnet run no terminal.

2. A API estará acessível em https://localhost:7082/ ou na porta configurada.
   
3. Certifique-se de ajustar as instruções conforme o ambiente e a configuração específicos do seu projeto .NET.

## Endpoints API

```markdown

Companies
POST /api/companies
Registra uma nova empresa.

GET /api/companies
Recupera a lista de todas as empresas.

DELETE /api/companies/{cnpj}
Exclui uma empresa com base no CNPJ.

GET /api/companies/{cnpj}
Recupera os detalhes de uma empresa com base no CNPJ.

PUT /api/companies/{cnpj}
Atualiza os dados de uma empresa com base no CNPJ.

Department
POST /api/department
Registra um novo departamento.

GET /api/department
Recupera a lista de todos os departamentos.

DELETE /api/department/{id}
Exclui um departamento com base no ID.

GET /api/department/{id}
Recupera os detalhes de um departamento com base no ID.

PUT /api/department/{id}
Atualiza os dados de um departamento com base no ID.

Employee
POST /api/employee
Registra um novo funcionário.

GET /api/employee
Recupera a lista de todos os funcionários.

DELETE /api/employee/{id}
Exclui um funcionário com base no ID.

GET /api/employee/{id}
Recupera os detalhes de um funcionário com base no ID.

PUT /api/employee/{id}
Atualiza os dados de um funcionário com base no ID.

EmployeeTask
POST /api/taskemployee
Associa um funcionário a uma tarefa.

DELETE /api/taskemployee/{taskId}/{employeeId}
Desassocia um funcionário de uma tarefa com base nos IDs da tarefa e do funcionário.

GET /api/taskemployee/{taskId}/{employeeId}
Recupera os detalhes da associação entre um funcionário e uma tarefa com base nos IDs da tarefa e do funcionário.

Task
POST /api/task
Registra uma nova tarefa.

GET /api/task
Recupera a lista de todas as tarefas.

DELETE /api/task/{id}
Exclui uma tarefa com base no ID.

GET /api/task/{id}
Recupera os detalhes de uma tarefa com base no ID.

PUT /api/task/{id}
Atualiza os dados de uma tarefa com base no ID.

```

## Banco de Dados
O projeto utiliza o [PostgresSQL](https://www.postgresql.org/) como banco de dados. As migrações necessárias do banco de dados são gerenciadas usando o [Entity Framework](https://docs.microsoft.com/pt-br/ef/).

