using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BDQuiz", menuName = "QuizGame/BD Quiz", order = 0)]
public class BDQuiz : ScriptableObject {
    public List<QuizQuestion> questions;
}