using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 4.5f;

    private CircleCollider2D circle;
    private Rigidbody2D body;

    [SerializeField] public bool allowVerticalMovement;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement;

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3( -Mathf.Sign(deltaX), 1, 1);
        }

        if (allowVerticalMovement)
        {
            float deltaY = Input.GetAxis("Vertical") * speed;
            movement = new Vector2(deltaX, deltaY);
            body.velocity = movement;
        }
        else
        {
            body.velocity = new Vector2(deltaX * speed, 0f);
        }
        
    }
}
