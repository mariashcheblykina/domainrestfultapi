using System;
using DomainTestWebApi.Models;

namespace DomainTestWebApi.Services.Response
{
    public class MainEntityResponse : BaseResponse
    {
        public MainEntity MainEntity { get; set; }
        
        private MainEntityResponse(bool success, string message, MainEntity mainEntity) : base(success, message)
        {
            MainEntity = mainEntity;
        }

        public MainEntityResponse(MainEntity mainEntity) : this (true, String.Empty, mainEntity)
        { }
        
        public MainEntityResponse(string message) : this (false, message, null)
        { }
    }
}