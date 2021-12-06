using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
   [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    public bool loadNextQuestion;
    public float fillFraction;
    public bool isAnsweringQuestion;
    float timerValue;
    void Update()
    {

        updateTimer();

        
    }

    public void cancleTimer()
    {
        timerValue=0;
    }

    void updateTimer()
    {
        timerValue-=Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue>0)
            {
                fillFraction=timerValue/timeToCompleteQuestion;


            }
            else 
            {

                isAnsweringQuestion=false;
                timerValue = timeToShowAnswer;

            }

        }
        else
        {
               if(timerValue>0)
            {
                fillFraction=timerValue/timeToShowAnswer;


            }
            else 
            {

                isAnsweringQuestion=true;;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion=true;

            }




        }



    }



}

