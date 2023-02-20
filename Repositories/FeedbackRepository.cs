using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class FeedbackRepository : IFeedbackRepository
	{
		public List<Feedback> GetFeedbacks() => FeedbackDAO.GetFeedbacks();
		public List<Feedback> GetCheckedFeedbacks() => FeedbackDAO.GetCheckedFeedbacks();
		public Feedback GetFeedbackById(int id) => FeedbackDAO.FindAuthorById(id);
		public void SaveFeedback(Feedback feedback) => FeedbackDAO.SaveFeedback(feedback);
		public void UpdateFeedback(Feedback feedback) => FeedbackDAO.UpdateFeedback(feedback);
		public void CheckedFeedback(Feedback feedback) => FeedbackDAO.CheckedFeedback(feedback);
		public void UnCheckedFeedback(Feedback feedback) => FeedbackDAO.UnCheckedFeedback(feedback);
		public void DeleteFeedback(Feedback feedback) => FeedbackDAO.DeleteFeedback(feedback);
	}
}
