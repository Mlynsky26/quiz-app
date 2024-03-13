namespace BlazorChat
{
    public class UserService
    {
        private Dictionary<string, string> users = new Dictionary<string, string>();
        public void Add(string connectionId, string username)
        {
            if (!users.ContainsValue(username))
            {
                users.Add(connectionId, username);
            }
        }

        public void RemoveByName(string username)
        {
            if (users.ContainsValue(username))
            {
                var item = users.First(user => user.Value == username);
                users.Remove(item.Key);
            }
        }

        public string GetConnectioIdByName(string username)
        {
            if (users.ContainsValue(username))
            {
                var item = users.First(user => user.Value == username);
                return item.Key;
            }
            return "";
        }

        public IEnumerable<(string ConnectionId, string Username)> GetAll()
        {
            return users.Keys.ToList().Select(key => (key, users[key]));
        }
    }
}
