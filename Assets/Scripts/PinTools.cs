using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinTools : MonoBehaviour
{
    [SerializeField] private Text[] pins = new Text[3];
    private int[] pinValue = new int [3];
    private RectTransform[] RTpin = new RectTransform[3];

    public delegate void WinCheckDelegate();
    public event WinCheckDelegate winning;
    public static PinTools pinToolsInstance;

    private void Awake() 
    {
        if (PinTools.pinToolsInstance != null) 
        {
            Destroy(this);
            return;
        }
        PinTools.pinToolsInstance = this;
    }

    private void Start()
    {
        PutPinsAtStartPosition();
    }
    private void Update()
    {
        if ((pinValue[0] == pinValue[1] && pinValue[1] == pinValue[2]) && GameManager.isGaming)
        {
            winning();
        }
    }
    public void PinValueChanging(int pin1, int pin2, int pin3)
    {
        //при первом изменении пинов начинаем проверку на выигрыш, для этого ставим флаг
        GameManager.isGaming = true;
        //проверка на превышение значения возможного диапазона
        if (((0 <= (pinValue[0] + pin1)) && ((pinValue[0] + pin1) <= 10)) &&
                ((0 <= (pinValue[1] + pin2)) && ((pinValue[1] + pin2) <= 10)) &&
                ((0 <= (pinValue[2] + pin3)) && ((pinValue[2] + pin3) <= 10)))
        {
            pinValue[0] += pin1;
            pinValue[1] += pin2;
            pinValue[2] += pin3;
        }
    }
    public void RefreshTextPinsView()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].text = pinValue[i].ToString();
            RTpin[i] = pins[i].rectTransform;
            RTpin[i].anchoredPosition = new Vector2(RTpin[i].anchoredPosition.x, pinValue[i] * 10);
        }
    }
    public void PutPinsAtStartPosition()
    {
        pinValue = new int[] { 5, 5, 5 };
        RefreshTextPinsView();
    }
}