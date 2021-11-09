using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Player input")]
public class PlayerInput : ScriptableObject, InputActions.IGamePlayActions
{
    public event UnityAction<Vector2> onMove = delegate{};
    public event UnityAction onStopMove = delegate{};
    InputActions inputActions;
    void OnEnable(){
        inputActions = new InputActions();
        inputActions.GamePlay.SetCallbacks(this);
    }
    void OnDisable(){
        DisableAllInputs();
    }

    public void EnableGamePlayInput(){
        inputActions.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void DisableAllInputs(){
        inputActions.GamePlay.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed){
            onMove.Invoke(context.ReadValue<Vector2>());
        }
        if (context.phase == InputActionPhase.Canceled){
            onStopMove.Invoke();
        }
    }
}
