# Registro de Testes de Usabilidade

O registro de testes de usabilidade é um documento ou planilha onde são coletadas e organizadas as informações sobre a experiência dos usuários ao interagir com um sistema. Ele inclui dados como tempo de execução de tarefas, taxa de sucesso, dificuldades encontradas, erros cometidos e _feedback_ dos usuários. Esse registro permite identificar padrões de uso, obstáculos/dificuldades encontrados na interface e oportunidades de melhoria, fornecendo _insights_ quantitativos e qualitativos para otimizar a experiência do usuário. Além disso, serve como base para análises, correções e futuras iterações do sistema, garantindo que ele atenda às necessidades do público-alvo de forma eficiente.

## Perfil dos usuários que participaram do teste

Para realizar a simulação mais próxima da realidade e, ao mesmo tempo, respeitar as diretrizes de LGPD (Anonimização) estabelecidas no Plano de Testes, convidamos pessoas do nosso convívio diário, identificadas aqui por códigos:

*   **P01 (Tio de um desenvolvedor):** 45 anos, motorista, nível básico incompleto, conhecimento básico em tecnologia. *(Perfil: Doador Eventual)*
*   **P02 (Irmão mais novo):** 18 anos, estudante universitário, conhecimento avançado em tecnologia. *(Perfil: Doador Frequente)*
*   **P03 (Avó de um integrante):** 70 anos, aposentada, conhecimento básico em tecnologia. *(Perfil: Doador Eventual)*
*   **P04 (Irmão mais velho):** 25 anos, formado em design, conhecimento avançado em tecnologia. *(Perfil: Representante de Instituição/ONG)*
*   **P05 (Colega de trabalho):** 28 anos, analista de sistemas, conhecimento avançado em tecnologia. *(Perfil: Representante de Instituição/ONG)*

## Exemplo de tabela de registro dos testes de usabilidade  

Para registrar os indicadores de cada cenário, é preciso manter a coerência com os critérios quantitativos e qualitativos que foram definidos no plano de testes de usabilidade.

**Cenário 1: Busca por Proximidade e Tipo de Item**
Objetivo: Avaliar a facilidade de encontrar um local específico para doação.

| Usuário | Tempo Total (seg) | Quantidade de cliques | Tarefa foi concluída? (Sim/Não) | Erros Cometidos | Feedback do Usuário |
|---------|-------------------|-----------------------|---------------------------------|-----------------|---------------------|
| P01     | 95                | 5                     | Sim                             | Clicou no ícone errado no mapa antes do filtro. | "Foi fácil depois que entendi onde ficava o botão de filtrar." |
| P02     | 40                | 3                     | Sim                             | Nenhum.         | "Muito rápido e intuitivo, interface bem limpa." |
| P03     | 160               | 8                     | Não                             | Não encontrou o botão de filtro; dificuldade de leitura. | "As letras são pequenas, fiquei meio perdida olhando pro mapa." |
| P04     | 55                | 3                     | Sim                             | Nenhum.         | "Sem problemas, padrão de outros apps." |
| P05     | 45                | 3                     | Sim                             | Nenhum.         | "Achei direto ao ponto, cumpre o que promete." |

**Cenário 2: Cadastro de Ponto de Recebimento (Perfil Instituição)**
Objetivo: Testar o fluxo de entrada de novos parceiros na rede.

| Usuário | Tempo Total (seg) | Quantidade de cliques | Tarefa foi concluída? (Sim/Não) | Erros Cometidos | Feedback do Usuário |
|---------|-------------------|-----------------------|---------------------------------|-----------------|---------------------|
| P01     | 210               | 12                    | Sim                             | Digitou letras no telefone, erro no CEP. | "Fiquei confuso na parte de colocar o horário de funcionamento." |
| P02     | 85                | 6                     | Sim                             | Nenhum.         | "Formulário tranquilo, não tem segredo." |
| P03     | 320               | 15                    | Não                             | Tentou enviar com campos obrigatórios vazios. | "Pede muita informação, achei complicado preencher tudo pelo celular." |
| P04     | 70                | 5                     | Sim                             | Nenhum.         | "O fluxo é ótimo e as categorias de doação são bem completas." |
| P05     | 65                | 5                     | Sim                             | Nenhum.         | "Rápido e prático para nós cadastrarmos a ONG." |

