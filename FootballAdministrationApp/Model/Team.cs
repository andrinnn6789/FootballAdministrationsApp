using System.Collections.ObjectModel;
using System.Linq;

namespace FootballAdministrationApp.Model
{
    public class Team
    {
        private static int currentId;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public bool isEditable { get; set; }

        private readonly ObservableCollection<Player> _players = new ObservableCollection<Player>(); 

        public Team()
        {
            Name = "Hobby Ginger";
            Country = "Germany";
            Id = currentId;
            currentId++;
        }

        public Team(string name,string country)
        {
            Name = name;
            Country = country;
            Id = currentId;
            currentId++;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            player.Team = this;
            player.Fk_TeamId = this.Id;
        }

        public ObservableCollection<Player> GetPlayers()
        {
            return _players;
        }

        public Player GetOnePlayerById(int idToSearch)
        {
            return _players.FirstOrDefault(p => p.Id == idToSearch);
        }

        public void RemoveOnePlayerById(int idToSearch)
        {
            var player = _players.FirstOrDefault(p => p.Id == idToSearch);
            _players.Remove(player);
            if (player != null)
            {
                player.Team = null;
                player.Fk_TeamId = 0;
            }
        }
    }
}
