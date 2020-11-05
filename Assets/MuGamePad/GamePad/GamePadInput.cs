using System;
using UnityEngine;
using static GamePadManager;

public class GamePadInput : MonoBehaviour
{
    public JoyInputs joyInputs;
    public GamePad SelectedGamePad;

    public Vector2 AxisInput;


    internal delegate void MovementDelegate(Vector2 axis);
    internal MovementDelegate AxisMovement;
    internal MovementDelegate Axis3rdMoveMent;

    internal Action Button0Down, Button1Down, Button2Down, Button3Down, Button4Down, Button5Down, Button6Down, Button7Down;
    internal Action Button0Up, Button1Up, Button2Up, Button3Up, Button4Up, Button5Up, Button6Up, Button7Up;
    internal Action Button0Press, Button1Press, Button2Press, Button3Press, Button4Press, Button5Press, Button6Press, Button7Press;


    private GamePadManager padManager;

    private void Start()
    {
        padManager = FindObjectOfType<GamePadManager>();
        LoadGamePad();
    }

    private void LoadGamePad()
    {
        switch (SelectedGamePad)
        {
            case GamePad.Gamepad1:
                joyInputs = padManager.Gamepad1;
                break;
            case GamePad.Gamepad2:
                joyInputs = padManager.Gamepad2;
                break;
            case GamePad.Gamepad3:
                joyInputs = padManager.Gamepad3;
                break;
            case GamePad.Gamepad4:
                joyInputs = padManager.Gamepad4;
                break;
        }
    }

    public void ChangeGamepad(GamePad pad)
    {
        SelectedGamePad = pad;
        LoadGamePad();
    }

    void Update()
    {
        CheckAxis();
        CheckAxis3rd();
        CheckButtonsDown();
        CheckButtonsUp();
        CheckButtonsPress();

        AxisInput = new Vector2(Input.GetAxis(joyInputs.xAxisKey), Input.GetAxis(joyInputs.yAxisKey));
    }

    private void CheckButtonsDown()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Button2Down?.Invoke();

        if (Input.GetKeyDown(joyInputs.button0Key)) Button0Down?.Invoke();
        if (Input.GetKeyDown(joyInputs.button1Key)) Button1Down?.Invoke();
        if (Input.GetKeyDown(joyInputs.button2Key)) Button2Down?.Invoke();
        if (Input.GetKeyDown(joyInputs.button3Key)) Button3Down?.Invoke();
        if (Input.GetKeyDown(joyInputs.button4Key)) Button4Down?.Invoke();
        if (Input.GetKeyDown(joyInputs.button5Key)) Button5Down?.Invoke();
        if (Input.GetKeyDown(joyInputs.button6Key)) Button6Down?.Invoke();
        if (Input.GetKeyDown(joyInputs.button7Key)) Button7Down?.Invoke();
    }

    private void CheckButtonsUp()
    {
        if (Input.GetKeyUp(KeyCode.Space)) Button2Up?.Invoke();

        if (Input.GetKeyUp(joyInputs.button0Key)) Button0Up?.Invoke();
        if (Input.GetKeyUp(joyInputs.button1Key)) Button1Up?.Invoke();
        if (Input.GetKeyUp(joyInputs.button2Key)) Button2Up?.Invoke();
        if (Input.GetKeyUp(joyInputs.button3Key)) Button3Up?.Invoke();
        if (Input.GetKeyUp(joyInputs.button4Key)) Button4Up?.Invoke();
        if (Input.GetKeyUp(joyInputs.button5Key)) Button5Up?.Invoke();
        if (Input.GetKeyUp(joyInputs.button6Key)) Button6Up?.Invoke();
        if (Input.GetKeyUp(joyInputs.button7Key)) Button7Up?.Invoke();
    }

    private void CheckButtonsPress()
    {
        if (Input.GetKey(joyInputs.button0Key)) Button0Press?.Invoke();
        if (Input.GetKey(joyInputs.button1Key)) Button1Press?.Invoke();
        if (Input.GetKey(joyInputs.button2Key)) Button2Press?.Invoke();
        if (Input.GetKey(joyInputs.button3Key)) Button3Press?.Invoke();
        if (Input.GetKey(joyInputs.button4Key)) Button4Press?.Invoke();
        if (Input.GetKey(joyInputs.button5Key)) Button5Press?.Invoke();
        if (Input.GetKey(joyInputs.button6Key)) Button6Press?.Invoke();
        if (Input.GetKey(joyInputs.button7Key)) Button7Press?.Invoke();
    }

    private void CheckAxis3rd()
    {
        float h = Input.GetAxis(joyInputs._3thAxisKey);
        float v = Input.GetAxis(joyInputs._5thAxisKey);

        int x, y;

        if (v > 0.3f) x = 1;
        else if (v < -0.3f) x = -1;
        else x = 0;

        if (h > 0.3f) y = 1;
        else if (h < -0.3f) y = -1;
        else y = 0;

        if (x != 0 && joyInputs._3thAxisInvert) x *= -1;
        if (y != 0 && joyInputs._5thAxisInvert) y *= -1;

        if (Mathf.Abs(x) > 0.3f || Mathf.Abs(y) > 0.3f)
            Axis3rdMoveMent?.Invoke(new Vector2(x, y));
    }

    private void CheckAxis()
    {
        float h = Input.GetAxis(joyInputs.xAxisKey);
        float v = Input.GetAxis(joyInputs.yAxisKey);

        float x, y;

        if (h > 0.3f || h < -0.3f) x = h;
        else x = 0;

        if (v > 0.3f || v < -0.3f) y = v;
        else y = 0;

        AxisMovement?.Invoke(new Vector2(x, y));

        x = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) x = -1;
        if (Input.GetKey(KeyCode.RightArrow)) x = 1;
        y = 0;
        if (Input.GetKey(KeyCode.UpArrow)) y = -1;
        if (Input.GetKey(KeyCode.DownArrow)) y = 1;

        if (x != 0 && joyInputs.xAxisInvert) x *= -1;
        if (y != 0 && joyInputs.yAxisInvert) y *= -1;

        AxisInput = new Vector2(x, y);
        AxisMovement?.Invoke(new Vector2(x, y));
    }

    public bool UseAxis()
    {
        float h = Input.GetAxis(joyInputs.xAxisKey);
        float v = Input.GetAxis(joyInputs.yAxisKey);

        if (Mathf.Abs(h) > 0.3f || Mathf.Abs(v) > 0.3f)
            return true;
        else
            return false;
    }

}
