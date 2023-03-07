using BusinessObjects;

namespace Repositories
{
	public interface IFeedbackRepository
	{
		List<Feedback> GetFeedbacks();
		List<Feedback> GetCheckedFeedbacks(int bookId);
		Feedback GetFeedbackById(int id);
		void SaveFeedback(Feedback feedback);
		void UpdateFeedback(Feedback feedback);
		void CheckedFeedback(Feedback feedback);
		void UnCheckedFeedback(Feedback feedback);
		void DeleteFeedback(Feedback feedback);
	}
}
