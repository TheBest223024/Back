using Library.Application.DTOs;

namespace Library.Application.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanDto>> GetActiveLoansAsync();
        Task<LoanDto> CreateLoanAsync(CreateLoanDto dto);
        Task<bool> ReturnLoanAsync(int loanId);
    }
}