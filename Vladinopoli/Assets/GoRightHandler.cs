using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoRightHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image rightButtonImage_1;
    [SerializeField] private Image rightButtonImage_2;
    [SerializeField] private Image leftButtonImage_1;
    [SerializeField] private Image leftButtonImage_2;
    [SerializeField] private Image mainImage;

    public void OnPointerDown(PointerEventData eventData)
    {

        if (StaticFunctions.instance.choiceMade == false)
        {
            StaticFunctions.instance.goRight = true;
            rightButtonImage_1.enabled = false;
            rightButtonImage_2.enabled = false;

            leftButtonImage_1.enabled = false;
            leftButtonImage_2.enabled = false;

            mainImage.enabled = false;
            StaticFunctions.instance.choiceMade = true;
        }
    }

    private void Update()
    {
        if (StaticFunctions.instance.choiceMade == false)
        {
            rightButtonImage_1.enabled = true;
            rightButtonImage_2.enabled = true;

            leftButtonImage_1.enabled = true;
            leftButtonImage_2.enabled = true;

            mainImage.enabled = true;
        }
    }
}
