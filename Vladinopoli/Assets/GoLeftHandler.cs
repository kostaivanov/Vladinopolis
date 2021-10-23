using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoLeftHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image leftButtonImage_1;
    [SerializeField] private Image leftButtonImage_2;
    [SerializeField] private Image rightButtonImage_1;
    [SerializeField] private Image rightButtonImage_2;
    [SerializeField] private Image mainImage;


    public void OnPointerDown(PointerEventData eventData)
    {
        StaticFunctions.instance.goLeft = true;
        leftButtonImage_1.enabled = false;
        leftButtonImage_2.enabled = false;

        rightButtonImage_1.enabled = false;
        rightButtonImage_2.enabled = false;

        mainImage.enabled = false;
    }
}
