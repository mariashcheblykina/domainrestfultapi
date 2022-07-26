using System;

namespace DomainTestWebApi.Resources
{
    public class MainEntityResource
    {
        public Guid Id { get; set; }
        public string FirstMainProperty { get; set; }
        public string SecondMainProperty { get; set; }
        public int IntMainProperty { get; set; }
        public DateTime DateTimeMainProperty { get; set; }
    }
}