using UnityEngine;
using System.Collections;

namespace menu
{
    public class MoveToV2 : MonoBehaviour
    {
        public int menuID;
        private Vector2 origen;
        public Vector2 moveAmount;
        public bool move;
        public bool atNewPos = false;//true it goes to new pos. False it goes to origen
        // Use this for initialization
        void Start()
        {
            origen = transform.position;
            if (move)
            {
                origen -= moveAmount;
            }
            //Debug.Log(this.name+ " moves " + origen);
        }

        // Update is called once per frame
        void Update()
        {
            if (atNewPos == false)
            {
                if (move)
                {
                    Vector2 temp1 = origen + moveAmount;
                    Vector2 temp2 = transform.position;
                    if (Vector2.Distance(temp2, temp1) > 0.01f)
                    {
                        Vector2 dir = temp1 - temp2;
                        transform.Translate(dir * Time.deltaTime * 4f);
                    }
                    else
                        atNewPos = true;
                }
                else
                {
                    Vector2 temp1 = origen;
                    Vector2 temp2 = transform.position;
                    if (Vector2.Distance(temp2, temp1) > 0.05f)
                    {
                        Vector2 dir = temp1 - temp2;
                        transform.Translate(dir * Time.deltaTime * 8f);
                    }
                    else
                        atNewPos = true;
                }
            }
        }

    }
}
