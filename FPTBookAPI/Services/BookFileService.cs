namespace FPTBookAPI.Services
{
	public class BookFileService : IBookFileService
	{
		IWebHostEnvironment environment;

		public BookFileService(IWebHostEnvironment env)
		{
			environment = env;
		}


		public Tuple<int, string> SaveBookImage(IFormFile imageFile)
		{
			try
			{
				var wwwPath = this.environment.WebRootPath;
				var path = Path.Combine(wwwPath, "BookImages");
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}

				// Check the allowed extenstions
				var ext = Path.GetExtension(imageFile.FileName);
				var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
				if (!allowedExtensions.Contains(ext))
				{
					string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
					return new Tuple<int, string>(0, msg);
				}
				string uniqueString = Guid.NewGuid().ToString();
				var newFileName = uniqueString + ext;
				var fileWithPath = Path.Combine(path, newFileName);
				var stream = new FileStream(fileWithPath, FileMode.Create);
				imageFile.CopyTo(stream);
				stream.Close();
				return new Tuple<int, string>(1, newFileName);
			}
			catch (Exception ex)
			{
				return new Tuple<int, string>(0, "Error has occured");
			}
		}

		public string GetImageByBook(string fileName)
		{
            string hostUrl = "https://localhost:7076/";
			string imagePath = "BookImages/" + fileName;
            string imageUrl = hostUrl + imagePath;
            return imagePath;
		}

		public bool DeleteBookImage(string imagePath)
		{
			try
			{
				int index = imagePath.IndexOf("BookImages");
				string imageFileName = imagePath.Substring(index);

				var wwwPath = this.environment.WebRootPath;
				var path = Path.Combine(wwwPath, imageFileName);
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
