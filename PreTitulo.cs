using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreTitulo : MonoBehaviour
{
    private fade fade;

    public int tempoEspera;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType(typeof(fade)) as fade;

        StartCoroutine("esperar");
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(tempoEspera);
        fade.fadeIn();

        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);

        SceneManager.LoadScene("telaInicial");
    }
}
