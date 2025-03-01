using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 6f;
    private GameLogical Logical;
    private float playerMoveRangeX=8f;
    void Start()
    {
        Logical = GameObject.FindGameObjectWithTag("Logical").GetComponent<GameLogical>();
    }

    void FixedUpdate()
    {
        if (Logical.GameStart)
        {
            float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            var move = new Vector3(moveX, 0, 0);
            float posX = transform.position.x;
            if (posX + move.x > -playerMoveRangeX && posX + move.x < playerMoveRangeX)
                transform.Translate(move);
        }
    }
}
