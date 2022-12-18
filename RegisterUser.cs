using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Newtonsoft.Json;

public class RegisterUser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InputField resgisterUser = null;

    [SerializeField]
    private InputField resgisterEmail = null;

    [SerializeField]
    private InputField resgisterPassWord = null;

    [SerializeField]
    private InputField resgisterType = null;



    public void FazerLogin()
    {
        StartCoroutine(EviarRequisicao());

    }

    IEnumerator EviarRequisicao()
    {
        string endPoint = "localhost:3333/api/v1";
        string username = resgisterUser.text;
        string email = resgisterEmail.text;
        string password = resgisterPassWord.text;
        string type = resgisterType.text;

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("type", type);

        UnityWebRequest w = UnityWebRequest.Post(endPoint + "/usuario", form);
        yield return w.SendWebRequest();

        if (w.isNetworkError || w.isHttpError)
        {
            Debug.Log(w.error);
        }
        else
        {
            StartCoroutine(CarregaScene());
        }

    }

    IEnumerator CarregaScene()
    {
        SceneManager.LoadScene("selecionarModo");
        yield return 0;
    }
}
