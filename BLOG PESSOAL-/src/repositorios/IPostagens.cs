using BLOG_PESSOAL_.src.dtos;
using BLOG_PESSOAL_.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<List<PostagemModelo>> PegarTodasPostagensAsync();
        Task<PostagemModelo> PegarPostagemPeloIdAsync(int id);
        Task<List<PostagemModelo>> PegarPostagensPorPesquisaAsync(string titulo, string descricaoTema, string nomeCriador);
        Task NovaPostagemAsync(NovaPostagemDTO postagem);
        Task AtualizarPostagemAsync(AtualizarPostagemDTO postagem);
        Task DeletarPostagemAsync(int id);


    }
}
