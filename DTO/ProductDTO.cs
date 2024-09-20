namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? Images { get; set; }

        public bool? IsPromotional { get; set; }

        public decimal? Score { get; set; }

        public int? Likes { get; set; }

        public int IdStore { get; set; }

    }
}