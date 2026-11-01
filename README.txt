README

# API de Autenticação JWT

## Descrição

Projeto desenvolvido em C# utilizando ASP.NET Core Web API
para implementar autenticação utilizando JSON Web Token (JWT).

O projeto utiliza usuário e senha fixos, sem necessidade
de banco de dados.

## Tecnologias utilizadas

- C#
- ASP.NET Core Web API
- JWT (JSON Web Token)
- Visual Studio
- Postman

## Credenciais de acesso

Usuário: admin

Senha: 123456

## Rotas da API

### POST /api/auth/login

Realiza a autenticação do usuário e retorna um token JWT.

### GET /api/usuario/perfil

Rota protegida que retorna o nome do usuário autenticado.

É necessário enviar um token JWT válido.

## Como executar

1. Abra o projeto no Visual Studio.
2. Instale o pacote Microsoft.AspNetCore.Authentication.JwtBearer.
3. Execute o projeto.
4. Utilize o Postman para testar as rotas.

## Testes realizados

- Login válido: 200 OK.
- Login inválido: 401 Unauthorized.
- Acesso sem token: 401 Unauthorized.
- Acesso com token válido: 200 OK.

## Objetivo

Demonstrar o funcionamento da autenticação e autorização
utilizando JWT em uma API REST.
