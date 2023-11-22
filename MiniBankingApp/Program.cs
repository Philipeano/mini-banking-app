using MiniBankingApp;

Console.WriteLine();

//var dataTypesExplorer = new ExploringDataTypes();

// Invoke the Demo() method to execute the code
// dataTypesExplorer.Demo();

// Invoke the ExploreTryCatch() method
//dataTypesExplorer.ExploreTryCatch();


// var serializationExplorer = new ExploringSerialization();
// serializationExplorer.Demo();


//var linqExplorer = new ExploringLINQFundamentals();
//linqExplorer.Demo();

var asyncExplorer = new ExploringAsyncProgramming();
await asyncExplorer.Demo();


// Display a welcome message to the user
// Setup a loop that keeps the program running until the user decides to quit/exit the system (HINT: Use a do...while loop)
// Present a menu to allow user choose a task or exit the system 
// 1 - Create an account
// 2 - Exit
// If user chooses to create an account, then prompt for the account opening details
// Display a success message upon account creation
// Present another menu to allow user choose a task or exit the system 
// 1 - Deposit funds
// 2 - Withdraw
// 3 - View balance
// 4 - Exit
// If user picks a task other than exit, then call the necessary method to perform the chosen task
// Display the menu again after completing each task
// Whenever the user chooses Exit, display a goodbye message and quit the program.


// Uses a counter, and a terminating value
/*
for (int i = 0; i < 5; i++)
{

}


// Uses an iterator within a collection
var collection = new string[5];
foreach (var item in collection)
{

}
*/






/*

// Instantiate the BankAccount class to open an account
var account = new BankAccount("Paul", "Konyefa", 10000, "Current");

// Display current balance
account.DisplayBalance();

Console.WriteLine();
Console.WriteLine();

// Deposit funds into the account
Console.WriteLine("Enter an amount to deposit...");
var depositAmountText = Console.ReadLine();
if (!double.TryParse(depositAmountText, out double depositAmount))
{
    Console.WriteLine("Invalid input! Please enter a valid amount.");
}
else
{
    account.DepositFunds(depositAmount);
}

Console.WriteLine();
Console.WriteLine();

// Withdraw funds from the account
Console.WriteLine("Enter an amount to withdraw...");
var withdrawalAmountText = Console.ReadLine();
if (!double.TryParse(withdrawalAmountText, out double withdrawalAmount))
{
    Console.WriteLine("Invalid input! Please enter a valid amount.");
}
else
{
    account.WithdrawFunds(withdrawalAmount);
}

*/
