using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    protected float lastFireTime;

    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;

    public float zoomFactor;
    public int range;
    public int damage;

    private float zoomFOV;
    private float zoomSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        //initalize zoom factor
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
        lastFireTime = Time.time - 10;
    }


    protected virtual void Update()
    {
        //right click to zoom
        if (Input.GetMouseButtonDown(1))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        }
        //other wise keep defult screen
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;
        }

    }

    private void prossesHit(GameObject hitObject)
    {

        //calls take damage if the player is the one hit
        if (hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().takeDamage(damage);
        }

        //calls take damage if the robot is the one hit
        if (hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().takeDamage(damage);
        }

    }


    protected void Fire()
    {
        //plays a audio clip depending if you fire a bullet or if you dont have bullets
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.usedAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
            
        }
        GetComponentInChildren<Animator>().Play("fire");
        //draw a ray
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //if the ray hits a robot in range call prosses hit function
        if (Physics.Raycast(ray, out hit, range))
        {
            prossesHit(hit.collider.gameObject);
        }

    }
       
    
}
