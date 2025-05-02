# GpsTogetherWebAPI 🚗📡

GpsTogetherWebAPI é uma API desenvolvida em ASP.NET Core com Entity Framework e SQL Server, com o objetivo de permitir que vários veículos compartilhem suas localizações em tempo real dentro de um grupo, como em caravanas, passeios ou viagens em comboio.

## 🔥 Funcionalidades

- Criar usuários
- Criar grupos com código único (tipo QR Code)
- Entrar em grupos via código
- Compartilhar localização (latitude, longitude e timestamp)
- Obter localização de todos os membros de um grupo
- Interface Swagger para testes

## 🧱 Tecnologias utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server (via Docker)
- Swagger (Swashbuckle)
- Git + GitHub

## 🚀 Como rodar o projeto

1. Clone o repositório:
```bash
git clone https://github.com/SEU_USUARIO/GpsTogetherWebAPI.git
```

2. Vá até a pasta:
```bash
cd GpsTogetherWebAPI
```

3. Suba o banco com Docker:
```bash
docker compose up -d
```

4. Rode as migrations:
```bash
dotnet ef database update
```

5. Execute a aplicação:
```bash
dotnet run
```

6. Acesse o Swagger:
[http://localhost:5023/swagger](http://localhost:5023/swagger)

 Localização em Tempo Real (SignalR)
O GpsTogether agora transmite localizações ao vivo entre usuários conectados usando SignalR.

✅ Como testar:
Execute a API:

bash
Copiar
Editar
dotnet run
Abra o arquivo em Pussk-patch-1 com Live Server

Clique em 🔌 Conectar e depois em 📡 Enviar Localização

Abra outra aba e repita o processo para simular outro veículo

✅ Quando um usuário envia sua posição, os outros a recebem em tempo real

🔧 Tecnologias utilizadas no real-time:
SignalR com ASP.NET Core

WebSocket (fallback para SSE ou Long Polling)

Frontend leve com HTML + JS

## ✨ Próximos passos

- Integração com mapas (ex: Leaflet.js, Google Maps)
- Transmissão em tempo real via SignalR
- Autenticação com JWT
- Frontend em Blazor ou React

---

> “As grandes ideias devem ser vistas, medidas e compartilhadas.” – Equipe GpsTogether
