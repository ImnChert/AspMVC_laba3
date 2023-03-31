using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Models
{
    internal class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public StatusCodeResult StatusCode { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
