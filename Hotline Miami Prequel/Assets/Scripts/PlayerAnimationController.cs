using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to control the movements and animations of characters.
/// </summary>

public class PlayerAnimationController : MonoBehaviour
{
    [Tooltip("Pulls animation controller from same game object labelled 'Character'")]
    public Animator anim;

    [Tooltip("The speed can only be as fast as 6.7, the fastest available animation.")]
    public float speed = 5;


    void Start()
    {
        // The animator component is picked up
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();   
    }

    public void MoveCharacter()
    {
        // Detect what direction the stick is being pushed.
        Vector3 stickDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // This ensures the direction cannot surpass 1 with a value clamp/cap.
        stickDirection = Vector3.ClampMagnitude(stickDirection, 1);

        // Even when the character is rotated, North will remain True North.
        // Professor: Inverts so that movement is world direction based, not local to character rotation.
        Vector3 animationDirection = transform.InverseTransformDirection(stickDirection);


        // Pass direct values if threshold is passed for either dash direction.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            /*
            if (animationDirection.z >= 0 && )
            {

            }
            anim.Play("Standing Dodge Backward");*/
        }
        else
        {  
            // Animator is told to use input from the multiple directions (floats).
            anim.SetFloat("Forward", animationDirection.z * speed);
            anim.SetFloat("Right", animationDirection.x * speed);
        }
        

    }
}
