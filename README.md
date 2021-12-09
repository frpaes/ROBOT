# ROBO
ROBO

## Como executar

Realizar o clone de todos os repositórios em sua maquina, buildar os projetos de API (Becomex.Robot.Api) e WEB (Becomex.Robot.Web) separadamente.

O projeto conta com somente uma tela de apresentação do ROBO, nessa interface é possivel manipular as ações.

## Atenção

Caso haja algum erro de IIS Express na API, altere a porta da aplicação no debug. E também altere a porta no appsettings do projeto WEB, para que reflita a mesma porta colocada na API.

### Observações

A solution se encontra dentro da pasta "Becomex.Robot";

### Endpoints

* `GET /api/v1/robots`
* `PUT /api/v1/robots/initialize`
* `PUT /api/v1/robots/movehead`
* `PUT /api/v1/robots/moveancon`
* `PUT /api/v1/robots/movefist`

### Importante

Aplicação desenvolvida em .NET Core 3.1.