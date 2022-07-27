using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leaderboard
{
    public class LeaderboardEntry 
    {
        public string Id { get; set; }
        public string Initials { get; set; }
        public int Score { get; set; }

        public LeaderboardEntry(string initials, int score)
        {
            Id = DateTime.Now.ToString();
            Initials = initials;
            Score = score;
        }
    }

}
