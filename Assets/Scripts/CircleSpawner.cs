using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����Ă���~�����
/// </summary>
public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private CircleBehavior _circlePrefab = default;
    private List<CircleType> _circleTypes = new List<CircleType>();
    private int _circleCount = 0;
    [SerializeField] private Transform _spawnPoint = default;

    void Start()
    {
        
        //�ŏ��ɉ����ݒ肵�Ă���
        for(int i = 0; i < 3; i++)
        {
            CreateCircleType();
        }

        SpawnCircle();
    }

    /// <summary>
    /// �o������~�̎�ނ����߂Ă���
    /// </summary>
    public void CreateCircleType()
    {
        CircleType type = (CircleType)Random.Range(0, 12);
        _circleTypes.Add(type);
    }

    /// <summary>
    /// ���݂̉~���o��������
    /// </summary>
    public void SpawnCircle()
    {
        var circle = GameObject.Instantiate(_circlePrefab, _spawnPoint);
        circle.SetCircleType(_circleTypes[_circleCount]);
        _circleCount++;
        CreateCircleType();
    }

}
