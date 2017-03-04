namespace PizzaForum.Service
{
    using System.Collections.Generic;
    using PizzaForum.ViewModels;
    using System.Linq;

    public class HomeService : Service
    {
        public IEnumerable<TopicViewModel> GetTopTenLatestTopics()
        {
            IEnumerable<TopicViewModel> topics =
                Context.Topics.OrderByDescending(model => model.PublishDate).Take(10).Select(vm => new TopicViewModel()
                {
                    CategoryName = vm.Category.Name,
                    AuthorName = vm.Author.Username,
                    Date = vm.PublishDate,
                    RepliesCount = vm.Replies.Count,
                    TopicTitle = vm.Title
                });

            return topics;
        }
    }
}
