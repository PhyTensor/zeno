using System.Numerics;

namespace QuantumSimulator;

public class QuantumRegister
{
    public int NumQubits { get; }
    public Complex[] Amplitudes { get; private set; }
    public bool IsMeasured;

    public QuantumRegister(int numQubits)
    {
        NumQubits = numQubits;
        Amplitudes = new Complex[(int)Math.Pow(2, numQubits)];
        Amplitudes[0] = 1; // initialize |0> state
    }

    public void ApplyGate()
    {

    }

    public void Measure()
    {

    }
}
