using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player; //acessando a classe Player
    private Animator anim; //acessando o animator

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
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
}


void OnRun()
{
    if(player.isRunning)
    {
        anim.SetInteger("transition", 2);
    }
}


#endregion




}
