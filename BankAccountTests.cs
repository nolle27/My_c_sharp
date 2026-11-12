
{
    
    public void Debit_WithValidAmount_UpdatesBalance()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = 4.55;
        double expected = 7.44;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act
        account.Debit(debitAmount);

        // Assert
        double actual = account.Balance;
        Assert.AreEqual(expected, actual, 0.001, "Saldo fout berekend");
    }
    
    public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = -100.00;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act & Assert
        try
        {
            account.Debit(debitAmount);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
            return;
        }

        Assert.Fail("De verwachte fout werd niet gegooid.");
    }

    
    public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = 20.0;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act & Assert
        try
        {
            account.Debit(debitAmount);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            return;
        }

        Assert.Fail("De verwachte fout werd niet gegooid.");
    }
}

