
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    private float Score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNexLevel = 10;

    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Score >= scoreToNexLevel)
        {
            Levelup();
        }
        Score += Time.deltaTime * difficultyLevel;
        scoretext.text = ((int)Score).ToString();
    }

    void Levelup()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNexLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }
}
