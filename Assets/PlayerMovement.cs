using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xMvt = 0f;
    float yMvt = 0f;

    public float runspeed = 40f;

    public CharacterController2D controller2D;

    public GameObject bullet;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;



    // Update is called once per frame
    void Update()
    {
        xMvt = Input.GetAxis("Horizontal") * runspeed;
        yMvt = Input.GetAxis("Vertical") * runspeed;

        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    private void FixedUpdate()
    {
        controller2D.Move(xMvt * Time.fixedDeltaTime, yMvt * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        xMvt = 0;
        yMvt = 0;
        Debug.Log("Has chocked");
    }

    void fire()
    {
        //Tire Une balle
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)((mousePos - transform.position));
        direction.Normalize();

        bulletPos = transform.position;
        bulletPos += new Vector2(1f, 0.13f);
        //Crée une instance de balle
        GameObject bulletInstance = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        //applique une velocité dans la direction de la souris
        bulletInstance.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        //TODO Ignore les collisions entre les balles et le joueurs
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), base.GetComponent<Collider2D>());
        
    }
}
