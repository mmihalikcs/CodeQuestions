Console.WriteLine("Initalizing Continuous Probability Distributions...");

// Guard clause for improper number of arguments passed via CLI
if (args.Length != 3)
{
    Console.Error.WriteLine("Improper amount of arguments passed to program. Verify and try again.");
    Environment.Exit(1);
}

// Call the implementations

// Normal
Console.WriteLine("Normal(<x>;<mu>,<sigma squared>) = <PDF(x)> (Mean : <mean>, Variance : <variance>)");


// Log-Normal
Console.WriteLine("Log-normal(<x>;<mu>,<sigma squared>) = <PDF(x)> (Mean : <mean>, Variance : <variance>)");

// Hold open for testing (real world we wouldn't do this - we'd echo out result another way)
Console.ReadLine();