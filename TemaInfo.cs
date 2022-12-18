using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemaInfo : MonoBehaviour
{
    private SoundController SoundController;
    private TemaScene TemaScene;


    [Header("Configuração do Tema")]
    public int      idTema;
    public string   nomeTema;
    public bool     requerNotaMinima;
    public int      notaMinimaNecessaria;


    [Header("Configuração das estrelas")]
    public int notaMin1estrela;
    public int notaMin2estrela;
    public int notaMin3estrela;

    [Header("Configuração do botão")]
    public Text idTemaTxt;
    public GameObject[] estrela;
    private Button btnTema;

    private int notaFinal;

    void Start()
    {
        SoundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        notaFinal = PlayerPrefs.GetInt("notaFinal_" + idTema.ToString());
        TemaScene = FindObjectOfType(typeof(TemaScene)) as TemaScene;

        btnTema = GetComponent<Button>();

        //idTemaTxt.text = idTemaTxt.ToString();

        estrelas();
        verificarNotaMinima();
    }

    void verificarNotaMinima()
    {
        btnTema.interactable = false;
        if(requerNotaMinima == true)
        {
            int notaTemaAnterior = PlayerPrefs.GetInt("notaFinal_" + (idTema - 1).ToString());
            if(notaTemaAnterior >= notaMinimaNecessaria)
            {
                btnTema.interactable = true;
            }
        }
        else
        {
            btnTema.interactable = true;
        }
    }

    public void selecionarTema()
    {
        SoundController.playButton();
        TemaScene.nomeTemaText.text = nomeTema;

        PlayerPrefs.SetInt("idTema", idTema);
        PlayerPrefs.SetString("nomeTema", nomeTema);
        PlayerPrefs.SetInt("notaMin1Estrela", notaMin1estrela);
        PlayerPrefs.SetInt("notaMin2Estrela", notaMin2estrela);
        PlayerPrefs.SetInt("notaMin3Estrela", notaMin3estrela);

        TemaScene.btnJogar.interactable = true;
    }

    public void estrelas()
    {
        foreach (GameObject es in estrela)
        {
            es.SetActive(false);
        }

        int nEstrelas = 0;

        if(notaFinal >= notaMin3estrela)
        {
            nEstrelas = 3;
        } else if(notaFinal >= notaMin2estrela)
        {
            nEstrelas = 2;
        } else if(notaFinal >= notaMin1estrela)
        {
            nEstrelas = 1;
        }
        

        for(int i = 0; i < nEstrelas; i++)
        {
            estrela[i].SetActive(true);
        }
    }

}