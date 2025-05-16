
using QuantumSimulator;

// Console.WriteLine("Hello, World!");
// QuantumRegister qreg = new QuantumRegister(2);
// foreach (var ampl in qreg.Amplitudes) Console.WriteLine($"{ampl} => {ampl.Magnitude}");

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Quantum Computing Simulator");
        Console.WriteLine("===========================");

        // Create a 2-qubit quantum register
        QuantumRegister register = new QuantumRegister(qubitCount: 2);

        // Create a quantum circuit containing the quantum register(s)
        // QuantumCircuit circuit = new QuantumCircuit(register: register);

        Console.WriteLine("Applying Hadamard gate to qubit 0...");
        // register.ApplyGate("H", targetQubit: 0);
        // circuit.Hadamard(targetQubit: 0);

        Console.WriteLine("Applying CNOT gate with control=0, target=1...");
        // register.ApplyGate("CNOT", targetQubit: 1, controlQubit: 0);
        // circuit.CNOT(targetQubit: 1, controlQubit: 0);

        Console.WriteLine("\nCurrent measurement probabilities:");
        // foreach (var (state, probability) in register.GetProbabilities())
        // foreach (var (state, probability) in circuit.GetProbabilities())
        {
            // Console.WriteLine($"{state}: {probability:P2}");
        }

        Console.WriteLine("\nMeasuring the register...");
        // string result = circuit.Measure();
        // Console.WriteLine($"Measurement result: {result}");
        Console.WriteLine("===========================");
    }
}

