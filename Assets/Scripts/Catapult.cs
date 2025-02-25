using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class CatapultController : MonoBehaviour
{
    [SerializeField] private Transform _startArmPosition;
    [SerializeField] private Transform _startProjectilePosition;
    [SerializeField] private Rigidbody _armRigidbody;
    [SerializeField] private Rigidbody _projectileRigidbody;

    private InputReader _inputReader;
    private Coroutine _reloadCoroutine;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.OnLaunchProjectile += LaunchProjectile;
        _inputReader.OnReloadCatapult += LaunchReloadCatapult;
    }

    private void OnDisable()
    {
        _inputReader.OnLaunchProjectile -= LaunchProjectile;
        _inputReader.OnReloadCatapult -= LaunchReloadCatapult;
    }

    private void LaunchProjectile()
    {
        _armRigidbody.isKinematic = false;
        _projectileRigidbody.isKinematic = false;
    }

    private void LaunchReloadCatapult()
    {
        if (_reloadCoroutine != null)
        {
            StopCoroutine(_reloadCoroutine);
        }

        _reloadCoroutine = StartCoroutine(ReloadCatapult());
    }

    private IEnumerator ReloadCatapult()
    {
        _armRigidbody.transform.position = _startArmPosition.position;
        _armRigidbody.transform.rotation = _startArmPosition.rotation;
        _armRigidbody.isKinematic = true;

        yield return new WaitForFixedUpdate();

        _projectileRigidbody.transform.position = _startProjectilePosition.position;
        _projectileRigidbody.isKinematic = true;

        _reloadCoroutine = null;
    }
}