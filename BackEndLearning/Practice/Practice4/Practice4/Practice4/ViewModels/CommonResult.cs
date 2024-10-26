namespace Practice4.ViewModels
{
    public class CommonResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public String? Error { get; set; }

        public T? Data { get; set; }
        public string? Timestamp { get; set; }
    }
}
