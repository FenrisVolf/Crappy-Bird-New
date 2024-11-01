using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Sprite[] sprites;
    private int spriteIndex;
    private SpriteRenderer spriteRenderer;
    public bool birdIsAlive = true;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public float tilt = 5f;
    public float strength = 5f;
    public float gravity = -9.81f;
    private Vector3 direction;
    public GameObject Bird;
    public SpriteRenderer artworkSprite;
    private LogicScript logic;
    private Animator animator;
    public AnimationClip AnimationClip;


    AudioManager audioManager;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {

        logic = GameObject.FindGameObjectWithTag("ScoreLogic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySFX(audioManager.wings);
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        {
         if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;
            }

            // Apply gravity and update the position
            direction.y += gravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;

            Vector3 rotation = transform.eulerAngles;
            rotation.z = direction.y * tilt;
            transform.eulerAngles = rotation;
        }

        if(transform.position.y >= 5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
        else if(transform.position.y <= -4.1f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Shit");
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}