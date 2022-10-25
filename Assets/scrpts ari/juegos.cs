using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class juegos : MonoBehaviour
{

    public Text nombredisplay;
    public Text puntosdisplay;
    public float record;
    public Text recordDisplay;
    public float puntajeactual;
    public string nombreEscena;

    private void Awake()
    {
        nombreEscena = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (DBManager.usuario == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        nombredisplay.text = "Player: " + DBManager.usuario;
        puntosdisplay.text = "score:0";
        recordDisplay.text = "Record: " + DBManager.record;
        DBManager.level = nombreEscena;
        record = DBManager.record;
    }

    public void CallSaveData()
    {
        if(puntajeactual > record)
        {
            DBManager.record = puntajeactual;
        }
        DBManager.record = puntajeactual;
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", DBManager.usuario);
        form.AddField("resultado", DBManager.record.ToString());
        form.AddField("level", DBManager.level.ToString());

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("game saved");
        }
        else
        {
            Debug.Log("save failed. error #" + www.text);
        }

        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        puntajeactual++;
        puntosdisplay.text = "Score: " + puntajeactual;
    }

}
