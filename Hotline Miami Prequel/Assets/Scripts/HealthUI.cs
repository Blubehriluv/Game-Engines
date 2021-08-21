using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthBox;
    public Transform canvas;
    private float waitTime = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*playerCamera.transform.position = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3
            (gameObject.transform.localPosition.x, cameraX, gameObject.transform.localPosition.z), cameraZ);*/

        healthBox.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        canvas.transform.Rotate(0, 0, 0);
    }
}
