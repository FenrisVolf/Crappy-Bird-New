using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class HighScore2 : MonoBehaviour
{
    public Text highScore;
    public LogicScript logic;
    public LogicScript playerScore;
    public LogicScript scoreText;
    public LogicScript number;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HiScore", 0).ToString();
    }

    // Update is called once per frame
    public void Store()
    {
        number = scoreText;
        highScore.text = highScore.text + scoreText.ToString();
    }
}
