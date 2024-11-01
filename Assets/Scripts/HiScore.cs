using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public int NewScore;
    public int HighScore;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HiScore").ToString();
        RecordHighScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecordHighScore()
    {
        if(PlayerPrefs.HasKey("HiScore"))
        {
            if(NewScore > PlayerPrefs.GetInt("HiScore"))
            {
                HighScore = NewScore;
                PlayerPrefs.SetInt("HiScore", HighScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            if(NewScore > HighScore)
            {
                HighScore = NewScore;
                PlayerPrefs.SetInt("HiScore", HighScore);
                PlayerPrefs.Save();
            }
        }
    }

}
