using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneAdmin : MonoBehaviour
{
    public GameTimerText gameTimerTextScript;
    public Text gameTimerTextObject;
    // Start is called before the first frame update
    void Awake()
    {
        gameTimerTextScript = FindObjectOfType<GameTimerText>();
        gameTimerTextScript.gameTimerText = gameTimerTextObject;
    }
    
}
