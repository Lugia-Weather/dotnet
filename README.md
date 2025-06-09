# LugiaWeather API

API RESTful desenvolvida em ASP.NET Core (.NET 9) com Entity Framework Core, utilizando migrations para gerenciamento de banco de dados relacional. A API gerencia dispositivos IoT, alertas e leituras para detecção de alagamentos, com endpoints para cadastro, consulta e validação de dados.

---

## 📌 Descrição

A LugiaWeather API oferece endpoints para:

- 📡 Cadastro, consulta e gerenciamento de dispositivos IoT
- 🚨 Consulta de alertas por dispositivo IoT
- 🌡️ Cadastro e consulta de leituras por dispositivo IoT

---

## 🚀 Como rodar o projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/Lugia-Weather/dotnet.git
   cd dotnet/lugiaweather-api
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

   Abra o navegador e acesse:

   ```
   http://localhost:5114/swagger
   ```

---

## 🔗 Acesso à API

Após rodar o projeto, a API estará disponível em:

```
http://localhost:5114
```
Você pode testar os endpoints diretamente pelo Swagger ou usando ferramentas como Postman, Insomnia ou curl.

Para acessar as Razor pages

```
http://localhost:5114/admin
```
---

## 🧪 Exemplos de Teste

### 🌐 Endpoint Raiz

**Requisição:**

```bash
curl http://localhost:5114/
```

**Resposta esperada:**

```json
{
  "mensagem": "Bem-vindo à API LugiaWeather!",
  "versao": "v1",
  "documentacao": "/swagger"
}
```

---

### 📡 Dispositivos IoT

#### 1. Listar dispositivos IoT (paginado)

```bash
curl "http://localhost:5114/dispositivos?pagina=1&quantidade=10"
```

#### 2. Buscar dispositivo IoT por ID

```bash
curl http://localhost:5114/dispositivos/1
```

#### 3. Cadastrar um dispositivo IoT

```bash
curl -X POST http://localhost:5114/dispositivos \
  -H "Content-Type: application/json" \
  -d '{
    "idModulo": "MOD123",
    "macEndereco": "00:11:22:33:44:55",
    "projeto": "Lugia Weather",
    "status": "Ativo",
    "latitude": -23.5505,
    "longitude": -46.6333
  }'
```

#### 4. Atualizar dispositivo IoT

```bash
curl -X PUT http://localhost:5114/dispositivos/1 \
  -H "Content-Type: application/json" \
  -d '{
    "idModulo": "MOD123",
    "macEndereco": "00:11:22:33:44:55",
    "projeto": "Lugia Weather",
    "status": "Inativo",
    "latitude": -23.5505,
    "longitude": -46.6333
  }'
```

#### 5. Remover dispositivo IoT

```bash
curl -X DELETE http://localhost:5114/dispositivos/1
```

---

### 🚨 Alertas

#### 1. Listar alertas de um dispositivo (com filtros opcionais de data)

```bash
curl "http://localhost:5114/alertas/1?data_inicio=2025-06-01&data_fim=2025-06-08"
```

---

### 🌡️ Leituras

#### 1. Listar leituras de um dispositivo (com filtros opcionais de data)

```bash
curl "http://localhost:5114/leituras/1?data_inicio=2025-06-01&data_fim=2025-06-08"
```

#### 2. Cadastrar uma leitura

```bash
curl -X POST http://localhost:5114/leituras \
  -H "Content-Type: application/json" \
  -d '{
    "idDispositivo": 1,
    "nivelAguaCm": 2.5,
    "statusNivel": "Alagado"
  }'
```

---

## 📦 Endpoints

### 🌐 Raiz

| Método | Rota | Descrição                           |
| ------ | ---- | ----------------------------------- |
| GET    | `/`  | Retorna uma mensagem de boas-vindas |

---

### 📡 Dispositivos IoT

| Método | Rota                 | Descrição                         |
| ------ | -------------------- | --------------------------------- |
| GET    | `/dispositivos`      | Lista paginada de dispositivos    |
| GET    | `/dispositivos/{id}` | Busca dispositivo por ID          |
| POST   | `/dispositivos`      | Cadastra um novo dispositivo      |
| PUT    | `/dispositivos/{id}` | Atualiza um dispositivo existente |
| DELETE | `/dispositivos/{id}` | Remove um dispositivo             |

---

### 🚨 Alertas

| Método | Rota                        | Descrição                                         |
| ------ | --------------------------- | ------------------------------------------------- |
| GET    | `/alertas/{id_dispositivo}` | Lista alertas de um dispositivo (filtro por data) |

---

### 🌡️ Leituras

| Método | Rota                         | Descrição                                          |
| ------ | ---------------------------- | -------------------------------------------------- |
| GET    | `/leituras/{id_dispositivo}` | Lista leituras de um dispositivo (filtro por data) |
| POST   | `/leituras`                  | Cadastra uma nova leitura                          |

---

## 📁 Estrutura do Projeto

```plaintext
.net/
├   lugiaweather-api/
├   ├── Data/
├   ├── Dtos/
├   ├── Endpoints/
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
├   ├── Dockerfile
├── README.md
└── LICENSE
```

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

### **Júlio César Nunes Oliveira - RM557774 2TDSFPF** - [GitHub](https://github.com/jubshereman)

### **Erik Paschoalatto dos Santos - RM554854 2TDSFPF** - [GitHub](https://github.com/ozerikoz)

### **Nathan Magno Gustavo Consolo - RM558987 2TDSFPF** - [GitHub](https://github.com/NathanMagno)
