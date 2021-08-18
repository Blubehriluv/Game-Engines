using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HealItem : ItemPickup
{
    public AudioSource sound;
    public Animator anim;
    private float PauseTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("attempted heal");
        if (other.gameObject.GetComponent<Health>() != null){
            other.gameObject.GetComponent<Health>().SetHealth("heal", 20);

            sound.Play();
            anim.SetBool("Used", true);
            StartCoroutine(nameof(Pause));
        }
        else
        {
            Debug.Log("What the heck just tried to heal?");
        }
    }

    IEnumerator Pause()
    {
        Debug.Log("Giving time for audio and animation.");
        yield return new WaitForSeconds(PauseTime);
        Debug.Log("Destroying parent object.");
        Destroy(transform.parent.gameObject);
    }
}
