using AlibabaClone.Application.DTOs.Transportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Application.Result
{
    public class Result<T>
    {
        public ResultStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }
        public bool IsSuccess => Status == ResultStatus.Success;

        public static Result<T> Success(T data) => new() { Status = ResultStatus.Success, Data = data };
        public static Result<T> Error(T data, string errorMessage) => new() { Status = ResultStatus.Error, Data = data, ErrorMessage = errorMessage };
        public static Result<T> NotFound(T data) => new() { Status = ResultStatus.NotFound, Data = data };
        public static Result<T> Unauthorized(T data) => new() { Status = ResultStatus.Unauthorized, Data = data };
    }
}
