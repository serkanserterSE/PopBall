using UnityEngine;
using UnityEngine.UI;

public class GameLogical : MonoBehaviour
{
    private int Score = 0;
    private Text ScoreText;
    private Button PlayButton;
    public bool GameStart = false;

    private void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();

        if (PlayButton != null)
            PlayButton.onClick.AddListener(StartGame);
    }

    public void ScoreIncrement(int scoreValue = 1)
    {
        Score += scoreValue;
        ScoreText.text = $"Score: {Score}";
    }

    public void StartGame()
    {
        GameStart = true;
        ScoreText.text = $"Score: #";
        PlayButton.gameObject.SetActive(false);

        var ballRB = GameObject.Find("Ball").GetComponent<Rigidbody>();
        var direction = new Vector3(-1, -1, 0).normalized;
        ballRB.velocity = direction * 10f;

        var blockSpawn = GameObject.Find("Blocks").GetComponent<BlockSpawn>();
        blockSpawn.StartSpawn();
    }

    public void GameOver()
    {
        GameStart = false;

        var ball = GameObject.Find("Ball");
        ball.transform.position = new Vector3(3, 5, 0);
        var ballRB = GameObject.Find("Ball").GetComponent<Rigidbody>();
        ballRB.velocity = new Vector3(0, 0, 0);

        var player = GameObject.Find("Player");
        player.transform.position = new Vector3(0, 0.5f, 0);

        var blockSpawn = GameObject.Find("Blocks").GetComponent<BlockSpawn>();
        blockSpawn.ClearAllBlocks();

        PlayButton.gameObject.SetActive(true);
    }
}
