namespace FlightsAppBE.Model.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
