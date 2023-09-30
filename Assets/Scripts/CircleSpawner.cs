using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 落ちてくる円を作る
/// </summary>
public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private CircleBehavior _circlePrefab = default;
    private List<CircleType> _circleTypes = new List<CircleType>();
    private int _circleCount = 0;
    [SerializeField] private Transform _spawnPoint = default;

    void Start()
    {
        
        //最初に何個か設定しておく
        for(int i = 0; i < 3; i++)
        {
            CreateCircleType();
        }

        SpawnCircle();
    }

    /// <summary>
    /// 出現する円の種類を決めていく
    /// </summary>
    public void CreateCircleType()
    {
        CircleType type = (CircleType)Random.Range(0, 12);
        _circleTypes.Add(type);
    }

    /// <summary>
    /// 現在の円を出現させる
    /// </summary>
    public void SpawnCircle()
    {
        var circle = GameObject.Instantiate(_circlePrefab, _spawnPoint);
        circle.SetCircleType(_circleTypes[_circleCount]);
        _circleCount++;
        CreateCircleType();
    }

}
