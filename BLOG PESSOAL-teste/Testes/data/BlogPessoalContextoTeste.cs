using Microsoft.EntityFrameworkCore;
using BLOG_PESSOAL_.src.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLOG_PESSOAL_.src.modelos;
using System.Linq;

namespace BLOGPESSOALTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _contexto;

        [TestInitialize]

        public void Inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                 .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                 .Options;

            _contexto = new BlogPessoalContexto(opt);



        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornarUsuario()
        {
            UsuarioModelo Usuario = new UsuarioModelo();

            Usuario.Nome = "Uriel Pereira";
            Usuario.Email = "Uriel@email.com";
            Usuario.Senha = "123456";
            Usuario.Foto = "Fotolinda";

            _contexto.Usuarios.Add(Usuario);

            _contexto.SaveChanges(); // Commita criação

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "Uriel@email.com"));

        }
    }
}
