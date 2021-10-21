using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoRightHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image leftButtonImage;
    [SerializeField] private Text leftButtonText;

    public void OnPointerDown(PointerEventData eventData)
    {
        StaticFunctions.instance.goRight = true;
        leftButtonImage.enabled = false;
        leftButtonText.enabled = false;
    }
}
