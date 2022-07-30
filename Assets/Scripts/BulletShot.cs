using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{

    private new Transform camera;
    private GameManager gameManager;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int outOfBounds = -60;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Set bullet to aim at player camera 
        camera = Camera.main.transform;
        Quaternion cameraRotation = Quaternion.LookRotation(camera.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, speed);
    }

    // Update is called once per frame
    void Update()
    {
        // Bullet movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if bullet is out of bound and destroy if it is
        if (transform.position.z <= outOfBounds)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Make sure you cant block bullets with gun
        if (collision.gameObject.name != "M1911 Handgun_Black (Shooting)")
        {
            Destroy(gameObject);
        }

        // Handle hit on player
        if (collision.gameObject.CompareTag("Head"))
        {
            Destroy(gameObject);
            gameManager.DecrementLives();
        }
    }
}
