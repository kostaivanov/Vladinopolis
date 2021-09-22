using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CanvasManager : MonoBehaviour
{
    private List<CanvasController> canvasControllerList;
    private CanvasController lastActiveCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.Game);
    }

    private void SwitchCanvas(CanvasType canvasType)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == canvasType);

        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("The main menu canvas was not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
