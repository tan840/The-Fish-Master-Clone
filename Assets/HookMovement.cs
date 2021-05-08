using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public Transform hookTransform;
    Camera mainCamera;
    public Vector2 mousePos;
    public bool canMove = true;
    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && Input.GetMouseButton(0))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = transform.position;
            pos.x = mousePos.x;
            transform.position = pos;
        }
        
    }
}
