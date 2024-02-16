using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;

	private void OnTriggerEnter(Collider other)
	{
		if(gameObject.tag=="Nectar" && other.gameObject.TryGetComponent(out Pikmin pikmin))
		{
 			Player player = GameObject.FindAnyObjectByType<Player>();
			player.UpgradePikmin();
		}
	}
}
