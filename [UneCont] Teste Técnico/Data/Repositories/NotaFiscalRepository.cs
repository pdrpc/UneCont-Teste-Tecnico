using _UneCont__Teste_Técnico.Data.Entity;
using _UneCont__Teste_Técnico.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Unecont.NfseApi.Data.Repositories;

namespace _UneCont__Teste_Técnico.Data.Repositories
{
    public class NotaFiscalRepository : BaseRepository<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<NotaFiscal>> GetByPrestadorCnpjAsync(string cnpjPrestador)
        {
            return await _dbSet.Where(nf => nf.CnpjPrestador == cnpjPrestador).ToListAsync();
        }

        public async Task<IEnumerable<NotaFiscal>> GetByTomadorCnpjAsync(string cnpjTomador)
        {
            return await _dbSet.Where(nf => nf.CnpjTomador == cnpjTomador).ToListAsync();
        }
    }
}
