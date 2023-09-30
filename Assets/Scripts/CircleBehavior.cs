using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‰~‚Ì“®‚«
/// </summary>
public class CircleBehavior : MonoBehaviour
{
    [SerializeField] private CircleType _type = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.TryGetComponent(out CircleBehavior circleBehavior))
        {
            Debug.Log("‰~“¯m‚Å‚ ‚½‚Á‚½");

            if (!circleBehavior.IsSameType(_type)) return;

            Debug.Log("“¯‚¶í—Ş“¯m‚Å‚ ‚½‚Á‚½");
        }

    }


    /// <summary>
    /// ‰~‚Ìí—Ş‚ğİ’è‚·‚é
    /// </summary>
    /// <param name="circleType">İ’è‚µ‚½‚¢í—Ş</param>
    public void SetCircleType(CircleType circleType)
    {
        _type = circleType;
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

}
