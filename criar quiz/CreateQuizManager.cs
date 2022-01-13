using UnityEngine;
using UnityEngine.UI;


public class CreateQuizManager : MonoBehaviour {
    [SerializeField] private InputField question;
    [SerializeField] private InputField answer;
    [SerializeField] private InputField[] options;

    [SerializeField] private Button buttonSave;


    public void EnableSave(string value) {
        if(string.IsNullOrEmpty(value))
            return;
        
        foreach(InputField correct in options) {
            if(correct.text.Equals(value)) {
                buttonSave.interactable = true;
                break;    

            } else {
                buttonSave.interactable = false;
            }
        }        
    }


    public void SaveQuiz() {
        QuizQuestion.question = question.text;
        QuizQuestion.option1 = options[0].text;
        QuizQuestion.option2 = options[1].text;
        QuizQuestion.option3 = options[2].text;
        QuizQuestion.option4 = options[3].text;
        QuizQuestion.anwser = answer.text;

        question.text = "";
        answer.text = "";

        foreach (InputField inputField in options) {
            inputField.text = "";
        }
    }
}
