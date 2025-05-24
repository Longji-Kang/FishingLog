namespace Fishing_API.Models.ApiModels.ResponseModels {
    public class PageListModel<T>() {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public required ICollection<T> Data { get; set; }
    }
}
