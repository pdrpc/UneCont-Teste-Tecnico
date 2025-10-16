using _UneCont__Teste_Técnico.Data.Entity;
using _UneCont__Teste_Técnico.Data.Interfaces;
using _UneCont__Teste_Técnico.Models.NotasFiscais.Responses;
using _UneCont__Teste_Técnico.Services.Auxiliares;
using _UneCont__Teste_Técnico.Services.Interfaces;
using AutoMapper;

namespace Unecont.NfseApi.Services.NotasFiscaisServices
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _repository;
        private readonly IMapper _mapper;
        private readonly XmlProcessor _xmlProcessor;

        public NotaFiscalService(INotaFiscalRepository repository, IMapper mapper, XmlProcessor xmlProcessor)
        {
            _repository = repository;
            _xmlProcessor = xmlProcessor;
            _mapper = mapper;
        }

        public async Task<NotasFiscaisResponseDTO> ImportarNotaFiscalAsync(string xmlContent)
        {
            var nota = _xmlProcessor.ProcessarXml(xmlContent);

            await _repository.AddAsync(nota);

            return _mapper.Map<NotasFiscaisResponseDTO>(nota);
        }

        public async Task<IEnumerable<NotasFiscaisResponseDTO>> ObterNotasFiscaisAsync()
        {
            var notas = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<NotasFiscaisResponseDTO>>(notas);
        }
    }
}