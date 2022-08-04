using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    private Player player; //acessando a classe Player
    private Animator anim; //acessando o animator

    private Casting cast;

    private bool isHitting;
    private float recoveryTime = 1f;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        cast = FindObjectOfType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();

        OnRun();

        if(isHitting)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
    }


#region Movement


void OnMove()
{
    //verificar se o personamgem esta andando
        if(player.direction.sqrMagnitude > 0)
        {
            if(player.isRolling)//se isRolling for true o player rola
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        //rotacionar o player quando ele virar pra tras
        if(player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if(player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if(player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }
}


void OnRun()
{
    if(player.isRunning)
    {
        anim.SetInteger("transition", 2);
    }
}


#endregion

    #region Attack

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);

        if(hit != null)
        {
            hit.GetComponentInChildren<AnimationControl>().OnHit(); //acessa o Sprite do skeleton pelo GetComponent e chama o OnHit
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
  
  
    
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
    #endregion

    //chamado quando jogador pressiona botao de acão na lagoa
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    //chamado quando termina de executar a animação de pesca
    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("hammering", true);
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
    }

    public void OnHit()
    {
        if(!isHitting)
        {
             anim.SetTrigger("hit");
             isHitting = true;
        }

    }

}
