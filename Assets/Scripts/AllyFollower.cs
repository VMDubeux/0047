using UnityEngine;

public class AllyFollower : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public float speed = 5f; // Velocidade de movimento do aliado
    public int formationRows = 2; // N�mero de linhas na forma��o
    public int formationColumns = 3; // N�mero de colunas na forma��o
    public float spacing = 2f; // Espa�amento entre os aliados na forma��o

    private void Update()
    {
        // Verificar se o jogador existe
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing.");
            return;
        }

        // Calcular a posi��o desejada para o aliado na forma��o
        Vector3 formationOffset = GetFormationOffset();
        Vector3 targetPosition = player.position + formationOffset;

        // Mover o aliado em dire��o � posi��o desejada
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }

    private Vector3 GetFormationOffset()
    {
        // Obter a posi��o do aliado na forma��o com base no �ndice dele na hierarquia
        int allyIndex = transform.GetSiblingIndex();
        int row = allyIndex / formationColumns;
        int column = allyIndex % formationColumns;

        // Calcular o deslocamento na forma��o com base na posi��o da linha e coluna
        float offsetX = (column - (formationColumns - 1) * 0.5f) * spacing;
        float offsetZ = row * spacing;

        // Retornar o deslocamento como um vetor
        return new Vector3(offsetX, 0f, offsetZ);
    }
}
