using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectStageScript : MonoBehaviour
{
    [SerializeField] Color _color;
    Color _defaultcolor;
    TextMesh _tm;


    void Start()
    {
        _tm = GetComponent<TextMesh>();
        _defaultcolor = _tm.color;

    }


    void Update()
    {
        
    }

    
    private void OnMouseOver()
    {
        _tm.color = _color;
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
