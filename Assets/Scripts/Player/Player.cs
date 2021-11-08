using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField]PlayerInput input;
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void OnEnable(){
        input.onMove += Move;
        input.onStopMove += StopMove;
    }
    void OnDisable(){
        input.onMove -= Move;
        input.onStopMove -= StopMove;
    }
    void Move(Vector2 moveInput){}
    void StopMove(){}
    void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rigidbody2D.gravityScale = 0f;
        input.EnableGamePlayInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
