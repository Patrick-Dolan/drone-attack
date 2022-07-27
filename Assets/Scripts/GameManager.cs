using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public int lives = 3;
    public int score = 0;

    // Prefabs
    public GameObject targetPrefab;
    public GameObject buildingPrefabLeft;
    public GameObject buildingPrefabRight;

    private float targetSpawnRate = 1.0f;
    private float buildingSpawnRate = 14.0f;

    // UI Elements
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverMenu;
    public GameObject startMenu;
    public char[] currentInitials = new char[] {'A', 'A', 'A'};
    public InitalCarousel initialsCarousel;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;

        StartCoroutine(SpawnBuilding());
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(targetSpawnRate);
            if (isGameActive)
            {
                Instantiate(targetPrefab);
            }
        }
    }

    IEnumerator SpawnBuilding()
    {
        while(true)
        {
            yield return new WaitForSeconds(buildingSpawnRate);
            Instantiate(buildingPrefabRight);
            Instantiate(buildingPrefabLeft);
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);

        StartCoroutine(SpawnTarget());
    }

    public void GameOver()
    {
        isGameActive = false;
        DestroyAllTargets();
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        // Reset game menus
        gameOverMenu.SetActive(false);
        startMenu.SetActive(true);

        // Reset lives and score 
        lives = 3;
        score = 0;

        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";

    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = $"Score: {score}";
    }

    public void DestroyAllTargets()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
