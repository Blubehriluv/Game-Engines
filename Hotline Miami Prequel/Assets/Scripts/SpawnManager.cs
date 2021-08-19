using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject pistol;
    public GameObject rifle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        Instantiate(player);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy);
    }
}
