# Registro de Testes de Software — Rede do Bem
> **Data:** Junho 2026

Este documento consolida e padroniza, no mesmo formato do Plano de Testes de Software, os registros de execução das duas rodadas de teste realizadas na aplicação **Rede do Bem**. Após os testes foram criadas duas listas de erros (BUG) e de melhorias (MEL) que foram solucionados posteriormente.


## Relatório Geral de Testes

**Resumo:** Foram executados 49 casos de teste ao longo de duas rodadas (5 na primeira, 44 na segunda). Na primeira rodada, todos os fluxos testados funcionaram, com apenas pequenas falhas de validação e feedback. Na segunda rodada, mais aprofundada, 41% dos casos passaram, 18% passaram parcialmente, 27% falharam e 5% não foram testados, resultando em 14 bugs e 18 melhorias identificadas.

**Pontos fortes:** autenticação, login e separação de perfis (Doador/Instituição) funcionam corretamente; geolocalização e listagem de campanhas têm boa performance; dashboard, filtros por tipo de doação e compartilhamento de campanhas funcionam como esperado.


**Conclusão:** o sistema cobre bem os fluxos essenciais de cadastro, login, busca e visualização de campanhas, mas a segunda rodada revelou falhas relevantes em funcionalidades de Instituição, notificações e regras de validação de doação, que devem ser priorizadas antes da entrega final. Os bugs críticos (upload de foto e autovalidação de doação) e os de prioridade alta já estão listados com responsabilidade de correção; as melhorias de UX (máscaras de campo, feedback de busca vazia, seleção de endereço via mapa) ficam como próximos passos de refinamento.



**Resumo Executivo:**

| Métrica | Quantidade | % |
|---------|-----------|---|
| Total de casos executados | 44 | 100% |
| ✅ Passou | 18 | 41% |
| ⚠️ Parcial | 8 | 18% |
| ❌ Falhou | 12 | 27% |
| ⬜ Não testado | 2 | 5% |

> **Bugs identificados:** 14 &nbsp;|&nbsp; **Melhorias identificadas:** 18

**Legenda de status:** ✅ PASSOU (comportamento conforme esperado) · ⚠️ PARCIAL (funciona com ressalvas ou bugs pontuais) · ❌ FALHOU (comportamento incorreto ou funcionalidade inoperante) · ⬜ NÃO TESTADO (não foi possível executar o teste)

