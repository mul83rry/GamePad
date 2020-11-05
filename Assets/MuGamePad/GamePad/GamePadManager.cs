using MU.Tools.SaveSystem;
using UnityEngine;

public class GamePadManager : MonoBehaviour
{

    [System.Serializable]
    public enum GamePad { Gamepad1, Gamepad2, Gamepad3, Gamepad4 };

    public JoyInputs Gamepad1, Gamepad2, Gamepad3, Gamepad4;
    [HideInInspector] public JoyInputs Gamepad1Default, Gamepad2Default, Gamepad3Default, Gamepad4Default;


    private void Reset()
    {
        ResetButtons();
    }


    private void ResetButtons()
    {
        Gamepad1Default = new JoyInputs
        {
            button0Key = "joystick 1 button 0",
            button1Key = "joystick 1 button 1",
            button2Key = "joystick 1 button 2",
            button3Key = "joystick 1 button 3",
            button4Key = "joystick 1 button 5",
            button5Key = "joystick 1 button 7",
            button6Key = "joystick 1 button 4",
            button7Key = "joystick 1 button 6",
            xAxisKey = "XAxis1",
            yAxisKey = "YAxis1",
            _3thAxisKey = "3rdAxis1",
            _5thAxisKey = "4rdAxis1"
        };

        Gamepad2Default = new JoyInputs
        {
            button0Key = "joystick 2 button 0",
            button1Key = "joystick 2 button 1",
            button2Key = "joystick 2 button 2",
            button3Key = "joystick 2 button 3",
            button4Key = "joystick 2 button 5",
            button5Key = "joystick 2 button 7",
            button6Key = "joystick 2 button 4",
            button7Key = "joystick 2 button 6",
            xAxisKey = "XAxis2",
            yAxisKey = "YAxis2",
            _3thAxisKey = "3rdAxis2",
            _5thAxisKey = "4rdAxis2"
        };

        Gamepad3Default = new JoyInputs
        {
            button0Key = "joystick 3 button 0",
            button1Key = "joystick 3 button 1",
            button2Key = "joystick 3 button 2",
            button3Key = "joystick 3 button 3",
            button4Key = "joystick 3 button 5",
            button5Key = "joystick 3 button 7",
            button6Key = "joystick 3 button 4",
            button7Key = "joystick 3 button 6",
            xAxisKey = "XAxis3",
            yAxisKey = "YAxis3",
            _3thAxisKey = "3rdAxis3",
            _5thAxisKey = "4rdAxis3"
        };

        Gamepad4Default = new JoyInputs
        {
            button0Key = "joystick 4 button 0",
            button1Key = "joystick 4 button 1",
            button2Key = "joystick 4 button 2",
            button3Key = "joystick 4 button 3",
            button4Key = "joystick 4 button 5",
            button5Key = "joystick 4 button 7",
            button6Key = "joystick 4 button 4",
            button7Key = "joystick 4 button 6",
            xAxisKey = "XAxis4",
            yAxisKey = "YAxis4",
            _3thAxisKey = "3rdAxis4",
            _5thAxisKey = "4rdAxis4"
        };

        // joy1
        Gamepad1 = SaveSystem.Load<JoyInputs>("Joy1Data");
        if (Gamepad1 is null)
        {
            Debug.Log("First Run");
            Gamepad1 = new JoyInputs();
            //firstRun = true;
            // setting up first value

            Gamepad1 = Mu.Tools.Utilities.Utilities.DeepClone(Gamepad1Default);
            SaveSystem.Save(Gamepad1, "Joy1Data");
            Debug.Log("save gamepad 1 data");
        }

        // joy2
        Gamepad2 = SaveSystem.Load<JoyInputs>("Joy2Data");
        if (Gamepad2 is null)
        {
            Gamepad2 = new JoyInputs();
            //firstRun = true;
            // setting up first value
            Gamepad2 = Mu.Tools.Utilities.Utilities.DeepClone(Gamepad2Default);
            SaveSystem.Save(Gamepad2, "Joy2Data");
            Debug.Log("save gamepad 2 data");
        }

        // joy3
        Gamepad3 = SaveSystem.Load<JoyInputs>("Joy3Data");
        if (Gamepad3 is null)
        {
            Debug.Log("First Run");
            Gamepad3 = new JoyInputs();
            //firstRun = true;
            // setting up first value
            Gamepad3 = Mu.Tools.Utilities.Utilities.DeepClone(Gamepad3Default);
            SaveSystem.Save(Gamepad3, "Joy3Data");
        }

        //joy4
        Gamepad4 = SaveSystem.Load<JoyInputs>("Joy4Data");
        if (Gamepad4 is null)
        {
            Gamepad4 = new JoyInputs();
            //firstRun = true;
            // setting up first value
            Gamepad4 = Mu.Tools.Utilities.Utilities.DeepClone(Gamepad4Default);
            SaveSystem.Save(Gamepad4, "Joy4Data");
        }

    }


    private void OnApplicationQuit()
    {
        SaveJoyData();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveJoyData();
    }

    public void SaveJoyData()
    {
        SaveSystem.Save(Gamepad1, "Joy1Data");
        SaveSystem.Save(Gamepad2, "Joy2Data");
        SaveSystem.Save(Gamepad3, "Joy3Data");
        SaveSystem.Save(Gamepad4, "Joy4Data");
    }

    [System.Serializable]
    public class JoyInputs
    {
        [SerializeField] public string xAxisKey;
        [SerializeField] public string yAxisKey;
        [SerializeField] public string _3thAxisKey;
        [SerializeField] public string _5thAxisKey;

        [SerializeField] public bool xAxisInvert;
        [SerializeField] public bool yAxisInvert;

        [SerializeField] public bool _3thAxisInvert;
        [SerializeField] public bool _5thAxisInvert;

        [SerializeField] public string button0Key;
        [SerializeField] public string button1Key;
        [SerializeField] public string button2Key;
        [SerializeField] public string button3Key;

        [SerializeField] public string button4Key;
        [SerializeField] public string button5Key;
        [SerializeField] public string button6Key;
        [SerializeField] public string button7Key;
    }

}
