﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
    public void Shoot()
    {

    }
    public override void OnTriggerHold()
    {

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
