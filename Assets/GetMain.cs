using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMain : MonoBehaviour
{
    public GameObject Flappy, Polly, Greg, Capt;
    private GameObject mySprite;
    private readonly string selectedCharacter = "SelectedCharacter";

    void Awake()
    {
        
    }

    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch (getCharacter)
        {
            case 1:
                mySprite = Instantiate(Polly);
                break;
            case 2:
                mySprite = Instantiate(Greg);
                break;
            case 3:
                mySprite = Instantiate(Capt);
                break;
            case 4:
                mySprite = Instantiate(Flappy);
                break;
            default:
                mySprite = Instantiate(Flappy);
                break;
        }
    }
}
