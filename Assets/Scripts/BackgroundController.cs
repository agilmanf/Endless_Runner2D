using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform camera;
    public GameObject bg;

    private Vector3 generatePos;

    private void Start()
    {
        generatePos = new Vector3(19,0,1);
        GenerateBackground();
    }

    void LateUpdate()
    {
        ///Debug.Log(generatePos.position);
        this.transform.position = camera.position;
    }

    public void GenerateBackground()
    {
        Instantiate(bg, generatePos,this.transform.rotation,this.transform);
    }
}
