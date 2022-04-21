using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject particlesPrefab;
    [SerializeField] float travelSpeed;
    [SerializeField] float lifeTime;

    Rigidbody2D m_rB;

    #region Public Methods

    #endregion

    #region Private Methods
    private void Start()
    {
        m_rB = GetComponent<Rigidbody2D>();

        m_rB.velocity = transform.right * travelSpeed;
        
        StartCoroutine(LifeTimeCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject newParticles = Instantiate(particlesPrefab, transform.position, transform.rotation, ParticlesCollection.GetInstance().transform);
        Destroy(gameObject);
    }

    #endregion

    #region Coroutines

    private IEnumerator LifeTimeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }

    #endregion
}
