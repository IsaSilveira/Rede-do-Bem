# Especificações do Projeto

## Personas

As personas a seguir representam os principais perfis de usuários que interagem diretamente com a plataforma **Rede do Bem**. Elas foram definidas para compreender as necessidades, dificuldades e objetivos dos usuários, servindo como base para a elaboração das histórias de usuário, definição de requisitos e construção dos casos de uso do sistema.

---
###  Mariana Silva — Educadora e Mobilizadora

<img width="180" height="180" alt="Gemini_Generated_Image_wvntxrwvntxrwvnt" src="https://github.com/user-attachments/assets/2eb1a230-e980-4e4b-9b2e-d3b953bdf372" />


- **Idade:** 48 anos  
- **Profissão:** Professora

Mariana Silva é uma educadora dedicada que acredita no papel social da escola. Além de ser doadora constante, ela utiliza sua influência na comunidade escolar para organizar redes de apoio e arrecadações de forma informal, conectando famílias que podem ajudar a pessoas em situação de vulnerabilidade no bairro.

**Dores:**
- Limitação de alcance: Sente que o impacto de suas ações fica restrito apenas às pessoas que já conhece ou que fazem parte da escola.
- Dificuldade de expansão: Gostaria de influenciar e engajar um público maior e mais diverso na causa, mas não sabe como alcançar novos doadores fora de sua rede direta.
- Sobrecarga ao gerenciar a logística das doações com poucos voluntários fixos.

**Objetivos:**
- Mobilizar e engajar mais moradores da cidade, extrapolando os limites do bairro.
- Facilitar a comunicação das necessidades urgentes para um público mais amplo.
- Estabelecer uma rede de solidariedade mais robusta e independente de sua presença física constante.


###  Carlos Mendes — Coordenador de ONG
<img width="180" height="180" alt="Gemini_Generated_Image_7u50nl7u50nl7u50 (1)" src="https://github.com/user-attachments/assets/cb1f44bd-6584-440b-910f-f971ff3cec48" />


- **Idade:** 45 anos  
- **Profissão:** Coordenador de ONG  

Carlos Mendes é responsável pela gestão de uma organização não governamental comunitária que atua no recebimento e distribuição de doações para famílias em situação de vulnerabilidade social. Ele organiza campanhas de arrecadação, gerencia voluntários e coordena a logística das doações.

**Dores:**
- Baixa visibilidade da ONG  
- Dificuldade em divulgar campanhas de arrecadação  

**Objetivos:**
- Divulgar o ponto de recebimento  
- Aumentar o volume de doações  
- Informar claramente quais itens são necessários  

---

###  João Silva — Doador Frequente

<img width="180" height="180" alt="Gemini_Generated_Image_6l9a9g6l9a9g6l9a" src="https://github.com/user-attachments/assets/f925ccc8-3ebc-4ed8-a525-7e0a5c5cbc0d" />


- **Idade:** 34 anos  
- **Profissão:** Analista administrativo  

João Silva é um doador frequente que costuma doar roupas e alimentos, mas possui pouco tempo disponível devido à rotina de trabalho.

**Dores:**
- Falta de tempo para procurar locais de doação  
- Dificuldade em encontrar pontos próximos e confiáveis  

**Objetivos:**
- Encontrar rapidamente pontos de doação próximos  
- Realizar doações de forma prática e segura  

---

###  Juliana Rocha — Doadora Eventual

<img width="180" height="180" alt="Gemini_Generated_Image_xj4a62xj4a62xj4a" src="https://github.com/user-attachments/assets/561a85f6-dbc5-4eda-b9b7-ea4a55b82ab4" />


- **Idade:** 27 anos  
- **Profissão:** Estudante universitária  

Juliana Rocha é uma doadora eventual que deseja doar eletrônicos e objetos em bom estado quando deixa de utilizá-los. Ela busca informações claras antes de realizar a doação.

**Dores:**
- Incerteza sobre quais locais aceitam tipos específicos de doação  
- Receio de deslocamentos longos sem garantia de aceitação  

