using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
	[NonSerialized] public float value;
}
