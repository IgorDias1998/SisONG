# 🧩 SisONG API

API RESTful desenvolvida com ASP.NET Core para gerenciar as operações de uma ONG, incluindo voluntários, doadores, doações, eventos, transações financeiras e relatórios.


## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- AutoMapper
- Swagger (Swashbuckle)
- FluentValidation / Data Annotations


## 📦 Funcionalidades da API

- ✅ Cadastro e login de usuários com perfis diferenciados (Administrador, Voluntário, Doador)
- ✅ Gerenciamento de voluntários, doadores e eventos
- ✅ Registro de participação de voluntários em eventos
- ✅ Controle de doações financeiras e de insumos
- ✅ Lançamento de transações financeiras (entradas e saídas)
- ✅ Cálculo automático do saldo financeiro da ONG
- ✅ Geração de relatórios por tipo e período
- ✅ Documentação de endpoints com Swagger


## 🛠️ Como Rodar a API Localmente

### 1. Clone o repositório
Terminal:
git clone https://github.com/seu-usuario/sisong-api.git
cd sisong-api

### 2. Configure a string de conexão no appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=sisongdb;user=root;password=suaSenha;"
}

### 3. Restaure os pacotes e aplique as migrations
Terminal:
dotnet restore
dotnet ef database update

### 4. Rode a aplicação
Terminal:
dotnet run

### 🧱 Estrutura do Projeto

Models - Entidades que representam os dados (ex: Voluntario, Evento, Doacao).
DTOs - Objetos usados para entrada e saída de dados via API.
Repositories - Camada de acesso ao banco de dados (CRUD).
Services - Regras de negócio e validações.
Controllers - Endpoints expostos via HTTP.
Profiles - Mapeamento automático entre Models e DTOs usando AutoMapper.

### 🧾 Referências

<a href="https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-9.0">Documentação oficial ASP.NET Core</a>
<a href="https://learn.microsoft.com/pt-br/ef/core/">Entity Framework Core</a>
<a href="https://automapper.org/">AutoMapper Documentation</a>
<a href="https://github.com/domaindrivendev/Swashbuckle.AspNetCore">Swashbuckle.AspNetCore - Swagger UI</a>
