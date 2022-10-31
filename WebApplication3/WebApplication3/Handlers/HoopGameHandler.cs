using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Handlers
{
    public class HoopGameHandler
    {
        public Player PlayGame(int numberOfPlayers)
        {
            var playerList = GeneratePlayers(numberOfPlayers);

            var index = 0; // who has ball
            while (playerList.Count > 1)
            {
                index = (index + 1) % playerList.Count;
                playerList.RemoveAt(index);
            }
            return playerList.FirstOrDefault(p => p != null);
        }

        private List<Player> GeneratePlayers(int numberOfPlayers)
        {
            List<Player> playerList = new List<Player>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                playerList.Add(new Player { No = i });
            }

            return playerList;
        }
    }
}
