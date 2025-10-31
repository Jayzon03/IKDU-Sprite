using UnityEngine;
using UnityEngine.InputSystem; //Vi skal bruge "InputSystem" Libary

public class playerMovement : MonoBehaviour
{
    private Vector2 movement; //Vi vil gemme det "Vector2" der kommer ind n�r brugeren trykker WASD ind p� movement
    private Rigidbody2D myBody; //Det er rigbody vi vil flytte rund.
    private Animator myAnimator; //Vi laver en Animator variable så vi kan pille ved i koden

    [SerializeField] private int speed = 5; //Den hastighed vores Human skal flyttes rundt i

    private void Awake() //Awake k�rer kun engang n�r program starter
    {
        myBody = GetComponent<Rigidbody2D>(); //Vi s�tter myBody ridgidbody til ridgidbody p� den gameobject vi sidder p�
        myAnimator = GetComponent<Animator>(); //Vi vil lege med den animator den sidder på vores gameobejct så derfor 
    }

    private void OnMovement(InputValue value) //Vi laver function der holder �je med vores input system value
    {
        movement = value.Get<Vector2>(); //Movement bliver sat til Vector2 fra vores Input action n�r brugeren trykker WASD

        if (movement.x != 0 || movement.y != 0)
        {//value.vector2 bliver sat til [0,0], når man ikke trykker på WASD og spilleren

        myAnimator.SetFloat("x", movement.x);
        myAnimator.SetFloat("y", movement.y);

            myAnimator.SetBool("isWalking", true);
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate() //FixedUpdate er mere effektiv end update n�r det kommer til based ting som flytning
    {
        myBody.linearVelocity = movement * speed; //Vi s�tter velocity af vores RidgidBody2D i den hastighed vi har sat
    }
}