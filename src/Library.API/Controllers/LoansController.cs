using Library.Application.DTOs;
using Library.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    private readonly ILoanService _service;

    public LoansController(ILoanService service)
    {
        _service = service;
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveLoans()
    {
        return Ok(await _service.GetActiveLoansAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLoanDto dto)
    {
        try
        {
            var loan = await _service.CreateLoanAsync(dto);
            return Ok(loan);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("return/{id}")]
    public async Task<IActionResult> ReturnLoan(int id)
    {
        var result = await _service.ReturnLoanAsync(id);
        return result ? Ok("Préstamo devuelto") : NotFound();
    }
}