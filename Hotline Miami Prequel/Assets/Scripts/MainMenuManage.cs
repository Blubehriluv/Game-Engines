using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuManage : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector2 target;
    public Vector2 position;
    public GameObject titleGraphic;
    
    private bool settingsAreOpen;
    

    // Start is called before the first frame update
    void Start()
    {
        settingsAreOpen = false;
        target = new Vector2(88, 210);
        position = titleGraphic.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!settingsAreOpen)
        {
            
        }
        else if (settingsAreOpen)
        {
            float step = speed * Time.deltaTime;
            titleGraphic.transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
        
    }

    public void OpenSetting()
    {
        settingsAreOpen = true;
    }

    public void PlayGame()
    {

    }

    public void GoBack()
    {
        settingsAreOpen = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
