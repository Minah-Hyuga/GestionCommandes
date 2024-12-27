using System;

namespace GestionCommandes.Services.Implementations
{
    public class ServiceResult<T>
    {
        public T Data { get; internal set; }
        public bool Success { get; internal set; }
        public string Message { get; internal set; }

        public static ServiceResult<T> Error(string message)
        {
            return new ServiceResult<T> { Success = false, Message = message };
        }

        public static ServiceResult<T> Success(T data, string message)
        {
            return new ServiceResult<T> { Success = true, Data = data, Message = message };
        }
    }
}
