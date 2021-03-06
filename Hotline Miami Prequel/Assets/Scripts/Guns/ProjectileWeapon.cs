using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] Pawn_al player;
    bool triggerPulled;
    public Projectile projectilePrefab;
    public GameObject place;
    [SerializeField] private Transform placeToSpawn;
    public Transform barrel;
    private float Damage;
    private bool hasGun = false;
    [SerializeField] private float timeNextShotIsReady;
    [SerializeField] private float shotsPerMinute;

    private void Awake()
    {
        timeNextShotIsReady = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        barrel = gameObject.GetComponent<Transform>();
        placeToSpawn = place.GetComponent<Transform>();
        projectilePrefab.gameObject.layer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        hasGun = player.HasAGgun();
        if (hasGun)
        {
            if (Time.time > timeNextShotIsReady)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("FIRE");  
                    Projectile projectile = Instantiate(projectilePrefab, placeToSpawn.position, barrel.rotation) as Projectile;
                    projectile.Damage = Damage;
                    timeNextShotIsReady += 60f / shotsPerMinute;
                }
            }
            else if (Time.time > timeNextShotIsReady)
            {
                timeNextShotIsReady = Time.time;
            }  
        }
        else if (!hasGun)
        {
            Debug.Log("Does not have a gun.");
        }
        
    }

    void GoodForBot()
    {
        if (hasGun)
        {
            string textForMe = "";
            if (textForMe == "Has player in sights")
            {
                if (Time.time > timeNextShotIsReady)
                {
                    Debug.Log("FIRE");
                    Projectile projectile = Instantiate(projectilePrefab, placeToSpawn.position, barrel.rotation) as Projectile;
                    projectile.Damage = Damage;
                    timeNextShotIsReady += 60f / shotsPerMinute;
                }
                else if (Time.time > timeNextShotIsReady)
                {
                    timeNextShotIsReady = Time.time;
                }
            }
        }
    }
}
