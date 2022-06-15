using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTROLScript : MonoBehaviour
{
    [SerializeField] Color _color;
    [SerializeField] GameObject _help;
    Color _defaultcolor;
    TextMesh _tm;


    void Start()
    {
        _tm = GetComponent<TextMesh>();
        _defaultcolor = _tm.color;
        _help.SetActive(false);
    }

    
    private void OnMouseOver()
    {
        _tm.color = _color;
    }


    private void OnMouseExit()
    {
        _tm.color = _defaultcolor;
    }


    public void Help()
    {
        _help.SetActive(true);
    }
}
