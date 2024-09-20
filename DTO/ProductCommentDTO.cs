namespace DTO
{
    public class ProductCommentDTO
    {
        public int Id { get; set; }

        public decimal? Score { get; set; }

        public string? Comment { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }
    }
}
