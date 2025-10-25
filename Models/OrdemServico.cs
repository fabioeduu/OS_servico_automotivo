using System.ComponentModel.DataAnnotations;

namespace OrdemServicoApp.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string? Veiculo { get; set; }

        [StringLength(20)]
        public string? Placa { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEntrada { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataSaida { get; set; }

        public StatusOrdem Status { get; set; }

        [StringLength(500)]
        public string? Descricao { get; set; }

        [Range(0, 1000000)]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [StringLength(100)]
        public string? Tecnico { get; set; }

        [StringLength(1000)]
        public string? Observacoes { get; set; }
    }
}