**Objetivos:**
- Saber exatamente onde pode doar itens específicos  
- Obter informações claras sobre o processo de doação  

---

###  Mariana Souza — Voluntária Social
<img width="180" height="180" alt="Gemini_Generated_Image_aa93xzaa93xzaa93" src="https://github.com/user-attachments/assets/b8897c90-6857-480b-84cc-b7766192430f" />


- **Idade:** 38 anos  
- **Profissão:** Voluntária social  

Mariana Souza organiza campanhas pontuais de arrecadação em sua comunidade, especialmente em períodos emergenciais, atuando de forma independente ou em parceria com outras iniciativas locais.

**Dores:**
- Divulgação limitada das campanhas  
- Dificuldade em alcançar um número maior de doadores  

**Objetivos:**
- Cadastrar pontos temporários de recebimento  
- Divulgar campanhas de forma eficiente  
- Facilitar a arrecadação de doações  

---

###  Ricardo Almeida — Representante de Empresa Doadora

<img width="180" height="180" alt="Gemini_Generated_Image_iggqliiggqliiggq" src="https://github.com/user-attachments/assets/476ba003-934b-48cb-98c1-ec1235826230" />

- **Idade:** 41 anos  
- **Profissão:** Gerente administrativo  

Ricardo Almeida representa uma pequena empresa que deseja destinar móveis, equipamentos e materiais excedentes de forma socialmente responsável.

**Dores:**
- Dificuldade em encontrar instituições que aceitem grandes volumes de doação  
- Falta de tempo para buscar essas informações manualmente  

**Objetivos:**
- Encontrar pontos de recebimento próximos  
- Realizar doações em maior quantidade de forma organizada  


## Histórias de Usuários

| Eu como "persona" | Quero/preciso "funcionalidade" | Para "motivo/valor" |
|---|---|---|
| Renata Gardim | cadastrar campanhas de arrecadação temporárias com data de início e fim | criar senso de urgência e organizar ações sazonais específicas |
| Renata Gardim | criar campanhas sem a exigência de um CNPJ | formalizar a iniciativa perante a cidade e transmitir maior credibilidade |
| Renata Gardim | cadastrar múltiplos pontos de coleta informais  | facilitar a entrega para doadores que possuem rotinas e localizações diferentes |


| Eu como "persona" | Quero/preciso "funcionalidade" | Para "motivo/valor" |
|---|---|---|
| Carlos Mendes | cadastrar um ponto de recebimento com nome, endereço e descrição | divulgar o local da ONG e facilitar que doadores encontrem o ponto |
| Carlos Mendes | informar quais tipos de doação são aceitos (roupas, alimentos, eletrônicos, móveis etc.) | evitar doações inadequadas e orientar o doador corretamente |
| Carlos Mendes | atualizar horários de funcionamento e formas de entrega | reduzir desencontros e melhorar a experiência do doador |
| Carlos Mendes | visualizar estatísticas simples (ex.: quantidade de acessos ao meu ponto/campanha) (opcional) | avaliar se a divulgação está funcionando e ajustar as campanhas |

| Eu como "persona" | Quero/preciso "funcionalidade" | Para "motivo/valor" |
|---|---|---|
| João Silva | permitir localizar automaticamente pontos próximos usando minha localização | economizar tempo e encontrar locais sem precisar pesquisar manualmente |
| João Silva | filtrar pontos por tipo de doação (roupas e alimentos) | encontrar rapidamente locais que aceitem o que eu quero doar |
| João Silva | visualizar detalhes do ponto (endereço, horários e itens aceitos) | planejar a doação e evitar deslocamento desnecessário |
| João Silva | salvar pontos como favoritos | acessar rapidamente os locais que já usei ou confio |

