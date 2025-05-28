using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector2 startPoint;
    Vector2 direction;

    [SerializeField] float maxSpeedDragRange;

    PlayerControl PlayerControl => PlayerControl.instance;


    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPoint = eventData.pressPosition;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        PlayerControl.SetDirection((eventData.position - startPoint).normalized);
        float dragRange = (eventData.position - startPoint).magnitude;

        float dragRatio = dragRange / maxSpeedDragRange;
        dragRatio = Mathf.Clamp(dragRatio, 0, 1);

        PlayerControl.UpdateSpeed(dragRatio);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        PlayerControl.ResetSpeed();
        PlayerControl.SetDirection(Vector3.zero);
    }
}
