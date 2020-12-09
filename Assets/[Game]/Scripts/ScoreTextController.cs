using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTextController : MonoBehaviour
{
    private Text scoreText;
    public Text ScoreText
    {
        get
        {
            if (scoreText == null)
                scoreText = GetComponent<Text>();

            return scoreText;
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    //Obje Aktif Edildiginde
    private void OnEnable()
    {
        EventManager.OnCoinPickUp.AddListener(UpdateScoreText);
    }

    //Obje pasif hale geldiginde
    private void OnDisable()
    {
        EventManager.OnCoinPickUp.RemoveListener(UpdateScoreText);
    }


    private void UpdateScoreText()
    {
        int point = FindObjectOfType<Player>().point;
        ScoreText.text = "Score " + point;
    }
}
