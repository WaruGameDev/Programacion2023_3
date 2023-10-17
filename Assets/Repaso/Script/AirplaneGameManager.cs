using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AirplaneGameManager : MonoBehaviour
{
    public static AirplaneGameManager instance;
    public int score;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AddPoint(0);
    }

    public void AddPoint(int amount)
    {
        score += amount;
        scoreText.text = "Puntos: " + score;
    }
}
