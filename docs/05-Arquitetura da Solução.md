# Arquitetura da Solução

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

<img alt="Diagrama" src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2026-1-e2-proj-int-t3-rede-do-bem/blob/main/src/diagramas/diagrama_classes.png" />



## Modelo ER (Projeto Conceitual)
<img width="8192" height="2126" alt="Car Evaluation Decision Flow-2026-05-10-180401" src="https://github.com/user-attachments/assets/c74952b6-30b2-46d3-848b-0775c791939c" />
<br/>
<br/>

# Projeto da Base de Dados
O projeto da base de dados corresponde à representação das entidades no formato de documentos, garantindo a integridade das restrições de cada perfil de usuário.

<img alt="Dados" src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2026-1-e2-proj-int-t3-rede-do-bem/blob/main/src/Base_Dados/Dados.png" />  


## Usuario
CREATE TABLE usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    senha VARCHAR(255) NOT NULL,
    cpf VARCHAR(14) UNIQUE
);

## Instituicao (Herda de Usuario)
CREATE TABLE instituicao (
    id_usuario INT PRIMARY KEY,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id) ON DELETE CASCADE
);

## ONG (Herda de Instituicao)
CREATE TABLE ong (
    id_instituicao INT PRIMARY KEY,
    cnpj VARCHAR(18) UNIQUE NOT NULL,
    descricao TEXT,
    FOREIGN KEY (id_instituicao) REFERENCES instituicao(id_usuario) ON DELETE CASCADE
);

## Empresa (Herda de Instituicao)
CREATE TABLE empresa (
    id_instituicao INT PRIMARY KEY,
    cnpj VARCHAR(18) UNIQUE NOT NULL,
    razao_social VARCHAR(255) NOT NULL,
    FOREIGN KEY (id_instituicao) REFERENCES instituicao(id_usuario) ON DELETE CASCADE
);

## CentroDoacao
CREATE TABLE centro_doacao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    endereco VARCHAR(255) NOT NULL
);

## Anuncio
CREATE TABLE anuncio (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    descricao TEXT,
    tipo_doacao VARCHAR(100),
    status VARCHAR(50),
    data_criacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    
   ## Chaves Estrangeiras para os relacionamentos de Anúncio
    id_usuario_criador INT NOT NULL,
    id_centro_doacao INT NOT NULL,
    
   ## Relacionamento "cria" (Usuario -> Anuncio)
    FOREIGN KEY (id_usuario_criador) REFERENCES usuario(id),
   ## Relacionamento "recebe" (CentroDoacao -> Anuncio)
    FOREIGN KEY (id_centro_doacao) REFERENCES centro_doacao(id)
);

## Tabela Associativa: Interesse (Relacionamento N:M entre Instituicao e Anuncio)
CREATE TABLE interesse_anuncio (
    id_instituicao INT,
    id_anuncio INT,
    PRIMARY KEY (id_instituicao, id_anuncio),
    FOREIGN KEY (id_instituicao) REFERENCES instituicao(id_usuario) ON DELETE CASCADE,
    FOREIGN KEY (id_anuncio) REFERENCES anuncio(id) ON DELETE CASCADE
);

# Tecnologias Utilizadas

<img width="2076" height="1771" alt="Diagrama de Tecnologias usadas" src="https://github.com/user-attachments/assets/dab553dd-659f-4353-bf60-16476bc50eb0" />

## Frontend: 
É a parte visual com a qual o usuário interage. É onde o doador ou a ONG preenche os formulários e clica nos botões.

## Comunicação (API REST com JSON): 
É a "ponte" de entrega.

## Backend (C# com .NET):
Ele recebe o JSON, processa as regras (ex: verificar senhas, validar dados) e decide se a ação é permitida.

## Banco de Dados (SQL):
Se o Backend em C# aprovar tudo, ele se conecta ao banco de dados e salva as informações da doação ou do usuário permanentemente em tabelas.





