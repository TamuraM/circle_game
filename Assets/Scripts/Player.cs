using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C���[�̓���
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
        //InputSystem��ǂݍ���
        var playerInput = GetComponent<PlayerInput>();
        var actionMap = playerInput.currentActionMap;
        _moveAction = actionMap["Move"];
        _fireAction = actionMap["Fire"];
    }

    void Update()
    {
        //���͂ō��E�ɓ�����
        float moveX = transform.position.x + _moveAction.ReadValue<float>() * _speed * Time.deltaTime;
        
        if(moveX < _minX) moveX = _minX;
        if(moveX > _maxX) moveX = _maxX;

        transform.position = new Vector3(moveX, transform.position.y, 0);

        if (!_nowCircle) return;

        //�~�𗎂Ƃ�
        if(_fireAction.triggered)
        {
            Debug.Log("���Ƃ���");
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
