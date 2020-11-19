# Binary API

## Objetivo
API em ASP .NET Core 3.1 que tem como intuito de gerênciar clientes, produtos e pedidos.

## Especificações Técnicas
- [X] MySQL 8
- [X] ASP .NET Core 3.1
- [X] Entity Framework Core

## Segurança
- [X] JWT
- [X] Roles

## Premissa
Está aplicação NÃO possuí o intuito de simplificar a resolução do problema ao máximo, e sim exemplificar implementações diversas
presentes no dia-a-dia do desenvolvedor como implementação de Design Patters, elaboração de testes, funcionalidades genéricas, etc...
Algumas implementações fora do escopo proposto foram adicionadas com o intuito de expandir a usabilidade.

## Básico

### Migrations

#### Visual Studio 2019
1. No menu "Exibir", selecione o submenu "Outras Janelas" e clique em "Console do Gerenciador de Pacotes"
2. No console, selecione o "Projeto padrão" como "Repository"
3. Digite e execute a seguinte linha "Add-Migration {nome}", onde o "{nome}" é relativo ao nome da migração
que deve ser definida pelo executor da aplicação (Exemplo VS2019-A)
4. Após a finalização do corregamento, execute o comando "Update-Database {nome}", onde o "{nome}" é relativo ao nome da migração
que foi gerada no passo anterior (Exemplo VS2019-B)

##### Exemplo VS2019-A
```
Add-Migration First
```

##### Exemplo VS2019-B
```
Update-Database First
```

#### Comando
1. Na pasta raiz do projeto, busque pelo caminho "~/Repository"
2. Execute uma instância do Powershell apartir desta pasta
3. Digite e execute a seguinte linha "dotnet ef migrations add {nome}", onde o "{nome}" é relativo ao nome da migração
que deve ser definida pelo executor da aplicação (Exemplo VS2019-C)
4. Após a finalização do corregamento, execute o comando "Update-Database {nome}", onde o "{nome}" é relativo ao nome da migração
que foi gerada no passo anterior (Exemplo VS2019-D)

##### Exemplo VS2019-C
```
dotnet ef migrations add FirstMigration
```

##### Exemplo VS2019-D
```
dotnet ef database update First
```

### Executando a Aplicação
1. Na pasta raiz do projeto, busque pelo caminho "~/Api/bin/Debug/netcoreapp3.1"
2. No caminho, execute o arquivo "Api.exe"

## Documentação das rotas

| Tipo    | Rota                              | Método                | Descrição                                                                                    |
|---------|-----------------------------------|-----------------------|----------------------------------------------------------------------------------------------|
| POST    | customer/login                    | Login                 | Loga o usuário no sistema, habilitando as demais funcionalidade.                             |
|         |                                   |                       | O método retorna um token para validação.                                                    |
| POST    | customer/include                  | Include               | Cadastra os dados do cliente.                                                                |
| PUT     | customer/edit                     | Edit                  | Altera os dados do cliente.                                                                  |
| DELETE  | customer/remove?codigo={codigo}   | Remove                | Exclui os dados do cliente.   						                                                   |
| GET     | product/all                       | All                   | Lista os dados de todos os produtos.   						                                           |
| POST    | product/include                   | Include               | Cadastra os dados do produto.                                                                |
| PUT     | product/edit                      | Edit                  | Altera os dados do produto.                                                                  |
| DELETE  | product/remove?codigo={codigo}    | Remove                | Exclui os dados do produto.   						                                                   |
| GET     | product/all-cutomer               | AllOrdersByCustomer   | Lista os dados de todos os produtos.   						                                           |
| POST    | order/include                     | Include               | Cadastra os dados do pedido.                                                                 |
| PUT     | order/edit                        | Edit                  | Altera os dados do pedido.                                                                   |
| DELETE  | order/remove?codigo={codigo}      | Remove                | Exclui os dados do pedido.   						                                                     |
