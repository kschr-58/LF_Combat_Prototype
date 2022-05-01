using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeTrail : MonoBehaviour
{
    [SerializeField] GameObject[] clones;
    [SerializeField] float cloneLifeTime;
    [SerializeField] float cloneSpawnDelay;

    bool isEmitting = false;
    bool canSpawnNextClone = true;

    #region Public Methods

    public void ActivateTrail()
    {
        this.isEmitting = true;
    }

    public void DeactivateTrail()
    {
        this.isEmitting = false;
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        if (!isEmitting) return;

        if (!canSpawnNextClone) return;

        if (clones.Length == 0) return;

        StartCoroutine(CloneSpawnCoroutine());
    }

    #endregion

    #region Coroutines

    private IEnumerator CloneSpawnCoroutine()
    {
        foreach(GameObject clone in clones)
        {
            if (!isEmitting) break;

            clone.SetActive(true);

            StartCoroutine(CloneCoroutine(clone));

            yield return new WaitForSeconds(cloneSpawnDelay);
        }
    }

    private IEnumerator CloneCoroutine(GameObject clone)
    {
        Transform newParent = ParticlesCollection.Singleton.transform;

        clone.transform.SetParent(newParent);
        
        yield return new WaitForSeconds(cloneLifeTime);

        clone.gameObject.SetActive(false);

        clone.transform.SetParent(transform);
    }

    #endregion
}
