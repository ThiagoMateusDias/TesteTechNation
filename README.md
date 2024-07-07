Sistema de Gestão Financeira.

Este projeto é uma aplicação web desenvolvida em ASP.NET Core para gerenciar indicadores financeiros de uma empresa. A aplicação permite visualizar e filtrar dados de notas fiscais emitidas, integrando funcionalidades de dashboard com gráficos interativos.

![telagrafico](https://github.com/ThiagoMateusDias/TesteTechNation/assets/155456682/fba4afcf-bc10-4836-986a-1501c01eebdc)
![telaLista](https://github.com/ThiagoMateusDias/TesteTechNation/assets/155456682/def663ad-6b76-4d61-80fa-d587a9d0442f)

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
Execução: Abra o projeto no Visual Studio ou utilize o terminal para executar dotnet run.
