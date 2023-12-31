using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 円の動き
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
            Debug.Log("円同士であたった");

            //違う種類ならここで終わり
            if (!circleBehavior.IsSameType(_type)) return;

            Debug.Log("同じ種類同士であたった");

            //相手のほうが偉かったらここで終わり
            if (_priorityNumber < circleBehavior.PriorityNumber) return;

            //まだ上があれば、ひとつ上の円を出現させる
            if((int)_type < _circles.Length - 1)
            {
                Vector3 instPos = transform.position + 
                    Vector3.Normalize(transform.position - collision.transform.position) * transform.localScale.x / 2;
                var nextType = _circles[(int)_type + 1];
                _spawner.SpawnCircle(instPos, nextType, (int)_type + 1);
                Debug.Log("ひとつ上の円を出現させた");
            }

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }

    /// <summary>
    /// この円の優先順位を決める
    /// </summary>
    /// <param name="num">こいつが何番目に偉いか</param>
    public void SetPriorityNumber(int num)
    {
        _priorityNumber = num;
    }

    /// <summary>
    /// CircleSpawnerの参照を設定する
    /// </summary>
    /// <param name="circleSpawner"></param>
    public void SetCircleSpawner(CircleSpawner circleSpawner)
    {
        _spawner = circleSpawner;
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

    public void SetIsCollidedTrue()
    {
        _isCollided = true;
    }

}
