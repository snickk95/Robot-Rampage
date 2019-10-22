using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;

    [SerializeField]
    private int pistolAmmo = 20;

    [SerializeField]
    private int shotGunAmmo = 10;

    [SerializeField]
    private int assultRiffleAmmo = 50;

    public Dictionary<string, int> tagToAmmo;

     void Awake()
    {
        tagToAmmo = new Dictionary<string, int>
      {
          {Constants.pistol, pistolAmmo },
          { Constants.shotgun, shotGunAmmo},
          { Constants.assultRifle, assultRiffleAmmo},
      };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // add amunition to the apropriate gun
    public void AddAmmo(string tag, int Ammo)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("unreconized gun type passed: " + tag);
        }
        tagToAmmo[tag] += Ammo;
    }

    //lets us knnow if we have ammo will return true if you hhave at least one bullet left
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("unreconized gun type passed: " + tag);
        }
        return tagToAmmo[tag] > 0;
    }

    // returns a bullet count for a gun
    public int getAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("unreconized gun type passed: " + tag);
        }
        return tagToAmmo[tag];
    }

    //check tag and subtracts a bullet from appropriate gun
    public void usedAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("unreconized gun type passed: " + tag);
        }

        tagToAmmo[tag]--;
        gameUI.setAmmoText(tagToAmmo[tag]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
