using Microsoft.AspNetCore.Components.Routing;

namespace RaceDayWeb.Models
{
    public class EventViewModel
    {
        public int EventId { get; set;  }
        public string Name { get; set; } = string.Empty;
        public string? Description {  get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Distance { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public int CreateByUserId { get; set; }
        public string? BannerImageUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new();

    }

    public class CategoryViewModel 
    {
        public int CategoryId{ get; set;  }
        public int EventId { get; set;  }
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; }
        public decimal RegistrationFee { get; set; }
    }
}
