using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextSceneScript : MonoBehaviour
{
    
    public void NextScene(string x)
    {
        SceneManager.LoadScene(x);
    }

    
}
