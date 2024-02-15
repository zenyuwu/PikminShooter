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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Fire();
			yahoo.Play();
        }
    }
}
