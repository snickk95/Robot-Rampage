using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{

    //scenes
    public const string sceneBattle = "battle";
    public const string sceneMenu = "MainMenu";

    //gun types
    public const string pistol = "pistol";
    public const string assultRifle = "assultRiffle";
    public const string shotgun = "shotgun";

    //robot types
    public const string RedRobot = "RedRobot";
    public const string BlueRobot = "BlueRobot";
    public const string yellowRobot = "YellowRobot";

    //pick up items
    public const int PickUpPistolAmmo = 1;
    public const int PickUpAssultRiffleAmmo = 2;
    public const int PickUpShotGunAmmo = 3;
    public const int PickUpHealth = 4;
    public const int PickUpArmor = 5;

    //misc
    public const string Game = "game";
    public const float CameraDefaultZoom = 60f;

    public static readonly int[] AllPickupTypes = new int[5]
       {
           PickUpPistolAmmo ,
           PickUpAssultRiffleAmmo,
           PickUpShotGunAmmo,
           PickUpHealth ,
           PickUpArmor
    };
       
}
