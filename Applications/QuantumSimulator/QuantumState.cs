using System.Numerics;


/// <summary>
/// Represents a quantum state of a register of qubits
/// </summary>
public class QuantumState
{
    private readonly Complex[] _amplitudes;

    public QuantumState(Complex[] amplitudes)
    {
        _amplitudes = amplitudes;
    }
}
