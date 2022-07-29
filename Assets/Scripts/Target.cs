using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float xRange = 8.0f;
    private float ySpawnPosMax = 8.0f;
    private float ySpawnPosMin = 1.0f;
    private float zSpawnPos = 50.0f;
    private float speed = 15.0f;
    private int droneSightDistance = 20;
    private bool hasShot = false;
    private Transform camera;
    public GameObject bulletPrefab;
    public AudioSource source;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomSpawnPos();
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        if (transform.position.z < droneSightDistance)
        {
            speed = 10.0f;
            Quaternion cameraRotation = Quaternion.LookRotation(camera.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, speed * Time.deltaTime);
            if (!hasShot)
            {
                ShootAtPlayer();
            }
        }
        HandleWhenOutOfBounds();
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), Random.Range(ySpawnPosMin, ySpawnPosMax), zSpawnPos);
    }

    public void HandleWhenOutOfBounds()
    {
        if(gameObject.transform.position.z < -60)
        {
            Destroy(gameObject);
        }
    }
    
    void ShootAtPlayer()
    {
        hasShot = true;
        source.PlayOneShot(shootSound);
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
