using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroChamado.Models
{
    public class ColaboradorModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; }
        [Required]
        public int Status { get; set; }
        [ForeignKey("Id")]
        [DisplayName("Setor")]
        public int SetorId { get; set; }
        public virtual SetorModel? Setor { get; set; }
    }
}
