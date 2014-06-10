using UnityEngine;
using System.Collections;
namespace Orbital
{
    public class DarkHoleEffects : StellarObject
    {

        // Use this for initialization
        void Start()
        {
            active = false;
            mass = 100f;
            if (particleSystem != null)
               particleSystem.emissionRate = 0f;
        }


        void Update()
        {
            if (active)
                if (particleSystem != null)
                    particleSystem.emissionRate = 100f;
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.collider.gameObject.tag == "Letter")
                mass += col.collider.gameObject.GetComponent<StellarObject>().mass*3;
        }
    }
}