using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    public float currentHealth;
    public Image healthBar;
    public float totalHealth;
    public bool isDead;

    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animControl;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            agent.SetDestination(player.transform.position);

            if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                animControl.PlayAnim(2);
            }
            else
            {
                animControl.PlayAnim(1);
            }

        /*
        Para fazer o skeleton rotacionar na direção do player
        precisamos saber quando ele esta indo para esquerda ou direita
        com esse calculo sabemos em qual direção está indo
        pra direita fica positivo e esqueda negativo

        Debug.log(player.transform.position.x - transform.position.x);
         */

            float posX = player.transform.position.x - transform.position.x;

            if(posX > 0)
            {
             transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }
}
