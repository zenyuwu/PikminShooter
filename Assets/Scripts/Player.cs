using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private Inventory inventory;
	[SerializeField] protected float health;
	[SerializeField] private VoidEvent gameOverEvent;
	[SerializeField] protected GameObject hitPrefab;
	[SerializeField] private AudioSource yahoo;
	[SerializeField] private float fireTimer;

	private float timer;

	public void ApplyDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			gameOverEvent?.RaiseEvent();
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

	void Start()
    {
        
    }

    void Update()
    {
		timer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
			timer = fireTimer;
            inventory.Fire();
			yahoo.Play();
        }
    }

	public void UpgradePikmin()
	{
		inventory.Upgrade();
	}
}
