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
        var mousePos = Input.mousePosition;  //�}�E�X���W���擾
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);  //�J�������W�ɕϊ�
        mousePos.z = 0;  //Z�������C��

        //���g�̈ʒu����}�E�X���W�̕����Ƀ��C���΂��ē��������R���C�_�[���ݒ肵�����C���[��������
        _hit = Physics2D.Raycast(this.transform.position, mousePos - transform.position, 100, _hookposlayer);
        
        Debug.DrawLine(this.transform.position,_hit.point);

        if (_hit)
        {
            _line.enabled = true;

            //LineRenderer�̎n�_�I�_�̐ݒ�
            _line.SetPosition(0, this.transform.position);
            _line.SetPosition(1, _hit.point);
        }
        else
        {
            _line.enabled = false;
        }

    }




}



