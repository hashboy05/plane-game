using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // [SerializeField] private Sprite[] targetSprite;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float cooldown;
    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0){
            timer = cooldown;
            GameObject newTarget = Instantiate(targetPrefab);
            // Check for children in targetPrefab
            if (newTarget.transform.childCount > 0)
            {
                // Iterate through each child and add to the dictionary
                foreach (Transform child in newTarget.transform)
                {
                    Damage.planes.Add(child.gameObject, 100); // Add each child to the dictionary
                }
            }
            newTarget.transform.position = new Vector2(0, transform.position.y);
        }
    }
}
