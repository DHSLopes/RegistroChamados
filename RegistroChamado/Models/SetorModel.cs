namespace RegistroChamado.Models
{
    public class SetorModel
    {
        [Key]
        public required int Id { get; set; }
        [Required]
        public required string Descricao { get; set; }
        [Required]
        public required int Status { get; set; }
    }
}
