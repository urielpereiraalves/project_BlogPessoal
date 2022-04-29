using System.ComponentModel.DataAnnotations;

namespace BLOG_PESSOAL_.src.dtos
{
    public class NovapostagemDTO
    {
        /// <summary>
        /// <para>Resumo: Classe espelho criar uma nova postagem</para>
        /// <para>Criado por: Uriel Pereira</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 29/04/2022</para>
        /// </summary>

        [Required, StringLength(30)]
        public string Titulo { get; set; }

        [Required, StringLength(100)]
        public string Descricao { get; set; }

        public string Foto { get; set; }

        [Required]
        public string EmailCriador { get; set; }

        [Required]
        public string descricaoTema { get; set; }



        public NovapostagemDTO(string titulo, string descricao, string foto, string emailCriador, int descricaoTema)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            EmailCriador = emailCriador;
            descricaoTema = descricaoTema;
        }
    }
    /// <summary>
    /// <para>Resumo: Classe espelho para alterar uma postagem</para>
    /// <para>Criado por: Uriel Pereira</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class AtualizarPostagemDTO
    {

        [Required, StringLength(30)]
        public string Titulo { get; set; }

        [Required, StringLength(100)]
        public string Descricao { get; set; }

        public string Foto { get; set; }

        [Required]
        public string DescricaoTema { get; set; }

        public AtualizarPostagemDTO(string titulo, string descricao, string foto, string descricaoTema)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            DescricaoTema = descricaoTema;
        }
    }
}