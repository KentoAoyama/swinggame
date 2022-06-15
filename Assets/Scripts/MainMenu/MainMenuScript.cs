using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{

    [SerializeField] Color _color;
    Color _defaultcolor;
    TextMesh _tm;
    [SerializeField] GameObject _thisText;
    [SerializeField] GameObject _thisbutton;
    [SerializeField] GameObject _nextText;
    [SerializeField] GameObject _nextButton;


    private void Start()
    {
        _tm = GetComponent<TextMesh>();
        _defaultcolor = _tm.color;

        _thisText.SetActive(true);
        _nextText.SetActive(false);
        _nextButton.SetActive(false);
        _thisbutton.SetActive(true);
    }

    
    private void OnMouseOver()
    {
        _tm.color = _color;
    }

    
    private void OnMouseExit()
    {
        _tm.color = _defaultcolor;
    }


    public void NextScene(string y)
    {
        SceneManager.LoadScene(y);
    }

    
    public void NextSelect()
    {
        _nextText.SetActive(true);
        _nextButton.SetActive(true);
        _thisbutton.SetActive(false);
        _thisText.SetActive(false);
    }
}
