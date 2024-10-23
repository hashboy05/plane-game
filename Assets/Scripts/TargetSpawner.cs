using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // [SerializeField] private Sprite[] targetSprite;
    [SerializeField] private BoxCollider2D cd;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float cooldown;
    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0){
            timer = cooldown;
            GameObject newTarget = Instantiate(targetPrefab);
            // float randomX = Random.Range(cd.bounds.min.x, cd.bounds.max.x);
            newTarget.transform.position = new Vector2(0, transform.position.y);
            // int randomIndex = Random.Range(0, targetSprite.Length);
            // newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[randomIndex];
        }
    }
}
