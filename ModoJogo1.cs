using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModoJogo1 : MonoBehaviour
{
    [Header("Configuração dos Textos")]
    public Text nomeTemaTxt;
    public Text perguntaTxt;
    public Image perguntaImg;
    public Text infoRespostasTxt;
    public Text notaFinalTxt;
    public Text msg1Txt;
    public Text msg2Txt;

    [Header("Configuração dos Textos (Alternativas)")]
    public Text altAtxt;
    public Text altBtxt;
    public Text altCtxt;
    public Text altDtxt;

    [Header("Configuração das Imagens (Alternativas)")]
    public Image altAimg;
    public Image altBimg;
    public Image altCimg;
    public Image altDimg;

    [Header("Configuração das Barras")]
    public GameObject barraProgresso;
    public GameObject barraTempo;

    [Header("Configuração dos Botões")]
    public Button[] botoes;
    public Color    corAcerto, corErro;
    //public AudioSource audiobtnA;
    //public AudioSource audiobtnB;

    [Header("Configuração do Modo de Jogo")]
    public bool     perguntasComImg;
    public bool     utilizarAlternativas;
    public bool     utilizarAlternativasIMG;
    public bool     perguntasAleatorias;
    public bool     jogarComTempo;
    public float    tempoResponder;
    public bool     mostrarCorreta;
    public float      qntPiscadas;

    [Header("Configuração das Perguntas")]
    public string[] perguntas;
    public Sprite[] perguntasImg;
    public string[] correta;
    //public int      qtdPerguntas;
    //public List<int> listaPerguntas;

    [Header("Configuração das Alternativas")]
    public string[] AlternativasA;
    public string[] AlternativasB;
    public string[] AlternativasC;
    public string[] AlternativasD;

    [Header("Configuração das Alternativas (Imagem)")]
    public Sprite[] AlternativasAImg;
    public Sprite[] AlternativasBImg;
    public Sprite[] AlternativasCImg;
    public Sprite[] AlternativasDImg;

    [Header("Configuração dos Paineis")]
    public GameObject[] paineis;
    public GameObject[] estrela;

    [Header("Configuração das Mensagens")]
    public string[] mensagem1;
    public string[] mensagem2;

    // ----------------------

    private int idResponder, qtdAcertos, notaMin1estrela, notaMin2estrela, notaMin3estrela, nEstrelas, idTema, idBtnCorreto;
    private float qtdRespondida, percProgresso, percTempo, notaFinal, valorQuestao, tempTime;
    private bool exibindoCorreta, testeFinalizado;

    private SoundController SoundController;

    // Start is called before the first frame update
    void Start()
    {
        SoundController = FindObjectOfType(typeof(SoundController)) as SoundController;

        int onOffTempo = PlayerPrefs.GetInt("onOffTempo");

        if (onOffTempo == 1)
        {
            jogarComTempo = true;
        } else
        {
            jogarComTempo = false;
        }

        tempoResponder = PlayerPrefs.GetFloat("tempoResponder");

        int onOffCorreta = PlayerPrefs.GetInt("onOffCorreta");

        if (onOffCorreta == 1)
        {
            mostrarCorreta = true;
        } else
        {
            mostrarCorreta = false;
        }

        qntPiscadas = PlayerPrefs.GetFloat("qntPiscadas");

        idTema = PlayerPrefs.GetInt("idTema");
        notaMin1estrela = PlayerPrefs.GetInt("notaMin1estrela");
        notaMin2estrela = PlayerPrefs.GetInt("notaMin2estrela");
        notaMin3estrela = PlayerPrefs.GetInt("notaMin3estrela");

        nomeTemaTxt.text = PlayerPrefs.GetString("nomeTema");

        barraTempo.SetActive(false);

        montarListaPerguntas();
        progressaoBarra();
        controleBarraTempo();

        valorQuestao = 10 / (float) perguntas.Length;

        paineis[0].SetActive(true);
        paineis[1].SetActive(false);

        notaMin1estrela = 3;
        notaMin2estrela = 5;
        notaMin3estrela = 7;


    }

    // Update is called once per frame

    void Update()
    {
        if(jogarComTempo == true && exibindoCorreta == false && testeFinalizado == false)
        {
            tempTime += Time.deltaTime;
            controleBarraTempo();

            if(tempTime >= tempoResponder)
            {
                proximaPergunta();
            }
        }
    }
 

    public void montarListaPerguntas()
    {
        /*
        if(perguntasAleatorias == true)
        {
            bool addPergunta = true; 

            if(qtdPerguntas > perguntas.Length)
            {
                qtdPerguntas = perguntas.Length;
            }

            while (listaPerguntas.Count < qtdPerguntas)
            { 
                    addPergunta = true;
                    int rand = Random.Range(0, perguntas.Length);
                    listaPerguntas.Add(rand);

                    foreach(int idP in listaPerguntas)
                    {
                        if(idP == rand)
                        {
                            addPergunta = false;
                        }
                    }
                    if(addPergunta == true)
                    {
                        listaPerguntas.Add(rand);
                    }
            }
            
        } else
        {
            for(int i = 0; i < perguntas.Length; i++)
            {
                listaPerguntas.Add(i);
            }
        }
        */
        if(perguntasComImg == true)
        {
            perguntaImg.sprite = perguntasImg[idResponder];
        }

        perguntaTxt.text = perguntas[idResponder];


        if (utilizarAlternativas == true && utilizarAlternativasIMG == false)
        {
            altAtxt.text = AlternativasA[idResponder];
            altBtxt.text = AlternativasB[idResponder];
            altCtxt.text = AlternativasC[idResponder];
            altDtxt.text = AlternativasD[idResponder];
        }
        else if (utilizarAlternativas == true && utilizarAlternativasIMG == true)
        {
            altAimg.sprite = AlternativasAImg[idResponder];
            altBimg.sprite = AlternativasBImg[idResponder];
            altCimg.sprite = AlternativasCImg[idResponder];
            altDimg.sprite = AlternativasDImg[idResponder];
        }

    }

    public void responder(string alternativa)
    {
        if (exibindoCorreta == true)
        {
            return;
        }

        qtdRespondida++;
        progressaoBarra();

        if (correta[idResponder] == alternativa)
        {
            qtdAcertos++;
            SoundController.playAcerto();
        } else
        {
            SoundController.playErro();
        }

        switch (correta[idResponder])
        {
            case "A":
                idBtnCorreto = 0;
                break;
            case "B":
                idBtnCorreto = 1;
                break;
            case "C":
                idBtnCorreto = 2;
                break;
            case "D":
                idBtnCorreto = 3;
                break;
        }

        if(mostrarCorreta == true)
        {
            foreach(Button b in botoes)
            {
                b.image.color = corErro;
            }
            exibindoCorreta = true;
            botoes[idBtnCorreto].image.color = corAcerto;
            StartCoroutine("mostrarAlternativaCorreta");
        }
        else
        {
            exibindoCorreta = true;
            StartCoroutine("aguardarProxima");
        }

    }
    public void proximaPergunta()
    {
        idResponder++;
        tempTime = 0;

        EventSystem.current.SetSelectedGameObject(null);

        if (idResponder < perguntas.Length)
        {
            if (perguntasComImg == true)
            {
                perguntaImg.sprite = perguntasImg[idResponder];
            }
            perguntaTxt.text = perguntas[idResponder];

            if (utilizarAlternativas == true && utilizarAlternativasIMG == false)
            {
                altAtxt.text = AlternativasA[idResponder];
                altBtxt.text = AlternativasB[idResponder];
                altCtxt.text = AlternativasC[idResponder];
                altDtxt.text = AlternativasD[idResponder];
            }
            else if (utilizarAlternativas == true && utilizarAlternativasIMG == true)
            {
                altAimg.sprite = AlternativasAImg[idResponder];
                altBimg.sprite = AlternativasBImg[idResponder];
                altCimg.sprite = AlternativasCImg[idResponder];
                altDimg.sprite = AlternativasDImg[idResponder];


            }
        }
        else
        {
            calcularNotaFinal();
        }
    }

    void progressaoBarra()
    {
        infoRespostasTxt.text = "Respondeu " + qtdRespondida + " de " +perguntas.Length + "";
        percProgresso = qtdRespondida / perguntas.Length;
        barraProgresso.transform.localScale = new Vector3(percProgresso, 1, 1);
    }

    public void controleBarraTempo()
    {
            if (jogarComTempo == true)
            {
                barraTempo.SetActive(true);
            }
        percTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;
        if(percTempo < 0)
        {
            percTempo = 0;
        }
        barraTempo.transform.localScale = new Vector3(percTempo, 1, 1);

    }

    void calcularNotaFinal()
    {
        testeFinalizado = true;
        notaFinal = Mathf.RoundToInt(valorQuestao * qtdAcertos);
        notaFinalTxt.text = notaFinal.ToString();

        if (notaFinal > PlayerPrefs.GetInt("notaFinal_" + idTema.ToString()))
        {
            PlayerPrefs.SetInt("notaFinal_" + idTema.ToString(), (int)notaFinal);
        }
        //notaFinalTxt.text = notaFinal.ToString(); ---------- caso eu nao queira sistema de recorde gravado

        if (notaFinal >= notaMin3estrela)
        {
            nEstrelas = 3;
            SoundController.playVinhata();
            
        }
        else if (notaFinal >= notaMin2estrela)
        {
            nEstrelas = 2;
            SoundController.playVinhata();
        }
        else if (notaFinal >= notaMin1estrela)
        {
            nEstrelas = 1;
            SoundController.playVinhata();
        }

        msg1Txt.text = mensagem1[nEstrelas];
        msg2Txt.text = mensagem2[nEstrelas];

        foreach (GameObject es in estrela)
        {
            es.SetActive(false);
        }

        for (int i = 0; i < nEstrelas; i++)
        {
            estrela[i].SetActive(true);
        }

        paineis[0].SetActive(false);
        paineis[1].SetActive(true);
    }

    IEnumerator aguardarProxima()
    {
        yield return new WaitForSeconds(1);
        exibindoCorreta = false;
        proximaPergunta();
    }

    IEnumerator mostrarAlternativaCorreta()
    {
        for(int i = 0; i < qntPiscadas; i++)
        {
            botoes[idBtnCorreto].image.color = corAcerto;
            yield return new WaitForSeconds(0.2f);
            botoes[idBtnCorreto].image.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }

        foreach (Button b in botoes)
        {
            b.image.color = Color.white;
        }

        exibindoCorreta = false;
        proximaPergunta();
    }
}
