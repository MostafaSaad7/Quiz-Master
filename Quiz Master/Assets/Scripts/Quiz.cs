using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
    {

        [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    QuestionSO Currentquestion;
    [SerializeField] List<QuestionSO> questions=new List<QuestionSO>();

    [Header("Answers")]
    [SerializeField] GameObject [] answersButtons;
    [SerializeField] int correctAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
   [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image TimerImage;
    Timer timer;

    void Start()
    {
        timer =FindObjectOfType<Timer>();
         
    }


      void Update() {
        
          TimerImage.fillAmount=timer.fillFraction;
          if(timer.loadNextQuestion)
          {
              hasAnsweredEarly=false;
              GetNextQuestion();
              timer.loadNextQuestion=false;

          }

          else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
          {
              DisplayAnswer(-1);
              setButtonState(false);

          }

        
    }


    public void onAnswerSelected (int index)
    {
        hasAnsweredEarly=true;
        DisplayAnswer(index);
        setButtonState(false);
        timer.cancleTimer();

    }

    void DisplayAnswer (int index)
    {   
        
        if(index==Currentquestion.GetCorrectAnswerIndex())
        {   
            questionText.text="Correct!!";
            Image buttonImage = answersButtons[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;


        }


        else 
        {
            correctAnswerIndex=Currentquestion.GetCorrectAnswerIndex();

            questionText.text="Sorry the correct answer was; \n"+Currentquestion.GetAnswer(correctAnswerIndex);

            Image buttonImage=answersButtons[correctAnswerIndex].GetComponent<Image>();

            buttonImage.sprite=correctAnswerSprite;

        }


    }


    void DisplayQuestions()
    {
                
        questionText.text=Currentquestion.GetQuestion();

        for(int i=0 ;i< 4 ;i++)
        
        {
            TextMeshProUGUI buttonText=answersButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text=Currentquestion.GetAnswer(i); 
        }





    }

    void GetNextQuestion()
    {   
        if(questions.Count>0)
        {
        setButtonState(true);
        setDefaultButtonSprites();
        GetRandomQuestion();
        DisplayQuestions();
    }
    }



    void GetRandomQuestion(){

        int index = Random.Range(0,questions.Count);
        Currentquestion=questions[index];

        if(questions.Contains(Currentquestion))
        questions.Remove(Currentquestion);
    }
    void setButtonState(bool state) 
    {
        for (int i = 0 ; i<answersButtons.Length;i++)
        {
            Button button = answersButtons[i].GetComponent<Button>();
            button.interactable=state;



        }
    }



    void setDefaultButtonSprites(){
         for(int i=0 ;i< answersButtons.Length ;i++)
        
        {
            Image buttonImage=answersButtons[i].GetComponentInChildren<Image>();
            buttonImage.sprite=defaultAnswerSprite;
    
            }





    }
}
