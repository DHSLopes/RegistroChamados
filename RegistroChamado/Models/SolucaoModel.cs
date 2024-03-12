using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroChamado.Models
{
    public class SolucaoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Data e Hora")]
        public required DateTime DataHora { get; set; }
        public required string Descricao { get; set; }
        [Required]
        [ForeignKey("Id")]
        [DisplayName("Chamado")]
        public int ChamadoId { get; set; }
        public virtual ChamadoModel? Chamado { get; set; }
    }
}