| Eu como "persona" | Quero/preciso "funcionalidade" | Para "motivo/valor" |
|---|---|---|
| Juliana Rocha | pesquisar pontos que aceitem eletrônicos e objetos específicos | garantir que minha doação será aceita antes de sair de casa |
| Juliana Rocha | visualizar um canal de contato do ponto (telefone/e-mail) quando disponível | tirar dúvidas rápidas antes de realizar a doação |
| Juliana Rocha | ver a confiabilidade do ponto (ex.: verificação/avaliação/denúncias)  | ter segurança de que o local é legítimo |
| Juliana Rocha | denunciar um ponto com informações falsas ou inadequadas (opcional) | ajudar a manter a plataforma confiável para todos |

| Eu como "persona" | Quero/preciso "funcionalidade" | Para "motivo/valor" |
|---|---|---|
| Mariana Souza | cadastrar um ponto temporário de campanha com data de início e fim | divulgar ações pontuais na comunidade e organizar arrecadações emergenciais |
| Mariana Souza | editar rapidamente informações da campanha (endereço, horários, itens aceitos) | ajustar mudanças sem perder doadores por desinformação |
| Mariana Souza | divulgar a campanha por link compartilhável (opcional) | ampliar o alcance em redes sociais e grupos de mensagem |
| Mariana Souza | registrar observações para doadores (ex.: “preferência por itens infantis”) | reduzir doações inadequadas e facilitar a triagem |

| Eu como "persona" | Quero/preciso "funcionalidade" | Para "motivo/valor" |
|---|---|---|
| Ricardo Almeida | cadastrar doações em maior volume (ex.: móveis e equipamentos) (opcional) | organizar melhor a logística e informar o tipo de item disponível |
| Ricardo Almeida | encontrar pontos próximos que aceitem móveis e grandes volumes | evitar desperdício e reduzir o tempo de busca por instituições adequadas |
| Ricardo Almeida | visualizar requisitos para doações grandes (ex.: agendamento, restrições de horário) | planejar a entrega de forma eficiente e evitar deslocamento em vão |
| Ricardo Almeida | acessar informações de contato do ponto para combinar recebimento (quando necessário) | garantir que a instituição consegue receber itens grandes |




## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais


 
<table>
  <thead>
    <tr>
      <th>ID Caso de Uso</th>
      <th>Caso de Uso</th>
      <th>ID Requisito</th>
      <th>Requisito</th>
      <th>Prioridade</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td rowspan="3" align="center"><b>UC01</b></td>
      <td rowspan="3">Criar e gerenciar perfil</td>
      <td align="center">RF01</td>
      <td>O sistema deve permitir a realização de cadastro e login diferenciado na plataforma (Doador/Instituição).</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td align="center">RF02</td>
      <td>O sistema deve permitir recuperação e alteração de senha.</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td align="center">RF03</td>
      <td>O sistema deve permitir editar informações de perfil (nome, contatos, foto, endereço).</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td rowspan="5" align="center"><b>UC02</b></td>
      <td rowspan="5">Visualizar ponto de doação ou instituição</td>
      <td align="center">RF04</td>
      <td>O sistema deve priorizar a visualização de campanhas e instituições próximas da localização do doador.</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td align="center">RF05</td>
      <td>O sistema deve permitir visualizar todas as instituições e campanhas por lista.</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td align="center">RF06</td>
      <td>O sistema deve permitir visualizar instituições e campanhas em um mapa interativo.</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td align="center">RF07</td>
      <td>O sistema deve permitir visualizar detalhes de um ponto (fotos, descrição, contato, tipo de doação e nota).</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td align="center">RF08</td>
      <td>O sistema deve permitir que doadores visualizem campanhas de uma instituição específica.</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td rowspan="2" align="center"><b>UC03</b></td>
      <td rowspan="2">Filtrar ponto de doação ou instituição</td>
      <td align="center">RF09</td>
      <td>O sistema deve permitir filtrar instituições e campanhas por localização (mapa interativo).</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td align="center">RF10</td>
      <td>O sistema deve permitir filtrar instituições e campanhas por tipo de doação (Alimentos, Roupas, etc.).</td>
      <td align="center">ALTA</td>
    </tr>
 <tr>
    <td rowspan="3" align="center"><b>UC04</b></td>
    <td rowspan="3">Criar e gerenciar campanhas</td>
    <td align="center">RF11</td>
    <td>O sistema deve permitir a criação e edição de campanhas com data de início/fim, local, descrição e tipo de doação.</td>
    <td align="center">ALTA</td>
  </tr>
  <tr>
    <td align="center">RF12</td>
    <td>O sistema deve permitir a visualização de quantas pessoas doaram em uma campanha.</td>
    <td align="center">MÉDIA</td>
  </tr>
  <tr>
    <td align="center">RF13</td>
    <td>O sistema deve permitir a validação de doações realizadas.</td>
    <td align="center">MÉDIA</td>
  </tr>
    <tr>
      <td align="center"><b>UC05</b></td>
      <td>Compartilhar campanhas</td>
      <td align="center">RF14</td>
      <td>O sistema deve permitir gerar link de compartilhamento externo para campanhas/perfis.</td>
      <td align="center">BAIXA</td>
    </tr>
    <tr>
      <td rowspan="2" align="center"><b>UC06</b></td>
      <td rowspan="2">Avaliar campanhas</td>
      <td align="center">RF15</td>
      <td>O sistema deve permitir salvar instituições para acompanhar novas atualizações.</td>
      <td align="center">MÉDIA</td>
    </tr>
    <tr>
      <td align="center">RF16</td>
      <td>O sistema deve permitir denunciar um ponto de coleta.</td>
      <td align="center">MÉDIA</td>
    </tr>
    <tr>
      <td align="center"><b>UC07</b></td>
      <td>Visualizar dashboard</td>
      <td align="center">RF17</td>
      <td>O sistema deve permitir visualizar dashboard com métricas do seu perfil.</td>
      <td align="center">ALTA</td>
    </tr>
    <tr>
      <td rowspan="2" align="center"><b>UC08</b></td>
      <td rowspan="2">Receber notificações</td>
      <td align="center">RF18</td>
      <td>O sistema deve ter notificações de novas campanhas próximas da localização do doador.</td>
      <td align="center">MÉDIA</td>
    </tr>
    <tr>
      <td align="center">RF19</td>
      <td>O sistema deve ter notificações de novas campanhas de instituições favoritadas.</td>
      <td align="center">MÉDIA</td>
    </tr>

  </tbody>
</table>


### Requisitos não Funcionais


| ID | Descrição do Requisito | Prioridade |
|----|------------------------|------------|
| RNF-001 | A interface deve ser intuitiva, com navegação simples para diferentes níveis de familiaridade tecnológica. | ALTA |
| RNF-002 | O sistema deve estar em conformidade com a LGPD. | ALTA |
| RNF-003 | O sistema deve ser compatível com dispositivos móveis, tablets e desktops. | ALTA |
| RNF-004 | A interface deve seguir boas práticas de acessibilidade digital (contraste, textos alternativos, navegação por teclado). | ALTA |
| RNF-005 | O sistema deve apresentar tempo de resposta adequado para consultas de pontos e campanhas. | MÉDIA |
| RNF-006 | O sistema deve possuir arquitetura modular para facilitar manutenção e evolução. | MÉDIA |
| RNF-007 | O sistema deve garantir disponibilidade mínima mensal adequada ao contexto acadêmico. | BAIXA |
| RNF-008 | O sistema deve registrar logs básicos de ações relevantes para auditoria e confiabilidade. | BAIXA |



## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                                           |
|--|---------------------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre               |
|02| O desenvolvimento é restrito aos membros atuais do grupo.           |
|03| Orçamento nulo (R$ 0,00) para infraestrutura e licenças.            |
|04| A interface terá suporte apenas ao idioma Português (PT-BR).        |

## Diagrama de Casos de Uso

<img width="1100" height="850" alt="Untitled (2)" src="https://github.com/user-attachments/assets/5065860e-c17d-4199-be34-fd0141347785" />


