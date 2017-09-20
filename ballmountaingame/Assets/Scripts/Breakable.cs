using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Breakable : MonoBehaviour
{
    public List<Collider> colliders;
    public bool destroyParentRigidBody = true;
    public bool breakOnCollision = true;
    public bool breakOnExplosion = true;
    public bool broken = false;

    void OnCollisionEnter(Collision c)
    {
        if (breakOnCollision)
        {
            if (c.rigidbody != null)
            {
                Break(c.collider.transform.position, (c.rigidbody.mass * c.rigidbody.velocity.magnitude));
            }
            else
            {
                Break(c.collider.transform.position, (this.gameObject.GetComponent<Rigidbody2D>().mass* this.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude));
            }
        }
    }

    public void Break(Vector3 origin, float power)
    {
        broken = true;
        if (destroyParentRigidBody)
        {
            Destroy(GetComponent<Rigidbody2D>());
        }

        for (int i = 0; i < colliders.Count; i++)
        {
            if (colliders[i] != null)
            {
                Rigidbody2D rb = colliders[i].gameObject.AddComponent<Rigidbody2D>();
                rb.AddForceAtPosition(((origin - this.transform.position).normalized), origin, ForceMode2D.Impulse);
            }
        }

       
    }
}
