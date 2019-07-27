### Desafio

De acordo com os requisitos da aplicação que foi sugerida no documento de nome “desafio.pdf” anexo ao projeto na pasta Docs fiz esta pequena aplicação somente com o que foi pedido mas, utilizando a arquitetura DDD (Domain Driven Design) de forma que alguns conceitos foram deixados de lado, isso significa que não estou utilizando o DDD em sua plenitude mas de uma forma leve também chamada de DDD-Lite.

#### Configurando o ambiente
Instalar:
- Visual Studio 2017 Community
- SQL Server 2017 Express
- Fazer download do projeto em:  [GithubProjeto]
- Após o download Abrir o arquivo “Desafio.csproj”

Dependencias:
- Utilizar o Package Manager do Visual Studio para restaurar as dependências (caso não aconteça automaticamente).

As dependências usadas foram:
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer.Design

Depois de instalar tudo e restaurar as dependencias vá no Package Manager Console do Visual Studio 2017 e execute o comando:
```sh
update-database
```
isso irá criar o banco de dados (não esqueça de alterar o ConnectionString no arquivo "appsettings.json" caso necessite)
#### Serviços
Foi utilizada a ferramenta [GetPostman] para testar todas as requisições.
#### Patrimonio
Endpoints:
```sh
GET: 'api/patrimonios'  => Consultar todos os patrimônios cadastrados
GET: 'api/patrimonios/{id}'  => Consultar o patrimônio por "Id"
POST: 'api/patrimonios' => Inserir um novo patrimonio
PUT: 'api/patrimonios/{id}' => Editar os dados de um patrimônio por "Id"
DELETE: 'api/patrimonios/{id}' => Excluir um patrimonio por "Id"

Regras de Validação:
1. 'O numero do tombo é gerado automaticamente'
2. 'Não permitir alteração do Numero do Tombo'
```
#### Marca
Endpoints:
```sh
GET: 'api/marcas' => Obter todas as marcas
GET: 'api/marcas/{id}' => Obter uma marca por ID
GET: 'api/marcas/{id}/patrimonios' => Obter todos os patrimônios de uma marca
POST: 'api/marcas' => Inserir uma nova marca
PUT: 'api/marcas/{id}' => Alterar os dados de uma marca
DELETE: 'api/marcas/{id}' => Excluir uma marca

Regras de validação:
1. 'Não permitir nome duplicado'
```
#### Usuarios
Endpoints:
```sh
GET: 'api/usuarios' => Listar os usuários
POST: 'api/usuarios' => Criar um usuário
DELETE: 'api/usuarios/{id}' => Excluir um usuário
PUT: 'api/usuarios/{id}' => Editar um usuário

Regras de validação:
1. 'Não permitir email duplicado'
```

[GetPostman]: <https://www.getpostman.com/>
[GithubProjeto]: <https://github.com/carlosrbatista1980/desafio>


