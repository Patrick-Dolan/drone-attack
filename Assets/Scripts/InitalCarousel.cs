using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitalCarousel : MonoBehaviour
{
    // Alphabet array
    char[] alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    String[] alphabet2 = new String[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U", "V", "W", "X", "Y", "Z"};

    public TextMeshProUGUI displayInitial;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        UpdateInitalUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInitalUp()
    {
        int index = Array.IndexOf(alphabet2, displayInitial.text);
        Debug.Log(index);
    }
    public void UpdateInitalDown()
    {

    }
}
