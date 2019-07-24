using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject[] comparables;
    

    public Transform spawnPos;
    public GameObject spawnee;

    // Update is called once per frame
    void Update()
    {
        GameObject a = spawnee;

        if (Input.GetMouseButton(0))
        {
            Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
            ScreenCapture.CaptureScreenshot("Assets/Mechanical_Turk_Test/Screenshots/A_" + a.name + "_B_" + ".jpg", 2);
        }
    }
}


//C:/Users/Eli VanderBilt/Documents/GitHub/ai2thor/unity/