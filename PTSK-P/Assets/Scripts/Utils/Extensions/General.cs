using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static partial class Extensions
    {
        public static void DestroyChildren(this Transform father)
        {
            foreach (Transform child in father) {
                GameObject.Destroy(child.gameObject);
            }
        }

        public static void DestroyParticleObjectOnActionStop(this ParticleSystem ps)
        {
            ParticleSystem.MainModule main = ps.main;
            main.stopAction = ParticleSystemStopAction.Destroy;
        }
    }
}