namespace DTO
{
    public class Response<T>
    {
        public bool Status { get; set; } = false;
        public T? Value { get; set; }
        public string? Msg { get; set; }
    }
}
