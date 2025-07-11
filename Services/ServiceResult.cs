﻿using System.Net;
using System.Text.Json.Serialization;

namespace App.Services
{
    //Servis katmanında yapılan işlemin sonucunu (başarılı mı, başarısız mı, hata mesajı ne, HTTP durumu ne, veri dönecek mi?)
    //tek bir yapı içinde ifade etmeyi sağlar.


    //Veri dönen işlemler için
    public class ServiceResult<T>
    {
        public T? Data { get; set;  }
        public List<string>? ErrorMessage { get; set; }
        [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;

        //static factory method
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        [JsonIgnore] public string? UrlAsCreated { get; set; }

        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = status
            };
        }

        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = HttpStatusCode.Created,
                UrlAsCreated = urlAsCreated 
            };
        }
        public static ServiceResult<T> Fail(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = errorMessage,
                Status = status
            };
        }
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = [errorMessage],
                Status = status
            };
        }
    }


    //Veri dönmeyen işlemler için (örneğin Update, Delete)
    public class ServiceResult
    {
        public List<string>? ErrorMessage { get; set; }

        [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;

        [JsonIgnore] public bool IsFail => !IsSuccess;

        //static factory method

        [JsonIgnore] public HttpStatusCode Status { get; set; }
        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = status
            };
        }
        public static ServiceResult Fail(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = errorMessage,
                Status = status
            };
        }
        public static ServiceResult Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = [errorMessage],
                Status = status
            };
        }
    }
}
