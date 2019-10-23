using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Image reticle;

    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    Player player;


    // Start is called before the first frame update
    void Start()
    {
        setArmorText(player.armor);
        setHealthText(player.health);
    }

    public void setArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    }

    public void setHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void setScoreText(int score)
    {
        scoreText.text ="Score: " + score;
    }

    public void setAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }

    public void setWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }


    public void setEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }


    public void ShowWaveClearBonus ()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");

    }

    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }

    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        // Restart the contureine so it dosent have a bug of ending early
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }


    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }

    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }

    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }

    public void UpdateReticle()
    {
        //switch statment to change sights of the gun
        switch (GunEquipper.activeWeponType)
        {
            case Constants.pistol:
                reticle.sprite = redReticle;
                break;
            case Constants.shotgun:
                reticle.sprite = yellowReticle;
                break;
            case Constants.assultRifle:
                reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
