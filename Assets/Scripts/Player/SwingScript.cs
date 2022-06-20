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
        //joint��line��؂��Ă���
        Hookoff();

        RunScript._initialPosition = this.transform.position;

        _ps = _particle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (_help==null)
        {
            Debug.Log("_help���A�T�C������Ă܂���");
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
            //LineRenderer�̎n�_�I�_�̐ݒ�
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
        if (Input.GetButtonDown("Fire1"))   //���N���b�N�����Ƃ�
        {

            //joint��line�̃I���I�t������
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
        var mousePos = Input.mousePosition;  //�}�E�X���W���擾
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //�J�������W�ɕϊ�
        mousePos.z = 0;  //Z�������C��

        //���g�̈ʒu����}�E�X���W�̕����Ƀ��C���΂��ē��������R���C�_�[���ݒ肵�����C���[��������
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, _hookLength, _hookPosLayer);
    }

     
    void Hookoff()
    {
        _sj.enabled = false;  //���Ԍo�߂Ńt�b�N��؂�
        _line.enabled = false;
        _hookTimer = 0;
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        //�ǂɂԂ������Ƃ��̏���
        if (collision.gameObject.tag == "Wall" && _sj.distance >= 1 || collision.gameObject.tag == "Ground" && _sj.distance >= 1)
        {
            _sj.autoConfigureDistance = false;
            _sj.distance--;
            _sj.autoConfigureDistance = true;
        }
    }
}














