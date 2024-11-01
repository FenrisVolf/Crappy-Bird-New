using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_Manager : MonoBehaviour
{
    public GameObject Flappy_0;
    public GameObject Polly_0;
    public GameObject Greg_0;
    public GameObject Capt_0;
    private Vector3 CharacterPosition;
    private Vector3 OffScreen;
    private int CharacterInt = 1;
    private SpriteRenderer FlappyRender, PollyRender, GregRender, CaptRender;
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        CharacterPosition = Flappy_0.transform.position;
        OffScreen = Polly_0.transform.position;
        FlappyRender = Flappy_0.GetComponent<SpriteRenderer>();
        PollyRender = Flappy_0.GetComponent<SpriteRenderer>();
        GregRender = Flappy_0.GetComponent<SpriteRenderer>();
        CaptRender = Flappy_0.GetComponent<SpriteRenderer>();
    }

    public void NextCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                FlappyRender.enabled = false;
                Flappy_0.transform.position = OffScreen;
                Polly_0.transform.position = CharacterPosition;
                PollyRender.enabled = true;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                PollyRender.enabled = false;
                Polly_0.transform.position = OffScreen;
                Greg_0.transform.position = CharacterPosition;
                GregRender.enabled = true;
                CharacterInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                GregRender.enabled = false;
                Greg_0.transform.position = OffScreen;
                Capt_0.transform.position = CharacterPosition;
                CaptRender.enabled = true;
                CharacterInt++;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                CaptRender.enabled = false;
                Capt_0.transform.position = OffScreen;
                Flappy_0.transform.position = CharacterPosition;
                FlappyRender.enabled = true;
                CharacterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    public void PreviousCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                FlappyRender.enabled = false;
                Flappy_0.transform.position = OffScreen;
                Capt_0.transform.position = CharacterPosition;
                CaptRender.enabled = true;
                CharacterInt--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                PollyRender.enabled = false;
                Polly_0.transform.position = OffScreen;
                Flappy_0.transform.position = CharacterPosition;
                FlappyRender.enabled = true;
                CharacterInt--;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                GregRender.enabled = false;
                Greg_0.transform.position = OffScreen;
                Polly_0.transform.position = CharacterPosition;
                PollyRender.enabled = true;
                CharacterInt--;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                CaptRender.enabled = false;
                Capt_0.transform.position = OffScreen;
                Greg_0.transform.position = CharacterPosition;
                GregRender.enabled = true;
                CharacterInt--;
                break;
            default:
                ResetInt();
                break;
        }
    }

    private void ResetInt()
    {
        if(CharacterInt >= 4)
        {
            CharacterInt = 1;
        }
        else 
        {
            CharacterInt = 4;        
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
