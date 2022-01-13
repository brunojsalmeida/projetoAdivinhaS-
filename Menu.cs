using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private ModoJogo1 ModoJogo1;


    public Camera Cam;
    public Dropdown dropdown;


    


    void Update()
    {
        switch (dropdown.value)
        {
            case 1:
                Cam.backgroundColor = Color.black;
                break;
            case 2:
                Cam.backgroundColor = Color.white;
                break;
            case 3:
                Cam.backgroundColor = Color.green;
                break;
            case 4:
                Cam.backgroundColor = Color.blue;
                break;
            case 5:
                Cam.backgroundColor = Color.yellow;
                break;
            case 6:
                Cam.backgroundColor = Color.red;
                break;
        }
    }
}
