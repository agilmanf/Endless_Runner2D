using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private ObstacleController parent;

    private void Start()
    {
        parent = transform.parent.GetComponent<ObstacleController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 10 * Time.deltaTime,Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "MainCharacter")
        {
            parent.PlayerDead();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
