using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour
{
    public GameObject bullet;
    public int health;
    public float timePassed;
    public int r;
    public int c;

    public BlueMoveScript blueGuyScript;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        health = 20;

        blueGuyScript = GameObject.Find("BlueGuy").GetComponent<BlueMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //ON DEATH
        if(health <= 0){
            blueGuyScript.money += 15;

            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 1f);

            GameObject.Find("Grid").GetComponent<GridManager>().gridMap[r,c].isFull = false;
            Destroy(gameObject);
        }

        //Fire after 2 sec
        timePassed += Time.deltaTime;
        if (timePassed > 2f){
            SoundFXManager.instance.PlaySoundFXClip(fireSound, transform, 1f);
            Instantiate(bullet, transform.position, Quaternion.identity);
            timePassed = 0f;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by bullet
        if(col.gameObject.layer == 11 || col.gameObject.layer == 20){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 4;
        }
        //hit by walker
        else if (col.gameObject.layer == 13 || col.gameObject.layer == 18){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 20;
        }
        //hit by runner
        else if (col.gameObject.layer == 17){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 5;
        }

        //hit by healpowerup
        else if (col.gameObject.layer == 21){
            health += 20;
        }
        //hit by atkpowerup
        else if (col.gameObject.layer == 24){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 14;
        }

        //hit by bossball
        else if (col.gameObject.layer == 28){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 10;
        }
    }
    
}
