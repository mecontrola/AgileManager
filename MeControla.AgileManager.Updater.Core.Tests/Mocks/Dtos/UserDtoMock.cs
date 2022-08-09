using MeControla.AgileManager.Updater.Core.Data.Dtos;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Dtos
{
    public class UserDtoMock
    {
        public static UserDto Create()
            => new()
            {
                Login = "mecontrola",
                Id = 69145974,
                NodeId = "MDQ6VXNlcjY5MTQ1OTc0",
                AvatarUrl = "https://avatars.githubusercontent.com/u/69145974?v=4",
                GravatarId = "",
                Url = "https://api.github.com/users/mecontrola",
                HtmlUrl = "https://github.com/mecontrola",
                FollowersUrl = "https://api.github.com/users/mecontrola/followers",
                FollowingUrl = "https://api.github.com/users/mecontrola/following{/other_user}",
                GistsUrl = "https://api.github.com/users/mecontrola/gists{/gist_id}",
                StarredUrl = "https://api.github.com/users/mecontrola/starred{/owner}{/repo}",
                SubscriptionsUrl = "https://api.github.com/users/mecontrola/subscriptions",
                OrganizationsUrl = "https://api.github.com/users/mecontrola/orgs",
                ReposUrl = "https://api.github.com/users/mecontrola/repos",
                EventsUrl = "https://api.github.com/users/mecontrola/events{/privacy}",
                ReceivedEventsUrl = "https://api.github.com/users/mecontrola/received_events",
                Type = "User",
                SiteAdmin = false
            };
    }
}