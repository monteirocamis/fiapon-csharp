using System.ComponentModel.DataAnnotations;


namespace FiapSmartCity.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome deve ter, no máximo, 50 caracteres")]
        [Display(Name = "NamePessoa:")]
        public String NomePessoa { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório!")]
        [StringLength(50, ErrorMessage = "O endereço deve ter, no máximo, 50 caracteres")]
        [Display(Name = "EnderecoPessoa:")]
        public String EnderecoPessoa { get; set; }

    }
}
