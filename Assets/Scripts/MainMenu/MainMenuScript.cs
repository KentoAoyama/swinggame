using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{

    [SerializeField] Color _color;
    [SerializeField] Color _defaultcolor;
    TextMesh _tm;
    [SerializeField] GameObject _thisText;
    [SerializeField] GameObject _thisbutton;
    [SerializeField] GameObject _nextText;
    [SerializeField] GameObject _nextButton;
    [SerializeField] float _changeSpeed = 1;


    private void Start()
    {
        _tm = GetComponent<TextMesh>();

        _thisText.SetActive(true);
        _nextText.SetActive(false);
        _nextButton.SetActive(false);
        _thisbutton.SetActive(true);
    }


    private void OnDisable()
    {
        float alfa = _tm.color.a;
        _tm.color -= new Color(0, 0, 0, alfa);
    }

    void FixedUpdate()
    {
        if (_tm.color.a < 255)
        {
            _tm.color += new Color(0, 0, 0, _changeSpeed);
        }
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
        _tm.color = _defaultcolor;
        _nextText.SetActive(true);
        _nextButton.SetActive(true);
        _thisbutton.SetActive(false);
        _thisText.SetActive(false);
    }
}
