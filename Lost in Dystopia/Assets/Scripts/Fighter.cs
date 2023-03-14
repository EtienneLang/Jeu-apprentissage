using UnityEngine;

namespace Assets.Scripts
{
    public class Fighter : MonoBehaviour
    {
        public int health;
        public int maxHealth;
        public HealtBar HealtBar;

        protected virtual void ReceiveDamage(Damage dmg)
        {
            health -= dmg.nbHitPoints;
            if (health <= 0)
            {
                health = 0;
                HealtBar.SetHealt(health);
                Death();
            }
            else
            {
                HealtBar.SetHealt(health);
                Debug.Log(health);
            }
        }

        protected virtual void Death() 
        {
            Destroy(gameObject);
        }


    }
}
