# Clean Architecture .NET 10 — Product Registration API

API desenvolvida com **.NET 10** aplicando os principais conceitos de **Clean Architecture**, com foco em separação de responsabilidades, organização em camadas e boas práticas de desenvolvimento backend.

O projeto simula um sistema de **cadastro de produtos**, permitindo operações de criação, consulta, atualização e remoção (CRUD), estruturado de forma escalável e preparada para ambientes corporativos.

---

## Objetivo do Projeto

Este projeto tem como finalidade:

- Demonstrar domínio em arquitetura limpa
- Aplicar princípios SOLID
- Implementar separação clara entre domínio e infraestrutura
- Estruturar um backend pronto para crescimento e manutenção
- Servir como projeto estratégico de portfólio backend

---

## Arquitetura

O projeto é baseado nos princípios da Clean Architecture, proposta por Robert C. Martin.

A estrutura é organizada em camadas bem definidas, garantindo baixo acoplamento e alta coesão.

### Estrutura do Projeto

---

### Domain
- Entidades
- Interfaces de Repositório
- Regras de negócio
- Contratos

### Application
- Use Cases
- DTOs / ViewModels
- Orquestração da lógica de aplicação
- Serviços de aplicação

### Infrastructure
- Implementação de repositórios
- Contexto do banco de dados
- Configuração do Entity Framework
- Persistência

### API (Presentation Layer)
- Controllers
- Configuração de Injeção de Dependência
- Middlewares
- Swagger

---

## Tecnologias Utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Docker
- Docker Compose

---

## Conceitos Aplicados

- Clean Architecture
- SOLID
- Inversão de Dependência
- Injeção de Dependência (IoC)
- Repository Pattern
- Separação de Camadas
- Organização modular
- Boas práticas de API REST

---

## Como Executar o Projeto

### Pré-requisitos

- .NET 10 SDK instalado
- SQL Server (ou Docker)
- Docker (opcional)

---

## ▶️ Executando Localmente (Sem Docker)

### 1️⃣ Clonar o repositório

```bash
git clone https://github.com/raffaell95/clean-arcuitecture-dotnet10.git
cd clean-arcuitecture-dotnet10
dotnet restore
dotnet ef database update --project CleanArchitecture.Infrascructure --startup-project CleanArchitecture.API
dotnet run
