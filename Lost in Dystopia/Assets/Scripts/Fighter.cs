using UnityEngine;

namespace Assets.Scripts
{
    public class Fighter : MonoBehaviour
    {
        public int health = 10;
        public int maxHitPoint = 10;
        
        
        protected virtual void ReceiveDamage(Damage dmg)
        {
            health -= dmg.nbHitPoints;
            if (health <= 0)
            {
                health = 0;
                Death();
            }
        }

        protected virtual void Death() 
        {
            Destroy(gameObject);
        }

    }
}
