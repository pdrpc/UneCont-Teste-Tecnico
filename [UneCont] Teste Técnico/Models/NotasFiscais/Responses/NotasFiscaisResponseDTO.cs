namespace _UneCont__Teste_Técnico.Models.NotasFiscais.Responses
{
    public class NotasFiscaisResponseDTO
    {
        public string NumeroNota { get; set; }
        public string CnpjPrestador { get; set; }
        public string CnpjTomador { get; set; }
        public DateTime DataEmissao { get; set; }
        public string DescricaoServico { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
