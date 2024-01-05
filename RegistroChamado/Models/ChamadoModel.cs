using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace RegistroChamado.Models
{
    public class ChamadoModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Data e Hora")]
        public required DateTime DataHora { get; set; }
        
        [Required]
        [ForeignKey("Id")]
        [DisplayName("Setor")]
        public required int SetorId { get; set; }
        public virtual SetorModel? Setor { get; set; }
        
        [ForeignKey("Id")]
        [DisplayName("Colaborador")]
        public required int ColaboradorId { get; set; }
        public virtual ColaboradorModel? Colaborador { get; set; }

        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string Prioridade { get; set; }
        public required string Status { get; set; }
    }
}
