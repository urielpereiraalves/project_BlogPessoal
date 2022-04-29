using BLOG_PESSOAL_.src.dtos;
using BLOG_PESSOAL_.src.modelos;

namespace BLOG_PESSOAL_.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
    /// <para>Criado por: Uriel Pereira</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>

    public interface IUsuario
    {
        void NovoUsuario(NovoUsuarioDTO usuario);
        void AtualizarUsuario(AtualizarUsuarioDTO usuario);

        void DeletarUsuario(int id);
        UsuarioModelo PegarUsuarioPeloId(int id);
        UsuarioModelo PegarUsuarioPeloEmail(string email);
        UsuarioModelo PegarUsuarioPeloNome(string nome);

    }
}
