using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ‰~‚Ì“®‚«
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
            Debug.Log("‰~“¯m‚Å‚ ‚½‚Á‚½");

            //ˆá‚¤í—Ş‚È‚ç‚±‚±‚ÅI‚í‚è
            if (!circleBehavior.IsSameType(_type)) return;

            Debug.Log("“¯‚¶í—Ş“¯m‚Å‚ ‚½‚Á‚½");

            //‘Šè‚Ì‚Ù‚¤‚ªˆÌ‚©‚Á‚½‚ç‚±‚±‚ÅI‚í‚è
            if (_priorityNumber < circleBehavior.PriorityNumber) return;

            //‚Ü‚¾ã‚ª‚ ‚ê‚ÎA‚Ğ‚Æ‚Âã‚Ì‰~‚ğoŒ»‚³‚¹‚é
            if((int)_type < _circles.Length - 1)
            {
                Vector3 instPos = transform.position + 
                    Vector3.Normalize(transform.position - collision.transform.position) * transform.localScale.x / 2;
                var nextType = _circles[(int)_type + 1];
                _spawner.SpawnCircle(instPos, nextType, (int)_type + 1);
                Debug.Log("‚Ğ‚Æ‚Âã‚Ì‰~‚ğoŒ»‚³‚¹‚½");
            }

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }

    /// <summary>
    /// ‚±‚Ì‰~‚Ì—Dæ‡ˆÊ‚ğŒˆ‚ß‚é
    /// </summary>
    /// <param name="num">‚±‚¢‚Â‚ª‰½”Ô–Ú‚ÉˆÌ‚¢‚©</param>
    public void SetPriorityNumber(int num)
    {
        _priorityNumber = num;
    }

    /// <summary>
    /// CircleSpawner‚ÌQÆ‚ğİ’è‚·‚é
    /// </summary>
    /// <param name="circleSpawner"></param>
    public void SetCircleSpawner(CircleSpawner circleSpawner)
    {
        _spawner = circleSpawner;
    }

    /// <summary>
    /// “–‚½‚Á‚½‰~‚ª“¯‚¶í—Ş‚©‚Ç‚¤‚©‚ğ•Ô‚·
    /// </summary>
    /// <param name="other">ŒÄ‚Ño‚·‘¤‚Ìí—Ş</param>
    /// <returns>“¯‚¶í—Ş‚¾‚Á‚½‚çtrue</returns>
    public bool IsSameType(CircleType other)
    {
        return _type == other;
    }

    public void SetIsCollidedTrue()
    {
        _isCollided = true;
    }

}
