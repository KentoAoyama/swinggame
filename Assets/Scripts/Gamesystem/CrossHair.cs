using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// </summary>
public class CrossHair : MonoBehaviour
{
    //[SerializeField] LineRenderer _line = default;
    //[SerializeField] Transform _player = default;

    
    void Start()
    {
        Cursor.visible = false;
        //_line.enabled = false;

    }

    
    void FixedUpdate()
    {
        var pos = Input.mousePosition;
        pos.z = 10;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(pos);

        this.transform.position = mousePosition;
        //mousePosition.z = 0;
    }
}
