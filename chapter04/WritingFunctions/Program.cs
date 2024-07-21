// TimesTable(number: 2, size: 10);
ConfigureConsole(culture: "fr-FR");

decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "FR");
WriteLine($"You must to pay {taxToPay:C} in tax");

RunCardinalToOrdinal();

RunFibImperative();

RunFibFunctional();