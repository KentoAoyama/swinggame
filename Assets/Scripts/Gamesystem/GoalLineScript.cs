using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalLineScript : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _player;

    void Start()
    {
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
        Time.timeScale = 0.5f;
        _panel.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("TitleScene");
    }
}
