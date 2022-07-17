using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfSight : MonoBehaviour
{

    [SerializeField] float maxDistance = 100f;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(startingPosition, transform.position);
        if (currentDistance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
