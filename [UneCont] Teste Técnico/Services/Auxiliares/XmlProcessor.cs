using _UneCont__Teste_Técnico.Data.Entity;
using System.Xml.Linq;

namespace _UneCont__Teste_Técnico.Services.Auxiliares
{
    public class XmlProcessor
    {

        //Processar um unico arquivo XML
        public NotaFiscal ProcessarXml(string xmlContent)
        {
            var doc = XDocument.Parse(xmlContent);

            var nota = ExtrairInfo(doc);

            ValidarNotaFiscal(nota);

            return nota;
        }

        private NotaFiscal ExtrairInfo(XDocument doc)
        {
            var nfElement = doc.Element("NotaFiscal");

            if(nfElement == null) throw new ArgumentException("XML inválido: Não encontrado o nó <NotaFiscal>.");

            var prestador = nfElement.Element("Prestador");
            var tomador = nfElement.Element("Tomador");
            var servico = nfElement.Element("Servico");
            var nota = new NotaFiscal
            {
                NumeroNota = nfElement.Element("Numero")?.Value,
                CnpjPrestador = prestador?.Element("CNPJ")?.Value,
                CnpjTomador = tomador?.Element("CNPJ")?.Value,
                DataEmissao = DateTime.Parse(nfElement.Element("DataEmissao")?.Value),
                DescricaoServico = servico?.Element("Descricao")?.Value,
                ValorTotal = decimal.Parse(servico?.Element("Valor")?.Value ?? "0", System.Globalization.CultureInfo.InvariantCulture)
            };

            return nota;
        }

        private void ValidarNotaFiscal(NotaFiscal nota)
        {
            if (string.IsNullOrEmpty(nota.NumeroNota) ||
               string.IsNullOrEmpty(nota.CnpjPrestador) ||
               string.IsNullOrEmpty(nota.CnpjTomador) ||
               string.IsNullOrEmpty(nota.DescricaoServico))
            {
                throw new InvalidOperationException("Falha na validação: Campos obrigatórios nulos ou vazios.");
            }

            if (!ValidarCnpj(nota.CnpjPrestador) || !ValidarCnpj(nota.CnpjTomador))
            {
                throw new InvalidOperationException("Falha na validação: CNPJs devem conter 14 dígitos válidos[cite: 25].");
            }

            if (nota.ValorTotal <= 0)
            {
                throw new InvalidOperationException("Falha na validação: O valor total deve ser maior que zero[cite: 26].");
            }

            if (nota.DataEmissao == default(DateTime))
            {
                throw new InvalidOperationException("Falha na validação: Data de emissão inválida ou ausente[cite: 27].");
            }
        }

        private bool ValidarCnpj(string cnpj)
        {
            return cnpj.Length == 14 && long.TryParse(cnpj, out _);
        }
    }
}
