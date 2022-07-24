using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private float targetSpawnRate = .5f;
    private float buildingSpawnRate = 14.0f;

    // UI Elements
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;

        StartCoroutine(SpawnBuilding());
    }

    // Update is called once per frame
    void Update()
    {
        
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

        StartCoroutine(SpawnTarget());
    }

    public void GameOver()
    {
        isGameActive = false;
        DestroyAllTargets();
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
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
