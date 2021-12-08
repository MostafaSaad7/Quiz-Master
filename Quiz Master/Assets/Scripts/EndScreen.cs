using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoreText;
    ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {


        finalscoreText.text="Congrateulations!!\n You got a score of "+ scoreKeeper.CalculateScore()+"%";
    }

}
