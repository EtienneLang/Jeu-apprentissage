using UnityEngine;

namespace Assets.Scripts
{
    public class Fighter : MonoBehaviour
    {
        public int health = 10;
        public int maxHitPoint = 10;
        
        
        protected virtual void ReceiveDamage()
        {

        }

    }
}
