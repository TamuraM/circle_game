using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �~�̓���
/// </summary>
public class CircleBehavior : MonoBehaviour
{
    [SerializeField] private CircleType _type = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.TryGetComponent(out CircleBehavior circleBehavior))
        {
            Debug.Log("�~���m�ł�������");

            if (!circleBehavior.IsSameType(_type)) return;

            Debug.Log("������ޓ��m�ł�������");
        }

    }


    /// <summary>
    /// �~�̎�ނ�ݒ肷��
    /// </summary>
    /// <param name="circleType">�ݒ肵�������</param>
    public void SetCircleType(CircleType circleType)
    {
        _type = circleType;
    }

    /// <summary>
    /// ���������~��������ނ��ǂ�����Ԃ�
    /// </summary>
    /// <param name="other">�Ăяo�����̎��</param>
    /// <returns>������ނ�������true</returns>
    public bool IsSameType(CircleType other)
    {
        return _type == other;
    }

}
