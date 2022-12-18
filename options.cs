using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    private SoundController soundController;

    public GameObject painel1Opcoes, painel2Opcoes, painel3Opcoes;
    public Toggle       onOffMusica, onOffEfeitos, onOffTempo, onOffCorreta;
    public Slider       volumeM, volumeE, duracaoT, duracaoP, quantidadeP;

    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;

        carregarPreferencias();
        painel1Opcoes.SetActive(true);
        painel2Opcoes.SetActive(false);
    }

    

    public void configuracoes(bool onOff)
    {
        soundController.playButton();
        painel1Opcoes.SetActive(!onOff);
        painel2Opcoes.SetActive(onOff);
        //painel3Opcoes.SetActive(!onOff);
    }

    public void deletarPontuacoes()
    {
        soundController.playButton();

        int onOffM = PlayerPrefs.GetInt("onOffMusica");
        int onOffE = PlayerPrefs.GetInt("onOffEfeitos");
        int onOffT = PlayerPrefs.GetInt("onOffTempo");
        int onOffC = PlayerPrefs.GetInt("onOffCorreta");
        float volumeMusica = PlayerPrefs.GetFloat("volumeMusica");
        float volumeEfeitos = PlayerPrefs.GetFloat("volumeEfeitos");
        float duracaoTempo = PlayerPrefs.GetFloat("tempoResponder");
        float duracaoCorreta = PlayerPrefs.GetFloat("qntPiscadas");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("ValoresDefault", 1);
        PlayerPrefs.SetInt("onOffMusica", onOffM);
        PlayerPrefs.SetInt("onOffEfeitos", onOffE);
        PlayerPrefs.SetInt("onOffTempo", onOffT);
        PlayerPrefs.SetInt("onOffCorreta", onOffC);
        PlayerPrefs.SetFloat("volumeMusica", volumeMusica);
        PlayerPrefs.SetFloat("volumeEfeitos", volumeEfeitos);
        PlayerPrefs.SetFloat("tempoResponder", duracaoTempo);
        PlayerPrefs.SetFloat("qntPiscadas", duracaoCorreta);
    }

    public void mutarMusica()
    {
        soundController.AudioMusic.mute = !onOffMusica.isOn;
        /*
        if(onOffMusica.isOn == false)
        {
            soundController.AudioMusic.mute = true;
        }
        else
        {
            soundController.AudioMusic.mute = false;
        }
        */
        if(onOffMusica.isOn == true)
        {
            PlayerPrefs.SetInt("onOffMusica", 1);
        } else
        {
            PlayerPrefs.SetInt("onOffMusica", 0);
        }
    }

    public void mutarEfeitos()
    {
        soundController.AudioFX.mute = !onOffEfeitos.isOn;
        if (onOffEfeitos.isOn == true)
        {
            PlayerPrefs.SetInt("onOffEfeitos", 1);
        } else
        {
            PlayerPrefs.SetInt("onOffEfeitos", 0);
        }
    }

    public void mutarTempo()
    {
        if(onOffTempo.isOn == true)
        {
            PlayerPrefs.SetInt("onOffTempo", 1);
        } else
        {
            PlayerPrefs.SetInt("onOffTempo", 0);
        }
        
    }

    public void mutarCorreta()
    {
        if(onOffCorreta.isOn == true)
        {
            PlayerPrefs.SetInt("onOffCorreta", 1);
        } else
        {
            PlayerPrefs.SetInt("onOffCorreta", 0);
        }
    }

    public void volumeMusica()
    {
        soundController.AudioMusic.volume = volumeM.value;
        PlayerPrefs.SetFloat("volumeMusica", volumeM.value);
    }

    public void volumeEfeitos()
    {
        soundController.AudioFX.volume = volumeE.value;
        PlayerPrefs.SetFloat("volumeEfeitos", volumeE.value);
    }

    public void duracaoTempo()
    {
        PlayerPrefs.SetFloat("tempoResponder", duracaoT.value);
    }

    public void QuantidadePerguntas()
    {
        // PlayerPrefs.SetFloat("qtdPerguntas", quantidadeP.value);
        Questions.numberQuestion = quantidadeP.value;
    }

    public void duracaoCorreta()
    {
        PlayerPrefs.SetFloat("qntPiscadas", duracaoP.value);
    }

    void carregarPreferencias()
    {

        //carrega os valores de configuração dos sons e musicas
        int onOffM = PlayerPrefs.GetInt("onOffMusica");
        int onOffE = PlayerPrefs.GetInt("onOffEfeitos");
        int onOffT = PlayerPrefs.GetInt("onOffTempo");
        int onOffC = PlayerPrefs.GetInt("onOffCorreta");
        float volumeMusica = PlayerPrefs.GetFloat("volumeMusica");
        float volumeEfeitos = PlayerPrefs.GetFloat("volumeEfeitos");
        float duracaoTempo = PlayerPrefs.GetFloat("tempoResponder");
        float quantidadePerguntas = PlayerPrefs.GetFloat("qtdPerguntas");
        float duracaoCorreta = PlayerPrefs.GetFloat("qntPiscadas");

        bool tocarMusica = false;
        bool tocarEfeitos = false;
        bool comTempo = false;
        bool comPiscadas = false;

        if (onOffM == 1)
        {
            tocarMusica = true;
        }
        if (onOffE == 1)
        {
            tocarEfeitos = true;
        }
        if(onOffT == 1)
        {
            comTempo = true;
        }
        if(onOffC == 1)
        {
            comPiscadas = true;
        }

        onOffMusica.isOn = tocarMusica;
        onOffEfeitos.isOn = tocarEfeitos;
        onOffTempo.isOn = comTempo;
        onOffCorreta.isOn = comPiscadas;

        volumeM.value = volumeMusica;
        volumeE.value = volumeEfeitos;
        duracaoT.value = duracaoTempo;
        duracaoP.value = duracaoCorreta;
    }
}
