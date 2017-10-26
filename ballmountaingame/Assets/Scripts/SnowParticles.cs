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
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            EmitAtLocation(collisionEvents[i]);
        }
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);


    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
      
        ParticleSystem.MainModule psMain = SnowPieces.main;

        Instantiate(Snow, particleCollisionEvent.intersection,Quaternion.identity);
    }


}



