using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurnClockwiseButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TurnCounterClockwiseButton turnCounterClockwiseButton;

    private Image buttonImage;

    private Color pressedColor = new Color(1f, 0.68f, 0.29f, 1f);
    private Color notPressedColor = new Color(1f, 0.68f, 0.29f, 0.5f);

    private bool isPointerDown = false;
    public bool IsPointerDown { get { return isPointerDown; } }

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    private void OnDisable()
    {
        buttonImage.color = notPressedColor;

        isPointerDown = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerDown = false;

        buttonImage.color = notPressedColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerId >= 0)
        {
            isPointerDown = true;

            buttonImage.color = pressedColor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }
}
