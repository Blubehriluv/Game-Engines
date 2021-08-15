using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    float currentHealth;
    float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        SetHealth("respawn", maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Manage the health of the player.
    /// </summary>
    /// <param name="occasion"> This is what is happening to the player in health management. </param>
    /// <param name="changeAmount"> This is how much their health should be changing. </param>
    /// <returns> The amount of health to be changed is passed into whatever variable needs it. </returns>
    public float SetHealth(string occasion, float changeAmount)
    {
        if (occasion == "damage")
        {
            Debug.Log("The player is taking " + changeAmount + " points of damage.");
            currentHealth -= changeAmount;
        }
        if (occasion == "respawn")
        {
            Debug.Log("The player is respawning at " + maxHealth + " health.");
            currentHealth = maxHealth;
        }
        if (occasion == "heal")
        {
            Debug.Log("The player is healing for " + changeAmount + " health points.");
            currentHealth += changeAmount;
        }
        return currentHealth;
    }
}
