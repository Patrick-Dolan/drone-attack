using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
    [SerializeField] float speed = 3;
    private Vector3 startPosLeft = new Vector3(-18, 0, 120);
    private Vector3 startPosRight = new Vector3(18, 0, 120);
    private Vector3 rotation = new Vector3(0, 90, 0);
    private float buildingBoundary = -150.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Generated Building Left"))
        {
            transform.position = startPosLeft;
            transform.Rotate(rotation);
        }
        
        if (gameObject.CompareTag("Generated Building Right"))
        {
            transform.position = startPosRight;
            transform.Rotate(rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.z <= buildingBoundary)
        {
            Destroy(gameObject);
        }
    }
}
