using UnityEngine;
using System.Collections;


namespace menu
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TriggerV2 : MonoBehaviour
    {
        public int OpenMenuID;
        public bool Disabled;
        public bool State = false;
        public bool triggered = false;

        void Start()
        {
            if (Disabled)
            {
                GetComponent<TextMesh>().renderer.material.color = Color.gray;
            }
        }

        public void IWillDo()
        {
            if (!Disabled)
            {
                State = true;
            }
        }
        void OnMouseClick()
        {
            if (!Disabled)
            {
                State = true;
            }
        }
    }
}