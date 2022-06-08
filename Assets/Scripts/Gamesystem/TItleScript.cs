using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScript : MonoBehaviour
{
    [SerializeField] Color _color;
    public void Scene()
    {
        SceneManager.LoadScene("Swing");
    }

    void OnMouseOver()
    {
        this.GetComponent<SpriteRenderer>().color = _color;
    }
}
