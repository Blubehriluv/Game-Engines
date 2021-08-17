using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour
{
    public Weapon weapon;
    public Transform attachmentPoint;
    bool isShifting;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        EquipWeapon(weapon);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("isShifting", true);

        }
        else 
        {
            anim.SetBool("isShifting", false);

        }*/
    }

    public void EquipWeapon(Weapon weapon)
    {
        weapon = Instantiate(weapon) as Weapon;
        weapon.transform.SetParent(gameObject.transform);
        weapon.transform.localPosition = attachmentPoint.transform.localPosition;
        weapon.transform.localRotation = attachmentPoint.transform.localRotation;

    }
}
