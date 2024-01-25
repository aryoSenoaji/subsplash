using System.Collections;
using UnityEngine;

public class Ranjau : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRanjau();
        CheckDestroy();
    }

    void MoveRanjau()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void CheckDestroy()
    {
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
