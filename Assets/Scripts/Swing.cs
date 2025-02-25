using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(HingeJoint), typeof(InputReader))]
public class Swing : MonoBehaviour
{
    [SerializeField] private int _torqueMultiplier = 2;

    private Rigidbody _rigidbody;
    private HingeJoint _hingeJoint;
    private InputReader _inputReader;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _hingeJoint = GetComponent<HingeJoint>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.OnSwingSwayed += AddTorque;
    }

    private void OnDisable()
    {
        _inputReader.OnSwingSwayed -= AddTorque;
    }

    private void AddTorque()
    {
        _rigidbody.AddTorque(_hingeJoint.axis * _torqueMultiplier, ForceMode.Force);
    }
}