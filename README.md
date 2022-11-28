# B3
  Esse é um projeto para calculo de um investimento em determinado periodo informado pelo usuário.
  
  Esse sistema foi de forma simples, uma vez que o desafio não exigiam uma modelagem complexa.

## Inicio

Para exceutar o sistema é necessário possuir os seguintes frameworks:

|.NET| Angular | Node|
| ------------- | ------------- |-------------|
| 7 | 15.0.1 | 18.12.1|

## WEB API

Após instalado os frameworks, o projeto pode ser executado localmente seguindo os passos a seguir.

### Executar a aplicação

#### Passo 1:

Relizar o download do projeto ou clonar em uma pasta em seu computador.

#### Passo 2:

Abra o código no Visual Studio 2022

#### Passo 3:

Clicar com o botão direto B3.API e clicar em 'Definir como projeto de inicialização', caso o programa esteja em português, a frase vem precedida pelo icone de uma engrenagem.

#### Passo 4:

Execute o projeto clicando em excutar projeto.

  >Caso não tenha o Docker instaldo no computador, sugiro que clique na setinha virada para baixo na IDE, selecione https e então execute, esse é o servidor padrão que vem juntamente com o framework.

#### Passo 5

Ao executar o sistema vai abrir o navegador padrão do computador juntamente com uma pagina do swagger e pronto o projeto pode ser executado e testado utilizando o swagger.

*Obs: Não será possivel executar com swagger sem a chave de acesso que está presente  no arquivo appsettings.Development.json.*

### Executar Teste de Unidade e Integração

Para facilitar o deploy da aplicação o sistema conta com teste das funcionalidades, para cobertura de teste foi utilizado uma extensão opensource Fine Code Coverage, para mostrar as porcentagens que o código foi testado.

Para executar os testes é necessário executar os seguintes passos

#### Passo 1:

No seu visual studio 2022 vá na aba Teste e clique em Gerenciador de Testes.

#### Passo 2:

Ao abrir a aba de gerenciador de teste clique com botão direito em cima de B3.Test e então clique em executar.

O sistema vai executar todos os testes configurados para o projeto.

>Um dos projetos pode dar erro, pois um arquivo csv pode não ir para a pasta de compilação do sistema, caso isso ocorra copie o arquivo data.csv e cole na pasta `bin/Debug` e execute os testes novamente.

#### Passo 3:

Após os testes serem realizados com sucesso você pode ir até a pasta `bin/Debug` e dentro dessa pasta vai conter uma pasta com nome fine covered dentro dela vai conter relatórios de cobertura do código, caso você queira verificar.

## WEB 

O Sistema web é um interface desenvolvida em angularpara que o usuario consiga informar um valor inicial e um periodo em mês para que sejá exibido quanto o valor irá render no periodo. 

### Executar a aplicação

Para rodar o sistema web é necessário possuir o Visual Studio Code e os frameworks instalados e configurados globalmente além de estar rodando a aplicação backend para conseguir realizar as requisições.

#### Passo 1:

Abra o visual studio code.

#### Passo 2:

Vá até o local onde o projeto se encontra na pasta `./src/Web/B3Web` e selecione o local e clique em abrir.

#### Passo 3:

Após carregado rode o comando `npm install` ele vai instalar os pacotes necessários para rodar o projeto.

#### Passo 4

Após a instalação dos pacotes execute o comando `ng s` ele vai iniciar o servidor para que o sistema começe a executar.

>Caso o sistema esteja rodando no `docker` é necessário abrir o arquivo environment.ts e alterar a porta da url de 7047 para porta que está rodando o docker do projeto backend.

#### Passo 5:

Após finalizar a execução abra o navegador e digite: `http://localhost:4200` ele vai mostrar o site.

#### Passo 6:

Insira os valores que estarão indicado na tela e clique no botão Pesquisar. 

Assim que clicar no botão será exibido um resultado na tabela abaixo do campo de pesquisa.

## Observações

O sistema foi pensado de forma a se comportar como microserviços, por esse motivo, não contém várias projetos classlib.
A separação das camadas foi realizado dentro de um único projeto.

O .Net 7 foi escolhido por ser o mais atual e o desafio permitir versões superiores ao .Net Framework 4.7.2.

