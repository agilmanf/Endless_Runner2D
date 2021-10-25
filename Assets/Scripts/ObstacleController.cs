using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform camera;
    public CharacterMoveController character;

    [Header("Obstacle Prefab")]
    public GameObject prefab;

    private float xOffset = 30;

    private float spawnPosX;
    private float spawnPosY;

    private Vector3 spawnPos;

    private void Start()
    {
        spawnPosX = transform.position.x + xOffset;
    }

    private void Update()
    {
        this.transform.position = camera.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(spawnPosX);
            GenerateObstacle();
        }

        if(transform.position.x > spawnPosX)
        {
            spawnPosX = transform.position.x + xOffset;
            spawnPosY = Random.Range(-3.40f, -1f);
            spawnPos = new Vector3(spawnPosX, spawnPosY, 1);
            GenerateObstacle();
            //Debug.Log(spawnPosX);
        }
    }

    private void GenerateObstacle()
    {
        Instantiate(prefab, spawnPos, this.transform.rotation, this.transform);
    }

    public void PlayerDead()
    {
        character.DeadAnim();
        character.GameOver();
    }
}
