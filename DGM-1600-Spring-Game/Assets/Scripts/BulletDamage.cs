using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    public int damage;
    public float lifespan;
    public bool bulletHit;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyBullet());
        bulletHit = false;
	}

    private void OnCollisionEnter(Collision other)
    {
        var hit = other.gameObject;

        var health = hit.GetComponent<WolfHealth>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
        bulletHit = true;
        if (bulletHit == true)
        {
            Debug.Log("bullet hit something destroying bullet");
            Destroy(gameObject);
        }
        
    }



    IEnumerator DestroyBullet()
    {
        
       yield return new WaitForSeconds(lifespan);

        Destroy(gameObject);
    }
}
