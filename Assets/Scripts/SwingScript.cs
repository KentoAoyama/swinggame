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
        //joint��line��؂��Ă���
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
            //LineRenderer�̎n�_�I�_�̐ݒ�
            _line.SetPosition(0, this.transform.position);
            _line.SetPosition(1, _hit.point);
        }
    }

    void Swing()
    {
        if (Input.GetButtonDown("Fire1"))   //���N���b�N�����Ƃ�
        {
            //_hookTimer += Time.deltaTime;

            //joint��line�̃I���I�t������
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
        var mousePos = Input.mousePosition;  //�}�E�X���W���擾
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //�J�������W�ɕϊ�
        mousePos.z = 0;  //Z�������C��

        //���g�̈ʒu����}�E�X���W�̕����Ƀ��C���΂��ē��������R���C�_�[���ݒ肵�����C���[��������
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, 100, _hookPosLayer);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //�ǂɂԂ������Ƃ��̏���
        if (collision.gameObject.tag == "Wall" && _sj.distance >= 1)
        {
            _sj.autoConfigureDistance = false;
            _sj.distance--;
            _sj.autoConfigureDistance = true;
        }
    }
}














