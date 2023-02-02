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
    [SerializeField] private Text btntext;

    private void Start()
    {
        btntext = GetComponent<Text>();
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
        vector.z = Input.acceleration.y;
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

        Physics.gravity = Garavity * vector.normalized * garavityScale;

    }

    // ボタンを押したときの処理
    public void OnButtonDown()
    {
        buttonDownFlag = true;
        btntext.text = "重力";
    }

    public void OnButtonUp()
    {
        buttonDownFlag = false;
        btntext.text = "重力off";
    }
}
