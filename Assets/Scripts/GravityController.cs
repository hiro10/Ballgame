using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityController : MonoBehaviour
{
    //重力加速度
    const float Garavity = 9.81f;
    
    // 重力の適用具合
    public float garavityScale = 1.0f;

    Vector3 vector = new Vector3();

    // ボタンを押したときtrue、離したときfalseになるフラグ
    private bool buttonDownFlag = false;
    private void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Main);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        var dir = Vector3.zero;

#if UNITY_ANDROID
        //ターゲット端末の縦横の表示に合わせてremapする
        vector.x = Input.acceleration.x;
        vector.y = Input.acceleration.y;
        vector.z = Input.acceleration.z;
#endif
        // キー入力
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
            // normalized 正規化
            Physics.gravity = Garavity * vector.normalized * garavityScale;
        }
    }

    // ボタンを押したときの処理
    public void OnButtonDown()
    {
        buttonDownFlag = true;
    }

    public void OnButtonUp()
    {
        buttonDownFlag = false;
    }
}
