using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarScript : MonoBehaviour
{
    public int health;
    public int r;
    public int c;

    public BlueMoveScript blueGuyScript;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //on death
        if(health <= 0){
            blueGuyScript.money += 20;

            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 1f);

            GameObject.Find("Grid").GetComponent<GridManager>().gridMap[r,c].isFull = false;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by walker
        if (col.gameObject.layer == 13 || col.gameObject.layer == 18){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 17){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 5;
        }
        
        //hit by healpowerup
        else if (col.gameObject.layer == 21){
            health += 30;
        }
        //hit by atkpowerup
        else if (col.gameObject.layer == 24){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 21;
        }

        //hit by bossball
        else if (col.gameObject.layer == 28){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 15;
        }
    }
}
