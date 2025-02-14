using UnityEngine;

public class BlockFeatures : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            var logical = GameObject.FindGameObjectWithTag("Logical").GetComponent<GameLogical>();
            logical.ScoreIncrement();

            Destroy(gameObject);
        }
    } 
}
