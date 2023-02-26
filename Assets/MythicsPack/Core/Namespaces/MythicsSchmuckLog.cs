//Date: 2/23/22
//COPYRIGHT: YOU ARE ALLOWED TO USE THIS 100% FREE FOR COMMERCIAL AND PERSONAL (just please credit via my YouTube: https://www.youtube.com/channel/UCpbuSisB4iGuvgOrKp5uLcQ).
using System.Net.Sockets;
using UnityEngine;
namespace MythicsErrorLog
{
	public class MythicsErrorLogContainer : MonoBehaviour
	{
		public class MythicsSchmuckLog
		{
			private string DebugString = "";
			private string errorMessage = "";
			string[] memeSchmuckStrings;

			public void Initialize()
			{
				memeSchmuckStrings = new string[7];
				memeSchmuckStrings[0] = "You are a true schmuck for causing this buffer overflow";
				memeSchmuckStrings[1] = "This isn't a recognized method. Did a wee little schmuck forget a 'using' statement or break a array bounds? Hmmm?";
				memeSchmuckStrings[2] = "You Schmucked up to many times ... ";
				memeSchmuckStrings[3] = "Wow very schmucky";
				memeSchmuckStrings[4] = "Dude your hurting my schmuck brain cells";
				memeSchmuckStrings[5] = "wowza!";
				memeSchmuckStrings[6] = "Holy Schmuck!";
			}
			private void resetString()
			{
				DebugString = "";
			}
			private void SchmuckToLog()
			{
				resetString();
				string Decoration = "";
				for (int i = 0; i < errorMessage.Length; i++)
				{
					Decoration += '=';
				}
				//Prologue:
					DebugString = DebugString.Insert(0, "Welcome to Schmuck Debugger. If you are reading this, then you schmucked up: ");
				//Meme:
					DebugString += "\n" + GetASchmuckMessage() + " - click me to see the reason";
				//Reason:
					DebugString += $"\n{Decoration}\n{errorMessage}";
				//Epilogue:
					DebugString += $"\nBrought to you by your sponsor SCHMUCK CONSOLE:\n{Decoration}";
				Debug.Log(DebugString);
			}
			#region regularSchmuckUps:
				public void SchmuckedUp(int value, Component script)
				{
					errorMessage = $"You Schmucked up {value} times: (in {script})";
					SchmuckToLog();
				}
				public void SchmuckedUp(string name, Component script)
				{
					errorMessage = $"You Schmucked up  trying to reference{name}: (in {script})";
					SchmuckToLog();
				}
				public void SchmuckedUp(int value, string name, Component script)
				{
					errorMessage = $"You Schmucked up {value} times trying to reference {name}: (in {script})";
					SchmuckToLog();
				}
			#endregion
			#region arraySchmuckUps
				public void ArraySchmuckUp(int amountOfIndexErrors, Component script)
				{
					errorMessage = $"You Schmucked up by going out of bounds {amountOfIndexErrors} times: (in {script})";
					SchmuckToLog();
				}
				public void ArraySchmuckUp(int amountOfIndexErrors, string nameOfArrayOrList, Component script)
				{
					errorMessage = $"You Schmucked up by going out of bounds {amountOfIndexErrors} times in the {nameOfArrayOrList} array/list: (in {script})";
					SchmuckToLog();
				}
				public void ArraySchmuckUp(int amountOfIndexErrors, string nameOfArrayOrList, Vector2 boundsOfArray, Component script)
				{
					errorMessage = $"You Schmucked up by going out of bounds {amountOfIndexErrors} times in the {nameOfArrayOrList} array/list going over the bounds [{boundsOfArray.x}, {boundsOfArray.y}: (in {script})";
					SchmuckToLog();
				}
			#endregion
			#region numberSchmuckUps
				public void InvalidNumberSchmuckUp(Vector3 numbers)
				{
					errorMessage = $"You Schmucked up by not using a valid enough data, you used {numbers.x} the recommended value is betweem [{numbers.y}, {numbers.z}]";
					SchmuckToLog();
				}
			#endregion
			private string GetASchmuckMessage()
			{
				int schmuckValue = Random.Range(0, memeSchmuckStrings.Length);
				return memeSchmuckStrings[schmuckValue];
			}
		}
	}
}
