using System.Numerics;

namespace QuantumSimulator;

/// <summary>
/// Represents a quantum register and its state.
/// </summary>
public class QuantumRegister
{
    private readonly Random _random = new();

    public int QubitCount { get; }
    // Statevector of the quantum register (2^n elements, initialised to |00...0>)
    public Complex[] Amplitudes { get; private set; }
    public bool IsMeasured;

    public QuantumRegister(int qubitCount)
    {
        QubitCount = qubitCount;
        Amplitudes = new Complex[(int)Math.Pow(2, qubitCount)];
        Amplitudes[0] = Complex.Zero; // initialize |0> state
    }

    public void ApplyGate()
    {

    }

    public void Measure()
    {

    }

    public static void PrintState()
    {

    }
}
