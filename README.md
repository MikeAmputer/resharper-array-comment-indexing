# ArrayCommentIndexing for Rider and ReSharper

[![Rider](https://img.shields.io/jetbrains/plugin/v/com.github.mikeamputer.arraycommentindexing.svg?label=Rider&colorB=0A7BBB&style=for-the-badge&logo=rider)](https://plugins.jetbrains.com/plugin/26764-array-comments-indexing)
[![ReSharper](https://img.shields.io/resharper/v/ReSharperPlugin.ArrayCommentIndexing.svg?label=ReSharper&colorB=0A7BBB&style=for-the-badge&logo=resharper)](https://plugins.jetbrains.com/plugin/26757-array-comment-indexing)

Sometimes you have to use indexed placeholders with `string.Format()` and [you are not alone](https://github.com/dotnet/runtime/discussions/100259). Keeping track of array element positions can be difficult. This plugin helps maintain clarity by adding and updating index comments via Context Actions.

```c#
const string notificationTemplate = @"Dear {0},

Your recent transaction (ID: {1}) of {2:C} on {3} has been processed.
The payment method used: {4}.
Status: {5}.

If you have any questions, please contact {6}.

Best regards,
Your Bank";

var args = new object[]
{
    /*0*/ user.GetProfile().GetFullName(),
    /*1*/ transaction.GetDetails().GetTransactionId(),
    /*2*/ transaction.GetAmount().CalculateWithTax(user.GetTaxRate()),
    /*3*/ transaction.GetTimestamp().ToString("MMMM dd, yyyy HH:mm"),
    /*4*/ user.GetPreferredPaymentMethod().GetDisplayName(),
    /*5*/ transaction.GetStatus().ToFriendlyString(user.GetLocale()),
    /*6*/ bank.GetSupportService().GetContactEmail(user.GetRegion(), true)
};

string notificationMessage = string.Format(notificationTemplate, args);
```

## Getting Started
1. Install the plugin from the JetBrains Marketplace (an IDE restart may be required).
2. Open the `Context Actions` menu (**Alt+Enter**) inside an array initializer.
3. Select `Add Index Comments to Array Elements` to annotate the array with index comments.
4. To update indexes, run the action again.

## Build
Run `./gradlew buildPlugin` from the solution root directory. The `output` directory will contain two files:
- `.nupkg` for ReSharper
- `.zip` for Rider.
