using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEfectoTamano : MonoBehaviour
{
    [SerializeField] private Vector3 sizeBoost = new Vector3(2f, 2f, 2f); 
    [SerializeField] private float duration = 5f;
    private Vector3 originalSize=  new Vector3(1,1,1);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            StartCoroutine(ApplySizePowerUp(player));
        }
    }

    private IEnumerator ApplySizePowerUp(PlayerController player)
    {
        player.transform.localScale = Vector3.Scale(originalSize, sizeBoost); 
        SetPowerUpVisibility(false);

        yield return new WaitForSeconds(duration); 

        player.transform.localScale = originalSize; 
        Destroy(gameObject);
    }

    private void SetPowerUpVisibility(bool isVisible)
    {
        GetComponent<MeshRenderer>().enabled = isVisible;
        GetComponent<Collider>().enabled = isVisible;
    }
}

