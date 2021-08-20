using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public bool isTriggerPulled = false;
    //public Transform rightHandPoint;
    //public Transform leftHandPoint;

    public UnityEvent OnMainActionStart;
    public UnityEvent OnMainActionEnd;
    public UnityEvent OnMainActionHold;

    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isTriggerPulled)
        {
            
        }
    }



    public enum WeaponAnimationType
    {
        None = 0,
        Handgun = 1,
        Rifle = 2
    }

    public abstract void OnTriggerPull();
    public abstract void OnTriggerRelease();
    public abstract void OnTriggerHold();
}
