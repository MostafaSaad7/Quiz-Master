using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Quiz Question",fileName ="New Question")]
public class QuestionSO : ScriptableObject
{

 //minimun 2 lines && max of 6 lines    
 [TextArea(2,6)]   
[SerializeField]string question="Enter new question text here";


public string getQuestion()
{

return question;


} 

}
