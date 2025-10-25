using OrdemServicoApp.Models;

namespace OrdemServicoApp.Data
{
    public class InMemoryOrdemServicoRepository : IOrdemServicoRepository
    {
        private readonly List<OrdemServico> _items = new();
        private int _nextId = 1;

        public InMemoryOrdemServicoRepository()
        {
            Add(new OrdemServico
            {
                Cliente = "Fabio H S Eduardo",
                Veiculo = "Mclaren 720s Spider",
                Placa = "MCL-4321",
                DataEntrada = DateTime.Now.AddDays(-1),
                DataSaida = null,
                Status = StatusOrdem.EmAndamento,
                Descricao = "Revisão completa",
                Valor = 850.00m,
                Tecnico = "Renato Kenji Sugaki",
                Observacoes = "Peças em garantia"
            });


            Add(new OrdemServico
            {
                Cliente = "Renato Kenji Sugaki",
                Veiculo = "Skyline GT-R",
                Placa = "SKY-1234",
                DataEntrada = DateTime.Now.AddDays(-2),
                DataSaida = null,
                Status = StatusOrdem.Cancelada,
                Descricao = "Troca de óleo e filtro",
                Valor = 250.00m,
                Tecnico = "Gabriel Wu",
                Observacoes = "Peças em garantia"
            });

            Add(new OrdemServico
            {
                Cliente = "Gabriel Wu Castro",
                Veiculo = "Porsche GT3 RS",
                Placa = "PSC-9876",
                DataEntrada = DateTime.Now.AddDays(-7),
                DataSaida = DateTime.Now.AddDays(-3),
                Status = StatusOrdem.Concluida,
                Descricao = "Revisão completa",
                Valor = 1200.00m,
                Tecnico = "Renato Kenji Sugaki",
                Observacoes = "Cliente satisfeito"
            });

          
        }

        public IEnumerable<OrdemServico> GetAll() => _items.OrderByDescending(x => x.DataEntrada);

        public IEnumerable<OrdemServico> Search(string? q)
        {
            if (string.IsNullOrWhiteSpace(q)) return GetAll();
            q = q.Trim().ToLowerInvariant();
            return _items.Where(x => (x.Cliente ?? string.Empty).ToLower().Contains(q)
                                  || (x.Veiculo ?? string.Empty).ToLower().Contains(q)
                                  || (x.Placa ?? string.Empty).ToLower().Contains(q))
                         .OrderByDescending(x => x.DataEntrada);
        }

        public OrdemServico? GetById(int id) => _items.FirstOrDefault(x => x.Id == id);

        public void Add(OrdemServico ordem)
        {
            ordem.Id = _nextId++;
            _items.Add(ordem);
        }

        public void Update(OrdemServico ordem)
        {
            var existing = GetById(ordem.Id);
            if (existing == null) return;
            existing.Cliente = ordem.Cliente;
            existing.Veiculo = ordem.Veiculo;
            existing.Placa = ordem.Placa;
            existing.DataEntrada = ordem.DataEntrada;
            existing.DataSaida = ordem.DataSaida;
            existing.Status = ordem.Status;
            existing.Descricao = ordem.Descricao;
            existing.Valor = ordem.Valor;
            existing.Tecnico = ordem.Tecnico;
            existing.Observacoes = ordem.Observacoes;
        }

        public void Delete(int id)
        {
            var e = GetById(id);
            if (e != null) _items.Remove(e);
        }
    }
}
