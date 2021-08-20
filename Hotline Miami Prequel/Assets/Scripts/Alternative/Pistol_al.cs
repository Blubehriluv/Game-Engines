using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_al : Weapon
{
    public void Shoot()
    {
        // TODO: Shoot one bullet
        // specific shoot sound
    }
    public override void OnTriggerHold()
    {

    }

    public void Reload()
    {
        // TODO: Reload the gun for ammo cache.
    }

    public override void OnTriggerPull()
    {
        isTriggerPulled = true;
    }

    public override void OnTriggerRelease()
    {
        isTriggerPulled = false;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }


}
