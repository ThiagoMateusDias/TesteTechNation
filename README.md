Sistema de Gestão Financeira.

Este projeto é uma aplicação web desenvolvida em ASP.NET Core para gerenciar indicadores financeiros de uma empresa. A aplicação permite visualizar e filtrar dados de notas fiscais emitidas, integrando funcionalidades de dashboard com gráficos interativos.

![telaHome](https://github.com/ThiagoMateusDias/TesteTechNation/assets/155456682/82d51624-47d0-45f6-9d34-fe394401dc50)
![telaGraficos](https://github.com/ThiagoMateusDias/TesteTechNation/assets/155456682/1d95280a-0fd5-4aa6-b908-2b7fe5326ea0)
![telaLista](https://github.com/ThiagoMateusDias/TesteTechNation/assets/155456682/7536dc6f-3be6-4d45-9ccc-f5ff98101124)

Funcionalidades Principais.

Dashboard de Indicadores: Visualização de indicadores financeiros como total geral, total do ano, notas sem cobrança, inadimplência, notas a vencer e notas pagas.
Filtros Avançados: Permite filtrar notas fiscais por tipo de pagamento, status da nota, ano, mês, trimestre, mês de emissão, mês de cobrança e mês de pagamento.
Gráficos Interativos: Apresenta gráficos de evolução da inadimplência e receita recebida ao longo do tempo.
Listagem de Notas Fiscais: Exibe uma lista detalhada de notas fiscais com informações como pagador, número de identificação, datas relevantes, valor, status da nota e tipo de pagamento.

Tecnologias Utilizadas.

Backend: ASP.NET Core, C# com .NET LTS, SQL Server.
Frontend: HTML, CSS (Bootstrap 5), JavaScript (jQuery, Chart.js).
Integrações: AutoMapper para mapeamento de objetos.

Como Executar.

Requisitos: Certifique-se de ter o .NET LTS instalado e um banco de dados SQL Server configurado.
Configuração: Clone o repositório e configure as conexões de banco de dados em appsettings.json.

1 - Baixar a imagem do SQL Server:
Execute o comando abaixo no terminal para baixar a imagem do SQL Server 2022:
docker pull mcr.microsoft.com/mssql/server:2022-latest

2 - Rodar o contêiner do SQL Server:
Execute o comando abaixo para aceitar os termos de licença e iniciar o contêiner do SQL Server:
docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Mudar123@" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

3 - Conectar ao SQL Server:
Conecte-se ao SQL Server utilizando a string de conexão localhost,1433 e as credenciais definidas (sa/Mudar123@).

4 - Executar o script para criar banco de dados e tabelas:
Baixe e execute o script SQL disponível em:
https://github.com/ThiagoMateusDias/TesteTechNation/blob/master/TesteTechNation/TesteTechNation.Data/Script.sql

5 - Executar o projeto no Visual Studio:
Abra o projeto no Visual Studio e selecione a opção para executar como contêiner (file).

