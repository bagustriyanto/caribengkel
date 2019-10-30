using System.Collections.Generic;

namespace CariBengkel.Domain.Responses {
    public class BaseResponse<T> where T : class {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> ListData { get; set; }
    }
}