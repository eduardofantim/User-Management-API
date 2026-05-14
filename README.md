# 👤 User Management API — V2

API RESTful para gerenciamento de usuários com autenticação JWT e controle de acesso por roles, desenvolvida em ASP.NET Core durante meus estudos de back-end.

---

## ✨ Funcionalidades

- ✅ Cadastro e autenticação de usuários
- ✅ Hash de senha com BCrypt
- ✅ Geração e validação de tokens JWT
- ✅ Controle de acesso por roles (User, Manager, Admin)
- ✅ CRUD completo de usuários
- ✅ Validação de dados com Data Annotations
- ✅ Proteção de rotas por nível de permissão

---

## 🚀 Tecnologias

| Tecnologia | Uso |
|---|---|
| C# / .NET 10 | Linguagem e plataforma |
| ASP.NET Core Web API | Framework da API |
| Entity Framework Core | ORM e migrations |
| SQL Server | Banco de dados |
| BCrypt.Net | Hash de senhas |
| JWT Bearer | Autenticação e autorização |

---

## 🔐 Autenticação

A API utiliza **JWT (JSON Web Token)**. Após o login, o token deve ser enviado no header de todas as requisições protegidas:

```
Authorization: Bearer {token}
```

O token contém a **Role** do usuário, que determina o nível de acesso às rotas.


---

## 👥 Roles e Permissões

| Role | Valor | Permissões |
|---|---|---|
| User | 0 | GET |
| Manager | 1 | GET, PUT |
| Admin | 2 | GET, PUT, DELETE |

---

## 📋 Endpoints

### Auth
| Método | Rota | Descrição | Auth |
|---|---|---|---|
| POST | `/api/auth/register` | Cadastra novo usuário | ❌ |
| POST | `/api/auth/login` | Autentica e retorna token JWT | ❌ |

### Users
| Método | Rota | Descrição | Auth |
|---|---|---|---|
| GET | `/api/users` | Lista todos os usuários | ✅ |
| GET | `/api/users/{id}` | Busca usuário por ID | ✅ |
| PUT | `/api/users/{id}` | Atualiza usuário | ✅ Admin, Manager |
| DELETE | `/api/users/{id}` | Remove usuário | ✅ Admin |

---

## 📦 Exemplos de Requisição

### Register
```json
POST /api/auth/register
{
  "name": "Eduardo Fantim",
  "email": "eduardo@email.com",
  "password": "senha123"
}
```

### Login
```json
POST /api/auth/login
{
  "email": "eduardo@email.com",
  "password": "senha123"
}
```
**Resposta:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Update
```json
PUT /api/users/1
Authorization: Bearer {token}
{
  "name": "Novo Nome",
  "email": "novo@email.com"
}
```

---

## ⚙️ Como rodar a aplicação

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/)
- SQL Server local ou em nuvem

### Passo a passo

```bash
# 1. Clone o repositório
git clone https://github.com/seu-usuario/user-management-api.git
cd user-management-api

# 2. Configure a connection string no appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=UserManagementDb;Trusted_Connection=True;"
}

# 3. Configure o JWT no appsettings.json
"JwtSettings": {
  "SecretKey": "sua-chave-secreta-minimo-32-chars",
  "Issuer": "UserManagement.Api",
  "Audience": "UserManagement.Api",
  "ExpiresInMinutes": 60
}

# 4. Execute as migrations
dotnet ef database update

# 5. Rode a aplicação
dotnet run
```

> ⚠️ **Atenção:** nunca suba sua `SecretKey` para o repositório.
> Use variáveis de ambiente ou User Secrets em produção.

---

## 🏗️ Estrutura do Projeto

```
UserManagement.Api/
├── Controllers/
│   ├── AuthController.cs      # Register e Login
│   └── UsersController.cs     # CRUD de usuários
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   ├── LoginDto.cs
│   ├── RegisterDto.cs
│   └── UpdateUserDto.cs
├── migrations/
├── Models/
│   └── User.cs                # Modelo + Enum UserRole
└── Program.cs
```

---

## 📈 Próximas versões

- [ ] Variáveis de ambiente para dados sensíveis (SecretKey, ConnectionString) - Importante
- [ ] Refresh Token
- [ ] Endpoint para promoção de roles por Admin
- [ ] Paginação nas listagens
- [ ] Testes unitários com xUnit
- [ ] Deploy no Railway ou Azure

---

## 👨‍💻 Autor

Desenvolvido por **Eduardo Fantim**  
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=flat&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/eduardo-fantim-5b2075207/)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=flat&logo=github&logoColor=white)](https://github.com/eduardofantim)
