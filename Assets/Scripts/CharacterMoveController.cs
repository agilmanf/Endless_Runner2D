using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    [Header("Movements")]
    public float moveAccel;
    public float maxSpeed;

    [Header("Jump")]
    public float jumpAccel;

    [Header("Ground Raycast")]
    public float groundRaycastDistance;
    public LayerMask groundLayerMask;

    [Header("Scoring")]
    public ScoreController score;
    public float scoringRatio;
    private float lastPositionX;

    [Header("GameOver")]
    public GameObject gameOverScreen;
    public float fallPositionY;

    [Header("Camera")]
    public CameraMoveController gameCamera;

    private bool isJumping;
    private bool isOnGround;

    private Animator anim;
    private CharacterSoundController sound;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<CharacterSoundController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isOnGround) isJumping = true;
        }

        anim.SetBool("isOnGround", isOnGround);

        // kalkulasi score
        int distancePassed = Mathf.FloorToInt(transform.position.x - lastPositionX);
        int scoreIncrement = Mathf.FloorToInt(distancePassed / scoringRatio);

        if(scoreIncrement > 0)
        {
            score.IncreaseCurrentScore(scoreIncrement);
            lastPositionX += distancePassed;
        }

        //game over
        if(transform.position.y < fallPositionY)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocityVector = rig.velocity;

        //Debug.Log(rig.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDistance, groundLayerMask);

        if (hit)
        {
            if (!isOnGround && rig.velocity.y <= 0) isOnGround = true;
        }

        else isOnGround = false;

        if (isJumping)
        {
            velocityVector.y += jumpAccel;
            sound.PlaySound();
            isJumping = false;
        }

        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);

        rig.velocity = velocityVector;
    }


    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * groundRaycastDistance), Color.white);
    }

    public void GameOver()
    {
        score.FinishScoring();
        gameOverScreen.SetActive(true);
        gameCamera.enabled = false;
        this.enabled = false;
    }

    public void DeadAnim()
    {
        anim.SetTrigger("Dead");
    }
}
