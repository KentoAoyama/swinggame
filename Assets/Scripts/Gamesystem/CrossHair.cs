using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// </summary>
public class CrossHair : MonoBehaviour
{

    
    void Start()
    {
        Cursor.visible = false;
    }

    
    void FixedUpdate()
    {
        var pos = Input.mousePosition;
        pos.z = 10;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(pos);

        this.transform.position = mousePosition;
    }
}
