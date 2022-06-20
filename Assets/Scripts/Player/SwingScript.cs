using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    [SerializeField] LayerMask _hookPosLayer = default;
    [SerializeField] SpringJoint2D _sj = default;
    [SerializeField] LineRenderer _line = default;
    [SerializeField] float _hookInterval = 0;
    [SerializeField] float _hookLength;
    [SerializeField] GameObject _help;
    [SerializeField] GameObject _particle;
    float _hookTimer;
    //Vector3 RunScript_initialPosition;
    public static RaycastHit2D _hit;
    ParticleSystem _ps;


    void Start()
    {
        //jointとlineを切っておく
        Hookoff();

        RunScript._initialPosition = this.transform.position;

        _ps = _particle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (_help==null)
        {
            Debug.Log("_helpがアサインされてません");
        }
        if (RunScript._startTimer > 3 && _help.activeSelf == false)
        {
            Swing();
        }
        
        if (_sj.enabled == true)
        {
            _hookTimer += Time.deltaTime;
            
            if (_hookTimer > _hookInterval)
            {
                Hookoff();
            }
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
        
        if (this.transform.position == RunScript._initialPosition)
        {
            Hookoff();
            RunScript._death = false;
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
    }


    void HookSwing()
    {
        
        HookShootLine();

        if (_hit)
        {
            _sj.connectedAnchor = _hit.point;
            _particle.transform.position = _hit.point;
            _ps.Play();
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
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, _hookLength, _hookPosLayer);
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
        if (collision.gameObject.tag == "Wall" && _sj.distance >= 1 || collision.gameObject.tag == "Ground" && _sj.distance >= 1)
        {
            _sj.autoConfigureDistance = false;
            _sj.distance--;
            _sj.autoConfigureDistance = true;
        }
    }
}














