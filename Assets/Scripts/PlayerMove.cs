using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 10f;
    private GameLogical Logical;

    void FixedUpdate()
    {
        Logical = GameObject.FindGameObjectWithTag("Logical").GetComponent<GameLogical>();

        if (Logical.GameStart)
        {
            float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(new Vector3(moveX, 0, 0));
        }
    }
}
