using System.ComponentModel.DataAnnotations;

namespace FiapSmartCity.Models
{
    public class Pet
    {
        public int IdPet { get; set; }
        [Required(ErrorMessage = "descricao obrigatoria")]
        [StringLength(50,ErrorMessage ="descricao deve ter 80 caracs" )]
        [Display(Name ="descricao: ")]

        public String NomePet { get; set; }
    }
}
