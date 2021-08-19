using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public Weapon weapon;
    public Transform rifleAttachmentPoint;
    public Transform handGunAttachmentPoint;
    public AudioSource[] sounds;
    public GameObject soundsHolder;
    public AudioSource unequipSound;
    public AudioSource equipSound;
    private bool hasGun;
    Animator anim;

    void Start()
    {
        sounds = soundsHolder.GetComponents<AudioSource>();
        anim = GetComponent<Animator>();
        //Transform tf = new Transform()
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weapon != null)
            {
                AnimChange(Weapon.WeaponAnimationType.None);
            }
            else
            {

            }
        }
    }

    public bool GetGunStatus()
    {
        return hasGun;
    }

    public void AnimChange(Weapon.WeaponAnimationType WeaponType)
    {
        unequipSound = sounds[0];
        equipSound = sounds[1];
        if (WeaponType == Weapon.WeaponAnimationType.None)
        {
            Unequip();
            anim.SetLayerWeight(1, 0.0f);
            anim.SetLayerWeight(2, 0.0f);
            unequipSound.Play();
            hasGun = false;
        }
        else if (WeaponType == Weapon.WeaponAnimationType.Handgun)
        {
            anim.SetLayerWeight(1, 1.0f);
            anim.SetLayerWeight(2, 0.0f);
            equipSound.Play();
            hasGun = true;
        }
        else if (WeaponType == Weapon.WeaponAnimationType.Rifle)
        {
            anim.SetLayerWeight(2, 1.0f);
            anim.SetLayerWeight(1, 0.0f);
            equipSound.Play();
            hasGun = true;
        }
    }

    public void EquipWeapon(Weapon weapon, Weapon.WeaponAnimationType weaponTypeHolder)
    {
        weapon.gameObject.layer = gameObject.layer;
        weapon = Instantiate(weapon);        
        weapon.transform.SetParent(gameObject.transform);
        if (weaponTypeHolder == Weapon.WeaponAnimationType.Rifle)
        {
            weapon.transform.localPosition = rifleAttachmentPoint.transform.localPosition;
            weapon.transform.localRotation = rifleAttachmentPoint.transform.localRotation;
        }
        else if (weaponTypeHolder == Weapon.WeaponAnimationType.Handgun)
        {
            weapon.transform.localPosition = handGunAttachmentPoint.transform.localPosition;
            weapon.transform.localRotation = handGunAttachmentPoint.transform.localRotation;
        }
        this.weapon = weapon;
        AnimChange(weaponTypeHolder);
    }

    public void Unequip()
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
    }
}
