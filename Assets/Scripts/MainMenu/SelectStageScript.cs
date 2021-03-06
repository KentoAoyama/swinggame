using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectStageScript : MonoBehaviour
{
    [SerializeField] Color _color;
    [SerializeField] Color _defaultcolor;
    TextMesh _tm;
    [SerializeField] float _changeSpeed = 1;


    void Start()
    {
        _tm = GetComponent<TextMesh>();
    }

    //private void OnEnable()
    //{
    //    float alfa = _tm.color.a;
    //    _tm.color -= new Color(0, 0, 0, 0);
    //}

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
        if (_tm.color == _defaultcolor)
        {
            _tm.color = _color;
        }
    }


    private void OnMouseExit()
    {
        _tm.color = _defaultcolor;
    }


    public void NextScene(string x)
    {
        SceneManager.LoadScene(x);
    }

}
