using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armor;
    public GameUI gameUI;

    private GunEquipper gunEquipper;
    private Ammo ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();

        gunEquipper = GetComponent<GunEquipper>();
    }
    //add health
    private void pickUpHealth()
    {
        health += 50;
            if (health>200)
        {
            health = 200;
        }
    }

    //add armor
    private void pickUpArmor()
    {
        armor += 15;
    }

    //add assultrifle ammo
    private void PickUpAssulAmmo()
    {
        ammo.AddAmmo(Constants.assultRifle, 50);
    }


    // add pistol ammo
    private void PickUpPistolAmmo()
    {
        ammo.AddAmmo(Constants.pistol, 20);
    }

    // add shot gun ammo
    private void PickUpShotgunAmmo()
    {
        ammo.AddAmmo(Constants.shotgun, 10);
    }



    public void PickUpItem(int pickupType)
    {
        switch(pickupType)
        {
            case Constants.PickUpArmor:
                pickUpArmor();
                break;

            case Constants.PickUpHealth:
                pickUpHealth();
                break;

            case Constants.PickUpAssultRiffleAmmo:
                PickUpAssulAmmo();
                break;

            case Constants.PickUpPistolAmmo:
                PickUpPistolAmmo();
                break;

            case Constants.PickUpShotGunAmmo:
                PickUpShotgunAmmo();
                break;

            default:
                Debug.LogError("Bad Pick Up type passes" + pickupType);
                break;
                

        }
    }




    public void takeDamage(int amount)
    {
        int healthDamage = amount;

        if (armor>0)
        {
            int effectiveArmor = armor * 2;
            effectiveArmor -= healthDamage;

            if (effectiveArmor>0)
            {
                armor = effectiveArmor / 2;
                return;
            }

            armor = 0;
        }

        health -= healthDamage;
        Debug.Log("health is " + health);

        if (health<=0)
        {
            Debug.Log("game over");
        }

        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
