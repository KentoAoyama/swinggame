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


    private void Start()
    {
        _tm = GetComponent<TextMesh>();
        _defaultcolor = _tm.color;
    }

    
    private void OnMouseOver()
    {
        _tm.color = _color;
        Debug.Log("OK");
    }

    
    private void OnMouseExit()
    {
        _tm.color = _defaultcolor;
    }


    public void NextScene(string y)
    {
        SceneManager.LoadScene(y);
    }

    //public void NextSelect(GameObject j, GameObject k)
    //{
    //    j.SetActive(true);
    //    k.SetActive(true);
    //    this.gameObject.SetActive(false);
    //}
}
