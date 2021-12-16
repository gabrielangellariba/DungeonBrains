using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace LP.TurnBasedStrategy {

    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;
        [SerializeField] private GameObject enemy = null;
        [SerializeField] private Slider playerHealth = null;
        [SerializeField] private Slider enemyHealth = null;
        [SerializeField] private Button attackBtn = null;
        [SerializeField] private Button healBtn = null;
   
        private bool isPlayerturn = true;

        private void attack(GameObject target, float damage)
        {
            if (target == enemy)
            {
                enemyHealth.value -= damage;
            }
            else
            {
                playerHealth.value -= damage;
            }
            enemyHealthCheck(enemyHealth.value);
            //changeTurn();
        }
   

        private void heal(GameObject target, float amount)
        {
            if (target == enemy)
            {
                enemyHealth.value += amount;
            }
            else
            {
                playerHealth.value += amount;
            }
            // changeTurn();
            enemyHealthCheck(enemyHealth.value);
        }
        
        public void BtnAttack()
        {
            attack(enemy, 10);
        }
        public void BtnHeal()
        {
            heal(player, 5);
        }

        private void changeTurn()
        {
            isPlayerturn = !isPlayerturn; 

            if (!isPlayerturn)
            {
                attackBtn.interactable = false;
                healBtn.interactable = false;

                StartCoroutine(enemyTurn());
            }
            else
            {
                attackBtn.interactable = true;
                healBtn.interactable = true;
            }
        }
        private void enemyHealthCheck(float enemyHealth)
        {
           if(enemyHealth == 0)
            {
                Debug.Log("You win");
                Destroy(enemy);

                playerHealth.value = float.MaxValue;
            }
            else
            {
                changeTurn();
            }

        }

        private IEnumerator enemyTurn()
        {
            yield return new WaitForSeconds(3);

            int random = 0;
            random = Random.Range(1, 3);

            if (random == 1)
            {
                attack(player, 12);
            }
            else
            {
                heal(enemy, 3);
            }
        }
    }

}



