using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public Weapon weapon;
    public Transform attachmentPoint;
    public AudioSource unequipSound;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AnimChange(Weapon.WeaponAnimationType.None);
        }
    }

    public void AnimChange(Weapon.WeaponAnimationType WeaponType)
    {
        unequipSound.GetComponent<AudioSource>();
        if (WeaponType == Weapon.WeaponAnimationType.None)
        {
            Unequip();
            anim.SetLayerWeight(1, 0.0f);
            anim.SetLayerWeight(2, 0.0f);
            unequipSound.Play();
        }
        else if (WeaponType == Weapon.WeaponAnimationType.Handgun)
        {
            anim.SetLayerWeight(1, 1.0f);
            anim.SetLayerWeight(2, 0.0f);
        }
        else if (WeaponType == Weapon.WeaponAnimationType.Rifle)
        {
            anim.SetLayerWeight(2, 1.0f);
            anim.SetLayerWeight(1, 0.0f);
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        weapon = Instantiate(weapon);        
        weapon.transform.SetParent(gameObject.transform);
        weapon.transform.localPosition = attachmentPoint.transform.localPosition;
        weapon.transform.localRotation = attachmentPoint.transform.localRotation;
        this.weapon = weapon;
        
    }

    public void Unequip()
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
    }
}
