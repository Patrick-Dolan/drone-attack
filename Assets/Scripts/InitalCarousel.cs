using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Leaderboard;

public class InitalCarousel : MonoBehaviour
{
    // Alphabet array
    String[] alphabet = new String[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T","U", "V", "W", "X", "Y", "Z"};

    // Prefabs
    public TextMeshProUGUI displayInitial1;
    public TextMeshProUGUI displayInitial2;
    public TextMeshProUGUI displayInitial3;

    // Script References
    public GameManager gameManager;
    public LeaderboardDisplay leaderboardDisplay;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        leaderboardDisplay = GameObject.Find("Leaderboard").GetComponent<LeaderboardDisplay>();
    }

    public void UpdateInitalUp(String buttonName)
    {
        int index; 
        int newIndex;

        switch (buttonName)
        {
            case "UpButtonBlock1":
                index = Array.IndexOf(alphabet, displayInitial1.text);
                if (index <= 0)
                {
                    newIndex = alphabet.Length - 1;
                    displayInitial1.text = alphabet[newIndex];

                }
                else
                {
                    newIndex = index - 1;
                    displayInitial1.text = alphabet[newIndex];
                }
                break;
            case "UpButtonBlock2":
                index = Array.IndexOf(alphabet, displayInitial2.text);
                if (index <= 0)
                {
                    newIndex = alphabet.Length - 1;
                    displayInitial2.text = alphabet[newIndex];

                }
                else
                {
                    newIndex = index - 1;
                    displayInitial2.text = alphabet[newIndex];
                }
                break;
            case "UpButtonBlock3":
                index = Array.IndexOf(alphabet, displayInitial3.text);
                if (index <= 0)
                {
                    newIndex = alphabet.Length - 1;
                    displayInitial3.text = alphabet[newIndex];

                }
                else
                {
                    newIndex = index - 1;
                    displayInitial3.text = alphabet[newIndex];
                }
                break;
        }
    }
    public void UpdateInitalDown(string buttonName)
    {
        int index;
        int newIndex;

        switch (buttonName)
        {
            case "DownButtonBlock1":
                index = Array.IndexOf(alphabet, displayInitial1.text);
                if (index >= alphabet.Length - 1)
                {
                    newIndex = 0;
                    displayInitial1.text = alphabet[newIndex];

                }
                else
                {
                    newIndex = index + 1;
                    displayInitial1.text = alphabet[newIndex];
                }
                break;
            case "DownButtonBlock2":
                index = Array.IndexOf(alphabet, displayInitial2.text);
                if (index >= alphabet.Length - 1)
                {
                    newIndex = 0;
                    displayInitial2.text = alphabet[newIndex];

                }
                else
                {
                    newIndex = index + 1;
                    displayInitial2.text = alphabet[newIndex];
                }
                break;
            case "DownButtonBlock3":
                index = Array.IndexOf(alphabet, displayInitial3.text);
                if (index >= alphabet.Length - 1)
                {
                    newIndex = 0;
                    displayInitial3.text = alphabet[newIndex];

                }
                else
                {
                    newIndex = index + 1;
                    displayInitial3.text = alphabet[newIndex];
                }
                break;
        }
    }

    public string CreateInitialsString()
    {
        string initials = displayInitial1.text + displayInitial2.text + displayInitial3.text;
        return initials;
    }

    public void AddToLeaderboard()
    {
        string initials = CreateInitialsString();
        gameManager.leaderboardData.Add(new LeaderboardEntry(initials, gameManager.score));
        leaderboardDisplay.UpdateLeaderBoard();
    }
}
