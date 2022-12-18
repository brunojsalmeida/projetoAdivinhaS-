using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TemaJogo : MonoBehaviour
{
    public Button btnPlay;
    public Text TextNomeTema;

    public GameObject InfoTema;
    public Text TextInfoTema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    public string[] nomeTema;
    public int numeroQuestoes;

    private int idTema;


    void Start()
    {
        idTema = 0;
        TextNomeTema.text = nomeTema[idTema];
        TextInfoTema.text = "você acertou x de x questões";

        InfoTema.SetActive(false);

        TextInfoTema.text = "";

        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        btnPlay.interactable = false;

    }


    public void selecionarTema(int i)
    {
        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
        TextNomeTema.text = nomeTema[idTema];

        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        int acertos = PlayerPrefs.GetInt("acertos" + idTema.ToString());

        estrela1.SetActive(false);  // --
        estrela2.SetActive(false);  // -- zera as estrelas antes de dar a nota
        estrela3.SetActive(false);  // --

        if (notaFinal == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 5)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }


        TextInfoTema.text = "você acertou " + acertos.ToString() + " de " + numeroQuestoes.ToString() + " questões!";
        InfoTema.SetActive(true);
        btnPlay.interactable = true;
    }
    
    public void jogar()
    {
        Application.LoadLevel("tema" + idTema.ToString());
    }

}
