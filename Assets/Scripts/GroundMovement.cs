using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private Vector3 loopStartPoint = new Vector3(0, 0, -24);
    private int loopEndPoint = -72;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= loopEndPoint)
        {
            transform.position = loopStartPoint;
        }
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
