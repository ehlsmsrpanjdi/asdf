using System.Collections;
using TMPro;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;

    bool isFlap = false;

    public bool godMode = false;

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI scoreText;
    bool GameStart = false;

    float Score = 0.0f;
    float MaxScore = 0.0f;

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
        _rigidbody.isKinematic = true;
        forwardSpeed = 0f;
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (!GameStart) return;
        if (isDead)
        {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameInstance.GetInst().ChangeScene(GameInstance.JumpGameScene);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameInstance.GetInst().ChangeScene(GameInstance.MainGameScene);
                }
        }
        else
        {
            Score += Time.deltaTime;
            if (MaxScore < Score)
            {
                scoreText.text = Score.ToString();
                MaxScore = Score;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameStart = true;
        if (godMode)
            return;

        if (isDead)
            return;

        isDead = true;
        countdownText.text = "Press Space Restart or\n Press E GameEnd";
    }

    IEnumerator StartCountdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "Game Start!\n Click!!!";
        yield return new WaitForSeconds(1f);
        GameStart = true;
        _rigidbody.isKinematic = false;
        countdownText.text = ""; // 필요하다면 비우기
        forwardSpeed = 3f;
    }

}