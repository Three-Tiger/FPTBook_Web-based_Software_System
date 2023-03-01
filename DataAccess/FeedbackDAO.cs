using BusinessObjects;
using BusinessObjects.Constraints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class FeedbackDAO
	{
		public static List<Feedback> GetFeedbacks()
		{
			var listFeedbacks = new List<Feedback>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listFeedbacks = context.Feedbacks.Include(b => b.Book).Include(b => b.User).Where(x => x.IsDeleted == false).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listFeedbacks;
		}

		public static List<Feedback> GetCheckedFeedbacks(int bookId)
		{
			var listFeedbacks = new List<Feedback>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listFeedbacks = context.Feedbacks
						.Where(x => x.IsDeleted == false && x.FeedStatus == FeedStatus.Checked && x.BookId == bookId)
						.Include(u => u.User)
						.ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listFeedbacks;
		}

		public static Feedback GetFeedbackById(int feedID)
		{
			Feedback feedback = new Feedback();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					feedback = context.Feedbacks.SingleOrDefault(x => x.FeedId == feedID);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return feedback;
		}

		public static void SaveFeedback(Feedback feedback)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					feedback.FeedStatus = FeedStatus.Unchecked;
					context.Feedbacks.Add(feedback);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void CheckedFeedback(Feedback feedback)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var f = context.Feedbacks.SingleOrDefault(c => c.FeedId == feedback.FeedId);
					f.FeedStatus = FeedStatus.Checked;
					context.Entry<Feedback>(f).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void UnCheckedFeedback(Feedback feedback)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var f = context.Feedbacks.SingleOrDefault(c => c.FeedId == feedback.FeedId);
					f.FeedStatus = FeedStatus.Unchecked;
					context.Entry<Feedback>(f).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void UpdateFeedback(Feedback feedback)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<Feedback>(feedback).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void DeleteFeedback(Feedback feedback)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var f = context.Feedbacks.SingleOrDefault(c => c.FeedId == feedback.FeedId);
					//context.Genres.Remove(c);
					f.IsDeleted = true;
					context.Entry<Feedback>(f).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
