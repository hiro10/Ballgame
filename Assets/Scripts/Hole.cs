using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // どのボールを吸い寄せるかtagで指定
    [SerializeField] string targetTag = default;

    bool isHolding;

    public bool IsHolding()
    {
        return isHolding;
    }

    /// <summary>
    /// ゴール判定
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==targetTag)
        {
            // 決定音の再生
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
        // コライダーに触れたオブジェクトのrigidbodyの取得
        Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるかの計算
        Vector3 direction = other.gameObject.transform.position - transform.position;

        direction.Normalize();

        // タグに応じてボールに力を加える
        if(other.gameObject.tag == targetTag)
        {
            // 中心地点でボールを止めるため減速させる
            rigidbody.velocity *= 0.9f;// 1sに60回実行
            rigidbody.AddForce(direction * -20f, ForceMode.Acceleration);

        }
        else
        {
            rigidbody.AddForce(direction * 80f, ForceMode.Acceleration);
        }
    }
}
