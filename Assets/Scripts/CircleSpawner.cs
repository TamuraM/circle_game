using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �����Ă���~�����
/// </summary>
public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager = default;
    [SerializeField] private CircleBehavior[] _circlePrefabs = new CircleBehavior[0];
    private List<int> _circleTypes = new List<int>();
    private int _circleCount = 0;
    private int _circleCount2 = -1;
    [SerializeField] private Transform _spawnPoint = default;
    [SerializeField] private Player _player = default;

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
        int type = Random.Range(0, _circlePrefabs.Length);
        _circleTypes.Add(type);
    }

    /// <summary>
    /// ���݂̉~���o��������
    /// </summary>
    public void SpawnCircle()
    {
        int nowType = _circleTypes[_circleCount];
        var circle = GameObject.Instantiate(_circlePrefabs[nowType], _spawnPoint);
        circle.SetCircleSpawner(this);
        circle.SetPriorityNumber(_circleCount);
        _circleCount++;
        CreateCircleType();
        _player.SetNowCircle(circle.gameObject.GetComponent<Rigidbody2D>());
    }

    /// <summary>
    /// �~���m���������ĐV�����~���o��������Ƃ�
    /// </summary>
    /// <param name="spawnPoint"></param>
    /// <param name="nextCircle"></param>
    public void SpawnCircle(Vector3 spawnPoint, GameObject nextCircle, int circleIndex)
    {
        var instCircle = Instantiate(nextCircle, spawnPoint, Quaternion.identity);
        var circle = instCircle.GetComponent<CircleBehavior>();
        circle.SetIsCollidedTrue();
        circle.SetCircleSpawner(this);
        circle.SetPriorityNumber(_circleCount2);
        circle.GetComponent<Rigidbody2D>().simulated = true;
        _circleCount2--;
        _scoreManager.ScorePlus(circleIndex);
    }

}
