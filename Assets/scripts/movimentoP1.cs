using System;
using UnityEngine;


public class movimentoP1 : MonoBehaviour
{
    public float speed = 5;
    public float limiteY = 3.5f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime );
        }

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -limiteY, limiteY);
        transform.position = pos;
    }
}
