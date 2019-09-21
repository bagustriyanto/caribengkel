namespace CariBengkel.Domain.Responses {
    public class PagingResponse : BaseResponse {
        public int Total { get; set; }
        public int FilterRecord { get; set; }
        public int Page { get; set; }
    }
}