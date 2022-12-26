using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    CharacterController playerController;

    private static float speed = 1f;
    private const float jumpHeight = 1f;
    private const float gravity = -9.81f;

    private Vector3 velocity;

    public Transform groundCheck;
    private const float groudDistance = 0.3f;
    public LayerMask groundMask;
    private bool isGrounded;

    public GameObject Border;
    private List<GameObject> borders = new List<GameObject>();

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groudDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;

        playerController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.T)) LimitationMovement(4, 4);
        //if (Input.GetKeyDown(KeyCode.G)) ReLimitationMovement();
    }

    /// <summary>
    /// Изменение скорости игрока за n секунд с текущей U1 до передоваеммой U2
    /// </summary>
    public static IEnumerator SpeedChangeCoroutine(float borderSpeed, int intervalSecond)
    {
        var step = (borderSpeed - speed) / intervalSecond;

        for (var i = 0; i < intervalSecond; i++)
        {
            speed += step;
            yield return new WaitForSeconds(1f);
        }

        yield break;
    }

    /// <summary>
    /// Генерация прозрычных стенок вокруг игрока. Принимает значения до 4.
    /// </summary>
    public void LimitationMovement(int frontBorders, int lateralBorders)
    {
        borders.Add(Instantiate(Border, new Vector3(transform.position.x + lateralBorders, transform.position.y + 2, transform.position.z), Quaternion.identity));
        borders.Add(Instantiate(Border, new Vector3(transform.position.x - lateralBorders, transform.position.y + 2, transform.position.z), Quaternion.identity));
        borders.Add(Instantiate(Border, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - frontBorders), Quaternion.Euler(0f, 90f, 0f)));
        borders.Add(Instantiate(Border, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + frontBorders), Quaternion.Euler(0f, 90f, 0f)));
    }

    public void ReLimitationMovement()
    {
        for (var i = 0; i < 4; i++) Destroy(borders[i]);
        borders.Clear();
    }
}