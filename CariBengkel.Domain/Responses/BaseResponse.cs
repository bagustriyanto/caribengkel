using System.Collections.Generic;
using Threenine.Data.Paging;

namespace CariBengkel.Domain.Responses {
    public class BaseResponse<T> where T : class {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public IPaginate<T> ListData { get; set; }
    }
}