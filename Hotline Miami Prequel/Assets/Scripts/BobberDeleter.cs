using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobberDeleter : MonoBehaviour
{
    public GameObject objectHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectHolder == null)
        {
            Debug.Log("its empty"); 
            Destroy(gameObject);
        }
    }
}
