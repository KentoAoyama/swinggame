using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    [SerializeField] Transform _setPos = default;
    [SerializeField] LayerMask _hookPosLayer = default;
    [SerializeField] SpringJoint2D _sj = default;
    [SerializeField] LineRenderer _line = default;
    [SerializeField] float _hookInterval = 0;
    float _hookTimer;
    Vector3 _initialPos;
    RaycastHit2D _hit;


    void Start()
    {
        //jointとlineを切っておく
        Hookoff();

        _initialPos = this.transform.position;
    }

    void Update()
    {
        
        Swing();

        
        if (_sj.enabled == true)
        {
            _hookTimer += Time.deltaTime;
            
            if (_hookTimer > _hookInterval)
            {
                Hookoff();
            }
        }
        
        
        if (this.transform.position == _initialPos)
        {
            Hookoff();
        }
    }

    void LateUpdate()
    {
        if (_hit)
        {
            //LineRendererの始点終点の設定
            _line.SetPosition(0, this.transform.position);
            _line.SetPosition(1, _hit.point);
        }
    }

    void Swing()
    {
        if (Input.GetButtonDown("Fire1"))   //左クリックしたとき
        {

            //jointとlineのオンオフをする
            if (_sj.enabled == false)
            {
                _sj.enabled = true;
                _line.enabled = true;

                HookSwing();
            }
            else
            {
                Hookoff();
            }

        }
        Debug.DrawLine(transform.position, _hit.point);
    }


    void HookSwing()
    {
        
        HookShootLine();

        if (_hit)
        {
            _setPos.transform.position = _hit.point;
            _sj.connectedAnchor = _setPos.position;            
        }
        else
        {
            Hookoff();
        }
    }


    void HookShootLine()
    {
        var mousePos = Input.mousePosition;  //マウス座標を取得
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //カメラ座標に変換
        mousePos.z = 0;  //Z軸だけ修正

        //自身の位置からマウス座標の方向にレイを飛ばして当たったコライダーが設定したレイヤーだったら
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, 100, _hookPosLayer);
    }

     
    void Hookoff()
    {
        _sj.enabled = false;  //時間経過でフックを切る
        _line.enabled = false;
        _hookTimer = 0;
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        //壁にぶつかったときの処理
        if (collision.gameObject.tag == "Wall" && _sj.distance >= 1)
        {
            _sj.autoConfigureDistance = false;
            _sj.distance--;
            _sj.autoConfigureDistance = true;
        }
    }
}














