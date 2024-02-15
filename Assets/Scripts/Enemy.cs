using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, IDamagable
{
	[SerializeField] protected float health;
	[SerializeField] protected int points;
	[SerializeField] protected IntEvent scoreEvent;
	[SerializeField] protected float fireTimer;

	[SerializeField] protected GameObject hitPrefab;
	[SerializeField] protected GameObject destroyPrefab;
	[SerializeField] protected Transform shooterTransform;
	[SerializeField] protected Pikmin pikminPrefab;
	[SerializeField] protected AIPerception perception;

	private float timer;

	public void ApplyDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			scoreEvent?.RaiseEvent(points);
			if (destroyPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
		else
		{
			if (hitPrefab != null)
			{
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		GameObject[] objects = perception.GetGameObjects();
		foreach(GameObject player in objects)
		{
			if (player == null) continue;
			if (Vector3.Distance(player.transform.position, transform.position) < 200)
			{
				if(timer <= 0)
				{
					Instantiate(pikminPrefab, shooterTransform.position, shooterTransform.rotation);
					timer = fireTimer;
				}
				var lookPos = player.transform.position - transform.position;
				lookPos.y = 0;
				var rotation = Quaternion.LookRotation(lookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
			}
		}
	}
}
