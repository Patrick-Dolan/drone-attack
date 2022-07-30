using Leaderboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Values")]
    public int lives = 3;
    public int score = 0;
    public bool isGameActive;
    public bool hasRun = false;
    public List<LeaderboardEntry> leaderboardData = new List<LeaderboardEntry>();

    [Header("Spawn Rates")]
    [SerializeField] private float targetSpawnRate = 1.0f;
    [SerializeField] private float buildingSpawnRate = 14.0f;

    [Header("Prefab References")]
    public GameObject targetPrefab;
    public GameObject buildingPrefabLeft;
    public GameObject buildingPrefabRight;


    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreToSubmit;
    public TextMeshProUGUI livesText;
    public GameObject gameOverMenu;
    public GameObject startMenu;
    public GameObject leaderboardObject;
    public GameObject initialsCarouselObject;

    [Header("Script References")]
    public InitalCarousel initialsCarousel;
    public LeaderboardDisplay leaderboardDisplay;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;

        audioManager = GameObject.Find("Player").GetComponent<AudioManager>();
        audioManager.PlayMenuMusic();

        StartCoroutine(SpawnBuilding());
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0 && !hasRun)
        {
            hasRun = true;
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

        // Hide menus
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        leaderboardObject.SetActive(false);

        audioManager.PlayGameMusic();

        StartCoroutine(SpawnTarget());
    }

    public void GameOver()
    {
        isGameActive = false;
        DestroyAllTargets();

        gameOverMenu.SetActive(true);
        leaderboardObject.SetActive(true);
        initialsCarouselObject.SetActive(true);

        audioManager.PlayMenuMusic();
    }

    public void RestartGame()
    {
        // Reset game menus
        gameOverMenu.SetActive(false);
        startMenu.SetActive(true);
        leaderboardObject.SetActive(false);
        initialsCarouselObject.SetActive(false);

        // Reset lives and score 
        lives = 3;
        score = 0;
        hasRun = false;

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
        scoreToSubmit.text = $"{score}";
    }

    public void DestroyAllTargets()
    {
        // Destroy Targets then bullets still flying
        GameObject[] drones = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < drones.Length; i++)
        {
            Destroy(drones[i]);
        }

        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("Enemy Bullet");
        for (int i = 0; i < enemyBullets.Length; i++)
        {
            Destroy(enemyBullets[i]);
        }
    }

    public void ToggleLeaderboard()
    {
        if (leaderboardObject.activeSelf == true)
        {
            leaderboardObject.SetActive(false);
        }
        else
        {
            leaderboardObject.SetActive(true);
        }
    }
}
