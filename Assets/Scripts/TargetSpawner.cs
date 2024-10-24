using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] targetPrefab;
    // [SerializeField] private float cooldown;
    // private float timer;
    private int currentIndex = 0; // Track which prefab to spawn next

    void Update()
    {
        // timer -= Time.deltaTime;
        // if (timer < 0)
        // {
            // timer = cooldown;

            // Make sure we have prefabs to spawn
            if (targetPrefab.Length > 0)
            {
                if (Damage.planes.Count==0){
                    // Spawn the current prefab
                    GameObject newTarget = Instantiate(targetPrefab[currentIndex]);

                    if (newTarget.transform.childCount > 0)
                    {
                        foreach (Transform child in newTarget.transform)
                        {
                            Damage.planes.Add(child.gameObject, 100);
                        }
                    }

                    newTarget.transform.position = new Vector2(0, transform.position.y);

                    // Move to next prefab
                    currentIndex++;

                    // Reset index if we've reached the end of the array
                    if (currentIndex >= targetPrefab.Length)
                    {
                        currentIndex = 0;
                    }
                }
            }
        // }
    }
}