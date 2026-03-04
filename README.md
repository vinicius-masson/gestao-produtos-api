Teste Técnico Techifin - gestão de Produtos

🚀 Como executar o projeto

✅ Pré-requisitos
.NET 8 SDK
Visual Studio 2022 ou VS Code (opcional)

📥 Configuração inicial
Extraia o projeto zipado, ou clone o repositório:
```bash
  git clone https://github.com/vinicius-masson/gestao-produtos-api.git
```

### ▶️ Executar a aplicação

```bash
cd src/Gestao.Produtos.API
dotnet run --launch-profile "https"
```
Acesse a documentação: https://localhost:7253/swagger

### 🔧 Estrutura do projeto

📦 Gestao.Produtos.API
├── 📂 src
│   ├── 📂 Gestao.Produtos.API           # API .NET 8 (Camada de Apresentação)
	  ├── 📂 Gestao.Produtos.Aplication    # API .NET 8 (Casos de Uso e DTOs)
	  ├── 📂 Gestao.Produtos.Domain        # API .NET 8 (Entidades e Regras de Negócio)
	  ├── 📂 Gestao.Produtos.Infra         # API .NET 8 (Repositórios, Migrations)
│   └── 📂 Gestao.Produtos.Crosscutting  # API .NET 8 (Injeção de Dependência)
├── 📂 tests
│   └── 📂 Gestao.Produtos.Tests         # API .NET 8 (Testes Unitários da amada aplication)
└── 📄 README.md                 # Este arquivo

## 👤 Author
[Vinicius Masson](https://www.linkedin.com/in/vinicius-masson/)
Software Developer | .NET
