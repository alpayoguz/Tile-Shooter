using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerContoller))]
[RequireComponent(typeof(Gun_Controller))]

public class Player : LivingEntity
{
    

    
    //player movement speed
    [Range(5,10)] public float  movementSpeed = 5f;


    Camera viewCamera;
    


    //reference to PlayerController script
    PlayerContoller playerCont;
    // reference to Gun_Controller script
    Gun_Controller gun_Controller;
    protected override void Start()
    {
        base.Start();
        viewCamera = Camera.main;
        playerCont = GetComponent<PlayerContoller>();
        gun_Controller = GetComponent<Gun_Controller>();
    }

    
    void Update()
    {
        
        Movement();
        PlaneAndRay();
        Shoot();


        



    }

    void Movement()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * movementSpeed;
        playerCont.Move(moveVelocity);
    }


    void PlaneAndRay()
    {
        float rayDistance;
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        // It's to create a plane
        Plane pln = new Plane(Vector3.up, Vector3.zero);



        //This is make plane intersect with ray that described as parameter
        if (pln.Raycast(ray, out rayDistance))
        {
            //This Vector3 is take the world coordinate of the ray point where it intersect with plane
            Vector3 rayContactWorldPointWithPlane = ray.GetPoint(rayDistance);
            Debug.DrawRay(ray.origin, rayContactWorldPointWithPlane, Color.red);

            //This method makes player look the position that we described above
            playerCont.LookAt(rayContactWorldPointWithPlane);

        }
    }


    void Shoot()
    {
        if(Input.GetMouseButton(0))
        {
            gun_Controller.Shoot();
        }
    }

   
}
