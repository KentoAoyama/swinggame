using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSelect : MonoBehaviour
{
    [SerializeField] Color _color;
    [SerializeField] Color _defaultcolor;
    TextMesh _tm;
    [SerializeField] float _changeSpeed = 1;
    [SerializeField] GameObject _stageText;
    [SerializeField] GameObject _stagebutton;
    [SerializeField] GameObject _firstText;
    [SerializeField] GameObject _firstButton;



    void Start()
    {
        _tm = GetComponent<TextMesh>();
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
        if (_tm.color == _defaultcolor)
        {
            _tm.color = _color;
        }
    }


    private void OnMouseExit()
    {
        _tm.color = _defaultcolor;
    }


    public void SelectBack()
    {
        _tm.color = _defaultcolor;
        _stageText.SetActive(false);
        _firstText.SetActive(true);
        _firstButton.SetActive(true);
        _stagebutton.SetActive(false);
    }
}
