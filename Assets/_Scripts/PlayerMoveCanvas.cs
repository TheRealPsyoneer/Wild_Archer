using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveCanvas : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    CanvasGroup canvasGroup;

    [SerializeField] Vector2 startPoint;
    [SerializeField] Vector2 direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        PlayerControl.instance.direction = (eventData.position - startPoint).normalized;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPoint = eventData.pressPosition;
        PlayerControl.instance.animator.SetFloat("Speed", PlayerControl.instance.stats.speed);
        PlayerControl.instance.speed = PlayerControl.instance.stats.speed;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        PlayerControl.instance.animator.SetFloat("Speed", 0);
        PlayerControl.instance.speed = 0;
    }
}
