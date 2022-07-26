using System;

namespace DomainTestWebApi.Models
{
    public class MainEntity
    {
        public Guid Id { get; set; }
        public string FirstMainProperty { get; set; }
        public string SecondMainProperty { get; set; }
        public int IntMainProperty { get; set; }
      //  public int RelatedIntProperty => (int) (IntMainProperty / 0.5);
        public DateTime DateTimeMainProperty { get; set; }
    }
}