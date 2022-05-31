using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour
{
    [SerializeField] Transform _setPos = default;
    [SerializeField] LayerMask _hookposlayer = default;
    [SerializeField] SpringJoint2D _sj = default;
    [SerializeField] LineRenderer _line = default;
    [SerializeField] float _jointDis;
    Vector3 _initialPosition;
    RaycastHit2D _hit;


    private void Start()
    {
        _sj.enabled = false;
        _line.enabled = false;

        _initialPosition = this.transform.position;
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))   //�E�N���b�N�����Ƃ�
        {
            //joint��line�̃I���I�t������
            if (_sj.enabled == false)
            {
                _sj.enabled = true;
                _sj.autoConfigureDistance = false;
                _line.enabled = true;

                WireSwing();

            }
            else
            {
                _sj.autoConfigureDistance = true;
                _sj.enabled = false;
                _line.enabled = false;
            }
        }


        if (_sj.distance == _jointDis)
        {
            _sj.autoConfigureDistance = true;
            _sj.enabled = false;
            _line.enabled = false;
        }
        Debug.DrawLine(transform.position, _hit.point);

        if (_hit)
        {
            //LineRenderer�̎n�_�I�_�̐ݒ�

            _line.SetPosition(0, this.transform.position);
            _line.SetPosition(1, _hit.point);
        }

        if (this.transform.position == _initialPosition)
        {
            _sj.autoConfigureDistance = true;
            _sj.enabled = false;
        }

    }


    void WireSwing()
    {

        WireShootLine();

        if (_hit)
        {
            _setPos.transform.position = _hit.point;
            _sj.connectedAnchor = _setPos.position;
        }
        else
        {
            _sj.autoConfigureDistance = true;
            _sj.enabled = false;
            _line.enabled = false;
        }
    }

    public void WireShootLine()
    {
        var mousePos = Input.mousePosition;  //�}�E�X���W���擾
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //�J�������W�ɕϊ�
        mousePos.z = 0;  //Z�������C��

        //���g�̈ʒu����}�E�X���W�̕����Ƀ��C���΂��ē��������R���C�_�[���ݒ肵�����C���[��������
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, 100, _hookposlayer);

    }


    //private void OnCollisionStay2D(Collision2D collision)
    //{

    //    //�ǂɂԂ������Ƃ��̏���
    //    if (collision.gameObject.tag == "Wall" && _springJoint2.distance >= 1)
    //    {
    //        _springJoint2.autoConfigureDistance = false;
    //        _springJoint2.distance--;
    //        _springJoint2.autoConfigureDistance = true;
    //    }
    //}

}
