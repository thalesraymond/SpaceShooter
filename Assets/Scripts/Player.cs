using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 6f;

    private const float TopBoundarie = 0f;
    private const float BottomBoundarie = -3.6f;

    private const float LeftBoundarie = -9f;
    private const float RightBoundarie = 9f;

    private const float OffScreenLeft = -11f;
    private const float OffScreenRight = 11f;

    public bool UseReversableHorizontalPosition = true;

    // Start is called before the first frame update
    void Start()
    {
         transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        this.MovePlayer();
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
        //transform.Translate(Vector3.right * this.Speed * Time.deltaTime * Input.GetAxis("Horizontal"));

        //transform.Translate(Vector3.up * this.Speed * Time.deltaTime * Input.GetAxis("Vertical"));

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
}
