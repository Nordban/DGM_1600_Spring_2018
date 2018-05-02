using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    public int damage;
    public float lifespan;
    public bool bulletHit;
    public WolfHealth wolfHealth;
    public WareWolfHealth wareWolfHealth;

    // Use this for initialization
    void Start () {
        StartCoroutine(DestroyBullet());
        bulletHit = false;
	}

    private void OnCollisionEnter(Collision other)
    {
        
        var hit = other.gameObject;
        if (other.gameObject.tag == "Wolf" /*Wolf(Clone)"*/)
        {
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
        else if (other.gameObject.name == "Warewolf(Clone)")
        {
            var health = hit.GetComponent<WareWolfHealth>();

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

        
        
    }



    IEnumerator DestroyBullet()
    {
        
       yield return new WaitForSeconds(lifespan);

        Destroy(gameObject);
    }
}
