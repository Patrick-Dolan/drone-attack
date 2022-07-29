using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(particleSystem.duration);
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {

    }

}
