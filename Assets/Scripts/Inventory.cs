using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] pikminPrefabs;
    [SerializeField] private Transform shooterTransform;
    [SerializeField] private TMP_Text[] pikminCounts;

    private int currentItem;

	void Start()
    {
        
    }

    void Update()
    {
        //setting the current item
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            pikminCounts[currentItem].color = Color.black;
            currentItem++;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            pikminCounts[currentItem].color = Color.black;
            currentItem--;
		}

        //keeping current item within bounds
        if(currentItem >= pikminPrefabs.Length)
        {
            currentItem = 0;
        }
        if(currentItem < 0)
        {
            currentItem = pikminPrefabs.Length - 1;
        }

        pikminCounts[currentItem].color = Color.red;
		Debug.Log("Current Item: " + currentItem);
	}

    public void Fire()
    {
        Instantiate(pikminPrefabs[currentItem], shooterTransform.position, shooterTransform.rotation);
    }
}
