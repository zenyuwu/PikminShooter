using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pikmin", menuName = "Weapon/Pikmin")]
public class PikminData : ScriptableObject
{
	public float lifetime;
	public float damage;
	public bool destroyOnImpact;

	[Header("Collider")]
	public float force;
	public ForceMode forceMode;
	public bool damageOverTime;
}
