using UnityEngine;
using UnityEngine.UI;

public class GameLogical : MonoBehaviour
{
    public bool GameStart = false;
    private int Score = 0;
    private Text ScoreText;
    private Button PlayButton;
    private Rigidbody BallRB;
    private GameObject Ball;
    public float BallSpeed = 10f;
    private GameObject Player;
    private BlockSpawn BlockSpawn;
    private void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
        BallRB = GameObject.Find("Ball").GetComponent<Rigidbody>();
        Ball = GameObject.Find("Ball");
        Player = GameObject.Find("Player");
        BlockSpawn = GameObject.Find("Blocks").GetComponent<BlockSpawn>();

        if (PlayButton != null)
            PlayButton.onClick.AddListener(StartGame);
    }

    public void ScoreIncrement(int scoreValue = 1)
    {
        Score += scoreValue;
        ScoreText.text = $"Score: {Score}";
        if (Score % 5 == 0)
            BallSpeed += 1f;
    }

    public void StartGame()
    {
        GameStart = true;
        ScoreText.text = $"Score: #";
        PlayButton.gameObject.SetActive(false);

        BallRB = GameObject.Find("Ball").GetComponent<Rigidbody>();
        BallRB.velocity = new Vector3(-1, -1, 0).normalized * 10f;

        BlockSpawn = GameObject.Find("Blocks").GetComponent<BlockSpawn>();
        BlockSpawn.StartSpawn();
    }

    public void GameOver()
    {
        GameStart = false;
        Score = 0;

        Ball = GameObject.Find("Ball");
        Ball.transform.position = new Vector3(3, 5, 0);
        BallRB = GameObject.Find("Ball").GetComponent<Rigidbody>();
        BallRB.velocity = new Vector3(0, 0, 0);

        Player = GameObject.Find("Player");
        Player.transform.position = new Vector3(0, 0.5f, 0);

        BlockSpawn = GameObject.Find("Blocks").GetComponent<BlockSpawn>();
        BlockSpawn.ClearAllBlocks();

        PlayButton.gameObject.SetActive(true);
    }
}
