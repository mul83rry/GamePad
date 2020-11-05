using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GamePadManager;

public class GamePadInputTest : MonoBehaviour
{
    [SerializeField] private GameObject axisObject, axiserdObject;
    [SerializeField] private Image button0, button1, button2, button3;
    [SerializeField] private Image button4, button5, button6, button7;
    [SerializeField] private Image buttonUp, buttonRight, buttonBottom, buttonLeft;
    [SerializeField] private float step = 1;

    public JoyInputs joy;
    public GamePad SelectedGamePad;

    private Vector2 axisFirstPosition, axis3rdFirstPosition;    

    [SerializeField]
    private GameObject BackMessage;

    private GamePadManager padManager;
    private void Awake()
    {
        axisFirstPosition = axisObject.transform.position;
        axis3rdFirstPosition = axiserdObject.transform.position;
    }

    private void Start()
    {
        padManager = FindObjectOfType<GamePadManager>();
        switch (SelectedGamePad)
        {
            case GamePad.Gamepad1:
                joy = padManager.Gamepad1;
                break;
            case GamePad.Gamepad2:
                joy = padManager.Gamepad2;
                break;
            case GamePad.Gamepad3:
                joy = padManager.Gamepad3;
                break;
            case GamePad.Gamepad4:
                joy = padManager.Gamepad4;
                break;
        }
    }


    public bool Down;
    public string KeyPressed;

    void Update()
    {
        CheckAxis();
        CheckAxis3rd();
        CheckButtons();

        if (Input.anyKeyDown)
        {
            Down = true;
            KeyPressed = Input.inputString;
        }
        else
            Down = false;
    }

    public void DetectPressedKeyOrButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                KeyPressed = kcode.ToString();
        }
    }

    private void CheckButtons()
    {
        if (joy.button0Key != "" && Input.GetKeyDown(joy.button0Key)) button0.color = new Color32(255, 255, 225, 255);
        else if (joy.button0Key != "" && Input.GetKeyUp(joy.button0Key)) button0.color = new Color32(255, 255, 225, 0);

        if (joy.button1Key != "" && Input.GetKeyDown(joy.button1Key)) button1.color = new Color32(255, 255, 225, 255);
        else if (joy.button1Key != "" && Input.GetKeyUp(joy.button1Key)) button1.color = new Color32(255, 255, 225, 0);

        if (joy.button2Key != "" && Input.GetKeyDown(joy.button2Key)) button2.color = new Color32(255, 255, 225, 255);
        else if (joy.button2Key != "" && Input.GetKeyUp(joy.button2Key)) button2.color = new Color32(255, 255, 225, 0);

        if (joy.button3Key != "" && Input.GetKeyDown(joy.button3Key)) button3.color = new Color32(255, 255, 225, 255);
        else if (joy.button3Key != "" && Input.GetKeyUp(joy.button3Key)) button3.color = new Color32(255, 255, 225, 0);

        //

        if (joy.button4Key != "" && Input.GetKeyDown(joy.button4Key)) button4.color = new Color32(255, 255, 225, 255);
        else if (joy.button4Key != "" && Input.GetKeyUp(joy.button4Key)) button4.color = new Color32(255, 255, 225, 0);

        if (joy.button5Key != "" && Input.GetKeyDown(joy.button5Key)) button5.color = new Color32(255, 255, 225, 255);
        else if (joy.button5Key != "" && Input.GetKeyUp(joy.button5Key)) button5.color = new Color32(255, 255, 225, 0);

        if (joy.button6Key != "" && Input.GetKeyDown(joy.button6Key)) button6.color = new Color32(255, 255, 225, 255);
        else if (joy.button6Key != "" && Input.GetKeyUp(joy.button6Key)) button6.color = new Color32(255, 255, 225, 0);

        if (joy.button7Key != "" && Input.GetKeyDown(joy.button7Key)) button7.color = new Color32(255, 255, 225, 255);
        else if (joy.button7Key != "" && Input.GetKeyUp(joy.button7Key)) button7.color = new Color32(255, 255, 225, 0);
    }

    private void CheckAxis3rd()
    {
        float h = Input.GetAxis(joy._3thAxisKey);
        float v = Input.GetAxis(joy._5thAxisKey);

        int x, y;

        if (v > 0.3f) x = 1;
        else if (v < -0.3f) x = -1;
        else x = 0;

        if (h > 0.3f) y = 1;
        else if (h < -0.3f) y = -1;
        else y = 0;

        if (x != 0 && joy._3thAxisInvert) x *= -1;
        if (y != 0 && joy._5thAxisInvert) y *= -1;

        axiserdObject.transform.position = axis3rdFirstPosition + (new Vector2(x, y) * step);
    }

    private void CheckAxis()
    {
        float h = Input.GetAxis(joy.xAxisKey);
        float v = Input.GetAxis(joy.yAxisKey);

        int x, y;

        if (h > 0.3f) x = 1;
        else if (h < -0.3f) x = -1;
        else x = 0;

        if (v > 0.3f) y = 1;
        else if (v < -0.3f) y = -1;
        else y = 0;

        if (x != 0 && joy.xAxisInvert) x *= -1;
        if (y != 0 && joy.yAxisInvert) y *= -1;

        if (x == 1)
            buttonRight.color = new Color32(255, 255, 225, 255);
        else
            buttonRight.color = new Color32(255, 255, 225, 0);

        if (x == -1)
            buttonLeft.color = new Color32(255, 255, 225, 255);
        else
            buttonLeft.color = new Color32(255, 255, 225, 0);

        if (y == 1)
            buttonUp.color = new Color32(255, 255, 225, 255);
        else
            buttonUp.color = new Color32(255, 255, 225, 0);

        if (y == -1)
            buttonBottom.color = new Color32(255, 255, 225, 255);
        else
            buttonBottom.color = new Color32(255, 255, 225, 0);

        axisObject.transform.position = axisFirstPosition + (new Vector2(x, y) * step);
    }

}
