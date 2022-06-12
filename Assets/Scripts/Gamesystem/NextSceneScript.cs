using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextSceneScript : MonoBehaviour
{
    [SerializeField] Color _changeColor;
    Color _defaultColor;
    Text _text;
    



    void Start()
    {
        _text = GetComponent<Text>();
        _defaultColor = _text.color;
    }

    
    public void NextScene(string x)
    {
        SceneManager.LoadScene(x);
    }

    
    private void OnMouseEnter()
    {
        _text.color = _changeColor;
    }

    private void OnMouseExit()
    {
        _text.color = _defaultColor;
    }
}
