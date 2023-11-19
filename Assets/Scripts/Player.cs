using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed = 6f;

    private const float TopBoundarie = 0f;
    private const float BottomBoundarie = -3.6f;

    public const float LeftBoundarie = -9f;
    public const float RightBoundarie = 9f;

    private const float OffScreenLeft = -11.3f;
    private const float OffScreenRight = 11.3f;

    public bool UseReversableHorizontalPosition = true;

    private const float _boostedSpeed = 10f;

    [SerializeField]
    private bool _isShieldActive = false;

    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private int _score = 0;

    public int Score => _score;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;

        StartCoroutine(this.ControlShieldPower());
    }

    // Update is called once per frame
    void Update()
    {
        this.MovePlayer();
    }

    public void TakeLife()
    {
        if (this._isShieldActive)
        {
            this._isShieldActive = false;
            return;
        }

        this._lives--;

        if (this._lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int GetLives()
    {
        return this._lives;
    }

    public bool IsAlive()
    {
        return this._lives > 0;
    }

    private void ApplyVerticalBoundaries()
    {
        if (this.transform.position.y >= TopBoundarie)
            transform.position = new Vector3(transform.position.x, TopBoundarie, 0);

        else if (this.transform.position.y <= BottomBoundarie)
            transform.position = new Vector3(transform.position.x, BottomBoundarie, 0);

    }

    private void ApplyHorizontalBoundaries()
    {
        if (this.transform.position.x <= LeftBoundarie)
            transform.position = new Vector3(LeftBoundarie, transform.position.y, 0);

        else if (this.transform.position.x >= RightBoundarie)
            transform.position = new Vector3(RightBoundarie, transform.position.y, 0);

    }

    private void ReverseHorizontalPositionWhenOffScreen()
    {
        if (this.transform.position.x <= OffScreenLeft)
            transform.position = new Vector3(OffScreenRight, transform.position.y, 0);

        else if (this.transform.position.x >= OffScreenRight)
            transform.position = new Vector3(OffScreenLeft, transform.position.y, 0);
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var movimentVector = this.Speed * Time.deltaTime * new Vector3(horizontalInput, verticalInput);

        transform.Translate(movimentVector);

        this.ApplyVerticalBoundaries();

        if (this.UseReversableHorizontalPosition)
            this.ReverseHorizontalPositionWhenOffScreen();
        else
            this.ApplyHorizontalBoundaries();
    }

    public void EnableSpeedBoost()
    {
        this.Speed = _boostedSpeed;
        StartCoroutine(this.PowerDownSpeedBoost());
    }

    IEnumerator PowerDownSpeedBoost()
    {
        yield return new WaitForSeconds(5.0f);

        this.Speed = 6.0f;
    }
    public void EnableShield()
    {
        this._isShieldActive = true;
        //        
    }

    IEnumerator ControlShieldPower()
    {
        while (this.IsAlive())
        {
            this.transform.Find("PlayerShield").transform.gameObject.SetActive(this._isShieldActive);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void AddScore(int points)
    {
        this._score += points;
    }
}
