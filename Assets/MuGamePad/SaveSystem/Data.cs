using System.Collections;
using System.Collections.Generic;
using MU.Tools.SaveSystem;
using UnityEngine;

public class Data : MonoBehaviour
{
	//[HideInInspector]
	public Datas MyData;

	[HideInInspector]
	public bool firstRun;

	private void Awake()
	{
		MyData = SaveSystem.Load<Datas>("Main");
		if (MyData is null)
		{
			MyData = new Datas();
			Debug.Log("First Run");
			firstRun = true;
			// setting up first value


			SaveSystem.Save(MyData, "Main");
		}
	}

	private void OnApplicationQuit()
	{
		SaveSystem.Save(MyData, "Main");
	}

	private void OnApplicationPause(bool pause)
	{
		SaveSystem.Save(MyData, "Main");
	}

	[System.Serializable]
	public class Datas
	{
		[SerializeField]
		public int Coins;
		
		// add security code!
	}

}