namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public ICollection<Loan> Loans { get; set; }
    }
}