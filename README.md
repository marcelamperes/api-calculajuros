# api-calculajuros
Projeto de cálculo de juros usando .NET Core

# Estrutura

O projeto tem a seguinte estrutura:
> API (API em .NET Core)
> API.Testes (Testes unitários)
> Web (Interface em .NET MVC chamando a API)

# Como sereia o projeto 100% pronto

Eu entregaria em uma estrutura DDD, mesmo não tendo acesso a banco de dados. Criaria classes para Juros e para o Cálculo. Assim, conseguiria usá-las nos testes.
Usaria Docker na API e no projeto Web.
Desenvolveria os testes no conceito TDD.

# Projeto API

A API tem dois controllers:
> TaxaJurosController
  > Tem o endpoint /taxaJuros que retorna o valor 0.01, que está configurado no arquivo appsettings.json.
> CalculaJurosController
  > Tem o endpoint /calculajuros, que recebe de parâmetro o valorinicial (double) e os meses (int), para fazer o cálculo do juros composto. Nesse endpoint tem uma chamada request para o endpoint /taxaJuros para retornar o valor do juros que é fixo. Ele retorna o cálculo: valorinicial * (1 + juros) ^ meses.
  > Tem o endpoint /showmethecode que retorna a URL do git, que está configurado no arquivo appsettings.json.

A API está configurada com Swagger. Então, consegue testá-la no navegador, rodando o projeto em localhost.

# Rodando o projeto

Faça download do código-fonte. Clique com o botão direito na Solution, e coloque para iniciar a API e o Web juntos. Assim, consegue testar pela interface o retorno dos endpoints.
Se quiser testar só a API, basta colocar o projeto da API como projeto inicial, e rodar.
