using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-5f, 0f, 0f) * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col){
        Destroy(gameObject);
    }
}
