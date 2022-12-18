using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComandosBasicos : MonoBehaviour
{
    private fade            fade;
    private SoundController soundController;
    private Menu menu;

    public GameObject painel1Sair, painel2Sair;
    public Camera Cam;

    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        menu = FindObjectOfType(typeof(Menu)) as Menu;
        fade = FindObjectOfType(typeof(fade)) as fade;
    }

    public void carregaCena(string nomeCena)
    {
        soundController.playButton();

        if (SceneManager.GetActiveScene().name != "telaInicial" && SceneManager.GetActiveScene().name != "selecionarModo" && SceneManager.GetActiveScene().name != "modo1" && SceneManager.GetActiveScene().name != "modo2" && SceneManager.GetActiveScene().name != "modo3" && SceneManager.GetActiveScene().name != "modo4")
        {
            soundController.AudioMusic.clip = soundController.musicas[0];
            soundController.AudioMusic.Play();
        }

        StartCoroutine("transicao", nomeCena);
    }

    public void jogarOutraVez()
    {
        soundController.playButton();
        int idCena = PlayerPrefs.GetInt("idTema");
        if (idCena != 0)
        {
            SceneManager.LoadScene(idCena.ToString());
        }
    }

    public void sairDoJogo(bool onOff)
    {
        painel1Sair.SetActive(!onOff);
        painel2Sair.SetActive(onOff);
    }

    public void sair()
    {
        Application.Quit();
    }

    IEnumerator transicao(string nomeCena)
    {
        fade.fadeIn();
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        SceneManager.LoadScene(nomeCena);
    }

   
}
