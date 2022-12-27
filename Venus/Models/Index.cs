
using Venus.Models;

namespace Venus.Models
{
    public class PaginationModel
    {
        public int PageSize = 0;
        public int TotalCount = 0;
        public int CurrentPage = 1;
        public int StartPage = 0;
        public int EndPage = 0;
        public int PrevPage = 0;
        public int NextPage = 0;
        public int MaxPage = 0;
        public int Offset = 0;

        public PaginationModel()
        {
        }

        public PaginationModel(int totalCount, int currentPage = 1, int pageSize = 8)
        {
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.MaxPage = totalCount / pageSize;
            if (totalCount % pageSize != 0)
            {
                this.MaxPage += 1;
            }
            if (currentPage > this.MaxPage)
            {
                currentPage = this.MaxPage;
            }
            this.CurrentPage = currentPage;
            this.StartPage = currentPage - 5;
            this.EndPage = currentPage + 5;
            if (this.StartPage < 1)
            {
                this.StartPage = 1;
            }
            if (this.EndPage > this.MaxPage)
            {
                this.EndPage = this.MaxPage;
            }
            this.PrevPage = currentPage - 1;
            this.NextPage = currentPage + 1;

            this.Offset = (currentPage - 1) * pageSize;
            if (this.Offset < 0)
            {
                this.Offset = 0;
            }
        }
    }

    public class IndexViewModel
    {
        public List<PictureModel> Range = new List<PictureModel>();

        public Dictionary<int, List<PictureModel>> Grid = new Dictionary<int, List<PictureModel>>();
        public PaginationModel Pagination = new PaginationModel();

        public IndexViewModel(List<PictureModel> range, PaginationModel pagination)
        {
            this.Range = range;
            this.Pagination = pagination;

            for (var index = 0; index < range.Count; index++)
            {
                var col = index % 6;
                var m = range[index];
                if (this.Grid.ContainsKey(col))
                {
                    this.Grid[col].Add(m);
                }
                else
                {
                    this.Grid[col] = new List<PictureModel>() { m };
                }
            }
        }
    }
}