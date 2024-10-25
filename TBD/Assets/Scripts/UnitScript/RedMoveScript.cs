using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMoveScript : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2;
        moveDir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3 (0f, Input.GetAxis("RedMove"), 0f);
        transform.position += Vector3.Normalize(moveDir) * moveSpeed * Time.deltaTime;
    }
}
