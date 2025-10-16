using _UneCont__Teste_Técnico.Models.NotasFiscais.Responses;

namespace _UneCont__Teste_Técnico.Services.Interfaces
{
    public interface INotaFiscalService
    {

        Task<NotasFiscaisResponseDTO> ImportarNotaFiscalAsync(string xmlContent);

        Task<IEnumerable<NotasFiscaisResponseDTO>> ObterNotasFiscaisAsync();
    }
}
