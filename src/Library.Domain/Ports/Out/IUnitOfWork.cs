namespace Library.Domain.Ports.Out
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        ILoanRepository Loans { get; }
        Task<int> SaveChangesAsync();
    }
}