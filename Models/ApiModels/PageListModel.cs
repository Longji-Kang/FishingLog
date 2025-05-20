namespace Fishing_API.Models.ApiModels {
    public class PageListModel<T>(int currPage, int totalPages, ICollection<T> data) {
        public int CurrentPage { get; set; } = currPage;
        public int TotalPages { get; set; } = totalPages;
        public ICollection<T> Data { get; set; } = data;
    }
}
