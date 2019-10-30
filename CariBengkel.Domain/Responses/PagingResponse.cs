namespace CariBengkel.Domain.Responses {
    public class PagingResponse<T> : BaseResponse<T> where T : class {
        public int Total { get; set; }
        public int FilterRecord { get; set; }
        public int Page { get; set; }
    }
}