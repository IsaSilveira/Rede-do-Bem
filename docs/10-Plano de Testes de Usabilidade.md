# Plano de Testes de Usabilidade — Rede do Bem
> **Data:** Junho 2026
> **Versão:** 1.0

Este documento define o plano de testes de usabilidade do sistema **Rede do Bem**, com foco em avaliar a qualidade da interface e a experiência dos usuários nos perfis **Doador** e **Instituição**.

---

## Objetivos do Teste

| ID | Objetivo |
|----|----------|
| OB01 | Verificar se os usuários concluem as tarefas essenciais sem auxílio. |
| OB02 | Identificar barreiras na navegação e na interação com o sistema. |
| OB03 | Medir a eficiência (tempo, cliques e erros) durante o uso. |
| OB04 | Avaliar a satisfação geral do usuário com a interface. |
| OB05 | Validar a acessibilidade para diferentes perfis de usuários. |

---

## Seleção dos Participantes

Serão selecionados **10 participantes** representativos do público-alvo. Em conformidade com a **LGPD**, todos serão identificados apenas por códigos (`P01`–`P10`).

| Código | Perfil | Quantidade | Familiaridade com Tecnologia |
|--------|--------|------------|------------------------------|
| P01–P02 | Doador iniciante | 2 | Baixa |
| P03–P05 | Doador intermediário | 3 | Média |
| P06 | Doador avançado | 1 | Alta |
| P07–P08 | Instituição iniciante | 2 | Baixa/Média |
| P09–P10 | Instituição experiente | 2 | Média/Alta |
| — | Participante com necessidade de acessibilidade | 1 (entre os 10) | — |

---

## Cenários de Teste de Usabilidade

**Legenda de prioridade:** 🔴 Alta · 🟡 Média · 🔵 Baixa
| ID | UC | Objetivo de Usabilidade | Prioridade | Passos | Resultado Esperado | Métricas Coletadas |
|----|----|--------------------------|------------|--------|----------------------|----------------------|
| CTU-001 | UC02 | Avaliar se o usuário identifica e visualiza as campanhas disponíveis na tela inicial sem dificuldade. | 🔴 Alta | Explore as campanhas disponíveis na tela inicial. | Usuário localiza e reconhece as campanhas listadas antes de cerca de 50% da rolagem da página, sem confusão. | Page views da Home · Profundidade de rolagem · Mapa de calor de cliques iniciais |
| CTU-002 | UC02 | Avaliar se o usuário consegue abrir o mapa interativo e localizar campanhas próximas à sua localização. | 🔴 Alta | Abra o mapa e veja as campanhas próximas a você. | Mapa carrega corretamente e usuário identifica campanhas próximas via toque/clique nos pins, sem repetir tentativas. | Mapa de calor de cliques no mapa · Cliques mortos |
| CTU-003 | UC03 | Avaliar se o usuário consegue aplicar filtros por tipo de doação e compreender os resultados retornados. | 🔴 Alta | Filtre as campanhas por tipo de doação (alimentos, roupas, etc.). | Filtro retorna apenas campanhas do tipo selecionado, sem cliques mortos ou retornos rápidos após aplicar. | Cliques mortos · Retornos rápidos (*quick backs*) |
| CTU-004 | UC02 | Avaliar se o usuário consegue abrir uma campanha de interesse e visualizar seus detalhes corretamente. | 🔴 Alta | Abra uma campanha que te interessou e veja os detalhes. | Página de detalhes abre corretamente e usuário permanece nela, sem retorno rápido imediato. | Page views de `/Campanhas/Details/X` · Retornos rápidos |
| CTU-005 | UC04 | Avaliar se o usuário consegue criar uma campanha própria preenchendo o formulário sem auxílio. | 🔴 Alta | Crie uma campanha sua (pode inventar uma situação). | Formulário de criação de campanha é preenchido e enviado com sucesso, sem erros técnicos. | Evento inteligente "Enviar formulário" · Erros de JavaScript |
| CTU-006 | UC04 | Avaliar se o usuário consegue concluir o fluxo de doação para uma campanha específica. | 🟡 Média | Doe para uma campanha da "Instituição Teste". | Doação é solicitada com sucesso para a campanha indicada, sem cliques mortos durante o fluxo. | Evento inteligente "Enviar formulário" · Clique de saída |
---

## Critérios de Aprovação

| ID | Critério | Meta |
|----|----------|------|
| CA-01 | Taxa de conclusão das tarefas críticas sem auxílio. | ≥ 90% |
| CA-02 | Tempo médio de conclusão dentro do limite de cada cenário. | 100% dentro do tempo |
| CA-03 | Satisfação média no questionário pós-teste (Likert 1–5). | ≥ 4,0 |
| CA-04 | Recomendação do sistema (nota 4 ou 5). | ≥ 80% |
| CA-05 | Nenhum erro crítico que impeça a conclusão de tarefas. | 0 erros críticos |
