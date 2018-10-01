using System;
using System.Threading.Tasks;

namespace assignment5
{
    public class PlayersProcessor
    {
        public IRepository IMR;

        public PlayersProcessor (IRepository ir)
        {
            IMR = ir;
        }
        public Task<Player> GetPlayer (Guid id)
        {
            return IMR.GetPlayer (id);
        }
        public Task<Player> GetPlayer (string name)
        {
            return IMR.GetPlayer (name);
        }
        public Task<Player[]> GetAllPlayers ()
        {
            return IMR.GetAllPlayers ();
        }
        public Task<Player[]> GetAllPlayersWithType (int type)
        {
            return IMR.GetAllPlayersWithType (type);
        }
        public Task<Player[]> GetAllPlayersMinScore (int minScore)
        {
            return IMR.GetAllPlayersMinScore (minScore);
        }
        public Task<AverageInfo> GetAverageLevel(){
            return IMR.GetAverageLevel();
        }
        public Task<Player> CreatePlayer (NewPlayer player)
        {
            Player createePlayer = new Player ();
            createePlayer.Id = Guid.NewGuid ();
            createePlayer.Name = player.Name;
            createePlayer.level = 0;
            createePlayer.Score = 0;
            createePlayer.IsBanned = false;
            createePlayer.CreationTime = DateTime.Now;
            return IMR.CreatePlayer (createePlayer);
        }
        public Task<Player> ModifyPlayer (Guid id, ModifiedPlayer player)
        {
            return IMR.ModifyPlayer (id, player);
        }
        public Task<Player> DeletePlayer (Guid id)
        {
            return IMR.DeletePlayer (id);
        }
    }
}