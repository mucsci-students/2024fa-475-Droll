using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBarScript : MonoBehaviour
{
    public int health;
    public int r;
    public int c;

    public RedMoveScript redGuyScript;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;

        redGuyScript = GameObject.Find("RedGuy").GetComponent<RedMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //on death
        if(health <= 0){
            redGuyScript.money += 20;

            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 1f);

            GameObject.Find("Grid").GetComponent<GridManager>().gridMap[r,c].isFull = false;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        //hit by walker
        if (col.gameObject.layer == 12 || col.gameObject.layer == 18){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 10;
        }
        //hit by runner
        else if (col.gameObject.layer == 16){
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 1f);
            health -= 5;
        }
        
        //hit by healpowerup
        else if (col.gameObject.layer == 22){
            health += 30;
        }
        //hit by atkpowerup
        else if (col.gameObject.layer == 23){
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
