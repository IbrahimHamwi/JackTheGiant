using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveJoystick playerMove;


    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }
    public void OnPointerDown(PointerEventData data)
    {
        GameManager.instance.isJoystickMoving = true;

        if (gameObject.name == "Left")
        {
            playerMove.SetMoveLeft(true);
        }
        else
        {
            playerMove.SetMoveLeft(false);
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        GameManager.instance.isJoystickMoving = false;

        playerMove.StopMoving();
    }
}


