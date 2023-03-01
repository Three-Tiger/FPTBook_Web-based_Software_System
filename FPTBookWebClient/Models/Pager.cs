namespace FPTBookWebClient.Models
{
	public class Pager
	{
		public int TotalBooks { get; private set; }
		public int CurrentPage { get; private set; }
		public int PageSize { get; private set; }

		public int TotalPage { get; private set; }
		public int StartPage { get; private set; }
		public int EndPage { get; private set; }

		public Pager()
		{

		}

		public Pager(int totalBooks, int page, int pageSize = 10)
		{
			int totalPages = (int)Math.Ceiling((decimal)totalBooks / (decimal)pageSize);
			int currentPage = page;

			int startPage = currentPage - 5;
			int endPage = currentPage + 4;

			if (startPage <=0)
			{
				endPage = endPage - (startPage - 1);
				startPage = 1;
			}

			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			TotalBooks = totalBooks;
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalPage = totalPages;
			StartPage = startPage;
			EndPage = endPage;
		}
	}
}
