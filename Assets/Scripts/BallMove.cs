using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody BallRB;
    private GameLogical Logical;

    void Start()
    {
        BallRB = GetComponent<Rigidbody>();
        Logical = GameObject.FindGameObjectWithTag("Logical").GetComponent<GameLogical>();
    }

    void FixedUpdate()
    {
        if (Logical.GameStart)
            BallRB.velocity = BallRB.velocity.normalized * Logical.BallSpeed;

        Debug.Log(BallRB.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
        {
            Logical.GameOver();
            return;
        }

        Vector3 normal = collision.contacts[0].normal;
        var direction = Vector3.Reflect(BallRB.velocity, normal);
        BallRB.velocity = (direction * Logical.BallSpeed).normalized;
    }
}
