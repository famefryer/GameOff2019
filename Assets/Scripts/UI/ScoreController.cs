using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private void Update()
    {
        UpdateValue(GameManager.Instance.currentScore);
    }
    public void UpdateValue(int value)
    {
        string[] texts = scoreText.text.Split(':');
        scoreText.text = texts[0] + ": " + value;
    }

}
