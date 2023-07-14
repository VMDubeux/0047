using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento do personagem
    public float jumpForce = 5f; // Força do pulo
    public Transform groundCheck; // Transform do objeto que verifica se o personagem está no chão
    public LayerMask groundLayer; // Camada do terreno

    private Rigidbody rb;
    private Vector3 movement; // Vetor de movimento
    private bool isGrounded; // Verifica se o personagem está no chão
    private int health = 100; // Pontos de vida do jogador

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Verificar se o personagem está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        // Obter entrada do jogador
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calcular vetor de movimento com base na entrada do jogador
        movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Verificar se o jogador pressionou a tecla de pulo e está no chão
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Mover o personagem usando o vetor de movimento normalizado
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        // Orientar o personagem na direção do movimento
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, toRotation, 0.15f));
        }
    }

    private void Jump()
    {
        // Aplicar força vertical para o pulo
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void TakeDamage(int damage)
    {
        // Reduzir pontos de vida do jogador
        health -= damage;

        // Verificar se o jogador morreu
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aqui você pode adicionar as ações que acontecem quando o jogador morre
        Debug.Log("Player died.");
        // Por exemplo, desabilitar o objeto do jogador, exibir uma mensagem de game over, reiniciar o nível, etc.
    }
}
