using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject targetPrefab;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        isGameActive = false;

        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(targetPrefab);
        }
    }
}
