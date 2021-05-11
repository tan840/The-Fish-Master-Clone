using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HookMovement : MonoBehaviour
{
    public Transform hookTransform;
    Camera mainCamera;
    public Vector2 mousePos;
    public bool canMove;
    private float length;
    public float strength;

    public Tweener cameraTween; 
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

    void StartFishing()
    {
        length = -50;
        strength = 3;
        float tiime = (-length) * 0.1f;
    }    
}
