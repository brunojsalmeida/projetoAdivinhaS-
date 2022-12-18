using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemaScene : MonoBehaviour
{
    private SoundController SoundController;

    public Text nomeTemaText;
    public Button btnJogar;

    // Start is called before the first frame update
    void Start()
    {
        SoundController = FindObjectOfType(typeof(SoundController)) as SoundController;

        btnJogar.interactable = false;
    }



    public void jogar()
    {
        SoundController.playButton();
        SoundController.AudioMusic.clip = SoundController.musicas[1];
        SoundController.AudioMusic.Play();

        int idCena = PlayerPrefs.GetInt("idTema");
        if(idCena != 0)
        {
           SceneManager.LoadScene(idCena.ToString());
        }
    }

}
