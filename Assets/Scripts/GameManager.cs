using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject targetPrefab;
    public GameObject buildingPrefabLeft;
    public GameObject buildingPrefabRight;
    private float targetSpawnRate = 1.0f;
    private float buildingSpawnRate = 14.0f;

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
            Instantiate(targetPrefab);
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
}
