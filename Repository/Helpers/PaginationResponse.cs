namespace Repository.Helpers
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> Datas { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }

        public PaginationResponse(IEnumerable<T> datas, int totolapage , int currentpage)
        {
            Datas = datas;
            TotalPage = totolapage;
            CurrentPage = currentpage;
            
        }
    }
}
