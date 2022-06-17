using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    [SerializeField] GameObject _help;
    GameObject _crosshair;
    Animator _anime;

    private void Start()
    {
        _crosshair = GameObject.Find("Crosshair");
        _anime = _help.GetComponent<Animator>();
        _help.SetActive(false);
    }


    public void HelpOn()
    {
        if (GoalLineScript._goal != true)
        {
            StartCoroutine(Helpon());
        }
    }

    public void Help0ff()
    {
        StartCoroutine(Helpoff());
    }


    IEnumerator Helpon()
    {
        _help.SetActive(true);
        Cursor.visible = true;
        _crosshair.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
    }

    IEnumerator Helpoff()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        _crosshair.SetActive(true);
        _anime.SetBool("HelpOff", true);
        yield return new WaitForSeconds(0.2f);
        _help.SetActive(false);
    }
}
