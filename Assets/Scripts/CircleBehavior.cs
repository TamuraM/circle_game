using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 円の動き
/// </summary>
public class CircleBehavior : MonoBehaviour
{
    [SerializeField] private CircleType _type = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.TryGetComponent(out CircleBehavior circleBehavior))
        {
            Debug.Log("円同士であたった");

            if (!circleBehavior.IsSameType(_type)) return;

            Debug.Log("同じ種類同士であたった");
        }

    }


    /// <summary>
    /// 円の種類を設定する
    /// </summary>
    /// <param name="circleType">設定したい種類</param>
    public void SetCircleType(CircleType circleType)
    {
        _type = circleType;
    }

    /// <summary>
    /// 当たった円が同じ種類かどうかを返す
    /// </summary>
    /// <param name="other">呼び出す側の種類</param>
    /// <returns>同じ種類だったらtrue</returns>
    public bool IsSameType(CircleType other)
    {
        return _type == other;
    }

}
