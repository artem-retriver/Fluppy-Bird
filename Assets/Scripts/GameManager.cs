using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;
    public Parallax[] parallax;

    public Text[] scoreText;
    public GameObject[] difficultsText;
    public GameObject playButton;

    public GameObject gameOver;
    public GameObject gameMain;
    public GameObject gamePlay;
    public GameObject gameSettings;

    public int score { get; private set; }
    public int chooseDifficult;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        parallax = FindObjectsOfType<Parallax>();

        Pause();
    }

    private void Update()
    {
        ChooseDifficults();
    }

    public void Play()
    {
        score = 0;

        for (int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].text = score.ToString();
        }

        playButton.SetActive(false);

        gameOver.SetActive(false);
        gameMain.SetActive(false);
        gamePlay.SetActive(true);
        gameSettings.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;


        DestroyPipes();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        gameSettings.SetActive(false);
        gamePlay.SetActive(false);

        Pause();
    }

    public void EasyDifficult()
    {
        chooseDifficult = 1;

        Play();
    }

    public void MiddleDifficult()
    {
        chooseDifficult = 2;

        Play();
    }

    public void HardDifficult()
    {
        chooseDifficult = 3;

        Play();
    }

    public void SettingsButton()
    {
        gamePlay.SetActive(false);
        gameSettings.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;

        for (int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].text = score.ToString();
        }
    }

    public void DestroyPipes()
    {
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void ChooseDifficults()
    {
        if (chooseDifficult == 1 || chooseDifficult == 0)
        {
            spawner.prefab.speed = 5f;
            parallax[0].animationSpeed = 1f;
            parallax[1].animationSpeed = 0.05f;

            difficultsText[0].SetActive(true);
            difficultsText[1].SetActive(false);
            difficultsText[2].SetActive(false);
        }
        else if (chooseDifficult == 2)
        {
            spawner.prefab.speed = 6.5f;
            parallax[0].animationSpeed = 1.5f;
            parallax[1].animationSpeed = 0.5f;

            difficultsText[0].SetActive(false);
            difficultsText[1].SetActive(true);
            difficultsText[2].SetActive(false);
        }
        else if (chooseDifficult == 3)
        {
            spawner.prefab.speed = 8f;
            parallax[0].animationSpeed = 2f;
            parallax[1].animationSpeed = 1f;

            difficultsText[0].SetActive(false);
            difficultsText[1].SetActive(false);
            difficultsText[2].SetActive(true);
        }
    }
}
