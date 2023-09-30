using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �~�̓���
/// </summary>
public class CircleBehavior : MonoBehaviour
{
    [SerializeField] private CircleType _type = default;
    [SerializeField] private CircleSpawner _spawner = default;
    [SerializeField] private GameObject[] _circles = new GameObject[0];
    private bool _isCollided = false;
    private int _priorityNumber = 0;
    public int PriorityNumber => _priorityNumber;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(!_isCollided)
        {
            _spawner.SpawnCircle();
            _isCollided = true;
        }

        if(collision.gameObject.TryGetComponent(out CircleBehavior circleBehavior))
        {
            Debug.Log("�~���m�ł�������");

            //�Ⴄ��ނȂ炱���ŏI���
            if (!circleBehavior.IsSameType(_type)) return;

            Debug.Log("������ޓ��m�ł�������");

            //����̂ق����̂������炱���ŏI���
            if (_priorityNumber < circleBehavior.PriorityNumber) return;

            //�܂��オ����΁A�ЂƂ�̉~���o��������
            if((int)_type < _circles.Length - 1)
            {
                Vector3 instPos = transform.position + 
                    Vector3.Normalize(transform.position - collision.transform.position) * transform.localScale.x / 2;
                var nextType = _circles[(int)_type + 1];
                _spawner.SpawnCircle(instPos, nextType, (int)_type + 1);
                Debug.Log("�ЂƂ�̉~���o��������");
            }

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }

    /// <summary>
    /// ���̉~�̗D�揇�ʂ����߂�
    /// </summary>
    /// <param name="num">���������ԖڂɈ̂���</param>
    public void SetPriorityNumber(int num)
    {
        _priorityNumber = num;
    }

    /// <summary>
    /// CircleSpawner�̎Q�Ƃ�ݒ肷��
    /// </summary>
    /// <param name="circleSpawner"></param>
    public void SetCircleSpawner(CircleSpawner circleSpawner)
    {
        _spawner = circleSpawner;
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

    public void SetIsCollidedTrue()
    {
        _isCollided = true;
    }

}
