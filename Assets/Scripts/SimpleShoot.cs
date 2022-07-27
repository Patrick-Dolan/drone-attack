using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public ParticleSystem impactParticle;

    [Header("Location References")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    private GameManager gameManager;
    public AudioSource source;
    public AudioClip fireSound;
    private LineRenderer line;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        line = GetComponent<LineRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    public void PullTrigger()
    {
        //Calls animation on the gun that has the relevant animation events that will fire
        gunAnimator.SetTrigger("Fire");
    }


    //This function creates the bullet behavior
    void Shoot()
    {
        //Play Gunshot Sound
        source.PlayOneShot(fireSound);

        //Create the muzzle flash
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        //Destroy the muzzle flash effect
        Destroy(tempFlash, destroyTimer);

        // Send out Raycast from barrel of gun
        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hitInfo, 100);

        // Set line positions and handle showing and turning it off
        line.SetPositions(new Vector3[] { barrelLocation.position, barrelLocation.position + barrelLocation.forward * 100 });
        line.enabled = true;
        StartCoroutine(ShotEffect());

        if (hasHit)
        {
            // Set Target name 
            string targetName = hitInfo.transform.gameObject.tag;
            string menuBlockName = hitInfo.transform.gameObject.name;

            // Create particle effect on hit
            Instantiate(impactParticle, hitInfo.transform.position,hitInfo.transform.rotation);

            // Shot behaviour switch
            switch (targetName)
            {
                case "Target":
                    gameManager.UpdateScore();
                    Destroy(hitInfo.transform.gameObject);
                    break;
                case "Start Button":
                    gameManager.StartGame();
                    break;
                case "Restart Button":
                    gameManager.RestartGame();
                    break;
            }

            switch (menuBlockName)
            {
                case "UpButtonBlock1":
                    gameManager.initialsCarousel.UpdateInitalUp(menuBlockName);
                    break;
                case "DownButtonBlock1":
                    gameManager.initialsCarousel.UpdateInitalDown(menuBlockName);
                    break;
                case "UpButtonBlock2":
                    gameManager.initialsCarousel.UpdateInitalUp(menuBlockName);
                    break;
                case "DownButtonBlock2":
                    gameManager.initialsCarousel.UpdateInitalDown(menuBlockName);
                    break;
                case "UpButtonBlock3":
                    gameManager.initialsCarousel.UpdateInitalUp(menuBlockName);
                    break;
                case "DownButtonBlock3":
                    gameManager.initialsCarousel.UpdateInitalDown(menuBlockName);
                    break;
            }
        }
    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

    private IEnumerator ShotEffect()
    {
        yield return new WaitForSeconds(0.25f);
        line.enabled = false;
    }
}
