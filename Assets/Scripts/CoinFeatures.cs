using UnityEngine;

public class CoinFeatures : MonoBehaviour
{
    private int hitCounter = 0;
    void OnCollisionEnter(Collision collision)
    {
        if (hitCounter > 1)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                var logical = GameObject.FindGameObjectWithTag("Logical").GetComponent<GameLogical>();
                logical.ScoreIncrement(6);

                Destroy(gameObject);
            }
        }
        else
        {
            hitCounter++;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
