using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Quiz Question",fileName ="New Question")]
public class QuestionSO : ScriptableObject
{

 //minimun 2 lines && max of 6 lines    
 [TextArea(2,6)]   
[SerializeField] string question="Enter new question text here";
[SerializeField] string [] answers =new string[4] ;
[SerializeField]int correctAnswerIndex;


public string GetQuestion()
{

return question;


} 

public int  GetCorrectAnswerIndex()
{

    return correctAnswerIndex;

}

public string GetAnswer (int index)
{

return answers[index];

}


}
