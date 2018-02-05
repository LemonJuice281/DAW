using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repository
{
    public class BDRepo : IRepository
    {
        private ApplicationDBContext dbc = new ApplicationDBContext();

        public User GetUser(string userName, string password)
        {
            var user = dbc.Users.Where(x => x.UserName == userName && x.Password == password).ToList<User>().FirstOrDefault();
            if (user == null)
                return null;

            return user;
        }

        public Team GetTeam(string teamName)
        {
            var team = dbc.Teams.Where(x => x.TeamName == teamName).FirstOrDefault();
            if (team == null)
                return null;

            return team;
        }

        public Player GetPlayer(string playerName)
        {
            var player = dbc.Players.Where(x => x.PlayerName == playerName).FirstOrDefault();
            if (player == null)
                return null;

            return player;
        }

        public List<Player> GetPlayersbyTeam(string teamName)
        {
            var players = dbc.Players.Where(x => x.PlayerTeam == teamName).ToList<Player>();

            if (players == null)
                return null;

            return players;
        }

        public T PostObject<T>(T item) where T : class
        {
            try
            {
                dbc.Add<T>(item);

                dbc.SaveChanges();
            }
            catch
            {
                return null;
            }

            return item;
        }

        public T PutObject<T>(T item) where T : class
        {
            try
            {
                dbc.Update<T>(item);

                dbc.SaveChanges();
            }
            catch
            {
                return null;
            }

            return item;
        }

        public T DeleteObject<T>(T item) where T : class
        {
            try
            {
                dbc.Remove<T>(item);

                dbc.SaveChanges();
            }
            catch
            {
                return null;
            }

            return item;
        }

        public List<T> GetObjects<T>() where T : class
        {
            var list = dbc.Set<T>().ToList<T>();

            return list;
        }
    }
}
