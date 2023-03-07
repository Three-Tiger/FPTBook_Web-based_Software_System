using BusinessObjects;
using DataAccess;

namespace Repositories
{
	public class FeedbackRepository : IFeedbackRepository
	{
		public List<Feedback> GetFeedbacks() => FeedbackDAO.GetFeedbacks();
		public List<Feedback> GetCheckedFeedbacks(int bookId) => FeedbackDAO.GetCheckedFeedbacks(bookId);
		public Feedback GetFeedbackById(int id) => FeedbackDAO.GetFeedbackById(id);
		public void SaveFeedback(Feedback feedback) => FeedbackDAO.SaveFeedback(feedback);
		public void UpdateFeedback(Feedback feedback) => FeedbackDAO.UpdateFeedback(feedback);
		public void CheckedFeedback(Feedback feedback) => FeedbackDAO.CheckedFeedback(feedback);
		public void UnCheckedFeedback(Feedback feedback) => FeedbackDAO.UnCheckedFeedback(feedback);
		public void DeleteFeedback(Feedback feedback) => FeedbackDAO.DeleteFeedback(feedback);
	}
}
