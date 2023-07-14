using UnityEngine;

public class AllyFollower : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float speed = 5f; // Velocidade de movimento do aliado
    public int formationRows = 2; // Número de linhas na formação
    public int formationColumns = 3; // Número de colunas na formação
    public float spacing = 2f; // Espaçamento entre os aliados na formação

    private void Update()
    {
        // Verificar se o jogador existe
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing.");
            return;
        }

        // Calcular a posição desejada para o aliado na formação
        Vector3 formationOffset = GetFormationOffset();
        Vector3 targetPosition = player.position + formationOffset;

        // Mover o aliado em direção à posição desejada
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }

    private Vector3 GetFormationOffset()
    {
        // Obter a posição do aliado na formação com base no índice dele na hierarquia
        int allyIndex = transform.GetSiblingIndex();
        int row = allyIndex / formationColumns;
        int column = allyIndex % formationColumns;

        // Calcular o deslocamento na formação com base na posição da linha e coluna
        float offsetX = (column - (formationColumns - 1) * 0.5f) * spacing;
        float offsetZ = row * spacing;

        // Retornar o deslocamento como um vetor
        return new Vector3(offsetX, 0f, offsetZ);
    }
}
