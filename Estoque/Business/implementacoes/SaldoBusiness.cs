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

        public int SaldoMaterial(string descricao)
        {
            int qtdMaterialEntrada = _entradaRepository.SaldoEntradaByMaterial(descricao);
            int qtdMaterialSaida = _saidaRepository.SaldoSaidaByMaterial(descricao);
            return (qtdMaterialEntrada.Equals(0)) ? 0 : qtdMaterialEntrada - qtdMaterialSaida;
        }
    }
}
