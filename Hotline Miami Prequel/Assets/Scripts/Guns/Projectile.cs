using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Projectile : MonoBehaviour
{
    public float Damage;
    public Rigidbody Rigidbody;
    float muzzleVelocity = 25f;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        Rigidbody.AddRelativeForce(Vector3.back * muzzleVelocity, ForceMode.VelocityChange);
        DestroySelf();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void DestroySelf()
    {
        Destroy(gameObject, 2);
    }
}
