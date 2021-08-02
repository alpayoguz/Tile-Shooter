using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerContoller : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRigidbody;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
       
    }




    public void Move(Vector3 velocity)
    {
        this.velocity = velocity;
    }

     void FixedUpdate()
    {

        // Normalde açıklamada Moves the kinematic rigidbody to position diyor ama o şekilde çalışmıyor. MEsela new Vector3(50,50,50) yazdım ama 50 50 50 ye doğru gitmiyor kod. 1 1 1 oluyor (50 ye bölüyor)
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

    public void LookAt(Vector3 lookPoint)
    {
        // This vector3 is to correct y axis of player. If we dont, the player rotates around y-axis.Player lean towards to the ground.
        Vector3 hightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(hightCorrectedPoint);
    }



}
