using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaTest : MonoBehaviour
{
    [SerializeField] private float maxStamina = 200;
    [SerializeField] private float staminaUse = 100;
    [SerializeField] private float staminaRechargeRate = 35;
    [SerializeField] private float invulnerabilityTime = 3.0f;
    private bool justUsedStamina = false;

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
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();
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

    void PlayParticles(ParticleSystem part)
    {
        particles.GetComponent<ParticleSystem>();
        part.Play();
    }

    void ReenableMesh()
    {
        circleMesh.SetActive(false);
        skinRender.SetActive(true);
        justUsedStamina = false;
    }

    IEnumerator Wait()
    {
        Debug.Log("Invulnerable.");
        yield return new WaitForSeconds(invulnerabilityTime);
        Debug.Log("Reenable mesh.");
        ReenableMesh();
    }
}
