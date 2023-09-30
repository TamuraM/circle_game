using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int[] _scores = new int[4];
    private int _score = 0;

    [SerializeField] private Text _scoreText = default;

    private void Start()
    {
        _scoreText.text = "0";
    }

    public void ScorePlus(int index)
    {
        _score += _scores[index];
        _scoreText.text = _score.ToString();
    }

}
