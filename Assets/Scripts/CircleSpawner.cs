using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// —‚¿‚Ä‚­‚é‰~‚ğì‚é
/// </summary>
public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private CircleBehavior _circlePrefab = default;
    private List<CircleType> _circleTypes = new List<CircleType>();
    private int _circleCount = 0;
    [SerializeField] private Transform _spawnPoint = default;

    void Start()
    {
        
        //Å‰‚É‰½ŒÂ‚©İ’è‚µ‚Ä‚¨‚­
        for(int i = 0; i < 3; i++)
        {
            CreateCircleType();
        }

        SpawnCircle();
    }

    /// <summary>
    /// oŒ»‚·‚é‰~‚Ìí—Ş‚ğŒˆ‚ß‚Ä‚¢‚­
    /// </summary>
    public void CreateCircleType()
    {
        CircleType type = (CircleType)Random.Range(0, 12);
        _circleTypes.Add(type);
    }

    /// <summary>
    /// Œ»İ‚Ì‰~‚ğoŒ»‚³‚¹‚é
    /// </summary>
    public void SpawnCircle()
    {
        var circle = GameObject.Instantiate(_circlePrefab, _spawnPoint);
        circle.SetCircleType(_circleTypes[_circleCount]);
        _circleCount++;
        CreateCircleType();
    }

}
