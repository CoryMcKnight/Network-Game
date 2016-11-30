using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour {
    
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health  != null)
        {
            health.TakeDamage(10000);
        }

        //Destroy(gameObject);
    }
}