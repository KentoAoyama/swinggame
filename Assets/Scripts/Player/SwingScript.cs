using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    [SerializeField] Transform _setPos = default;
    [SerializeField] LayerMask _hookPosLayer = default;
    [SerializeField] SpringJoint2D _sj = default;
    [SerializeField] LineRenderer _line = default;
    // float _hookInterval = 10f;
    //float _hookTimer;

    Vector3 _initialPosition;
    RaycastHit2D _hit;


    private void Start()
    {
        //jointとlineを切っておく
        _sj.enabled = false;
        _line.enabled = false;

        _initialPosition = this.transform.position;
    }

    private void Update()
    {
        Swing();

        if (this.transform.position == _initialPosition)
        {
            _sj.enabled = false;
            _line.enabled = false;
        }
    }

    private void LateUpdate()
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
            //_hookTimer += Time.deltaTime;

            //jointとlineのオンオフをする
            if (_sj.enabled == false)
            {
                _sj.enabled = true;
                _line.enabled = true;

                HookSwing();
            }
            else
            {
                _sj.enabled = false;
                _line.enabled = false;
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
            _sj.enabled = false;
            _line.enabled = false;
        }
    }


    public void HookShootLine()
    {
        var mousePos = Input.mousePosition;  //マウス座標を取得
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //カメラ座標に変換
        mousePos.z = 0;  //Z軸だけ修正

        //自身の位置からマウス座標の方向にレイを飛ばして当たったコライダーが設定したレイヤーだったら
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, 100, _hookPosLayer);
    }


    private void OnCollisionStay2D(Collision2D collision)
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