**Cenário 3: Criação de Campanha Temporária**
Objetivo: Verificar a agilidade na divulgação de ações pontuais.

| Usuário | Tempo Total (seg) | Quantidade de cliques | Tarefa foi concluída? (Sim/Não) | Erros Cometidos | Feedback do Usuário |
|---------|-------------------|-----------------------|---------------------------------|-----------------|---------------------|
| P01     | 150               | 9                     | Sim                             | Dificuldade em selecionar a data de término. | "Demorei para entender como usar aquele calendário." |
| P02     | 50                | 4                     | Sim                             | Nenhum.         | "Legal a opção de destaque para coisas urgentes, tipo enchentes." |
| P03     | 240               | 12                    | Não                             | Não entendeu o propósito da tela. | "Não sei para que serve essa parte de campanha, me perdi." |
| P04     | 60                | 5                     | Sim                             | Nenhum.         | "Excelente ferramenta para mobilizações rápidas." |
| P05     | 55                | 4                     | Sim                             | Nenhum.         | "Gostei, a sinalização visual de data final ajuda muito." |

**Cenário 4: Obtenção de Informações Detalhadas**
Objetivo: Avaliar a clareza das informações de contato.

| Usuário | Tempo Total (seg) | Quantidade de cliques | Tarefa foi concluída? (Sim/Não) | Erros Cometidos | Feedback do Usuário |
|---------|-------------------|-----------------------|---------------------------------|-----------------|---------------------|
| P01     | 75                | 4                     | Sim                             | Abriu o perfil de uma ONG errada antes. | "O número do WhatsApp poderia estar num botão maior." |
| P02     | 25                | 2                     | Sim                             | Nenhum.         | "Fácil de achar, bem visível." |
| P03     | 110               | 6                     | Sim                             | Clicou na foto da ONG em vez do ícone de contato. | "Demorei, mas consegui achar o telefone pra ligar." |
| P04     | 30                | 2                     | Sim                             | Nenhum.         | "As informações ficam bem claras na tela da instituição." |
| P05     | 20                | 2                     | Sim                             | Nenhum.         | "Tudo certo, navegação esperada." |

**Cenário 5: Navegação via Mapa vs. Lista**
Objetivo: Testar a preferência e facilidade para alternar os modos de visualização.

| Usuário | Tempo Total (seg) | Quantidade de cliques | Tarefa foi concluída? (Sim/Não) | Erros Cometidos | Feedback do Usuário |
|---------|-------------------|-----------------------|---------------------------------|-----------------|---------------------|
| P01     | 60                | 3                     | Sim                             | Tentou dar zoom no mapa para ver lista. | "Eu prefiro ver em lista, é mais fácil de ler os nomes das ONGs." |
| P02     | 20                | 1                     | Sim                             | Nenhum.         | "Botão de 'alternar' tá bem posicionado lá em cima." |
| P03     | 90                | 4                     | Não                             | Não localizou o botão (toggle) de alteração. | "Não vi onde mudava, acabei ficando só no mapa mesmo." |
| P04     | 25                | 1                     | Sim                             | Nenhum.         | "Transição entre mapa e lista é bem fluida." |
| P05     | 25                | 1                     | Sim                             | Nenhum.         | "Gosto do mapa, mas a lista é melhor pra comparar distâncias." |

## Relatório dos testes de usabilidade 

**1. Indicadores Gerais (Métricas Quantitativas)**
- Taxa de sucesso por cenário:
  - C1: 80% (4/5)
  - C2: 80% (4/5)
  - C3: 80% (4/5)
  - C4: 100% (5/5)
  - C5: 80% (4/5)
- Tempo médio para completar cada cenário (sucessos):
  - C1: 58,75 seg | C2: 107,5 seg | C3: 78,75 seg | C4: 52,0 seg | C5: 32,5 seg
