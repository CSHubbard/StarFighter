using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  private Vector2 rawInput;

  [SerializeField] private float moveSpeed = 10f;

  [SerializeField] private float paddingLeft;
  [SerializeField] private float paddingRight;
  [SerializeField] private float paddingTop;
  [SerializeField] private float paddingBottom;
  Shooter shooter;


  Vector2 minBounds;
  Vector2 maxBounds;

  private void Awake()
  {
    shooter = GetComponent<Shooter>();
  }

  // Start is called before the first frame update
  void Start()
  {
    InitBounds();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
  }

  private void InitBounds()
  {
    Camera mainCamera = Camera.main;
    minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
    maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
  }

  private void Move()
  {
    Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
    Vector2 newPos = new();
    newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
    newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingBottom);
    transform.position = newPos;
  }

  void OnMove(InputValue value)
  {
    rawInput = value.Get<Vector2>();
  }

  void OnFire(InputValue value)
  {
    if (shooter != null)
    {
      shooter.isFiring = value.isPressed;
      Debug.Log(value.isPressed);
    }
  }
}
