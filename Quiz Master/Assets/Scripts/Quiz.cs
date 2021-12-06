using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
    {

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [SerializeField] GameObject [] answersButtons;

    [SerializeField] int correctAnswerIndex;

    [SerializeField] Sprite defaultAnswerSprite;

   [SerializeField] Sprite correctAnswerSprite;
    void Start()
    {
        DisplayQuestions();
         
    }


    public void onAnswerSelected (int index)
    {

        if(index==question.GetCorrectAnswerIndex())
        {   
            questionText.text="Correct!!";
            Image buttonImage = answersButtons[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;


        }


        else 
        {
            correctAnswerIndex=question.GetCorrectAnswerIndex();

            questionText.text="Sorry the correct answer was; \n"+question.GetAnswer(correctAnswerIndex);

            Image buttonImage=answersButtons[correctAnswerIndex].GetComponent<Image>();

            buttonImage.sprite=correctAnswerSprite;

        }

        setButtonState(false);

    }



    void DisplayQuestions()
    {
                
        questionText.text=question.GetQuestion();

        for(int i=0 ;i< 4 ;i++)
        
        {
            TextMeshProUGUI buttonText=answersButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text=question.GetAnswer(i); 
        }





    }

    void GetNextQuestion()
    {

        setButtonState(true);
        setDefaultButtonSprites();
        DisplayQuestions();
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
