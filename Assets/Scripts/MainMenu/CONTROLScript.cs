using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTROLScript : MonoBehaviour
{
    [SerializeField] Color _color;
    [SerializeField] Color _defaultcolor;
    [SerializeField] GameObject _help;
    [SerializeField] float _changeSpeed = 1;
    TextMesh _tm;
    GameObject _crosshair;
    Animator _anime;


    void Start()
    {
        _tm = GetComponent<TextMesh>();
        _help.SetActive(false);
        _crosshair = GameObject.Find("Crosshair");
        _anime = _help.GetComponent<Animator>();
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


    public void Help()
    {
        _help.SetActive(true);
        Cursor.visible = true;
        _crosshair.SetActive(false);
    }

    public void Helpoff()
    {
        Cursor.visible = false;
        _crosshair.SetActive(true);
        _anime.SetBool("HelpOff", true);
        Invoke("HelpOff", 0.3f);
    }

    void HelpOff()
    {
        _help.SetActive(false);
    }
}
