using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public MeshFilter daMesh;
    public Weapon rifle;
    //private Pistol_al pistol;
    // Start is called before the first frame update
    void Start()
    {
        daMesh = gameObject.GetComponent<MeshFilter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (daMesh.name == "M4_8")
        {
            Debug.Log("Picked up rifle.");
            other.gameObject.GetComponent<Pawn_al>().SetRifle();
            //other.gameObject.GetComponent<Pawn_al>().EquipWeapon(rifle);
            OnDestroy();

        }
        else if (daMesh.name == "M1911")
        {
            Debug.Log("Picked up pistol.");
            other.gameObject.GetComponent<Pawn_al>().SetPistol();
            OnDestroy();
        }
        else
        {
            Debug.Log("idk what the name is.");
        }
        //other.gameObject.GetComponent<Pawn>().
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
