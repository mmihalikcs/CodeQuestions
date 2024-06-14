using Distributions.Implementations;
using Distributions.Interface;

Console.WriteLine("Initalizing Continuous Probability Distributions...");

// Guard clause for improper number of arguments passed via CLI
if (args.Length != 3)
{
    Console.Error.WriteLine("Improper amount of arguments passed to program. Verify and try again.");
    Environment.Exit(1);
}

// Pull out the variables for consistency and guard check them to ensure they are actually some for of a number
if (!Double.TryParse(args[0], out double mu)) {
    throw new ArgumentException("Failed to parse mu value", "mu"); ;
}

if (!Double.TryParse(args[1], out double sigmaSquared)) {
    throw new ArgumentException("Failed to parse sigmaSquared value", "sigmaSquared"); ;
}

if (!Double.TryParse(args[2], out double x)) {
    throw new ArgumentException("Failed to parse x value", "x"); ;
}


// Call the implementations
// Normal
IContinuousProbabilityDistribution normalDistrib = new NormalDistribution(mu, sigmaSquared);
Console.WriteLine($"Normal({x};{mu},{sigmaSquared}) = {normalDistrib.PDF(x)} (Mean : {normalDistrib.Mean}, Variance : {normalDistrib.Variance})");

// Log-Normal
IContinuousProbabilityDistribution logNormalDistrib = new LogNormalDistribution(mu, sigmaSquared);
Console.WriteLine($"Log-normal({x};{mu},{sigmaSquared}) = {logNormalDistrib.PDF(x)} (Mean : {logNormalDistrib.Mean}, Variance : {logNormalDistrib.Variance})");

// Hold open for testing (real world we wouldn't do this - we'd echo out result another way)
Console.ReadLine();