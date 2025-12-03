using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public int score = 0;
    public TextMeshPro scoreText;
    public GameObject winPanel;
    public Projectile.ColorType colorType;

    private void Start()
    {
        winPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (colorType == other.GetComponent<Projectile>().colorType)
            {
                score += other.GetComponent<Projectile>().scoreValue;
            }
            else
            {
                score -= other.GetComponent<Projectile>().scoreValue;
            }
            score = Mathf.Max(score, 0);
            UpdateScoreUI();
            Destroy(other.gameObject);

            if (score >= 20)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        score = 0;
        UpdateScoreUI();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {  
        Application.Quit();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}