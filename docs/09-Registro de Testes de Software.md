
https://github.com/user-attachments/assets/7f9d5bef-1a79-45d2-944d-8f177622c8c6
# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

| **Caso de Teste** 	| **CT01 – Cadastrar perfil / Realizar Login / Redefinir senha** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF01 e RF02 - Usuário consegue se cadastrar, logar, recuperar senha, com as validações funcionando |
|Registro de evidência | https://github.com/user-attachments/assets/93c60e32-4280-4084-8361-705cbdc29422 |

| **Caso de Teste** 	| **CT02 – Exploração por Localização** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF04, RF05, RF06, RF09 - Validar exibição de campanhas e instituições com base na localização.|
|Registro de evidência | https://github.com/user-attachments/assets/2da6af60-dd27-4522-a667-bd098be19954 |

| **Caso de Teste** 	| **CT03 – Dashboard* 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF17 - usuário consegue ter um resumo do uso da aplicação.|
|Registro de evidência | https://github.com/user-attachments/assets/b5049f98-287c-454f-aa2e-bb6fa390828b |

| **Caso de Teste** 	| **CT04 - Editar informações de perfil* |
|:---:	|:---:	|
|	Requisito Associado 	| RF03 – O sistema deve permitir editar informações de perfil (nome, contatos, foto, endereço).|
|Registro de evidência | https://github.com/user-attachments/assets/e588b5cb-46fb-491a-a818-cbdab9745d0e |

| **Caso de Teste** 	| **CT05 – Interação do Usuário* 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF14 – O sistema deve permitir favoritar instituições para acompanhar novas atualizações |
|Registro de evidência | https://github.com/user-attachments/assets/37face44-bc41-4370-87a4-dd301c3843b8 |



## Relatório de testes de software

### 1. Resultados Obtidos e Pontos Fortes
Os testes realizados evidenciaram que os fluxos fundamentais da plataforma **Rede do Bem** estão maduros e funcionais. Os pontos fortes identificados incluem:
*   **Autenticação e Perfis (CT01):** O controle de acesso e a separação entre doadores e instituições funcionaram sem falhas, garantindo a segurança e o redirecionamento exigido pelos requisitos (RF01, RF02).
*   **Geolocalização (CT02):** A integração e renderização das buscas por localização se mostraram rápidas e precisas, permitindo localizar rapidamente instituições próximas, o que é o coração da proposta de valor do sistema.
*   **Performance (CT03 e CT05):** O carregamento do Dashboard e as interações de favoritar instituições apresentaram tempos de resposta imediatos, indicando que as chamadas (queries) ao banco de dados estão bem otimizadas.

Esses aspectos positivos asseguram que o sistema entregue o seu objetivo principal de aproximar doadores e ONGs de maneira estável.

### 2. Fragilidades e Falhas Detectadas
Apesar do bom desempenho geral, algumas fragilidades foram detectadas nos testes de caixa-branca/preta, impactando principalmente a experiência de usuário em cenários de exceção:
*   **Edição de Perfil (CT04):** Ao tentar salvar o perfil com o campo "Telefone" em um formato inesperado, o sistema retornou um erro não tratado da API em vez de um aviso amigável na interface. Isso gera uma barreira cognitiva para usuários com pouca vivência digital.
*   **Filtros de Localização (CT02):** Quando não há instituições em um determinado raio buscado, a interface não exibe nenhuma mensagem clara de *feedback* (como "Não encontramos pontos próximos, tente expandir a busca"). O usuário pode ter a falsa impressão de que a aplicação travou.

### 3. Estratégias de Correção e Próximos Passos
Para corrigir as deficiências apontadas, o grupo adotará as seguintes estratégias de código para as próximas iterações:
1.  **Ajustes na Interface (Views):** Implementar mensagens de estado vazio (*empty states* e *Toast notifications*) caso uma busca não retorne resultados, melhorando o *feedback* visual.
2.  **Validação de Dados (Models/Views):** Aplicar *Data Annotations* mais rígidas nas models do C# e máscaras de *input* no formulário de edição de perfil (CT04) para impedir a digitação de caracteres inválidos antes do envio (letras no telefone, erro de formatação de CEP).
3.  **Tratamento de Exceções (Controllers):** Melhorar o bloco `try/catch` nos *Controllers* do ASP.NET Core para capturar erros de banco de dados e lançar mensagens amigáveis em português para a interface.

**Conclusão:**
De forma geral, os testes de software comprovam que a aplicação alcançou os critérios de êxito estipulados para a versão atual. As falhas relatadas são de gravidade moderada, focadas em validações, e não impedem os fluxos principais de cadastro e busca. A implementação das correções citadas no *Back-end* e *Front-end* elevará significativamente a resiliência do produto final.
