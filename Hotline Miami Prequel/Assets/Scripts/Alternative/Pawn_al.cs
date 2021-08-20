using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_al : MonoBehaviour
{
    private Animator anim;
    public float speed = 5;
    public float turnSpeed = 180;
    public Camera playerCamera;
    public Weapon heldWeapon;
    private AudioSource[] sounds;
    [SerializeField] private Transform hand;
    [SerializeField] private GameObject soundsHolder;
    private AudioSource unequipSound;
    private AudioSource equipSound;
    [SerializeField] private Rifle_al rifleHolder;
    [SerializeField] private Pistol_al pistolHolder;
    //private Pistol_al pistol;
    [SerializeField] private float distance;
    private bool hasAWeapon;
    

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        hasAWeapon = false;
        sounds = soundsHolder.GetComponents<AudioSource>();
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

    public bool HasAGgun()
    {
        return hasAWeapon;
    }

    public void SetRifle()
    {
        anim.SetLayerWeight(2, 1.0f);
        anim.SetLayerWeight(1, 0.0f);
        EquipWeapon(Weapon.WeaponAnimationType.Rifle);
    }

    public void SetPistol()
    {
        anim.SetLayerWeight(1, 1.0f);
        anim.SetLayerWeight(2, 0.0f);
        EquipWeapon(Weapon.WeaponAnimationType.Handgun);
    }

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

    private void RotateTowards(Vector3 lookAtPoint)
    {
        // Acquires rotation to be used for looking where we want.
        Quaternion goalRotation = Quaternion.LookRotation(lookAtPoint - transform.position, Vector3.up);

        // Will rotate less than the given TurnSpeed towards the goal.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime * 2);
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
