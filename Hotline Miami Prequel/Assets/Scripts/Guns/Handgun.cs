using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
    private Handgun thisHandgun;
    private WeaponAnimationType animationType;
    bool isEntered = false;
    bool hasGun = false;

    // Start is called before the first frame update
    void Start()
    {
        animationType = WeaponAnimationType.Handgun;
        thisHandgun = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        hasGun = other.GetComponent<Pawn>().GetGunStatus();
        if (hasGun == true)
        {

        }
        else
        {
            if (isEntered == false)
            {
                isEntered = true;
                other.GetComponent<Pawn>().EquipWeapon(thisHandgun, animationType);
                //other.GetComponent<Pawn>().AnimChange(animationType);
                DestroyHandgun();
            }
        }
    }

    public void DestroyHandgun()
    {
        Destroy(transform.parent.gameObject);
    }


}
