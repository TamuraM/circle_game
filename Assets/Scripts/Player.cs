using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの動き
/// </summary>
public class Player : MonoBehaviour
{
    private InputAction _moveAction, _fireAction;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _minX = -5;
    [SerializeField] private float _maxX = 5;
    [SerializeField] private Rigidbody2D _nowCircle = null;

    void Start()
    {
        //InputSystemを読み込む
        var playerInput = GetComponent<PlayerInput>();
        var actionMap = playerInput.currentActionMap;
        _moveAction = actionMap["Move"];
        _fireAction = actionMap["Fire"];
    }

    void Update()
    {
        //入力で左右に動かす
        float moveX = transform.position.x + _moveAction.ReadValue<float>() * _speed * Time.deltaTime;
        
        if(moveX < _minX) moveX = _minX;
        if(moveX > _maxX) moveX = _maxX;

        transform.position = new Vector3(moveX, transform.position.y, 0);

        if (!_nowCircle) return;

        //円を落とす
        if(_fireAction.triggered)
        {
            Debug.Log("落とした");
            _nowCircle.gameObject.transform.parent = null;
            _nowCircle.simulated = true;
            _nowCircle = null;
        }

    }

    public void SetNowCircle(Rigidbody2D circle)
    {
        _nowCircle = circle;
    }

}
