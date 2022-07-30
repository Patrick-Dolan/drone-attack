using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Spawning information")]
    [SerializeField] private float xRange = 8.0f;
    [SerializeField] private float ySpawnPosMax = 8.0f;
    [SerializeField] private float ySpawnPosMin = 1.0f;
    [SerializeField] private float zSpawnPos = 50.0f;

    [Header("Movement Variables")]
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private int droneSightDistance = 20;

    [Header("Shooting Information")]
    [SerializeField] private bool hasShot = false;
    [SerializeField] private float shotDelay = 1.0f;
    [SerializeField] private float stopTime = 0;
    private new Transform camera;

    [Header("Prefab References")]
    public GameObject bulletPrefab;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomSpawnPos();
        shotDelay = Random.Range(0.5f, 2.0f);
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // Behavior change when drone sees player
        if (transform.position.z < droneSightDistance)
        {
            // Start delay for shot and stop movement
            stopTime += Time.deltaTime;
            speed = 5.0f;

            // Aim and Shoot at player
            
            Quaternion cameraRotation = Quaternion.LookRotation(camera.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, speed * Time.deltaTime);

            // Check that drone aim delay has been met
            if (stopTime > shotDelay)
            {
                //Drones get one shot at player
                if (!hasShot)
                {
                    ShootAtPlayer();
                }

                // One second after shot drone should start moving again
                if (stopTime + 1 > shotDelay)
                {
                    speed = 12.0f;
                }

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
