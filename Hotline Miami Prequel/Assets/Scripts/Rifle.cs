using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rifle : Weapon
{
    public AudioSource sound;
    private Rifle thisRifle;
    private WeaponAnimationType animationType;

    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        animationType = WeaponAnimationType.Rifle;
        thisRifle = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Pawn>().EquipWeapon(thisRifle);
        other.GetComponent<Pawn>().AnimChange(animationType);
        sound.Play();
        StartCoroutine(nameof(Pause));
        
    }

    public void DestroyRifle()
    {
        Destroy(transform.parent.gameObject);
    }

    IEnumerator Pause()
    {
        Debug.Log("Giving time for audio and animation.");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Destroying parent object.");
        DestroyRifle();
    }
}
