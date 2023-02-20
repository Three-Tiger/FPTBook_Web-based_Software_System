namespace FPTBookAPI.Services
{
	public interface IBookFileService
	{
		Tuple<int, string> SaveBookImage(IFormFile imageFile);
		string GetImageByBook(string fileName);
		bool DeleteBookImage(string imageFileName);
	}
}
