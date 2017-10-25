using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SnowParticles : MonoBehaviour {



    public ParticleSystem particleLauncher;
    public ParticleSystem SnowPieces;
    public GameObject Snow;

    List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>(500);
    }

    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
           // splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
            EmitAtLocation(collisionEvents[i]);
        }

    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        SnowPieces.transform.position = particleCollisionEvent.intersection;
        //SnowPieces.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
        ParticleSystem.MainModule psMain = SnowPieces.main;

        Instantiate(Snow, particleCollisionEvent.intersection,Quaternion.identity);
    }


}



