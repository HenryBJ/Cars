using System.Collections.Generic;

namespace Cars.Models
{
    public class PageModel
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public ICollection<OwnerModel> Data { get; set; }
    }
}