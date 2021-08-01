using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaTest : MonoBehaviour
{
    public Slider fillBar;
    public Slider fillBar2;
    public float stam;
    private float staminaUse = 15;

    // Start is called before the first frame update
    void Start()
    {
        stam = 200;
        fillBar.maxValue = stam;
        fillBar.value = stam;

        fillBar2.maxValue = stam;
        fillBar2.value = stam;
    }

    // Update is called once per frame
    void Update()
    {
        if (fillBar2.value != fillBar2.maxValue && fillBar.value != fillBar.maxValue)
        {
            fillBar.value += 15 * Time.deltaTime;
            fillBar2.value += 15 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fillBar.value -= 30;
            fillBar2.value -= 30;
        }
        
        

    }


    void UseStamina()
    {
        stam -= staminaUse;
        //fillBar.value
    }
}
