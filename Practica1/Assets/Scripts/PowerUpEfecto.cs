using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEfecto : MonoBehaviour
{
    [SerializeField] private float speedBoost = 10f;
    [SerializeField] private float duration = 5f;
    private float originalSpeed = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            StartCoroutine(ApplyPowerUp(player));
        }
    }

    private IEnumerator ApplyPowerUp(PlayerController player)
    {
        player.playerSpeed += speedBoost; 
        SetPowerUpVisibility(false);

        yield return new WaitForSeconds(duration); 

        player.playerSpeed = originalSpeed;
        Destroy(gameObject);
    }

    private void SetPowerUpVisibility(bool isVisible)
    {
        GetComponent<MeshRenderer>().enabled = isVisible;
        GetComponent<Collider>().enabled = isVisible;
    }
}



