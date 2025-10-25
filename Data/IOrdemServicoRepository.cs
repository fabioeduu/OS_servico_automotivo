using OrdemServicoApp.Models;

namespace OrdemServicoApp.Data
{
    public interface IOrdemServicoRepository
    {
        IEnumerable<OrdemServico> GetAll();
        IEnumerable<OrdemServico> Search(string? q);
        OrdemServico? GetById(int id);
        void Add(OrdemServico ordem);
        void Update(OrdemServico ordem);
        void Delete(int id);
    }
}
