using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalLineScript : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _result;
    [SerializeField] GameObject _player;
    public static bool _goal;

    void Start()
    {
        _result.SetActive(false);
        _panel.SetActive(false);
    }



    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == _player)
        {
            StartCoroutine("Goal");
        }
    }


    IEnumerator Goal()
    {
        _goal = true;
        Time.timeScale = 0.5f;
        _panel.SetActive(true);
        yield return new WaitForSeconds(1);
        _result.SetActive(true);
        Time.timeScale = 1.0f;
    }
    //SceneManager.LoadScene("TitleScene");
}
