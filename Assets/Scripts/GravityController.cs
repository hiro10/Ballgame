using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityController : MonoBehaviour
{
    //�d�͉����x
    const float Garavity = 9.81f;
    
    // �d�͂̓K�p�
    public float garavityScale = 1.0f;

    Vector3 vector = new Vector3();

    // �{�^�����������Ƃ�true�A�������Ƃ�false�ɂȂ�t���O
    private bool buttonDownFlag = false;
    private void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Main);
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void Update()
    {
        var dir = Vector3.zero;

#if UNITY_ANDROID
        //�^�[�Q�b�g�[���̏c���̕\���ɍ��킹��remap����
        vector.x = Input.acceleration.x;
        vector.y = Input.acceleration.y;
        vector.z = Input.acceleration.z;
#endif
        // �L�[����
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");

        if (buttonDownFlag==true)
        {
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }
        if (vector.magnitude > 0.1f)
        {
            // normalized ���K��
            Physics.gravity = Garavity * vector.normalized * garavityScale;
        }
    }

    // �{�^�����������Ƃ��̏���
    public void OnButtonDown()
    {
        buttonDownFlag = true;
    }

    public void OnButtonUp()
    {
        buttonDownFlag = false;
    }
}
