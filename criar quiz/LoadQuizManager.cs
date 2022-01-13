using UnityEngine;
using UnityEngine.UI;

public class LoadQuizManager : MonoBehaviour {
    [SerializeField] private Text question;
    [SerializeField] private Text option1;
    [SerializeField] private Text option2;
    [SerializeField] private Text option3;
    [SerializeField] private Text option4;
    

    private void Start() {
        SettingQuiz();
    }


    private void SettingQuiz() {
        question.text = QuizQuestion.question;
        option1.text = QuizQuestion.option1;
        option2.text = QuizQuestion.option2;
        option3.text = QuizQuestion.option3;
        option4.text = QuizQuestion.option4;
    }

   
    public void VerifyAnwser(Text value) {
        if(value.text.Equals(QuizQuestion.anwser))
            print("Acertou");

        else
            print("Errou");
    }
}
