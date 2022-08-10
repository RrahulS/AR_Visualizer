using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRefrenceResollution : MonoBehaviour
{
    public CanvasScaler scaler;
    // Start is called before the first frame update
    void Start()
    {
        scaler.referenceResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
    }

    private void Update()
    {
        scaler.referenceResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        
    }


}
