using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SnowParticles : MonoBehaviour {



    public ParticleSystem particleLauncher;
    public ParticleSystem SnowPieces;
    public GameObject Snow;
    public bool StopSnowing;

    List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (StopSnowing == false)
        {
            for (int i = 0; i < collisionEvents.Count; i++)
            {
                EmitAtLocation(collisionEvents[i]);

            }
            if (collisionEvents.Count < 0)
            {
                return;
            }

            ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        }
    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
      
        ParticleSystem.MainModule psMain = SnowPieces.main;

        Instantiate(Snow, particleCollisionEvent.intersection,Quaternion.identity);
    }


}



