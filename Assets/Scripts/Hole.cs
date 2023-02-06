using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // �ǂ̃{�[�����z���񂹂邩tag�Ŏw��
    [SerializeField] string targetTag = default;

    bool isHolding;

    public bool IsHolding()
    {
        return isHolding;
    }

    /// <summary>
    /// �S�[������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==targetTag)
        {
            // ���艹�̍Đ�
            SoundManager.instance.PlaySE(SoundManager.SE.Gole);
            isHolding = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // �R���C�_�[�ɐG�ꂽ�I�u�W�F�N�g��rigidbody�̎擾
        Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();

        // �{�[�����ǂ̕����ɂ��邩�̌v�Z
        Vector3 direction = other.gameObject.transform.position - transform.position;

        direction.Normalize();

        // �^�O�ɉ����ă{�[���ɗ͂�������
        if(other.gameObject.tag == targetTag)
        {
            // ���S�n�_�Ń{�[�����~�߂邽�ߌ���������
            rigidbody.velocity *= 0.9f;// 1s��60����s
            rigidbody.AddForce(direction * -20f, ForceMode.Acceleration);

        }
        else
        {
            rigidbody.AddForce(direction * 80f, ForceMode.Acceleration);
        }
    }
}
