using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownPlaceholderScript : MonoBehaviour
{

    public Text DropFundoTxt;
                

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        int j;

        if (Configuration.Instance.ButtonNumber == 0)
        {
            j = 7;
        }
        else if (Configuration.Instance.ButtonNumber == 1)
        {
            j = 6;
        }
        else if (Configuration.Instance.ButtonNumber == 2)
        {
            j = 5;
        }
        else if (Configuration.Instance.ButtonNumber == 3)
        {
            j = 4;
        }
        else if (Configuration.Instance.ButtonNumber == 4)
        {
            j = 3;
        }
        else
        {
            j = 7;
        }
        dropButtonNumberTxt.text = string.Format("{0}", j);

        dropSequenceSizeTxt.text = string.Format("{0}", Configuration.Instance.SequenceSize);
    
        if (Configuration.Instance.Speed == 0)
        {
            dropSpeedTxt.text = "Rápido";
        }else if (Configuration.Instance.Speed == 1)
        {
            dropSpeedTxt.text = "Normal";
        }
        else
        {
            dropSpeedTxt.text = "Lento";
        }
        */
        

        if (Configuration.Instance.BackgroundGameColor == 0)
        {
            DropFundoTxt.text = "Branco";
        }
        else
        {
            DropFundoTxt.text = "Preto";
        }
        
        /*

        //SONS
        if (Configuration.Instance.Sonds == 0)
        {
            DropSondsTxt.text = "Piano";
        }
        else if(Configuration.Instance.Sonds == 1)
        {
            DropSondsTxt.text = "Digital";
        }
        else
        {
        
            DropSondsTxt.text = "Flauta";
        }
        //DropFundoTxt.text = string.Format("{0}", Configuration.Instance.BackgroundGameColor);

        */

    }
}