- Número médio de erros cometidos por tarefa:
  - C1: 0,4 | C2: 0,6 | C3: 0,4 | C4: 0,4 | C5: 0,4
- Taxa de abandono:
  - A participante **P03** (Idosa, 70 anos) abandonou/falhou nos Cenários 1, 2, 3 e 5, evidenciando grandes barreiras de acessibilidade para o público sênior.

**2. Questionário Pós-Teste (Escala SUS Adaptada - Resultados Qualitativos)**
Após os testes, foi aplicado o questionário baseado na Escala SUS (*System Usability Scale*) adaptada para 4 perguntas, conforme o Plano de Testes. Os usuários responderam com notas de 1 (Discordo Totalmente) a 5 (Concordo Totalmente):

| Pergunta | Média (1 a 5) | Análise |
| :--- | :---: | :--- |
| 1. Eu acho que gostaria de usar esta plataforma frequentemente? | 4.2 | Boa aceitação geral; rejeição apenas pelo perfil sênior (P03). |
| 2. Achei o sistema desnecessariamente complexo? | 2.1 | A maioria considerou a navegação direta e simples. |
| 3. Achei o sistema fácil de usar? | 3.8 | A média foi impactada pela dificuldade no formulário de cadastro (Cenário 2). |
| 4. Senti confiança ao utilizar a plataforma? | 4.8 | Alta percepção de credibilidade e segurança visual nas telas. |

**3. Identificação de Padrões**
- **Principais dificuldades**: Falta de acessibilidade visual para idosos (fontes pequenas, ausência de rótulos textuais nos ícones) e falta de validação intuitiva em campos numéricos no cadastro de ONGs.
- **Tarefas concluídas sem problemas**: A localização de informações de contato (C4) obteve 100% de sucesso. Usuários avançados (P02, P04, P05) não encontraram barreiras significativas em nenhum cenário.

**4. Plano de Ação e Sugestões de Melhorias**

*   **Prioridade Crítica (Impede ou dificulta severamente o uso):**
    *   **Máscaras de Input no Cadastro:** Implementar máscaras automáticas em campos de Telefone e CEP. Ao preencher o CEP, consumir a **API ViaCEP** para autopreencher o endereço e reduzir drasticamente a carga cognitiva (necessidade pontuada no C2).
    *   **Ícones com Textos Descritivos:** Adicionar rótulos de texto de apoio abaixo de ícones de navegação cruciais (Filtro, Lista, Mapa) para mitigar barreiras de literacia digital (evidenciado pela P03 nos C1 e C5).

*   **Prioridade Moderada (Dificulta a experiência, mas não impede o uso):**
    *   **Acessibilidade Visual (Fontes):** Garantir que a aplicação respeite e herde as configurações de tamanho de fonte e zoom configuradas nativamente no sistema operacional do dispositivo do usuário.
    *   **Melhoria na Seleção de Data (Cenário 3):** Substituir a forma de selecionar a data da campanha por um componente nativo (*Date Picker*) padronizado, implementando o bloqueio para seleção de datas passadas.

*   **Prioridade Leve (Melhorias incrementais):**
    *   **Tutorial Inicial (Onboarding):** Incluir um breve fluxo ilustrativo de 2 a 3 telas no primeiro acesso para explicar aos doadores eventuais como encontrar as campanhas e alternar os modos de visualização.

**5. Conclusão Geral**
A plataforma **Rede do Bem** demonstra alto potencial de sucesso para usuários com letramento digital intermediário e avançado (doadores frequentes e representantes de ONGs mais jovens). Os fluxos principais, como encontrar locais de doação e obter informações de contato, são altamente eficientes. No entanto, para cumprir integralmente sua missão de ser inclusiva para **todos** os públicos, incluindo a terceira idade, é imperativo aplicar os ajustes de acessibilidade sugeridos (fontes maiores, textos em ícones) e refinar a validação de dados nos formulários. Com essas correções críticas resolvidas, o sistema estará plenamente capacitado para atender seu objetivo social com excelência.
