namespace Fishing_API.Models.ApiModels.RequestModels {
    public class PageRequestObject {
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int? totalPages { get; set; }
    }
}
