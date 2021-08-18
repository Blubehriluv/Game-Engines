using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private WeaponAnimationType animationType = WeaponAnimationType.None;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum WeaponAnimationType
    {
        None = 0,
        Rifle = 1,
        Handgun = 2
    }
}
