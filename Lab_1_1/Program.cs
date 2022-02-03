using Lab_1_1;

const int NumberOfAlgorithms = 5;
const string HelloMessege = "Choose a alhorithm:\n1. Railway fence\n2. Key phrase\n3. Rotating Lattice\n4. Cesar\n5. Cesar new";
const string Choice = "Input your choise: ";


while (true)
{
    Console.WriteLine(HelloMessege);
    var choose = ConsoleValidation.ValidateInt(Choice, 1, NumberOfAlgorithms);
    Console.WriteLine();

    var output = choose switch
    {
        1 => AlgorithmsMethods.Railway(),
        2 => AlgorithmsMethods.KeyPhrase(),
        3 => AlgorithmsMethods.RotatingLattice(),
        4 => AlgorithmsMethods.Cesar(),
        5 => AlgorithmsMethods.NewCesar(),
    };

    Console.WriteLine($"Output: {output}");
    Console.WriteLine();
}