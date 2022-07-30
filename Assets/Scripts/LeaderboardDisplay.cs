using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{
    // Leaderboard list
    public List<TextMeshProUGUI> leaderboardList = new List<TextMeshProUGUI>();

    // Script References
    public GameManager gameManager;

    public void UpdateLeaderBoard()
    {
        gameManager.leaderboardData.Sort((x, y) => y.Score.CompareTo(x.Score));

        // Updates leaderboad canvas
        for (int i = 0; i < gameManager.leaderboardData.Count && i < 5; i++)
        {
            leaderboardList[i].text = $"{i + 1}. {gameManager.leaderboardData[i].Initials}: {gameManager.leaderboardData[i].Score}";
        }
    }
}
