using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{
    // Prefabs
    public List<TextMeshProUGUI> leaderboardList = new List<TextMeshProUGUI>();

    // Script References
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLeaderBoard()
    {
        //leaderboardList[0].text = gameManager.leaderboardData[0].Initials;
        for (int i = 0; i < gameManager.leaderboardData.Count; i++)
        {
            leaderboardList[i].text = $"{i + 1}. {gameManager.leaderboardData[i].Initials} scored {gameManager.leaderboardData[i].Score}";
        }
       
    }
}
