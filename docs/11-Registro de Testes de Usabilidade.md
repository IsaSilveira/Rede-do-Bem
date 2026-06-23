# Registro de Testes de Usabilidade — Rede do Bem
> **Data:** Junho 2026 &nbsp;|&nbsp; **Versão:** 2.0

Este documento registra a execução dos testes de usabilidade do sistema **Rede do Bem**, com base no roteiro de 8 passos enviado aos participantes e nos dados comportamentais reais coletados pela ferramenta **Microsoft Clarity**.

---

## Sumário

- [Metodologia](#metodologia)
- [Roteiro Enviado aos Participantes](#roteiro-enviado-aos-participantes)
- [Painel Geral — Microsoft Clarity](#painel-geral--microsoft-clarity)
- [Insights de Comportamento (Mapa de Calor)](#insights-de-comportamento-mapa-de-calor)
- [Registro por Cenário de Teste](#registro-por-cenário-de-teste)
- [Feedback Qualitativo dos Participantes](#feedback-qualitativo-dos-participantes)
- [Conclusões Gerais e Recomendações](#conclusões-gerais-e-recomendações)

---

## Metodologia

Aos participantes foi enviado um roteiro de 8 passos livres, sem supervisão direta, a serem executados na aplicação. Em paralelo, a ferramenta **Microsoft Clarity** coletou dados comportamentais reais de uso (cliques, rolagem, gravações de sessão, cliques mortos, retornos rápidos e eventos de formulário), permitindo cruzar o roteiro proposto com evidências objetivas de comportamento.

---

## Roteiro Enviado aos Participantes

1. Explore as campanhas disponíveis na tela inicial.
2. Abra o mapa e veja as campanhas próximas a você.
3. Filtre as campanhas por tipo de doação (alimentos, roupas, etc.).
4. Abra uma campanha que te interessou e veja os detalhes.
5. Crie uma campanha sua (pode inventar uma situação).
6. Favorite uma instituição que você gostaria de acompanhar.
7. Doe para uma campanha da "Instituição Teste".
8. Veja suas notificações no app.

---

## Painel Geral — Microsoft Clarity

<img width="2550" height="2013" alt="Clarity_Rede_do_Bem_Painel_06-19-2026 10 23" src="https://github.com/user-attachments/assets/2b10479c-9522-469e-91ce-2413d79e69cf" />


**Filtros aplicados:** Últimos 3 dias · Navegador: MobileSafari

| Métrica | Valor |
|---------|-------|
| Sessões | 15 (0 sessões de bot excluídas) |
| Páginas por sessão (média) | 3,53 |
| Profundidade de rolagem (média) | 86,15% |
| Tempo fora da sessão | 45 segundos (de 1,2 min de tempo total) |
| Usuários únicos | 3 |
| Sessões com novos usuários | 100% (15) |
| Sessões com usuários retornando | 0% |
| Usuário principal | 8 sessões — Brasil, dispositivo móvel |

**Insights de interação:**

| Indicador | Valor |
|-----------|-------|
| Cliques contínuos | 0% |
| Cliques mortos (*dead clicks*) | 13,33% (2 sessões) |
| Rolagem excessiva | 0% |
| Retornos rápidos (*quick backs*) | 46,67% (7 sessões) |

**Eventos inteligentes:** Enviar formulário — 26,67% &nbsp;|&nbsp; Clique de saída — 20%

**Erros de JavaScript:** 0% (0 total) &nbsp;|&nbsp; **Funis:** não configurados no período

**Páginas mais acessadas:**

| Página | Sessões |
|--------|---------|
| Página inicial (`/`) | 11 |
| `/Campanhas/Details/3` | 5 |
| `/Campanhas/Details/1` | 4 |
| `/Perfil/Editar` | 4 |
| `/Dashboard` | 3 |

---

## Insights de Comportamento (Mapa de Calor)

**Comportamento do usuário:**
- Usuários em dispositivos móveis rolaram, em média, até 50% da página inicial, com queda gradual após 55% — apenas 11,1% chegaram ao final da página.
- Os cliques iniciais se concentraram no menu de navegação e no ícone de perfil na barra inferior.
- Os últimos cliques mais frequentes também ocorreram no ícone de perfil e no botão "Quero Doar!".

> [!NOTE]
> Como a troca entre lista e mapa, e a aplicação de filtros, ocorrem dentro da própria página inicial (sem mudança de URL), os cliques mortos (13,33%) registrados nessa página podem incluir tentativas de interação com os pins do mapa ou com os filtros que não responderam como esperado.

---

## Registro por Cenário de Teste

**Legenda de status:** ✅ Confirmado pelo Clarity · ⚠️ Evidência indireta

| ID | Passo do Roteiro | UC | Evidência via Clarity | Status |
|----|--------------------|----|--------------------------|--------|
| CTU-001 | 1. Explorar campanhas na tela inicial | UC02 | Página inicial concentrou o maior volume de tráfego (11 sessões). Mapa de calor mostra rolagem média de apenas 50%, com só 11,1% atingindo o final — parte das campanhas pode não ser vista. | ⚠️ Evidência indireta |
| CTU-002 | 2. Abrir o mapa e ver campanhas próximas | UC02 | Sem URL própria (ocorre dentro da Home). Os 13,33% de cliques mortos registrados na página podem incluir tentativas de interação com os pins do mapa. | ⚠️ Evidência indireta |
| CTU-003 | 3. Filtrar campanhas por tipo de doação | UC03 | Sem URL ou evento dedicado. Os 46,67% de retornos rápidos no período podem refletir tentativas de filtro sem o resultado esperado. | ⚠️ Evidência indireta |
| CTU-004 | 4. Abrir uma campanha e ver detalhes | UC02 | Duas páginas de detalhe de campanha tiveram tráfego direto e confirmado: `/Campanhas/Details/3` (5 sessões) e `/Campanhas/Details/1` (4 sessões). | ✅ Confirmado |
| CTU-005 | 5. Criar uma campanha própria | UC04 | Evento inteligente "Enviar formulário" disparado em 26,67% das sessões; não há página dedicada de criação de campanha entre as mais acessadas para confirmar isoladamente. | ⚠️ Evidência indireta |
| CTU-006 | 7. Doar para uma campanha da "Instituição Teste" | UC04 | Mesmo evento "Enviar formulário" (26,67%) e "Clique de saída" (20%) podem estar associados a essa etapa, sem possibilidade de isolar do passo de criação de campanha. | ⚠️ Evidência indireta |

---

## Feedback Qualitativo dos Participantes

Além dos dados do Clarity, os participantes relataram observações diretas durante a execução do roteiro. Esses relatos complementam os dados quantitativos, especialmente nos passos que o Clarity não consegue isolar (mapa, filtro, favoritar, notificações).

| Código | Perfil | Passo Relacionado | Feedback Relatado | Classificação |
|--------|--------|---------------------|----------------------|----------------|
| P02 | Doador iniciante | Acesso ao sistema (pré-roteiro) | Não conseguiu abrir o link enviado para o teste; o navegador do celular retornou erro ao carregar a página. | 🔴 Bloqueante |
| P03 | Doador intermediário | 2. Abrir o mapa | Teve dificuldade para localizar o botão de alternância entre lista e mapa, levando quase 1 minuto até encontrá-lo. | 🟡 Melhoria |
| P04 | Doador intermediário | Roteiro completo | Achou tudo muito fácil e concluiu todos os 8 passos sem pedir ajuda em nenhum momento. | 🟢 Positivo |
| P05 | Doador intermediário | 8. Ver notificações | Não percebeu de imediato que havia notificações novas, pois o ícone não exibia nenhum indicador visual (badge). | 🟡 Melhoria |
| P06 | Doador avançado | 6. Favoritar instituição | Relatou que a instituição já aparecia como favoritada antes mesmo de realizar a ação de favoritar. | 🔴 Bug |
| P07 | Instituição iniciante (acessibilidade) | 3. Filtrar por tipo de doação | Com zoom de 150% no navegador do celular, parte do texto das opções de filtro ficava cortada. | 🟡 Acessibilidade |
| P08 | Instituição iniciante | 5. Criar uma campanha | Não conseguiu adicionar um novo tipo de item durante a criação da campanha. | 🔴 Bug |
| P09 | Instituição experiente | 7. Doar para a "Instituição Teste" | Concluiu a doação, mas não recebeu nenhuma confirmação visual na tela; ficou em dúvida se a ação havia sido registrada. | 🟡 Melhoria |

> [!IMPORTANT]
> Os relatos de P06 (instituição favoritada sem ação do usuário) e P08 (impossibilidade de adicionar novo tipo de item) confirmam, por observação direta, falhas já mapeadas anteriormente no levantamento de bugs do sistema — reforçando a prioridade de correção dessas duas falhas.

---

## Conclusões Gerais e Recomendações

A navegação da Home até os detalhes de uma campanha (passos 1 e 4) é a parte do roteiro com evidência mais sólida: o tráfego confirma que os usuários conseguem sair da listagem inicial e abrir campanhas específicas sem erros técnicos (0% de erros de JavaScript). Já os passos que ocorrem dentro da mesma página (mapa, filtros) ou que compartilham o mesmo evento genérico (criar campanha e doar) não puderam ser isolados com precisão nos dados atuais — os 13,33% de cliques mortos e 46,67% de retornos rápidos são os sinais mais próximos disponíveis, mas representam o comportamento agregado do site, não de uma etapa específica.

O feedback qualitativo reforça e detalha esse cenário: enquanto P04 concluiu o roteiro inteiro sem dificuldades, os relatos de P06 e P08 confirmam, por observação direta, duas falhas que os dados agregados do Clarity não conseguiriam revelar isoladamente — a instituição favoritada automaticamente e a impossibilidade de adicionar um novo tipo de doação. O caso de P02 (link inacessível) também chama atenção para um ponto fora do escopo da aplicação em si: a distribuição do link de teste precisa ser validada antes da próxima rodada, para não comprometer a amostra.


---
