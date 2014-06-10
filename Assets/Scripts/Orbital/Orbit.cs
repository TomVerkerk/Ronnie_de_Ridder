using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Orbital
{
    public class Orbit : StellarObject
    {

        public StellarObject parentobj;
        protected Transform parentPos;
        const float gravitationalConstant = 0.5f;
        // Use this for initialization
        void Start()
        {
            if (parentobj == null)
            {
                parentobj = transform.parent.gameObject.GetComponent<StellarObject>();
                parentPos = transform.parent;
            }else{
				parentPos=parentobj.transform;
			}

        }

        void FixedUpdate()
        {
            if (parentPos != null && parentobj.active)
            {
				rigidbody.isKinematic=false;
                Vector3 diff = parentPos.position - transform.position;
                Vector3 direction = diff.normalized ;
                float gravitationalForce = (parentobj.mass * mass * gravitationalConstant) / diff.sqrMagnitude;
                rigidbody.AddForce(direction * gravitationalForce );
                //rigidbody.AddRelativeForce(Vector3.right * 40f);
                transform.Translate(Vector3.left / 100f);
              //  transform.LookAt(Vector3.zero,);
            }
        }
    }
}
