using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //
            // 📚 BOOKS
            //
            CreateMap<Book, BookDto>();

            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());   // Id lo genera la BD


            //
            // 📘 LOANS
            //
            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.BookTitle,
                    opt => opt.MapFrom(src => src.Book != null ? src.Book.Title : string.Empty));

            CreateMap<CreateLoanDto, Loan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}