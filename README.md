# Petshop Search

Sistema de busca de petshops.

## Arquitetura e Design

### Clean Architecture
O projeto é estruturado seguindo os princípios da Clean Architecture, dividido em camadas:

- **Core**: Entidades, DTOs, interfaces e extensões
- **Infrastructure**: Simulação de persistência e dados dos petshops
- **Test**: Testes unitários
- **ConsoleApp**: Interface com usuário

### Princípios e Padrões
- Clean Code
- Princípios SOLID
- Padrão escolhido: Strategy para cálculo de preços
- LINQ para manipulação de coleções
- Expressões ternárias para código conciso

## Premissas

- Preços fixos para cada petshop
- Preços diferenciados para:
  - Cães pequenos e grandes
  - Dias úteis e finais de semana
- Distância como critério de desempate

## Requisitos

- .NET 9
- Visual Studio 2022, VS Code ou Rider

## Como Executar

```bash
# Clone o repositório
git clone https://github.com/MoacyrPereira/Petshop_Search.git

# Navegue até a pasta
cd Petshop_Search

# Restaure as dependências
dotnet restore

# Execute o projeto
dotnet run --project ConsoleApp
```

### Formato de Entrada
```
dd/MM/yyyy QtdCaesPequenos QtdCaesGrandes
```
Exemplo:
```
12/02/2025 3 5
```

### Executando Testes
```bash
dotnet test
```

## Decisões Técnicas

- **Strategy Pattern**: Encapsula a lógica de cálculo de preços, facilitando a adição de novos petshops
- **LINQ**: Utilizado para ordenação e seleção do melhor petshop
- **Validações**: Implementadas usando expressões ternárias para código mais limpo
- **Testes**: Cobertura dos principais cenários de negócio

## Estrutura do Projeto

```
Petshop_Search/
├── src/
│   ├── Core/
│   │   ├── Entities/
│   │   ├── Extensions/
│   │   └── Repositories/
│   ├── Infrastructure/
│   │   └── Repositories/
│   └── ConsoleApp/
└── tests/
    └── Core.Tests/
```


## Autor

Moacyr Pereira