| ID | Título | UC | Requisito | Prioridade | Status | Observações |
|----|--------|----|-----------|------------|--------|-------------|
| CT-001 | Cadastro de usuário Doador com dados válidos | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-002 | Cadastro de usuário Instituição com dados válidos e dados registrados no perfil | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-003 | Cadastro com e-mail já existente | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-004 | Cadastro com campos obrigatórios em branco | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-005 | Login com credenciais válidas (Doador) | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-006 | Login com credenciais válidas (Instituição) | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-007 | Login com senha incorreta | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-008 | Login com e-mail não cadastrado | UC01 | RF01 | 🔴 ALTA | ✅ PASSOU | |
| CT-009 | Recuperação de senha com e-mail válido | UC01 | RF02 | 🔴 ALTA | ✅ PASSOU | |
| CT-010 | Recuperação de senha com e-mail inexistente | UC01 | RF02 | 🔴 ALTA | ✅ PASSOU | |
| CT-011 | Editar dados de perfil (Doador) | UC01 | RF03 | 🔴 ALTA | ✅ PASSOU | |
| CT-012 | Editar dados de perfil (Instituição) e verificar atualização para outros usuários | UC01 | RF03 | 🔴 ALTA | ✅ PASSOU | |
| CT-013 | Upload de foto de perfil | UC01 | RF03 | 🔴 ALTA | ✅ PASSOU | |
| CT-014 | Visualizar campanhas priorizadas por proximidade (Doador) | UC02 | RF04 | 🔴 ALTA | ✅ PASSOU | |
| CT-015 | Visualizar lista de todas as campanhas | UC02 | RF05 | 🔴 ALTA | ✅ PASSOU | |
| CT-016 | Campanhas do próprio usuário logado não aparecem na tela Home | UC02 | RF05 | 🔴 ALTA | ⚠️ PARCIAL | OK para Doador. Bug: campanhas criadas pela Instituição não aparecem no próprio perfil da Instituição (deveria aparecer). |
| CT-017 | Visualizar campanhas e instituições no mapa | UC02 | RF06 | 🔴 ALTA | ✅ PASSOU | |
| CT-018 | Visualizar detalhes de uma campanha | UC02 | RF07 | 🔴 ALTA | ✅ PASSOU | |
| CT-019 | Visualizar campanhas de uma instituição específica | UC02 | RF08 | 🔴 ALTA | ❌ FALHOU | Não funciona. Campanhas da instituição não aparecem no perfil dela para outros usuários visualizarem. |
| CT-020 | Visualizar lista de instituições | UC02 | RF05 | 🔴 ALTA | ✅ PASSOU | |
| CT-021 | Filtrar campanhas por localização no mapa | UC03 | RF09 | 🔴 ALTA | ✅ PASSOU | |
| CT-022 | Filtrar campanhas por tipo de doação - Alimentos | UC03 | RF10 | 🔴 ALTA | ✅ PASSOU | |
| CT-023 | Filtrar campanhas por tipo de doação - Roupas | UC03 | RF10 | 🔴 ALTA | ✅ PASSOU | |
| CT-024 | No cadastro de nova campanha, cadastrar novo item e selecioná-lo nas opções | UC03 | RF10 | 🔴 ALTA | ❌ FALHOU | Funcionalidade não implementada ou com defeito. |
| CT-025 | Criar campanha com todos os dados válidos e horário de funcionamento | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-026 | Criar campanha com data de fim anterior à data de início | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-027 | Criar campanha com campos obrigatórios em branco | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-028 | Editar campanha própria | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-029 | Excluir campanha própria | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-030 | Tentativa de editar campanha de outro usuário | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-031 | Tentativa de excluir campanha de outro usuário | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-032 | Campanhas ativas e histórico no perfil do usuário | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-033 | Campanha expirada some da listagem e permanece no histórico | UC04 | RF11 | 🔴 ALTA | ✅ PASSOU | |
| CT-034 | Visualizar quantidade de doadores de uma campanha | UC04 | RF12 | 🟡 MÉDIA | ⚠️ PARCIAL | Funciona na página da campanha. Melhoria: exibir também no card da campanha na listagem. |
| CT-035 | Validar doação realizada | UC04 | RF13 | 🟡 MÉDIA | ✅ PASSOU | |
| CT-036 | Gerar link de compartilhamento de campanha | UC05 | RF14 | 🔵 BAIXA | ✅ PASSOU | |
| CT-037 | Favoritar instituição (Doador) | UC06 | RF15 | 🟡 MÉDIA | ✅ PASSOU | |
| CT-038 | Desfavoritar instituição (Doador) | UC06 | RF15 | 🟡 MÉDIA | ✅ PASSOU | |
| CT-039 | Denunciar ponto de coleta (Doador) | UC06 | RF16 | 🟡 MÉDIA | ✅ PASSOU | |
| CT-040 | Acessar dashboard com métricas do perfil (Instituição) | UC07 | RF17 | 🔴 ALTA | ✅ PASSOU | |
| CT-041 | Dashboard sem dados históricos (Instituição recém-criada) | UC07 | RF17 | 🟡 MÉDIA | ✅ PASSOU | |
| CT-042 | Receber notificação de nova campanha próxima (Doador) | UC08 | RF18 | 🟡 MÉDIA | ✅ PASSOU | |
| CT-043 | Clicar em notificação e ir direto para a campanha | UC08 | RF18, RF19 | 🟡 MÉDIA | ✅ PASSOU | |

---

### Lista de Bugs — Segunda Rodada

