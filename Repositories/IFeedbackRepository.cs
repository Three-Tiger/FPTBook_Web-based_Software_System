using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IFeedbackRepository
	{
		List<Feedback> GetFeedbacks();
		List<Feedback> GetCheckedFeedbacks();
		Feedback GetFeedbackById(int id);
		void SaveFeedback(Feedback feedback);
		void UpdateFeedback(Feedback feedback);
		void CheckedFeedback(Feedback feedback);
		void UnCheckedFeedback(Feedback feedback);
		void DeleteFeedback(Feedback feedback);
	}
}
