using BLOG_PESSOAL_.src.dtos;
using BLOG_PESSOAL_.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLOG_PESSOAL_.src.repositorios
{
        /// <summary>
        /// <para>Resumo: Responsavel por representar ações de CRUD de tema</para>
        /// <para>Criado por: Uriel Pereira</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 29/04/2022</para>
        /// </summary>
        public interface ITema
        {
        Task<List<TemaModelo>> PegarTodosTemasAsync();
        Task<TemaModelo> PegarTemaPeloIdAsync(int id);
        Task<List<TemaModelo>> PegarTemasPelaDescricaoAsync(string descricao);
        Task NovoTemaAsync(NovoTemaDTO tema);
        Task AtualizarTemaAsync(AtualizarTemaDTO tema);
        Task DeletarTemaAsync(int id);

        }

}
