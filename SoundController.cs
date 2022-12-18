using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public  AudioSource  AudioMusic, AudioFX;
    public  AudioClip    SomAcerto, SomErro, SomBotao, vinheta;
    public  AudioClip[]  musicas;    

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        carregarPreferencias();
        AudioMusic.clip = musicas[0];
        AudioMusic.Play();
    }

    public void playAcerto()
    {
        AudioFX.PlayOneShot(SomAcerto);
    }

    public void playErro()
    {
        AudioFX.PlayOneShot(SomErro);
    }

    public void playButton()
    {
        AudioFX.PlayOneShot(SomBotao);
    }

    public void playVinhata()
    {
        AudioFX.PlayOneShot(vinheta);
        AudioFX.Play();
    }

    void carregarPreferencias()
    {
        //verifica se há registro dos valores iniciais de configuração, se não houver, grava os valores iniciais
        if(PlayerPrefs.GetInt("ValoresDefault") == 0)
        {
            PlayerPrefs.SetInt("ValoresDefault", 1);
            PlayerPrefs.SetInt("onOffMusica", 1);
            PlayerPrefs.SetInt("onOffEfeitos", 1);
            PlayerPrefs.SetFloat("volumeMusica", 1);
            PlayerPrefs.SetFloat("volumeEfeitos", 1);
        }

        //carrega os valores de configuração dos sons e musicas
        int onOffMusica = PlayerPrefs.GetInt("onOffMusica");
        int onOffEfeitos = PlayerPrefs.GetInt("onOffEfeitos");
        float volumeMusica = PlayerPrefs.GetFloat("volumeMusica");
        float volumeEfeitos = PlayerPrefs.GetFloat("volumeEfeitos");

        bool tocarMusica = false;
        bool tocarEfeitos = false;

        if(onOffMusica == 1)
        {
            tocarMusica = true;
        }
        if(onOffEfeitos == 1)
        {
            tocarEfeitos = true;
        }

        AudioMusic.mute = !tocarMusica;
        AudioFX.mute = !tocarEfeitos;

        AudioMusic.volume = volumeMusica;
        AudioFX.volume = volumeEfeitos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
