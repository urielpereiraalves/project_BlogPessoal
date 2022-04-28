using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BLOG_PESSOAL_.src.modelos
{
    [Table("tb_usuarios")]
    public class UsuarioModelo
    {
        [Key] // primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //define o numero do id que sera gerado automaticamente
        public int Id { get; set; }

        [Required] // nome caso seja obrigatório colocar
        [StringLength(50)] // tamanho da string 50
        public string Nome { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength (30)]

        public string Senha { get; set; }

        public string Foto { get; set; } // foto tambem é string,não precisa colocar que tem limitações de string
        [JsonIgnore]
        public List<PostagemModelo> MinhasPostagens { get; set; }
    }
}
