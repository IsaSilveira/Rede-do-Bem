# Plano de Testes de Usabilidade: Projeto Rede do Bem

Os testes de usabilidade permitem avaliar a qualidade da interface com o usuário da aplicação interativa.

## Definição do(s) objetivo(s)

O objetivo principal deste teste é avaliar se a plataforma Rede do Bem cumpre sua promessa de reduzir barreiras logísticas e informacionais no processo de doação.
Eficácia: Verificar se o usuário consegue localizar um ponto de coleta e entender quais itens são aceitos sem auxílio externo.
Eficiência: Medir o tempo e o número de cliques necessários para cadastrar um novo ponto de doação ou campanha.
Navegabilidade: Identificar se os filtros por "Tipo de Doação" (alimentos, roupas, etc.) são intuitivos.
Acessibilidade: Garantir que perfis com pouca familiaridade tecnológica consigam navegar no mapa e encontrar endereços.

## Seleção dos participantes

Seleção dos Participantes
Para representar o público-alvo diversificado, serão selecionados 7 participantes, divididos nos seguintes perfis:
- Doador Eventual (3 pessoas): Usuários com pouca experiência em apps de impacto social, foco em facilidade de busca.
- Doador Frequente (2 pessoas): Usuários familiarizados com tecnologia que buscam rapidez. Perfil focado na criação de campanhas temporárias.
- Representante de Instituição/ONG (2 pessoas): Perfil focado na gestão e cadastro de pontos de coleta e campanhas.

## Definição de cenários de teste

Abaixo, os cinco cenários essenciais para validar as funcionalidades do sistema:
- Cenário 1: Busca por Proximidade e Tipo de Item
Objetivo: Avaliar a facilidade de encontrar um local específico doação e recebimento de donativos.
Contexto: Você tem uma sacola de roupas usadas em bom estado e quer doá-las hoje em um local próximo à sua casa.
Tarefa: Acessar a plataforma, filtrar e localizar o ponto de coleta mais próximo do seu endereço atual.
Critério de Sucesso: O usuário aplica o filtro corretamente e visualiza o endereço e horário de funcionamento do local em menos de 2 minutos.

- Cenário 2: Cadastro de Ponto de Recebimento (Perfil Instituição)
Objetivo: Testar o fluxo de entrada de novos parceiros na rede.
Contexto: Você representa uma ONG que começou a aceitar doações de móveis e eletrônicos e precisa que os doadores te encontrem.
Tarefa: Realizar o cadastro da sua instituição, inserindo endereço, tipos de itens aceitos e horário de atendimento.
Critério de Sucesso: O ponto de coleta aparece corretamente no mapa após a finalização do cadastro.

- Cenário 3: Criação de Campanha Temporária (Perfil Frequente)
Objetivo: Verificar a agilidade na divulgação de ações pontuais.
Contexto: Houve uma enchente na região e você está organizando uma arrecadação de alimentos apenas para o próximo final de semana.
Tarefa: Criar uma "Campanha de Arrecadação Temporária", definindo a data de início, término e o objetivo da ação.
Critério de Sucesso: A campanha é criada com uma sinalização visual de que é um evento temporário.

- Cenário 4: Obtenção de Informações Detalhadas
Objetivo: Avaliar a clareza das informações de contato.
Contexto: Você encontrou um local que aceita eletrônicos, mas tem dúvida se eles aceitam televisores antigos (CRT).
Tarefa: Localizar o ponto no mapa e encontrar o número de WhatsApp ou telefone para tirar a dúvida.
Critério de Sucesso: O usuário encontra a informação de contato em no máximo 3 cliques a partir da tela inicial.

- Cenário 5: Navegação via Mapa vs. Lista
Objetivo: Testar a preferência e facilidade de interface.
Contexto: Você quer ver todas as opções de doação de alimentos disponíveis na sua cidade para escolher a que parece mais organizada.
Tarefa: Alternar entre a visão de mapa e a visão de lista para comparar as instituições cadastradas.
Critério de Sucesso: O usuário consegue alternar o modo de visualização e identificar qual instituição está mais próxima pela lista.

## Métodos de coleta de dados

Para cada teste, utilizaremos uma abordagem mista:
- Métricas Quantitativas (Observação Direta)
Tempo por Tarefa: Cronometragem do início ao fim de cada cenário.
- Taxa de Erro: Quantas vezes o usuário clicou em funções erradas ou se sentiu "perdido".
- Taxa de Sucesso: Se a tarefa foi concluída 
Métricas Qualitativas
- Protocolo de Pensar Alto: O usuário será incentivado a verbalizar suas dúvidas e frustrações enquanto navega.
Questionário Pós-Teste (Escala SUS - System Usability Scale):
Eu acho que gostaria de usar esta plataforma frequentemente?
Achei o sistema desnecessariamente complexo?
Achei o sistema fácil de usar?
Senti confiança ao utilizar a plataforma?

## Ética e Proteção de Dados (LGPD)
Anonimização: Os voluntários serão identificados apenas por códigos (ex: Participante 01, P02).
Termo de Consentimento: Todos assinarão um termo autorizando a gravação da tela e áudio apenas para fins de análise acadêmica.
Dados Sensíveis: Não serão coletados CPFs, endereços reais dos voluntários ou fotos de seus rostos na documentação final.
