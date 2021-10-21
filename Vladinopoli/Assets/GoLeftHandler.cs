using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoLeftHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image rightButtonImage;
    [SerializeField] private Text rightButtonText;


    public void OnPointerDown(PointerEventData eventData)
    {
        StaticFunctions.instance.goLeft = true;
    }
}
