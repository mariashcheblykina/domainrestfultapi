using System;

namespace DomainTestWebApi.Models
{
    public class RelatedEntity
    {
        public Guid Id { get; set; }
        public string FirstRelatedProperty { get; set; }
        public string SecondRelatedProperty { get; set; }
    }
}