using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private Transform camera;
    public GameManager gameManager;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        camera = Camera.main.transform;
        Quaternion cameraRotation = Quaternion.LookRotation(camera.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        gameManager.DecrementLives();
    }
}
