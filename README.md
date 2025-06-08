# LugiaWeather API

API RESTful desenvolvida em ASP.NET Core (.NET 9) com Entity Framework Core, utilizando migrations para gerenciamento de banco de dados relacional. A API gerencia dispositivos IoT, alertas e leituras para detecção de alagamentos, com endpoints para cadastro, consulta e validação de dados.

---

## 📌 Descrição

A LugiaWeather API oferece endpoints para:

- 📡 Cadastro, consulta e gerenciamento de dispositivos IoT
- 🚨 Consulta de alertas
- 🌡️ Cadastro e consulta de leituras

---

## 🚀 Como rodar o projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/Lugia-Weather/.net.git
   cd .net/lugiaweather-api
   ```

2. Restaure os pacotes e compile:

   ```bash
   dotnet restore
   dotnet build
   ```

3. Rode a aplicação:

   ```bash
   dotnet run
   ```

4. Acesse o Swagger para testar os endpoints:

   ```
   http://localhost:5114/swagger
   ```

---

## 📦 Endpoints (Exemplo)

### 🌐 Raiz

| Método | Rota | Descrição                           |
| ------ | ---- | ----------------------------------- |
| GET    | `/`  | Retorna uma mensagem de boas-vindas |

---

### 📡 Dispositivos IoT

| Método | Rota            | Descrição                      |
| ------ | --------------- | ------------------------------ |
| GET    | `/dispositivos` | Lista paginada de dispositivos |
| POST   | `/dispositivos` | Cadastra um novo dispositivo   |

---

### 🚨 Alertas

| Método | Rota       | Descrição                 |
| ------ | ---------- | ------------------------- |
| GET    | `/alertas` | Lista paginada de alertas |
| POST   | `/alertas` | Cadastra um novo alerta   |

---

### 🌡️ Leituras

| Método | Rota        | Descrição                  |
| ------ | ----------- | -------------------------- |
| GET    | `/leituras` | Lista paginada de leituras |
| POST   | `/leituras` | Cadastra uma nova leitura  |

---

## 📁 Estrutura do Projeto

```plaintext
.net/
   lugiaweather-api/
   ├── Data/
   ├── Dtos/
   ├── Endpoints/
├   ├── Enums/
├   ├── Errors/
├   ├── Migrations/
├   ├── Models/
├   ├── Pages/
├   ├── Properties/
├   ├── Services/
├   ├── Validators/
├   ├── wwwroot/
├   ├── Program.cs
├   ├── appsettings.json
└── README.md
```
