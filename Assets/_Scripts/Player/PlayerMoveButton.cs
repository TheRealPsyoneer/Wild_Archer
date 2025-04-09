using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector2 startPoint;
    Vector2 direction;
    PlayerControl PlayerControl => PlayerControl.instance;


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPoint = eventData.pressPosition;
        PlayerControl.UpdateSpeed();
    }

    public void OnDrag(PointerEventData eventData)
    {
        PlayerControl.SetDirection((eventData.position - startPoint).normalized);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        PlayerControl.ResetSpeed();
    }
}
