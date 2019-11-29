using System.Collections.Generic;
using System.Linq;
using Threenine.Data.Paging;

namespace CariBengkel.Domain.Responses {
    public class BaseResponse<T> where T : class {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public T Data { get; set; }
        public IPaginate<T> ListData { get; set; }
    }
}