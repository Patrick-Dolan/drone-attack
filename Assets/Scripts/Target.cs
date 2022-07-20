using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float xRange = 5.0f;
    private float ySpawnPosMax = 5.0f;
    private float ySpawnPosMin = 0.0f;
    private float zSpawnPos = 50.0f;
    private float speed = 10.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), Random.Range(ySpawnPosMin, ySpawnPosMax), zSpawnPos);
    }
}
