using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour
{

    bool isShifting;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
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
}
