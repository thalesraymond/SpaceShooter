using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private Sprite[] _liveSprites;

    [SerializeField]
    private Image _currentLifeCount;

    [SerializeField]
    private Text _gameOverText;

    [SerializeField]
    private Text _restartText;

    // Start is called before the first frame update
    void Start()
    {
        this._player = GameObject.Find("Player").GetComponent<Player>();

        this.UpdateScoreText(0);

        this._gameOverText.gameObject.SetActive(!this._player.IsAlive());
        this._restartText.gameObject.SetActive(!this._player.IsAlive());
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateScoreText(this._player.Score);
        this.UpdateDisplayedLives();

        this._gameOverText.gameObject.SetActive(!this._player.IsAlive());
        this._restartText.gameObject.SetActive(!this._player.IsAlive());

        this.CheckForRestart();

        this.CheckForEscape();
    }

    private void UpdateScoreText(int score)
    {
        this._scoreText.text = "Score: " + score;
    }

    private void UpdateDisplayedLives()
    {
        var currentPlayerLives = this._player.GetLives();

        this._currentLifeCount.sprite = this._liveSprites[currentPlayerLives];
    }

    private void CheckForRestart()
    {
        if (Input.GetKeyDown(KeyCode.R) && this._restartText.IsActive())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void CheckForEscape()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("QUIIIIIIT");
            Application.Quit();
        }
    }
}
