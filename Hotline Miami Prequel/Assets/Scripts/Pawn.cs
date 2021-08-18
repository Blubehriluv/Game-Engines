using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour
{
    public Weapon weapon;
    public Weapon rifle;
    public Weapon pistol;
    public Transform attachmentPoint;
    bool isShifting;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        EquipWeapon(rifle);
        //ChangeLayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O)){
            Debug.Log("Pressed O for Roifle");
            HoldRifle();
        }
        else if (Input.GetKey(KeyCode.P)){
            Debug.Log("Pressed P for peestol");
            HoldPeestol();
        }
        else if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U for unequip");
            Unequip();
        }
    }

    public void HoldPeestol()
    {
        anim.SetLayerWeight(1, 1.0f);
        anim.SetLayerWeight(2, 0.0f);

    }

    public void HoldRifle()
    {
        anim.SetLayerWeight(2, 1.0f);
        anim.SetLayerWeight(1, 0.0f);
    }

    public void EquipWeapon(Weapon weapon)
    {
        weapon = Instantiate(weapon) as Weapon;
        weapon.transform.SetParent(gameObject.transform);
        weapon.transform.localPosition = attachmentPoint.transform.localPosition;
        weapon.transform.localRotation = attachmentPoint.transform.localRotation;

    }

    public void Unequip()
    {
        if (weapon)
        {
            DestroyImmediate(weapon, true);
            weapon = null;
        }
    }
}
