using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrayCube : MonoBehaviour
{
    public TextMeshPro myAssociatedText;
    public void updateNumber(int value)
    {
        myAssociatedText.SetText(value.ToString());
    }
}
