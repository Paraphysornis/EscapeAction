using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    uint score = 0;
    Text scoreText;

    void Start()
    {
        scoreText = this.GetComponent<Text>();
    }

    public void ScorePlus()
    {
        score += 100;
        scoreText.text = "SCORE " + score.ToString();
    }
}
