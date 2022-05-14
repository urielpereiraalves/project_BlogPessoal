using BLOG_PESSOAL_.src.dtos;
using BLOG_PESSOAL_.src.modelos;
using BLOG_PESSOAL_.src.data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLOG_PESSOAL_.src.repositorios.implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar ITema</para>
    /// <para>Criado por: Uriel Pereira</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>
    public class TemaRepositorio : ITema
    {

        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion Atributos

        #region Construtores

        public TemaRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion Construtores

        #region Metodos

        /// <summary>
        /// <para>Resumo: Método assíncrono para atualizar um tema</para>
        /// </summary>
        /// <param name="tema">AtualizarTemaDTO</param>
        public async Task AtualizarTemaAsync(AtualizarTemaDTO tema)
        {
            var TemaExistente =await PegarTemaPeloIdAsync(tema.Id);
            TemaExistente.Descricao = tema.Descricao;
            _contexto.Temas.Update(TemaExistente);
           await _contexto.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resumo: Método assíncrono para deletar um tema</para>
        /// </summary>
        /// <param name="id">Id do tema</param>
        public async Task DeletarTemaAsync(int id)
        {
            _contexto.Temas.Remove(await PegarTemaPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo tema</para>
        /// </summary>
        /// <param name="tema">NovoTemaDTO</param>
        public async Task NovoTemaAsync(NovoTemaDTO tema)
        {
           await _contexto.Temas.AddAsync(new TemaModelo
            {
                Descricao = tema.Descricao
            });
            await _contexto.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar temas pela descrição</para>
        /// </summary>
        /// <param name="descricao">Descrição do tema</param>
        /// <return>Lista TemaModelo</return>
        public async Task<List<TemaModelo>> PegarTemasPelaDescricaoAsync(string descricao)
        {
            return await _contexto.Temas
                .Where(t => t.Descricao.Contains(descricao))
                .ToListAsync();

        }
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos temas</para>
        /// </summary>
        /// <return>Lista TemaModelo</return>
        public async Task<List<TemaModelo>> PegarTodosTemasAsync()
        {
            return await _contexto.Temas
                .ToListAsync();
        }
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um tema pelo Id</para>
        /// </summary>
        /// <param name="id">Id do tema</param>
        /// <return>TemaModelo</return>
        public async Task<TemaModelo> PegarTemaPeloIdAsync(int id)
        {
            return await _contexto.Temas.FirstOrDefaultAsync(t => t.Id == id);

        }

        #endregion Metodos
    }
}