using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToolClick : MonoBehaviour
{
    [SerializeField, Range(-3, 3)] int[] pin;    

    public void ButtonClicked()
    {
        PinTools.pinToolsInstance.PinValueChanging(pin[0], pin[1], pin[2]);
        PinTools.pinToolsInstance.RefreshTextPinsView();
    }
}
