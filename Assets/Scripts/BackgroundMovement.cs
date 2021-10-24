using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private Transform parent;
    private float destroyPos = 19;
    private Vector3 generatePos;

    private void Start()
    {
        parent = transform.parent.GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        generatePos = new Vector3(parent.position.x + destroyPos, 0, 1);
        transform.Translate(-1 * Time.deltaTime,0,0);

        // Recycle the background
        if (this.transform.position.x + destroyPos < parent.position.x)
        {
            this.transform.position = generatePos;
        }
    }
}
