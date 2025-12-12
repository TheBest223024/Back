using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Ports.Out;

namespace Library.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LoanService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<LoanDto> CreateLoanAsync(CreateLoanDto dto)
        {
            var book = await _uow.Books.GetByIdAsync(dto.BookId);
            if (book == null) throw new Exception("Libro no encontrado");
            if (book.Stock == 0) throw new Exception("No hay stock disponible");

            book.Stock -= 1;

            var loan = new Loan
            {
                BookId = dto.BookId,
                StudentName = dto.StudentName,
                LoanDate = DateTime.Now,
                Status = "Active",
                CreatedAt = DateTime.Now
            };

            await _uow.Loans.AddAsync(loan);
            await _uow.SaveChangesAsync();

            return new LoanDto
            {
                Id = loan.Id,
                BookTitle = book.Title,
                StudentName = loan.StudentName,
                LoanDate = loan.LoanDate,
                Status = loan.Status
            };
        }

        public async Task<IEnumerable<LoanDto>> GetActiveLoansAsync()
        {
            var loans = await _uow.Loans.GetActiveLoansAsync();
            return loans.Select(l => new LoanDto
            {
                Id = l.Id,
                BookTitle = l.Book.Title,
                StudentName = l.StudentName,
                LoanDate = l.LoanDate,
                Status = l.Status
            });
        }

        public async Task<bool> ReturnLoanAsync(int loanId)
        {
            var loan = await _uow.Loans.GetByIdAsync(loanId);
            if (loan == null || loan.Status == "Returned")
                return false;

            var book = await _uow.Books.GetByIdAsync(loan.BookId);
            book.Stock += 1;

            loan.Status = "Returned";
            loan.ReturnDate = DateTime.Now;

            _uow.Loans.Update(loan);
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}