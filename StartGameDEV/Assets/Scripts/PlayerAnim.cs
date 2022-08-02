using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player; //acessando a classe Player
    private Animator anim; //acessando o animator

    private Casting cast;

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

}
