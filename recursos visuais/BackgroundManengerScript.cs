using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManengerScript : MonoBehaviour
{
    public Text txtUI_1, txtUI_2;
    public GameObject fundoB, fundoP;
    public Color preto, banco;

    void Start()
    {
        if (Configuration.Instance.BackgroundGameColor == 0)
        {
            fundoB.SetActive(true);
            fundoP.SetActive(false);
            txtUI_1.color = preto;
            txtUI_2.color = preto;
        }
        else
        {
            fundoB.SetActive(false);
            fundoP.SetActive(true);
            txtUI_1.color = banco;
            txtUI_2.color = banco;
        }
        
    }

}
