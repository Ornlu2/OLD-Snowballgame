using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour {

    public ParticleSystem particleLauncher;
    public ParticleSystem SnowPieces;
    public GameObject Snow;


    List<ParticleCollisionEvent> ExplosioncollisionEvents;

    void Start()
    {
        ExplosioncollisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        
            for (int i = 0; i < ExplosioncollisionEvents.Count; i++)
            {
                EmitAtLocation(ExplosioncollisionEvents[i]);

            }
            if (ExplosioncollisionEvents.Count < 0)
            {
                return;
            }

            ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, ExplosioncollisionEvents);

        
    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {

        ParticleSystem.MainModule psMain = SnowPieces.main;

        Instantiate(Snow, particleCollisionEvent.intersection, Quaternion.identity);
    }
}






