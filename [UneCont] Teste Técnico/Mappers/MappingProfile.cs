using _UneCont__Teste_Técnico.Data.Entity;
using _UneCont__Teste_Técnico.Models.NotasFiscais.Responses;
using AutoMapper;

namespace Unecont.NfseApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamento da Entidade (Origem) para o DTO de Resposta (Destino)
            // (Usado em ObterNotasFiscaisAsync e ImportarNotaFiscalAsync)
            CreateMap<NotaFiscal, NotasFiscaisResponseDTO>();

            // Mapeamento de DTO para Entidade (se fosse necessário receber dados do usuário
            // e criar uma NotaFiscal diretamente a partir do DTO de Request,
            // mas aqui a Entidade é criada pelo XmlProcessor, então não é estritamente necessário.)
            // Ex: CreateMap<ImportarNotasFiscaisRequestDTO, NotaFiscal>();
        }
    }
}