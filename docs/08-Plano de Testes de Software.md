# Plano de Testes de Software - Rede do Bem

Este documento descreve os cenários de teste para validar se o sistema **Rede do Bem** atende aos requisitos funcionais (RF) definidos na especificação do projeto.

---

### CT01 – Autenticação e Conta (Perfis Distintos)
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RF01, RF02, RF03** |
| **Objetivo** | Verificar cadastro, login, recuperação de senha e edição de perfil para diferentes tipos de usuários. |
| **Passos** | 1. Acessar tela de cadastro.<br>2. Preencher dados válidos.<br>3. Selecionar tipo de perfil (Doador/Instituição).<br>4. Realizar login com credenciais.<br>5. Solicitar recuperação de senha. <br> 6. Editar informações do perfil. |
| **Critério de Êxito** | Usuário consegue se cadastrar, logar, recuperar senha e editar perfil corretamente, com validações funcionando. |

---

### CT02 – Exploração por Localização
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RF04, RF05, RF06, RF09**  |
| **Objetivo** |Validar exibição de campanhas e instituições com base na localização. |
| **Passos** | 1. Acessar lista de campanhas.<br>2. Acessar mapa interativo.<br>3. Ativar localização.<br>4. Aplicar filtro por localização. |
| **Critério de Êxito** | Sistema exibe campanhas corretamente em lista e mapa, priorizando por proximidade e aplicando filtros. |

---

### CT03 – Filtros e Visualização
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RF07, RF08, RF10**  |
| **Objetivo** | Validar filtros e visualização de detalhes das campanhas e instituições. |
| **Passos** | 1. Selecionar campanha ou instituição.<br>2. Visualizar detalhes.<br>3. Aplicar filtro por tipo de doação. |
| **Critério de Êxito** | Detalhes são exibidos corretamente e filtros retornam resultados esperados. |

---

### CT04 – Gestão de Campanhas
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RF11, RF12, RF13** |
| **Objetivo** | Validar criação, edição e controle de campanhas. |
| **Passos** | 1. Criar nova campanha.<br>2. Editar campanha existente.<br>3. Visualizar número de doadores.<br>4. Validar doação. |
| **Critério de Êxito** |Campanhas são gerenciadas corretamente e dados exibidos são consistentes. |

---

### CT05 – Interação do Usuário
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RF14, RF15, RF16** |
| **Objetivo** | Validar interações do usuário com o sistema. |
| **Passos** | 1. Gerar link de compartilhamento.<br>2. Favoritar instituição.<br>3. Realizar denúncia. |
| **Critério de Êxito** | Ações são executadas corretamente e registradas no sistema. |

---

### CT06 –Dashboard e Notificações
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RF17, RF18, RF19** |
| **Objetivo** | Validar métricas do sistema e envio de notificações. |
| **Passos** | 1. Acessar dashboard <br> 2. Criar campanha próxima <br> 3. Atualizar instituição favorita |
| **Critério de Êxito** | Dashboard exibe dados corretamente e notificações são enviadas conforme esperado. |

---

### CT07 –Usabilidade e Acessibilidade
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RNF-001, RNF-004** |
| **Objetivo** | Validar facilidade de uso e acessibilidade do sistema. |
| **Passos** | 1. Navegar no sistema como novo usuário.<br>2. Testar navegação por teclado.  |
| **Critério de Êxito** | Sistema é intuitivo e acessível para diferentes usuários. |

---

### CT08 – Segurança e LGPD
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RNF-002, RNF-008** |
| **Objetivo** | Validar segurança dos dados e registro de atividades. |
| **Passos** | 1. Tentar acessar sem login. <br>2. Realizar ações no sistema |
| **Critério de Êxito** | Dados protegidos e logs registrados corretamente. |

---

### CT09 – Compatibilidade
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RNF-003**|
| **Objetivo** | Validar funcionamento em diferentes dispositivos. |
| **Passos** | 1. Acessar via celular. <br> 2. Acessar via desktop. |
| **Critério de Êxito** | Interface adaptada corretamente em todos os dispositivos. |

---
### CT10 – Performance e Disponibilidade
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RNF-005, RNF-007** |
| **Objetivo** | Validar desempenho e estabilidade do sistema. |
| **Passos** | 1. Realizar consultas de campanhas <br>2. Simular uso contínuo. |
| **Critério de Êxito** | Sistema responde rapidamente e mantém disponibilidade adequada. |

---

### CT11 – Arquitetura
| Campo | Detalhes |
| :--- | :--- |
| **Requisito Associado** | **RNF-006** |
| **Objetivo** | Validar estrutura modular do sistema. |
| **Passos** | 1. Alterar um módulo do sistema. <br>2. Testar funcionalidade geral. |
| **Critério de Êxito** | Alterações não afetam outros módulos. |

---
