void WithdrawExceptions(string accountName, decimal amount)
{
    if (string.IsNullOrWhiteSpace(accountName))
    {
        throw new ArgumentException(message: "Account name cannot be empty", paramName: nameof(accountName));
    }

    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(paramName: nameof(amount), message: $"{nameof(amount)} cannot be negative or zero");
    }

    WriteLine($"Successful Withdrawal: {amount}");
}

void WithdrawGuardClauses(string accountName, decimal amount)
{
    ArgumentException.ThrowIfNullOrWhiteSpace(accountName, paramName: nameof(accountName));

    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount, paramName: nameof(amount));

    WriteLine($"Successful Withdrawal: {amount}");
}


// WithdrawGuardClauses(accountName: "", amount: 1);
// WithdrawGuardClauses(accountName: "test", amount: 0);
WithdrawGuardClauses(accountName: "test", amount: 1);