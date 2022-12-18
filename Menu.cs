using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private ModoJogo1 ModoJogo1;
    private ComandosBasicos comandosBasicos;


    public Camera Cam;
    public Dropdown dropdown;


    void Update()
    {
        switch (dropdown.value)
        {
            case 1:
                Cam.backgroundColor = Color.black;
                CameraColor.color = Color.black;
                break;
            case 2:
                Cam.backgroundColor = Color.white;
                CameraColor.color = Color.white;
                break;
            case 3:
                Cam.backgroundColor = Color.green;
                CameraColor.color = Color.green;
                break;
            case 4:
                Cam.backgroundColor = Color.blue;
                CameraColor.color = Color.blue;
                break;
            case 5:
                Cam.backgroundColor = Color.yellow;
                CameraColor.color = Color.yellow;
                break;
            case 6:
                Cam.backgroundColor = Color.red;
                CameraColor.color = Color.red;
                break;
        }
    }
}
