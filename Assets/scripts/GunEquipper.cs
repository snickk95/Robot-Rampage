using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    public static string activeWeponType;

    public GameObject pistol;
    public GameObject assultRiffle;
    public GameObject shotGun;
    GameObject activeGun;
    // Start is called before the first frame update
    void Start()
    {
        activeWeponType = Constants.pistol;

        activeGun = pistol;
    }


    //turn all guns as deactivated then sets the current one to weapon and activates it
    private void loadWepon(GameObject weapon)
    {
        pistol.SetActive(false);
        assultRiffle.SetActive(false);
        shotGun.SetActive(false);

        weapon.SetActive(true);
        activeGun = weapon;
    }


    // set so that when you push 1 2 or 3 you switch to the weapon
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            loadWepon(pistol);
            activeWeponType = Constants.pistol;
            
        }
        else if (Input.GetKeyDown("2"))
        {
            loadWepon(assultRiffle);
            activeWeponType = Constants.assultRifle;
        }
        
        else if (Input.GetKeyDown("3"))
        {
            loadWepon(shotGun);
            activeWeponType = Constants.shotgun;
        }
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
