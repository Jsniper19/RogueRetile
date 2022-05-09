using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Vector3 Target;

    private void Start()
    {
        Target = transform.position;
    }

    void Update()
    {
        Target = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - Speed, transform.position.y), Time.deltaTime * Speed);
            Target.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + Speed, transform.position.y), Time.deltaTime * Speed);
            Target.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + Speed), Time.deltaTime * Speed);
            Target.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - Speed), Time.deltaTime * Speed);
            Target.y = -1;
        }

        transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
    }
}
