using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pikmin : MonoBehaviour
{
    [SerializeField] protected PikminData pikminData;

	private void Start()
	{
		if(pikminData.force != 0) GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * pikminData.force, pikminData.forceMode);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!pikminData.damageOverTime && collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			damagable.ApplyDamage(pikminData.damage);
		}

		if (pikminData.destroyOnImpact)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if (pikminData.damageOverTime && collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			damagable.ApplyDamage(pikminData.damage * Time.deltaTime);
		}
	}
}
