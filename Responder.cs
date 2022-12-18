using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Responder : MonoBehaviour
{
    private int idTema;

    public Image Pergunta;
    public Text Descricao;
    public Text RespostaA;
    public Text RespostaB;
    public Text RespostaC;
    public Text RespostaD;
    public Text InfoRespostas;
    public Text textoTempo;
    public int limiteDeTempo;

    public AudioSource audiobtnA;
    public AudioSource audiobtnB;
    public AudioSource audiobtnC;
    public AudioSource audiobtnD;

    public AudioClip soundAcerto;
    public AudioClip soundErro;

    public Sprite[] perguntas;      // armazena todas perguntas
    public string[] descricao;        // armazena todas as descrições
    public string[] alternativaA;   // armazena todas alternativas A
    public string[] alternativaB;   // armazena todas alternativas B
    public string[] alternativaC;   // armazena todas alternativas C
    public string[] alternativaD;   // armazena todas alternativas D
    public string[] corretas;       // armazena todas alternativas corretas

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;

    private bool rodadaAtiva;
    private float tempoRestante;
    

    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;


        Pergunta.sprite = perguntas[idPergunta];
        Descricao.text = descricao[idPergunta];
        RespostaA.text = alternativaA[idPergunta];
        RespostaB.text = alternativaB[idPergunta];
        RespostaC.text = alternativaC[idPergunta];
        RespostaD.text = alternativaD[idPergunta];

        InfoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";

        tempoRestante = limiteDeTempo;
        UpdateTimer();
        rodadaAtiva = true;
    }

    public void resposta(string alternativa)
    {
        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                audiobtnA.PlayOneShot(soundAcerto);
                acertos += 1;
            }
            else
            {
                audiobtnA.PlayOneShot(soundErro);
            }
        }
        else if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                audiobtnB.PlayOneShot(soundAcerto);
                acertos += 1;
            }
            else
            {
                audiobtnB.PlayOneShot(soundErro);
            }
        }
        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                audiobtnC.PlayOneShot(soundAcerto);
                acertos += 1;
            }
            else
            {
                audiobtnC.PlayOneShot(soundErro);
            }

        }
        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                audiobtnD.PlayOneShot(soundAcerto);
                acertos += 1;
            }
            else
            {
                audiobtnD.PlayOneShot(soundErro);
            }
        }
        proximaPergunta();
    }

    void proximaPergunta()
    {
        idPergunta++;

        if (idPergunta <= (questoes - 1))
        {
            Pergunta.sprite = perguntas[idPergunta];
            Descricao.text = descricao[idPergunta];
            RespostaA.text = alternativaA[idPergunta];
            RespostaB.text = alternativaB[idPergunta];
            RespostaC.text = alternativaC[idPergunta];
            RespostaD.text = alternativaD[idPergunta];

            InfoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";

            tempoRestante = limiteDeTempo;
            UpdateTimer();
            rodadaAtiva = true;


        }
        else // o que acontece quando as perguntas encerram
        {

            media = 10 * (acertos / questoes); // calcula a média final obtida
            notaFinal = Mathf.RoundToInt(media); // arredonda a média final obtida, tanto pra cima quanto para baixo

            if (notaFinal > PlayerPrefs.GetInt(idTema.ToString())) // se a nota da atual rodada for maior da já cadastrada no sistema
            {
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal); // garante que a nota é gravada em um tema específico
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);     // garante que os acertos são gravados em um tema específico
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal); // garante que todas as notas sejam gravadas, não apenas de recorde
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);     // garante que todos os acertos sejam gravados, não apenas de recorde

            Application.LoadLevel("notaFinal");
        }
    }

    void Update()
    {
        if (rodadaAtiva)
        {
            tempoRestante -= Time.deltaTime;
            UpdateTimer();
            if (tempoRestante <= 0)
            {
                proximaPergunta();

            }
        }

    }
    private void UpdateTimer()
    {
        textoTempo.text = "Tempo: " + Mathf.Round(tempoRestante).ToString();
    }

    public void EndRound()
    {
        rodadaAtiva = false;
    }
}
