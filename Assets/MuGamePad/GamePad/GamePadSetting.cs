using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GamePadManager;

public class GamePadSetting : MonoBehaviour
{
	public JoyInputs joy;
	private JoyInputs joyDefault;

	public GamePad SelectedGamePad;

	public Button SelectedButton; //    :/
	public string SelectedValue;

	private GamePadManager padManager;

	private int selectedGamepad;

	private bool loadComplete;

	[SerializeField]
	private Toggle XAxis, YAxis, XAxis2, YAxis2;

	[SerializeField]
	private GameObject PressAButton;

	[SerializeField]
	private List<Transform> Tabs = new List<Transform>();

	private GamePadInput gamePad;

	private void Awake()
	{
		padManager = FindObjectOfType<GamePadManager>();

		gamePad = GetComponent<GamePadInput>();
		
		// add button event
		gamePad.Button1Down += Button1Down;
	}

    private void Button1Down()
    {
		Debug.Log("Button1 Down");
    }

    private void Start()
	{
		LoadJoyData();
	}

	public void ResetSetting()
	{

	}

	private void LoadJoyData()
	{
		switch (SelectedGamePad)
		{
			case GamePad.Gamepad1:
				joy = padManager.Gamepad1;
				joyDefault = padManager.Gamepad1Default;
				selectedGamepad = 1;
				break;
			case GamePad.Gamepad2:
				joy = padManager.Gamepad2;
				joyDefault = padManager.Gamepad2Default;
				selectedGamepad = 2;
				break;
			case GamePad.Gamepad3:
				joy = padManager.Gamepad3;
				joyDefault = padManager.Gamepad3Default;
				selectedGamepad = 3;
				break;
			case GamePad.Gamepad4:
				joy = padManager.Gamepad4;
				joyDefault = padManager.Gamepad4Default;
				selectedGamepad = 4;
				break;
		}

		XAxis.isOn = joy.xAxisInvert;
		YAxis.isOn = joy.yAxisInvert;
		XAxis2.isOn = joy._3thAxisInvert;
		YAxis2.isOn = joy._5thAxisInvert;


		FindObjectOfType<GamePadInputTest>().joy = joy;
		loadComplete = true;
	}

	private void SaveJoyData()
	{
		switch (SelectedGamePad)
		{
			case GamePad.Gamepad1:
				padManager.Gamepad1 = joy;
				break;
			case GamePad.Gamepad2:
				padManager.Gamepad2 = joy;
				break;
			case GamePad.Gamepad3:
				padManager.Gamepad3 = joy;
				break;
			case GamePad.Gamepad4:
				padManager.Gamepad4 = joy;
				break;
		}

		padManager.SaveJoyData();

	}

	void Update()
	{
		if (SelectedValue != "")
			Buttons();
	}

	public void SelectButton(Button button)
	{
		SelectedButton = button;

		PressAButton.SetActive(true);
	}

	public void SelectName(string value)
	{
		SelectedValue = value;
	}

	public void ChangeJoyStick(int index)
	{
		switch (index)
		{
			case 0:
				SelectedGamePad = GamePad.Gamepad1;				
				LoadJoyData();
				for (int i = 0; i < Tabs.Count; i++)
					Tabs[i].transform.localScale = Vector3.one;				
				Tabs[index].transform.localScale = new Vector3(1, 1.2f, 1);
				break;
			case 1:
				SelectedGamePad = GamePad.Gamepad2;
				LoadJoyData();
				for (int i = 0; i < Tabs.Count; i++)
					Tabs[i].transform.localScale = Vector3.one;
				Tabs[index].transform.localScale = new Vector3(1, 1.2f, 1);
				break;
			case 2:
				SelectedGamePad = GamePad.Gamepad3;
				LoadJoyData();
				for (int i = 0; i < Tabs.Count; i++)
					Tabs[i].transform.localScale = Vector3.one;
				Tabs[index].transform.localScale = new Vector3(1, 1.2f, 1);
				break;
			case 3:
				SelectedGamePad = GamePad.Gamepad4;
				LoadJoyData();
				for (int i = 0; i < Tabs.Count; i++)
					Tabs[i].transform.localScale = 				
				Tabs[index].transform.localScale = new Vector3(1, 1.2f, 1);
				break;
			default:
				break;
		}
	}


	public void ChangeXAxis(int index)
	{
		if (!loadComplete)
			return;

		// save setting
		joy.xAxisInvert = XAxis.isOn;
		joy.yAxisInvert = YAxis.isOn;
		joy._3thAxisInvert = XAxis2.isOn;
		joy._5thAxisInvert = YAxis2.isOn;

		Debug.Log("change axis");

		SaveJoyData();
		LoadJoyData();
	}

	private void Buttons()
	{
		if (Input.GetKeyDown(joyDefault.button0Key))
		{
			joy.button0Key = SelectedValue.Replace("{x}", selectedGamepad.ToString());
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}

		if (Input.GetKeyDown(joyDefault.button1Key))
		{
			joy.button1Key = SelectedValue.Replace("{x}", selectedGamepad.ToString()); ;
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}

		if (Input.GetKeyDown(joyDefault.button2Key))
		{
			joy.button2Key = SelectedValue.Replace("{x}", selectedGamepad.ToString()); ;
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}

		if (Input.GetKeyDown(joyDefault.button3Key))
		{
			joy.button3Key = SelectedValue.Replace("{x}", selectedGamepad.ToString()); ;
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}

		//

		if (Input.GetKeyDown(joyDefault.button4Key))
		{
			joy.button4Key = SelectedValue.Replace("{x}", selectedGamepad.ToString());
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}

		if (Input.GetKeyDown(joyDefault.button5Key))
		{
			joy.button5Key = SelectedValue.Replace("{x}", selectedGamepad.ToString());
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}

		if (Input.GetKeyDown(joyDefault.button6Key))
		{
			joy.button6Key = SelectedValue.Replace("{x}", selectedGamepad.ToString());
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}

		if (Input.GetKeyDown(joyDefault.button7Key))
		{
			joy.button7Key = SelectedValue.Replace("{x}", selectedGamepad.ToString());
			SelectedValue = "";
			SaveJoyData();
			LoadJoyData();
			PressAButton.SetActive(false);
		}
	}


}
