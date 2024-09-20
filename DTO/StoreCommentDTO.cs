namespace DTO
{
    public class StoreCommentDTO
    {
        public int Id { get; set; }

        public decimal? Score { get; set; }

        public string? Comment { get; set; }

        public int CustomerId { get; set; }

        public int StoreId { get; set; }
    }
}
