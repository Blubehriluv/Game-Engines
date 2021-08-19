using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    bool triggerPulled;
    public Projectile projectilePrefab;
    private Transform barrel;
    private float Damage;
    private float muzzleVelocity = 200;

    // Start is called before the first frame update
    void Start()
    {
        barrel = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("FIRE");
            Projectile projectile = Instantiate(projectilePrefab) as Projectile;
            projectile.Damage = Damage;
            projectile.rb.AddRelativeForce(Vector3.forward * muzzleVelocity, ForceMode.VelocityChange);

        }
    }
}
