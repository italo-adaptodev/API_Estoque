using Estoque.Business.interfaces;
using Estoque.Repository.interfaces;

namespace Estoque.Business.implementacoes
{
    public class SaldoBusiness : ISaldoBusiness
    {
        private IEntradaEstoqueRepository _entradaRepository;
        private ISaidaEstoqueRepository _saidaRepository;
        private IMaterialRepository _materialRepository;

        public SaldoBusiness(IEntradaEstoqueRepository entradaRepository, ISaidaEstoqueRepository saidaRepository, IMaterialRepository materialRepository)
        {
            _entradaRepository = entradaRepository;
            _saidaRepository = saidaRepository;
            _materialRepository = materialRepository;
        }

        public int FindQtdByMaterial(string material)
        {
            return _entradaRepository.SaldoEntradaByMaterial(material);
        }

        public int FindQtdRetiradaByMaterial(string material)
        {
            return _saidaRepository.SaldoSaidaByMaterial(material);
        }

        public int SaldoMaterial(string descricao)
        {
            int qtdMaterialEntrada = FindQtdByMaterial(descricao);
            int qtdMaterialSaida = FindQtdRetiradaByMaterial(descricao);
            return qtdMaterialEntrada - qtdMaterialSaida; 
        }
    }
}
