using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField, Tooltip("")] float maxHealth;
    [SerializeField, Tooltip("")] float healthHeal;
    [SerializeField, Tooltip("")] float healRate;
    [SerializeField, Tooltip("")] float currentHealth;

    [SerializeField, Tooltip("")] float bossBulletDamage;
    [SerializeField, Tooltip("")] float enemyBulletDamage;
    [SerializeField, Tooltip("")] float generalDamage;

    public UnityEvent OnDie;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Removing health");
            TakeDamage("just me");
        }
    }

    public void TakeDamage(string damageType)
    {
        if (damageType == "bossBullet")
        {
            Debug.Log("Damage source: Boss");
            SetHealth("damage", bossBulletDamage);
        }
        else if (damageType == "enemyBullet")
        {
            Debug.Log("Damage source: Enemy");
            SetHealth("damage", enemyBulletDamage);
        }
        else
        {
            Debug.Log("Damage source: General");
            SetHealth("damage", generalDamage);
        }
    }

    public void Heal()
    {
        SetHealth("heal", healthHeal);
    }

    public void Die()
    {
        Destroy(this.gameObject);
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
            float damageThreshold = currentHealth - changeAmount;
            if (damageThreshold <= 0)
            {
                Debug.Log("The player is dead.");
                currentHealth = 0;
                OnDie.Invoke(); 
                Die();
            }
            else
            {
                Debug.Log("The player is taking " + changeAmount + " points of damage.");
                currentHealth -= changeAmount;
            }
        }
        if (occasion == "respawn")
        {
            Debug.Log("The player is respawning at " + maxHealth + " health.");
            currentHealth = maxHealth;
        }
        if (occasion == "heal")
        {
            float healthThreshold = currentHealth + changeAmount;
            if (healthThreshold > maxHealth)
            {
                Debug.Log("The player has healed to max health.");
                currentHealth = maxHealth;
            }
            else
            {
                Debug.Log("The player is healing for " + changeAmount + " health points.");
                currentHealth += changeAmount;
            }
        }
        return currentHealth;
    }
}