| ID | Prioridade | Título | CT Relacionado | Descrição | Status |
|----|------------|--------|-----------------|-----------|--------|
| BUG-001 | 🚨 CRÍTICA | Erro ao salvar foto de perfil (Hot Reload .NET) | CT-013 | Ao selecionar e tentar salvar uma foto de perfil — tanto no perfil de Doador quanto de Instituição — o sistema retorna um erro interno relacionado ao Hot Reload do .NET. A foto não é salva. | OK |
| BUG-002 | 🚨 CRÍTICA | Usuário consegue validar sua própria doação | CT-035 | O dono da campanha consegue registrar e validar uma doação para a sua própria campanha. Um usuário não deve poder doar para si mesmo nem validar a própria doação. | OK |
| BUG-003 | 🔴 ALTA | Mapa não exibe campanhas automaticamente | CT-017 | As campanhas não aparecem no mapa ao acessar a tela. Elas só são exibidas após o usuário clicar manualmente em "buscar endereço no mapa". | OK |
| BUG-004 | 🔴 ALTA | Campanhas da Instituição não aparecem no seu próprio perfil | CT-016, CT-019 | As campanhas criadas por uma Instituição não estão sendo exibidas no perfil da própria Instituição. Outros usuários também não conseguem ver as campanhas ao acessar o perfil de uma instituição específica. | OK |
| BUG-005 | 🔴 ALTA | Nome da Instituição não atualiza após edição do perfil | CT-002, CT-012 | Ao editar o nome da Instituição no perfil, a atualização não é refletida corretamente nos locais onde o nome é exibido (cards de campanha, listagem de instituições, etc.). | OK |
| BUG-006 | 🔴 ALTA | Padronização de Campos | CT-012 | O formulário de edição de perfil da Instituição não valida o campo de número de endereço/telefone, permitindo inserção de texto livre com letras. | OK |
| BUG-007 | 🔴 ALTA | Favoritar e Desfavoritar instituição não funcionam | CT-037, CT-038, CT-043 | A funcionalidade de favoritar e desfavoritar uma instituição não está operacional. Isso também impede o funcionamento das notificações de campanhas de instituições favoritadas. | OK |
| BUG-008 | 🔴 ALTA | Clique em notificação não redireciona para a campanha | CT-044 | Ao clicar em uma notificação de campanha, o sistema não redireciona o usuário para a página de detalhes da campanha correspondente. | OK |
| BUG-009 | 🔴 ALTA | Cadastro de novo tipo de item de doação na campanha não funciona | CT-024 | Ao tentar cadastrar um novo tipo de item aceito durante a criação de campanha, a funcionalidade não está operacional ou não foi implementada. | OK |
| BUG-010 | 🟡 MÉDIA | Após login de Instituição, redireciona para tela de Pontos de Coleta inexistente | CT-006 | Ao fazer login com uma conta de Instituição já cadastrada, o sistema redireciona para a tela de Pontos de Coleta, que não existe mais na aplicação. | OK |
| BUG-011 | 🟡 MÉDIA | Sistema solicita seleção de foto ao clicar em Sair no perfil da Instituição | CT-013 | Ao clicar no botão Sair enquanto está no perfil da Instituição, o sistema exibe um prompt solicitando seleção de nova foto de perfil antes de realizar o logout. | OK |
| BUG-012 | 🟡 MÉDIA | Perfil de Instituição não reflete edição de campanha corretamente | CT-030 | Após a edição de uma campanha, o perfil de Instituição não exibe o estado atualizado corretamente. | OK |
| BUG-013 | 🔵 BAIXA | Logs de erro insuficientes para diagnóstico | — | O sistema não apresenta logs de erro suficientes para entender o que está acontecendo nos fluxos com falha, dificultando o diagnóstico e a correção de bugs. | OK |

---

### Lista de Melhorias — Segunda Rodada

