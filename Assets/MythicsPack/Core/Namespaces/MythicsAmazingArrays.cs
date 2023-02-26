using UnityEngine;
namespace MythicsFabulousArrays
{
	public class MythicsAmazingArrays//Smucktile is just a name (a joke for a knock off name for versatile [a template])
	{
		#region SortArray:
			public int[] MythicsArraySort(int[] passedArray, bool direction)
			{
				//First Determine if the array is invalid:
				if (passedArray.Length < 1)
				{
					int[] invalid = new int[1];
					invalid[0] = 0;
					return invalid;
				}
				//Insertion Sort Forward:
				if (direction)
				{
					int value;
					int j;
					for (int i = 1; i < passedArray.Length; i++)
					{
						value = passedArray[i];
						j = i - 1;
						while ((j >= 0) && (passedArray[j] > value))
						{
							passedArray[j + 1] = passedArray[j];
							j = j - 1;
						}
						passedArray[j + 1] = value;
					}
					//copy array and convert to a string again:
					return passedArray;
				}
				else
				{
					//Insertion Sort Backwards:
					int value;
					int j;
					for (int i = 1; i < passedArray.Length; i++)
					{
						value = passedArray[i];
						j = i - 1;
						while ((j >= 0) && (passedArray[j] < value))
						{
							passedArray[j + 1] = passedArray[j];
							j = j - 1;
						}
						passedArray[j + 1] = value;
					}
					return passedArray;
				}
			}
			public string[] MythicsArraySort(char[] passedArray, bool direction)
			{
				//copy array and convert to a int:
				int[] intArray = new int[passedArray.Length];
				for (int i = 0; i < passedArray.Length; i++)
				{
					intArray[i] = passedArray[i] - '0';
				}
				//First Determine if the array is invalid:
				if (intArray.Length < 1)
				{
					string[] invalid = new string[1];
					invalid[0] = "invalid";
					return invalid;
				}
				//Insertion Sort Forward:
				if (direction)
				{
					int value;
					int j;
					for (int i = 1; i < intArray.Length; i++)
					{
						value = intArray[i];
						j = i - 1;
						while ((j >= 0) && (intArray[j] > value))
						{
							intArray[j + 1] = intArray[j];
							j = j - 1;
						}
						intArray[j + 1] = value;
					}
					//copy array and convert to a string again:
					string[] stringArray = new string[passedArray.Length];
					for (int i = 0; i > passedArray.Length; i++)
					{
						stringArray[i] = intArray[i].ToString() + '0';
					}
					return stringArray;
				}
				else
				{
					//Insertion Sort Backwards:
					int value;
					int j;
					for (int i = 1; i < intArray.Length; i++)
					{
						value = intArray[i];
						j = i - 1;
						while ((j >= 0) && (intArray[j] < value))
						{
							intArray[j + 1] = intArray[j];
							j = j - 1;
						}
						intArray[j + 1] = value;
					}
					//copy array and convert to a string again:
					string[] stringArray = new string[passedArray.Length];
					for (int i = 0; i < passedArray.Length; i++)
					{
						stringArray[i] = intArray[i].ToString() + '0';
					}
					return stringArray;
				}
			}
		#endregion
		#region Average:
			public float MythicsAverage(float[] array)
			{
				float result = 0.0f;
				foreach (int number in array)
				{
					result += number;
				}
				return (result / array.Length);
			}
			public float MythicsAverage(int[] array)
			{
				float result = 0;
				foreach (int number in array)
				{
					result += number;
				}
				return (result / array.Length);
			}
		#endregion
		#region Sum:
			public float MythicsSum(float[] array)
			{
				float value = 0;
				foreach (float number in array)
				{
					value += number;
				}
				return value;
			}
			public int MythicsSum(int[] array)
			{
				int value = 0;
				foreach (int number in array)
				{
					value += number;
				}
				return value;
			}
		#endregion
		#region Median:
		public int MythicsMedian(int[] array)
		{
			MythicsArraySort(array, true);
			if(array.Length % 2 == 0)
			{//Even:
				return (array[array.Length/2 - 2] + array[array.Length/2 - 1]/2);
			}//Odd:
			return (array[array.Length/2 - 1]/2);
		}
		#endregion
	}
}
