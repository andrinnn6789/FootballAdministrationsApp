using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace FootballAdministrationApp.Model
{
    public class Team
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        private readonly List<Player> _players = new List<Player>(); 

        public Team()
        {
            Name = "Hobby Ginger";
            Country = "Germany";
        }

        public Team(string name,string country)
        {
            Name = name;
            Country = country;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            player.Team = this;
            player.Fk_TeamId = this.Id;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _players;
        }

        public Player GetOnePlayerById(int idToSearch)
        {
            return _players.FirstOrDefault(p => p.Id == idToSearch);
        }

        public void DeleteOnePlayerById(int idToSearch)
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
