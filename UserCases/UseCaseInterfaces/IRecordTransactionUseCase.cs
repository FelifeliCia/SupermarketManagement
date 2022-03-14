namespace UseCases
{
    public interface IRecordTransactionUseCase
    {
        void Excute(string cashierName, int productId, int qty);
    }
}