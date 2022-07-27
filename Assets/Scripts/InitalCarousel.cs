using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitalCarousel : MonoBehaviour
{
    // Alphabet array
    String[] alphabet = new String[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T","U", "V", "W", "X", "Y", "Z"};

    // Prefabs
    public GameManager gameManager;
    public TextMeshProUGUI displayInitial1;
    public TextMeshProUGUI displayInitial2;
    public TextMeshProUGUI displayInitial3;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        UpdateInitalUp("UpButtonBlock1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInitalUp(String buttonName)
    {
        int index = Array.IndexOf(alphabet, displayInitial1.text);
        int newIndex;

        switch (buttonName)
        {
            case "UpButtonBlock1":
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

            
        }
    }
    public void UpdateInitalDown(string buttonName)
    {
        int index = Array.IndexOf(alphabet, displayInitial1.text);
        int newIndex;

        switch (buttonName)
        {
            case "DownButtonBlock1":
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
        }
    }
}
