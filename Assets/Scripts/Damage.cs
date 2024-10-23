using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public static Dictionary<GameObject,int> planes = new Dictionary<GameObject, int>();
    public static void ReduceDamage(int bulletDamage, GameObject gameObject){
        planes[gameObject] -= bulletDamage;
        
        if (planes[gameObject] < 0){
            planes.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}