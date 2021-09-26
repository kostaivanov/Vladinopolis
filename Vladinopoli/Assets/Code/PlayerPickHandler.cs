using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPickHandler : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        name = EventSystem.current.currentSelectedGameObject.name;
        StaticFunctions.instance.name = name;
    }
}
