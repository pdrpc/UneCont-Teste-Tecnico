using Microsoft.AspNetCore.Mvc;
using _UneCont__Teste_Técnico.Services.Interfaces;
using _UneCont__Teste_Técnico.Data.Entity;
using _UneCont__Teste_Técnico.Models.NotasFiscais.Requests;
using _UneCont__Teste_Técnico.Models.NotasFiscais.Responses;

namespace Unecont.NfseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly INotaFiscalService _notaFiscalService;

        public NotasController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotasFiscaisResponseDTO>>> GetNotas()
        {
            var notas = await _notaFiscalService.ObterNotasFiscaisAsync();
            return Ok(notas);
        }

        [HttpPost("importar")]
        public async Task<IActionResult> ImportarXml([FromBody] ImportarNotasFiscaisRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.ConteudoXml))
            {
                return BadRequest("O conteúdo XML (`ConteudoXml`) é obrigatório no corpo da requisição.");
            }

            try
            {
                var notaResponse = await _notaFiscalService.ImportarNotaFiscalAsync(request.ConteudoXml);

                return Created(uri: string.Empty, value: notaResponse);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = "Erro de Validação", Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = "Erro no XML", Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Erro Interno", Message = "Ocorreu um erro inesperado ao importar o XML: " + ex.Message });
            }
        }
    }
}