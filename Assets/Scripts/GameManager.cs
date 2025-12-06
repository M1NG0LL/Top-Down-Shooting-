using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("UI")]
    public TMP_Text gameOverText;  // Drag your text here
    public TMP_Text scoreText;

    [Header("Game Data")]
    public int score = 0;
    public bool isGameOver = false;

    private CanvasGroup goFade;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;

        goFade = gameOverText.GetComponent<CanvasGroup>();
        if (goFade == null)
            goFade = gameOverText.gameObject.AddComponent<CanvasGroup>();

        goFade.alpha = 0f;

        UpdateScoreUI();
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        StartCoroutine(FadeIn(goFade));
    }

    IEnumerator FadeIn(CanvasGroup cg)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime * 1.5f;
            cg.alpha = t;
            yield return null;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
}
