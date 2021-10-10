using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerPickHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Button currentButton;
    private ColorBlock colorDisabled;


    private void Start()
    {
        colorDisabled = GetComponent<Button>().colors;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        name = EventSystem.current.currentSelectedGameObject.name;
        StaticFunctions.instance.name = name;

        currentButton.interactable = false;
        colorDisabled.disabledColor = new Color(0.8f, 0.8f, 0.8f);
    }
}
