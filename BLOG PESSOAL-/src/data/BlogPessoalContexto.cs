using BLOG_PESSOAL_.src.modelos;
using Microsoft.EntityFrameworkCore;
namespace BLOG_PESSOAL_.src.data{    public class BlogPessoalContexto : DbContext    {
        /// <summary>
        /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
        /// <para>Criado por: Uriel Pereira</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 12/05/2022</para>
        /// </summary>        public DbSet<UsuarioModelo> Usuarios { get; set; }        public DbSet<TemaModelo> Temas { get; set; }        public DbSet<PostagemModelo> Postagens { get; set; }        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)        {        }    }}
