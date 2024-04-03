using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalParticleSystem
{
    private static Transform particleSystemParent;
    private static Dictionary<string, List<ParticleSystem>> particleSystems = new Dictionary<string, List<ParticleSystem>>();

    public static ParticleSystem Play(ParticleSystem particlePrefab, Transform transform)
    {
        if (particleSystems.TryGetValue(particlePrefab.name, out List<ParticleSystem> particleSystemList))
        {
            for (int i = 0; i < particleSystemList.Count; i++)
            {
                if (particleSystemList[i].isStopped)
                {
                    // particleSystemList[i].Stop();
                    particleSystemList[i].transform.position = transform.position;
                    particleSystemList[i].Play();
                    return particleSystemList[i];
                }
            }
            return SpawnParticleSystem(particlePrefab, transform);
        }
        return SpawnParticleSystem(particlePrefab, transform);
    }

    private static ParticleSystem SpawnParticleSystem(ParticleSystem particlePrefab, Transform transform)
    {
        if (particleSystemParent == null)
            particleSystemParent = new GameObject { name = "Particle Systems" }.transform;

        ParticleSystem newParticleSystem = GameObject.Instantiate(particlePrefab, particleSystemParent);
        newParticleSystem.transform.position = transform.position;

        if (particleSystems.ContainsKey(particlePrefab.name))
            particleSystems[particlePrefab.name].Add(newParticleSystem);
        else
            particleSystems.Add(particlePrefab.name, new List<ParticleSystem>() { newParticleSystem });

        return newParticleSystem;
    }

    public static void Clear()
    {
        particleSystems.Clear();
    }
}