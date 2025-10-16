# [UneCont] Teste Técnico
Este projeto implementa o desafio de criar um serviço que lê arquivos XML de notas fiscais de serviço (NFS-e simplificada), valida os dados e os persiste em SQL Server, expondo-os via API REST.

Tecnologias Essenciais
  ASP.NET Core Web API: Plataforma principal do serviço.
  Entity Framework Core (EF Core): Persistência no SQL Server.
  Padrão Repository: Abstração de acesso a dados e alta testabilidade.
  AutoMapper: Mapeamento de Entidades para DTOs.
  Swagger/OpenAPI: Documentação e testes interativos da API.

Arquitetura e Decisões de Design
  A arquitetura utiliza o princípio da Separação de Preocupações (SoC), dividindo as responsabilidades:  
  Camada de Dados (/Data):  
  Padrão Repository Genérico: O IBaseRepository centraliza o CRUD. O NotaFiscalRepository lida com consultas específicas.  
  Entidades vs. DTOs: A Entidade (NotaFiscal.cs) é usada apenas para persistência, enquanto os DTOs (/Models) são usados para comunicação na API.  
  Camada de Serviço (/Services):  
  Serviço de Domínio: O NotaFiscalService atua como o coordenador principal.  
  Serviço Auxiliar: O XmlProcessor isola a lógica de parsing e validação de formato e regras de negócio de input (CNPJ de 14 dígitos, Valor > 0).  
  Assincronicidade: Uso extensivo de async/await para garantir alta escalabilidade e melhor concorrência nas operações de I/O (Banco de Dados e Leitura de Arquivo).

Configuração (Setup)
  1. Inicialização do Banco de Dados
  O banco de dados é inicializado através das Migrations do Entity Framework Core, que cria a estrutura da tabela NotasFiscais no SQL Server (LocalDB):  
  Utilizando o Package Manager Console (PM Console) execute os comandos para criar e aplicar a migração:
    Add-Migration InitialSetup
    Update-Database

Uso da API
  Execute o projeto e acesse o Swagger UI (https://localhost:PORTA/swagger).
  
  1. Importar Nota Fiscal (POST)
  Esta rota é a principal funcionalidade, recebendo o conteúdo XML como uma string no corpo da requisição para processamento, validação e persistência.  
  Endpoint: POST /api/notas/importar
  
  Corpo da Requisição (Body): Envie um JSON contendo o XML de teste como uma string de linha única no campo ConteudoXml.
  
  Exemplo de Body:  
  JSON  
  {
    "ConteudoXml": "<NotaFiscal><Numero>67890</Numero><Prestador><CNPJ>22345678000177</CNPJ></Prestador><Tomador><CNPJ>88765432000166</CNPJ></Tomador><DataEmissao>2023-12-05</DataEmissao><Servico><Descricao>Serviços de   manutenção de sistemas</Descricao><Valor>2400.00</Valor></Servico></NotaFiscal>"
  }
  
  Retorno: 201 Created (Sucesso).
  
  2. Consultar Notas Fiscais (GET)
  Endpoint: GET /api/notas  
  Retorno: 200 OK com um array de NotasFiscaisResponseDTO.
