using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This manages the Pawn's behavior when moving around ingame, setting the camera, and interacting with weapons.
/// </summary>
public class Pawn_al : MonoBehaviour
{
    [Header("General Parameters")]
    [SerializeField, Tooltip("The animator located on the 'Player' for altering layer weight/visibilty")] Animator anim;
    [SerializeField, Tooltip("Grabs the in scene Main Camera")] Camera playerCamera;
    [SerializeField, Tooltip("Controls how quickly the Pawn can spin around to keep up with the mouse cursor.")] float turnSpeed = 180;
    [SerializeField, Tooltip("How far away the camera is from the Pawn")] float distance;

    [Header("Weapon Reference Variables")]
    [SerializeField, Tooltip("For controlling the Rifle gun.")] Rifle_al rifleHolder;
    [SerializeField, Tooltip("For controlling the Pistol gun.")] Pistol_al pistolHolder;
    [SerializeField, Tooltip("For manipulating whatever weapon the Pawn is holding.")] Weapon heldWeapon;
    [SerializeField, Tooltip("Helps to pass information about the Pawn currently having a weapon.")] bool hasAWeapon;

    [Header("Audio Parameters")]
    [SerializeField, Tooltip("Initial hold for manipulating the Audio Sources.")] GameObject soundsHolder;
    [SerializeField, Tooltip("The held AudioSources are placed into this array.")] AudioSource[] sounds;
    [SerializeField, Tooltip("The sound to play when dropping a gun.")] AudioSource unequipSound;
    [SerializeField, Tooltip("The sound to play when equipping a gun.")] AudioSource equipSound;


    void Start()
    {
        anim = GetComponent<Animator>();                        // Grabs the animator
        hasAWeapon = false;                                     // Begins the player with no weapon
        sounds = soundsHolder.GetComponents<AudioSource>();     // Sends available sounds to array
        unequipSound = sounds[0];
        equipSound = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        // Detect what direction the stick is being pushed.
        Vector3 stickDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // This ensures the direction cannot surpass 1 with a value clamp/cap.
        stickDirection = Vector3.ClampMagnitude(stickDirection, 1);

        // Even when the character is rotated, North will remain True North.
        // Professor: Inverts so that movement is world direction based, not local to character rotation.
        Vector3 animationDirection = transform.InverseTransformDirection(stickDirection);

        RotateToMousePointer();

        // For handling trigger events
        if (Input.GetButtonDown("Fire1"))
        {
            heldWeapon.OnTriggerPull();
            heldWeapon.OnMainActionStart.Invoke();
            // Add the shoot function
        }
        if (Input.GetButtonUp("Fire1"))
        {
            heldWeapon.OnTriggerRelease();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            // weapon.AltFirePull();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            DropWeapon();
        }
    }

    /// <summary>
    /// Use this getter in other scripts to signify when a weapon is being held already.
    /// This can prevent taking too many guns or activating sounds prematurely.
    /// </summary>
    /// <returns>Will return whether or not the player has a gun on them.</returns>
    public bool HasAGgun()
    {
        return hasAWeapon;
    }

    /// <summary>
    /// Set the rifle animation and equip the weapon.
    /// </summary>
    public void SetRifle()
    {
        anim.SetLayerWeight(2, 1.0f);
        anim.SetLayerWeight(1, 0.0f);
        EquipWeapon(Weapon.WeaponAnimationType.Rifle);
    }

    /// <summary>
    /// Set the pistol animation and equip the weapon.
    /// </summary>
    public void SetPistol()
    {
        anim.SetLayerWeight(1, 1.0f);
        anim.SetLayerWeight(2, 0.0f);
        EquipWeapon(Weapon.WeaponAnimationType.Handgun);
    }

    /// <summary>
    /// After triggering a WeaponPickup, this function will call and enable the weapon for the player.
    /// It plays sounds here and sets the currently held weapon.
    /// </summary>
    /// <param name="WeaponType">The weapon type helps clearly state if the player has a Handgun, Rifle, or Nothing(None)</param>
    public void EquipWeapon (Weapon.WeaponAnimationType WeaponType)
    {
        hasAWeapon = true;
        if (WeaponType == Weapon.WeaponAnimationType.Rifle)
        {
            rifleHolder.gameObject.SetActive(true);
            heldWeapon = rifleHolder;

            equipSound.Play();
        }
        else if (WeaponType == Weapon.WeaponAnimationType.Handgun)
        {
            pistolHolder.gameObject.SetActive(true);
            heldWeapon = pistolHolder;

            equipSound.Play();
        }
    }
    public void RotateToMousePointer()
    {
        // Acquire the plane
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        // A ray is cast from the mouse to the plane.
        Ray theRay = playerCamera.ScreenPointToRay((Input.mousePosition));
        // This gives us the actual distance
        groundPlane.Raycast(theRay, out distance);
        // Use the given distance to find the point.
        Vector3 targetPoint = theRay.GetPoint(distance);

        // Calls the RotateTowards function
        RotateTowards(targetPoint);

        Vector3 relative;
        relative = transform.InverseTransformDirection(Vector3.forward);
        // Debug.Log(relative);
    }

    private void RotateTowards(Vector3 lookAtPoint)
    {
        // Acquires rotation to be used for looking where we want.
        Quaternion goalRotation = Quaternion.LookRotation(lookAtPoint - transform.position, Vector3.up);

        // Will rotate less than the given TurnSpeed towards the goal.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime * 2);
    }


    /// <summary>
    /// Forces the player to drop their weapon and allows them to pick up another.
    /// </summary>
    public void DropWeapon()
    {
        if (heldWeapon)
        {
            hasAWeapon = false;
            rifleHolder.gameObject.SetActive(false);
            pistolHolder.gameObject.SetActive(false);
            anim.SetLayerWeight(1, 0.0f);
            anim.SetLayerWeight(2, 0.0f);
            unequipSound.Play();
            heldWeapon = null;
        }
    }
}
