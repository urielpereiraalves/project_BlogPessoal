using BLOG_PESSOAL_.src.dtos;
using BLOG_PESSOAL_.src.modelos;
using System.Collections.Generic;

namespace BLOG_PESSOAL_.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar uma nova postagem</para>
    /// <para>Criado por: Uriel Pereira</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IPostagens
    {
        void NovaPostagem(NovaPostagemDTO postagem);
        void AtualizarPostagem(AtualizarPostagemDTO postagem);
        void DeletarPostagem(int id);
        PostagemModelo PegarPostagemPeloId(int id);
        List<PostagemModelo> PegarTodasPostagens();
        List<PostagemModelo> PegarPostagensPeloTitulo(string titulo);
        List<PostagemModelo> PegarPostagensPelaDescricao(string descricao);

    }

    public class NovaPostagemDTO
    {
    }
}
