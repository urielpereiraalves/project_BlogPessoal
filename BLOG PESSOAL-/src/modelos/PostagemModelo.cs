using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLOG_PESSOAL_.src.modelos
{
    [Table("tb_postagens")]
    public class PostagemModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public string Foto { get; set; }

        [ForeignKey("fk_usuario")]
        public UsuarioModelo Criador { get; set; }

        [ForeignKey("fk_tema")]
        public TemaModelo Tema { get; set; }

    }
}
