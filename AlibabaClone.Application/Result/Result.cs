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

        private Result(ResultStatus status, T? data = default, string? errorMessage = null)
        {
            Status = status;
            Data = data;
            ErrorMessage = errorMessage;
        }
        public static Result<T> Success(T data) =>
        new(ResultStatus.Success, data);
        public static Result<T> Error(string errorMessage) =>
            new(ResultStatus.Error, default, errorMessage);
        public static Result<T> NotFound(string? errorMessage = null) =>
            new(ResultStatus.NotFound, default, errorMessage);
        public static Result<T> Unauthorized(string? errorMessage = null) =>
            new(ResultStatus.Unauthorized, default, errorMessage);
    }
}
