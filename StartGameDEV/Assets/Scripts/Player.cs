using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private float speed; //velocidade do Player
   [SerializeField] private float runSpeed;

   private Rigidbody2D rig; //manipular o rigidbody

   private float initialSpeed;
   private bool _isRunning;
   private bool _isRolling;
   private Vector2 _direction; //armazenar a direção que o personagem vai mover

   //propriedade da variavel, para que ele seja acessado de qualquer lugar
   public Vector2 direction
   {
        get { return _direction; }
        set { _direction = value; }
   }

   public bool isRunning
   {
        get { return _isRunning; }
        set { _isRunning = value; }
   }

   public bool isRolling
   {
        get { return _isRolling; }
        set { _isRolling = value; }
   }

   private void Start()
   {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
   }


    private void Update()
    {
       OnInput();

       OnRun();

       OnRolling();
    }    


    private void FixedUpdate() //fixedupdate para coisas relacionadas a fisica
    {
        OnMove();
    }


#region Movement

void OnInput()
{
    _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  
}

void OnMove()
{
     rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
}

void OnRun()
{
    if(Input.GetKeyDown(KeyCode.LeftShift))
    {
        speed = runSpeed;
        _isRunning = true;
    }

    if(Input.GetKeyUp(KeyCode.LeftShift))
    {
        speed = initialSpeed;
        _isRunning = false;
    }
}

void OnRolling()
{
    if(Input.GetMouseButtonDown(1)) //1 - botão direito do mouse
    {
        _isRolling = true;
    }

    if(Input.GetMouseButtonUp(1))
    {
        isRolling = false;
    }
}






















#endregion


}
