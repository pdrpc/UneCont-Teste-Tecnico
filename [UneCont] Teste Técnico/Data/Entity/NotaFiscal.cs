using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _UneCont__Teste_Técnico.Data.Entity
{
    public class NotaFiscal
    {
        // 1. Chave Primária para o Banco de Dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string NumeroNota { get; set; }

        [Required]
        [StringLength(14)]
        public string CnpjPrestador { get; set; }

        [Required]
        [StringLength(14)]
        public string CnpjTomador { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        [Required]
        public string DescricaoServico { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorTotal { get; set; }

        public DateTime DataImportacao { get; set; } = DateTime.UtcNow;
    }
}