# Arquitetura da Solução

A solução **Rede do Bem** é uma aplicação web estruturada no padrão **MVC (Model-View-Controller)** sobre a plataforma **ASP.NET Core**, com persistência em **SQL Server** via **Entity Framework Core**. A arquitetura segue a separação clara de responsabilidades entre apresentação, regras de negócio e acesso a dados, sendo documentada por três artefatos integrados — Diagrama de Classes, Modelo ER e Projeto da Base de Dados, garantindo coerência total entre documentação e implementação.

## Diagrama de Classes

O diagrama de classes ilustra graficamente a estrutura estática do software e como as classes da aplicação estão interligadas. Cada classe serve de modelo para materializar os objetos que executarão na memória.

As classes apresentadas correspondem fielmente às implementadas no projeto ASP.NET Core MVC, organizadas em quatro camadas:

| Camada | Conteúdo |
|---|---|
| **Enums & Interface** | `TipoUsuario`, `StatusDoacao`, `IValidatableObject` |
| **Models** | `Usuario`, `Campanha`, `Doacao`, `Notificacao`, `Avaliacao`, `Denuncia`, `InstituicaoSalva`, `PerfilUsuario`, `PerfilInstituicao`, `Dashboard` |
| **Data Access** | `ApplicationDbContext` (EF Core) |
| **Controllers** | `CampanhasController`, `DoacoesController`, `NotificacaoController`, `PerfilController`, `PerfilInstituicaoController`, `AvaliacaoController`, `InstituicoesController`, `QueroDoarController`, `DashboardController` |

<img width="7872" height="5895" alt="rede_do_bem_class_diagram_v2" src="https://github.com/user-attachments/assets/57224536-bc85-41cd-af48-0729792268ec" />

## Modelo ER (Projeto Conceitual)

O Modelo ER representa, em nível conceitual, como as entidades do domínio se relacionam entre si na aplicação. Foi derivado diretamente do Diagrama de Classes, considerando apenas as entidades persistidas (`DbSet` no `ApplicationDbContext`) e traduzindo as classes de junção (`Avaliacao`, `Denuncia`, `InstituicaoSalva`) em relacionamentos N:M com atributos próprios.

Entidades modeladas: `USUARIO`, `CAMPANHA`, `DOACAO`, `NOTIFICACAO`, `PERFIL_USUARIO`, `PERFIL_INSTITUICAO`.

Principais relacionamentos:

- `USUARIO` (Instituição) **CRIA** `CAMPANHA` — 1:N
- `CAMPANHA` **RECEBE** `DOACAO` — 1:N
- `USUARIO` (Doador) **SOLICITA** `DOACAO` — 1:N
- `USUARIO` **AVALIA** `USUARIO` (Instituição) — N:M
- `USUARIO` **DENUNCIA** `CAMPANHA` — N:M
- `USUARIO` (Doador) **SALVA** `USUARIO` (Instituição) — N:M
- `USUARIO` **POSSUI** `PERFIL_USUARIO` / `PERFIL_INSTITUICAO` — 1:1

<img width="3458" height="4183" alt="rede_do_bem_er_diagram" src="https://github.com/user-attachments/assets/2877f009-d4d6-435c-846a-cdc60564b9ec" />

## Projeto da Base de Dados

O projeto da base de dados materializa o Modelo ER em formato físico, representando as entidades como **tabelas relacionais** com colunas tipadas, chaves primárias, chaves estrangeiras e restrições de integridade (`NOT NULL`, `UNIQUE`, `DEFAULT`, tamanhos máximos e valores enumerados).

O esquema é composto por 10 tabelas: `Usuarios`, `Campanhas`, `Doacoes`, `Notificacoes`, `Avaliacoes`, `Denuncias`, `InstituicoesSalvas`, `PerfilUsuarios`, `PerfilInstituicoes` e `Dashboards`. As chaves estrangeiras garantem a integridade referencial entre as entidades, conforme os relacionamentos definidos no Modelo ER.

<img width="2831" height="2268" alt="rede_do_bem_db_diagram" src="https://github.com/user-attachments/assets/e821a289-3355-4027-8cb7-c059c542c572" />

---

# Tecnologias Utilizadas

A solução **Rede do Bem** é implementada com uma stack **Microsoft-centric**, organizada em quatro camadas que se comunicam de forma desacoplada.

## Linguagens, frameworks e ferramentas

| Categoria | Tecnologia | Função |
|---|---|---|
| **Linguagem (Backend)** | C# (.NET 8) | Implementação das regras de negócio |
| **Framework Web** | ASP.NET Core MVC | Padrão arquitetural Model-View-Controller |
| **ORM** | Entity Framework Core | Mapeamento objeto-relacional |
| **Banco de Dados** | SQL Server / LocalDB | Persistência das informações |
| **Linguagem (Frontend)** | HTML5, CSS3, JavaScript | Apresentação e interação |
| **Motor de Views** | Razor Pages (.cshtml) | Renderização das telas no servidor |
| **Prototipação** | Figma | Wireframes e design system |
| **Versionamento** | Git + GitHub | Controle de versão e colaboração |
| **Containerização** | Docker | Padronização do ambiente |
| **IDE** | Visual Studio 2022 / VS Code | Desenvolvimento |
| **Migrations** | EF Core Migrations | Versionamento do schema do banco |

## Fluxo de interação do usuário com o sistema

### Frontend
É a parte visual com a qual o usuário interage. É onde o doador ou a ONG preenche os formulários e clica nos botões.

### Comunicação (API REST com JSON)
É a "ponte" de entrega entre frontend e backend.

### Backend (C# com .NET)
Recebe o JSON, processa as regras (ex.: verificar senhas, validar dados, autorizar ações) e decide se a operação é permitida.

### Banco de Dados (SQL)
Se o backend em C# aprovar a operação, ele se conecta ao banco de dados e grava as informações da doação ou do usuário permanentemente em tabelas.

---

# Hospedagem

A hospedagem da plataforma **Rede do Bem** foi planejada na nuvem **Microsoft Azure**, coerente com a stack Microsoft adotada no desenvolvimento, garantindo escalabilidade, segurança e integração nativa com os serviços já utilizados.

## Estratégia de hospedagem

| Componente | Serviço | Justificativa |
|---|---|---|
| **Aplicação Web** | Azure App Service | Hospedagem gerenciada para apps ASP.NET Core, com escalabilidade automática, deploy contínuo via GitHub e certificado HTTPS gratuito |
| **Banco de Dados** | Azure SQL Database | Banco SQL totalmente gerenciado, com backups automáticos, alta disponibilidade e camada de segurança gerenciada pela Microsoft |
| **Armazenamento de arquivos** | Azure Blob Storage | Armazenamento de imagens (fotos de perfil, campanhas) fora do banco, reduzindo custo e melhorando performance |
| **Versionamento e CI/CD** | GitHub + GitHub Actions | Pipeline automatizado que faz build, testes e deploy para o App Service a cada push na branch principal |

## Processo de lançamento

1. **Push para o GitHub** — código é versionado na branch principal.
2. **GitHub Actions** dispara o pipeline de CI/CD, executando build e testes.
3. **Deploy automatizado** para o Azure App Service, com aplicação das migrations do EF Core no Azure SQL Database.
4. **Aplicação disponível** publicamente via URL HTTPS fornecida pelo App Service.
