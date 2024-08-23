using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "ScriptableObjects/Resources", order = 1)]
public class ResourcesValue : ScriptableObject
{
    public int valueResources { get; private set; }
    public void SetValue(int value)
    {
        valueResources = valueResources + value;
    }
     
}