using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField]PlayerInput input;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingX = .2f;
    [SerializeField] float paddingY = .2f;
    // Start is called before the first frame update
    void OnEnable(){
        input.onMove += Move;
        input.onStopMove += StopMove;
    }
    void OnDisable(){
        input.onMove -= Move;
        input.onStopMove -= StopMove;
    }
    void Move(Vector2 moveInput){
        Vector2 moveAmount = moveInput * moveSpeed;
        rigidbody2D.velocity = moveAmount;
        StartCoroutine(MovePositionLimitCoroutine());
    }
    void StopMove(){
        rigidbody2D.velocity = Vector2.zero;
        StopCoroutine(MovePositionLimitCoroutine());
    }
    void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rigidbody2D.gravityScale = 0f;
        input.EnableGamePlayInput();
    }

    // Update is called once per frame ，資源消耗很大，能不寫在update裡就不要，這樣只有移動事件發生才會去算
    IEnumerator MovePositionLimitCoroutine(){
        while(true){
            transform.position = Viewport.Instance.PlayerMoveablePosition(transform.position, paddingX, paddingY);
            yield return null;
        }
    }
}
