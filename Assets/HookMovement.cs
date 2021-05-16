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
    public Collider2D collider;

    public Tweener cameraTween; 
    void Awake()
    {
        mainCamera = Camera.main;
        collider = GetComponent<Collider2D>();
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
            StartFishing();
        }
        
    }

    void StartFishing()
    {
        length = -50;
        strength = 3;
        float time = (-length) * 0.1f;
        cameraTween = mainCamera.transform.DOMoveY(length, 1+ time * 0.25f, false).OnUpdate(delegate
        {
            if (mainCamera.transform.position.y <= -11f)
            {
                transform.SetParent(mainCamera.transform);
            }
            canMove = false;
        }).OnComplete(delegate
        {

            collider.enabled = true;
            cameraTween = mainCamera.transform.DOMoveY(0, time *5f, false).OnUpdate(delegate
            {
                if (mainCamera.transform.position.y >= -25f)
                {
                    StopFishing();
                }
            });
           
        });

        //screen game
        collider.enabled = false;
        canMove = true;

    }    

    void StopFishing()
    {
        canMove = false;
        cameraTween.Kill(false);
        cameraTween = mainCamera.transform.DOMoveX(0, 2f, false).OnUpdate(delegate
        {
            if (mainCamera.transform.position.y >= -11f)
            {
                transform.SetParent(null);
                transform.position = new Vector2(transform.position.x, -6);
            }
        }).OnComplete(delegate
        {
            transform.position = Vector2.down * 6;
            collider.enabled = false;
            int num = 0;
            canMove = true;
        });
    }
}