| ID | Prioridade | Título | CT Relacionado | Descrição | Status |
|----|------------|--------|-----------------|-----------|--------|
| MEL-001 | 🔴 ALTA | Não exibir campanhas do próprio usuário na tela "Quero Doar" | CT-016 | As campanhas criadas pelo usuário logado não devem aparecer na tela de "Quero Doar", evitando que ele doe para si mesmo. | ⬜ Pendente |
| MEL-002 | 🔴 ALTA | Endereço com seleção real via mapa (cadastro e edição) | CT-002, CT-012 | O campo de endereço deve oferecer sugestões válidas integradas ao mapa para seleção, evitando endereços inválidos ou inexistentes. | ⬜ Pendente |
| MEL-003 | 🔴 ALTA | Campo endereço obrigatório no cadastro de Instituição | CT-002 | O cadastro de uma Instituição deve exigir o preenchimento do endereço, pois é dado essencial para a exibição no mapa. | ⬜ Pendente |
| MEL-004 | 🔴 ALTA | Adicionar seção de campanhas ativas e histórico ao perfil de Instituição | CT-032 | O perfil de Instituição deve exibir as campanhas ativas e o histórico de campanhas encerradas, assim como já funciona para o perfil de Doador. | ⬜ Pendente |
| MEL-005 | 🔴 ALTA | Remover "instituiçãoid" e exibir nome real da Instituição com link para o perfil | CT-018 | A descrição da campanha exibe "instituiçãoid" em vez do nome real. Corrigir para exibir o nome completo com link clicável para o perfil da Instituição. | ⬜ Pendente |
| MEL-006 | 🔴 ALTA | Ícone de notificação com badge e menu no canto superior esquerdo | CT-042, CT-043 | Adicionar ícone de sino com bolinha indicadora de novas notificações no canto superior direito. Mover o menu para o canto superior esquerdo. | ⬜ Pendente |
| MEL-007 | 🔴 ALTA | Permitir múltiplas doações na mesma campanha com revalidação individual | CT-035 | O sistema deve permitir que um usuário doe mais de uma vez na mesma campanha, com cada doação validada individualmente pelo dono. | ⬜ Pendente |
| MEL-008 | 🔴 ALTA | Não exibir a própria Instituição do usuário logado na tela "Quero Doar" | CT-016 | O usuário Instituição não deve ver a própria instituição como opção na tela "Quero Doar". | ⬜ Pendente |
| MEL-009 | 🔴 ALTA | Exibir "Doação Validada" para o Doador após validação | CT-035 | Quando o dono da campanha validar a doação, o Doador deve receber uma confirmação visível informando que sua doação foi validada. | ⬜ Pendente |
| MEL-010 | 🔴 ALTA | Notificação de doação recebida clicável para o dono validar | CT-044 | Ao receber a notificação de que uma doação foi realizada, o dono deve conseguir clicar e ser redirecionado para a campanha para validar. | ⬜ Pendente |
| MEL-011 | 🟡 MÉDIA | Limitar lista de Instituições a 3 itens visíveis com rolagem na tela "Quero Doar" | CT-020 | Quando houver muitas instituições, exibir no máximo 3 com rolagem interna para não encobrir as campanhas listadas abaixo. | ⬜ Pendente |
| MEL-012 | 🟡 MÉDIA | Permitir seleção de múltiplos tipos de doação no filtro | CT-022, CT-023 | O filtro por tipo de doação deve permitir selecionar mais de um tipo simultaneamente. | ⬜ Pendente |
| MEL-013 | 🟡 MÉDIA | Adicionar nome da campanha de forma destacada no card da listagem | CT-015 | O card de campanha na listagem deve exibir o nome da campanha de forma destacada para facilitar a identificação pelo Doador. | ⬜ Pendente |
| MEL-014 | 🟡 MÉDIA | Exibir quantidade de doadores no card de campanha da listagem | CT-034 | Além da página de detalhes, o card da campanha na listagem deve exibir a quantidade de doadores. | ⬜ Pendente |
| MEL-015 | 🟡 MÉDIA | Crop e ajuste de foto de perfil antes de salvar | CT-013 | Ao selecionar uma foto de perfil, permitir que o usuário recorte e ajuste a imagem antes de salvar. | ⬜ Pendente |
| MEL-016 | 🟡 MÉDIA | Campos de número com formatação e validação correta | CT-012 | Os campos de número (telefone, endereço) devem aplicar máscara de formatação e aceitar apenas valores numéricos. | ⬜ Pendente |
| MEL-017 | 🟡 MÉDIA | Adicionar opção "Minhas Doações" ao menu de navegação | — | O menu deve incluir uma opção para o usuário visualizar o histórico completo de todas as doações realizadas, com status de validação. | ⬜ Pendente |
| MEL-018 | 🔵 BAIXA | Melhorar estrutura visual do formulário de cadastro de campanha | CT-025 | O formulário de criação e edição de campanha deve ter sua estrutura visual melhorada para facilitar o preenchimento e reduzir erros. | ⬜ Pendente |

