using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour
{
    public Weapon weapon;
    public Weapon pistol;
    public Transform attachmentPoint;
    bool isShifting;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        EquipWeapon(weapon);
        ChangeLayer();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeLayer()
    {
        anim.SetLayerWeight(0, 1);
    }

    public void EquipWeapon(Weapon weapon)
    {
        weapon = Instantiate(weapon) as Weapon;
        weapon.transform.SetParent(gameObject.transform);
        weapon.transform.localPosition = attachmentPoint.transform.localPosition;
        weapon.transform.localRotation = attachmentPoint.transform.localRotation;

    }
}
