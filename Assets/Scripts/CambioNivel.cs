using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    public juegos juegosScript;
    public bool ShowCursor = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadNextScene();
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadNextScene();
        }

    }

    void LoadNextScene()
    {
        juegosScript = FindObjectOfType<juegos>();
        juegosScript.puntajeactual = GameTimerText.gameTimer;
        juegosScript.CallSaveData();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (ShowCursor == false)
        {
            Cursor.visible = true;
        }
    }
}
