using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] pikminPrefabs;
    [SerializeField] private Transform shooterTransform;
    [SerializeField] private TMP_Text[] pikminCounts;
    [SerializeField] private Image[] pikminImages;
    [SerializeField] private Sprite[] pikminSprites;
    [SerializeField] private GameObject[] leafPrefabs;
    [SerializeField] private GameObject[] budPrefabs;
    [SerializeField] private GameObject[] flowerPrefabs;
    private int tier = 0;


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

    public void Upgrade()
    {
        switch (tier)
        {
            case 0:
                for(int i = 0; i < pikminPrefabs.Length; i++)
                 {
                    pikminPrefabs[i] = budPrefabs[i];
                    pikminImages[i].overrideSprite = pikminSprites[i];
                }
                tier++;
                break;
            case 1:
				//for (int i = 0; i < pikminPrefabs.Length; i++)
				//{
				//	pikminPrefabs[i] = flowerPrefabs[i];
				//}
                tier++;
				break;
            case 2:
                break;
        }
    }
}
