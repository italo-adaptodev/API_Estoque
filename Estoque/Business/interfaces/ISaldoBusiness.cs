namespace Estoque.Business.interfaces
{
    public interface ISaldoBusiness
    {
        int FindQtdByMaterial(string material);
        int SaldoMaterial(string descricao);
        int FindQtdRetiradaByMaterial(string material);
    }
}
