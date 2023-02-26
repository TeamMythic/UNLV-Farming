using UnityEngine;
using MythicsFabulousArrays;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class ExamplesOfUsingMythicsArrays : MonoBehaviour
{
	[Header("The Cube Prefab: ")]
	[SerializeField] private Transform cubePrefab;
	MythicsAmazingArrays MythicsArrayFunctions = new MythicsAmazingArrays();
	[Header("Please Make sure your array bounds is between 0 - 32")]
	[Header("INT ARRAY: ")]
	[Header("Select if you want to see in debugger only: ")]
	[SerializeField] private bool testInDebuggerOnly = false;
	[SerializeField] Transform location0;
	public int[] intArray = new int[2];//Look in Unity Editor to assign Values:
	private List<ArrayCube> spawnedCubes = new List<ArrayCube>();
	[Header("Canvas: ")]
	[SerializeField] private TextMeshProUGUI resultText;
	public void calculateSum()
	{
		StartCoroutine(updateResultTextIE("SUM", MythicsArrayFunctions.MythicsSum(intArray), 2f));
	}
	private IEnumerator updateResultTextIE(string name, float value, float duration)
	{
		resultText.enabled = true;
		resultText.SetText($"{name}: {value}");
		yield return new WaitForSeconds(duration);
		resultText.SetText($"");
		resultText.enabled = false;
	}
	public void calculateAverage()
	{
		StartCoroutine(updateResultTextIE("Average", MythicsArrayFunctions.MythicsAverage(intArray), 2f));
	}
	public void calculateMedian()
	{
		StartCoroutine(updateResultTextIE("Median", MythicsArrayFunctions.MythicsMedian(intArray), 2f));
	}
	private void Start()
	{
		if(testInDebuggerOnly) TestInDebuggerOnly();
		else startSpawning();
	}
	private void TestInDebuggerOnly()
	{
		DebugToScreen(MythicsArrayFunctions.MythicsArraySort(intArray, true), "Array Sort");
		DebugToScreen(MythicsArrayFunctions.MythicsArraySort(intArray, false), "Array Sort (Backwards)");
	}
	public void sort(bool value)
	{
		intArray = MythicsArrayFunctions.MythicsArraySort(intArray, value);
		deleteAll();
		startSpawning();
	}
	private void deleteAll()
	{
		while(spawnedCubes.Count > 0)
		{
			ArrayCube temp = spawnedCubes[0];
			spawnedCubes.Remove(temp);
			Destroy(temp.gameObject);
		}
	}
	public void startSpawning()
	{//Called from event:
		Vector3 lastLocation = location0.position;
		Vector3 location;
		for (int i = 0; i < intArray.Length; i++)
		{
			if(i == 0)
			{
				location = location0.position;
			}
			else
			{
				location = grabLocation(i, lastLocation);
			}
			lastLocation = location;
			var obj = Instantiate(cubePrefab, location, location0.rotation);
			obj.name = $"Cube: {i}";
			ArrayCube tempScript = obj.GetComponent<ArrayCube>();
			tempScript.updateNumber(intArray[i]);
			spawnedCubes.Add(tempScript);

		}
	}
	private Vector3 grabLocation(int index, Vector3 lastLocation)
	{
		if((index >= 0 && index < 7) || (index >= 8 && index < 14) || (index >= 15 && index < 21) || index >= 22 && index < 28)
		{//Move x + 2:
			return lastLocation + new Vector3(2, 0, 0);
		}//Move z - 2:
		else if(index == 7)
		{
			return location0.position + new Vector3(0, 0, -2);
		}
		else if (index == 14)
		{
			return location0.position + new Vector3(0, 0, -4);
		}
		else if (index == 21)
		{
			return location0.position + new Vector3(0, 0, -6);
		}
		return Vector3.zero;//Fail Safe:
	}
	private void DebugToScreen(int[] array, string title)
	{
		string Decoration = "====================";
		string value = "";
		Debug.Log(Decoration);
		Debug.Log($"{title}:");
		Debug.Log("------------");
		for (int i = 0; i < intArray.Length; i++)
		{
			if (i > 0) value += ", ";
			value += intArray[i];
		}
		Debug.Log(value);
	}
}
