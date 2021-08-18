using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaTest : MonoBehaviour
{
    [Header("Stamina Variables")]
    [SerializeField, Tooltip("The maximum amount of stamina possible to have.")] float maxStamina = 200;
    [SerializeField, Tooltip("The amount of stamina to be consumed when used.")] float staminaUse = 100;
    [SerializeField, Tooltip("The amount of stamina that recharges incrimentally over time.")] float staminaRechargeRate = 35;
    [SerializeField, Tooltip("The amount of time the player is invulnerable.")] float invulnerabilityTime = 3.0f;
    bool justUsedStamina = false;

    [Header("Object Holders")]
    public GameObject skinRender;
    public GameObject circleMesh;
    public GameObject particles;

    // Bars for the stamina
    public Slider leftFillBar;
    public Slider rightFillBar;

    void Start()
    {
        // Fill bars are set to contain the maximum stamina amount
        leftFillBar.maxValue = maxStamina;
        leftFillBar.value = maxStamina;
        rightFillBar.maxValue = maxStamina;
        rightFillBar.value = maxStamina;

        // Grabs the MeshRenderer component from the player
        skinRender.GetComponent<MeshRenderer>();
        circleMesh.GetComponent<MeshRenderer>();
        circleMesh.SetActive(false);
    }

    void Update()
    {
        // If the fill bars aren't full, allow them to recharge.
        if (rightFillBar.value != rightFillBar.maxValue && leftFillBar.value != leftFillBar.maxValue)
        {
            leftFillBar.value += staminaRechargeRate * Time.deltaTime;
            rightFillBar.value += staminaRechargeRate * Time.deltaTime;
        }
        // If the player is pressing Shift, remove some stamina
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UseStamina(staminaUse);
        }
    }

    // This removes the stamina from the fill bars
    void UseStamina(float useThisMuch)
    {
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();
        if (justUsedStamina)
        {
            //TODO: Add sound.
            Debug.Log("Maybe play a sound here or something.");
        }
        else if (!justUsedStamina)
        {
            if (leftFillBar.value > staminaUse)
            {
                leftFillBar.value -= staminaUse;
                rightFillBar.value -= staminaUse;
                skinRender.SetActive(false);
                circleMesh.SetActive(true);
                justUsedStamina = true;
                ps.Play();
                StartCoroutine(nameof(Wait));
            }
            else if (leftFillBar.value < staminaUse)
            {
                Debug.Log("You can't use this yet.");
            }
        }
    }

    // Grabs Particle System and plays the animation when called.
    void PlayParticles(ParticleSystem part)
    {
        // TODO: Make the animation length match the invulnerability time.
        particles.GetComponent<ParticleSystem>();
        part.Play();
    }

    // This reenables the normal mesh and gets rid of the circle mesh.
    void ReenableMesh()
    {
        circleMesh.SetActive(false);
        skinRender.SetActive(true);
        justUsedStamina = false;
    }

    // IEnumerator to make the game wait before changing meshes.
    IEnumerator Wait()
    {
        Debug.Log("Invulnerable.");
        yield return new WaitForSeconds(invulnerabilityTime);
        Debug.Log("Reenable mesh.");
        ReenableMesh();
    }
}
