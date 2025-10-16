using _UneCont__Teste_Técnico.Data.Entity;

namespace _UneCont__Teste_Técnico.Data.Interfaces
{
    public interface INotaFiscalRepository : IBaseRepository<NotaFiscal>
    {
        Task<IEnumerable<NotaFiscal>> GetByTomadorCnpjAsync(string tomador);
        Task<IEnumerable<NotaFiscal>> GetByPrestadorCnpjAsync(string prestador);
    }
}
