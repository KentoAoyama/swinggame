using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void NextStage(string x)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(x);
        TimerScript._currentTime = 0;
    }
}
