using System.ComponentModel.DataAnnotations;

namespace escolaNC.Modelos
{
    public class Login
    {

        public string nome { get; set; }

        [Key]
        public string cpf { get; set; }

        public string hash_senha { get; set; }

    }
}
