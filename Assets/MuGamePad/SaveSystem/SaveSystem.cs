using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

namespace MU.Tools.SaveSystem
{
	public static class SaveSystem
	{
		public static string MainPath { get; set; }
		public static List<string> Categories { get; set; } = new List<string>();
#if UNITY_EDITOR
		[MenuItem("Data/Clear GamePad Data")]
		public static void DeleteAll()
		{
			List<string> dataName = new List<string>
			{
				"Main",  "Joy1Data", "Joy2Data", "Joy3Data", "Joy4Data"
			};

			MainPath = Application.persistentDataPath;

			foreach (var name in dataName)
			{
				string path = $"{MainPath}/{name}.dat";
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}


			EditorUtility.DisplayDialog("Clear GamePad Data",
				"Data Deleted", "OK");

		}
#endif
		public static void Save<T>(T data, string name)
		{
			MainPath = Application.persistentDataPath;

			var binary = new BinaryFormatter();

			string path = $"{MainPath}/{name}.dat";

			var stream = !File.Exists(path) ?
				File.Create(path) : File.Open(path, FileMode.Open);

			binary.Serialize(stream, data);
			stream.Close();
		}


		public static T Load<T>(string name) where T : class
		{
			MainPath = Application.persistentDataPath;

			string path = $"{MainPath}/{name}.dat";
			if (!File.Exists(path))
				return null;

			var binary = new BinaryFormatter();
			var stream = File.Open($"{MainPath}/{name}.dat", FileMode.Open);
			T result = (T)binary.Deserialize(stream);
			stream.Close();
			return result;

		}

	}



}
