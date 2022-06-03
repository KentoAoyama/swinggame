using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookLine : MonoBehaviour
{
    //[SerializeField] Transform _setPos = default;

    [SerializeField] LayerMask _hookposlayer = default;
    [SerializeField] LineRenderer _line = default;
    RaycastHit2D _hit;

    
    private void Start()
    {
        _line.enabled = false;
    }

   
    private void FixedUpdate()
    {
        var mousePos = Input.mousePosition;  //マウス座標を取得
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //カメラ座標に変換
        mousePos.z = 0;  //Z軸だけ修正

        //自身の位置からマウス座標の方向にレイを飛ばして当たったコライダーが設定したレイヤーだったら
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, 100, _hookposlayer);
        
        Debug.DrawLine(this.transform.position,_hit.point);

        if (_hit)
        {
            _line.enabled = true;

            //LineRendererの始点終点の設定
            _line.SetPosition(0, this.transform.position);
            _line.SetPosition(1, _hit.point);
        }
        else
        {
            _line.enabled = false;
        }

    }




}



