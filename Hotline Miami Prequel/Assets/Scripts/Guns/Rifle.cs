using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    private Rifle thisRifle;
    private WeaponAnimationType animationType;
    bool isEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        animationType = WeaponAnimationType.Rifle;
        thisRifle = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isEntered == false)
        {
            isEntered = true;
            //other.GetComponent<Pawn>().AnimChange(animationType);
            other.GetComponent<Pawn>().EquipWeapon(thisRifle, animationType);
            DestroyRifle();
        }
    }

    public void DestroyRifle()
    {
        Destroy(transform.parent.gameObject);
    }
}
