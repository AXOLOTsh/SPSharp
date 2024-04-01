# Introduction
If you think that the idea of writing comments and instructions in English for a library that will be used by Russian-speaking developers is frankly stupid, then no, you don’t think so.
SPSharp is a class library for working with the [SPWorlds API](https://spworlds.readthedocs.io/ru/latest/). You can use it to view card details, transfer money and other SPWorlds API functions. It’s worth saying here that when developing SPSharp, I relied heavily on [SpWorldsApiForCS](https://github.com/flaxytop/SpWorldsApiForCS), since I found the official documentation not clear.
# Installing
After downloading the repository, you can include the compiled .dll file into your project or include the .csproject.
# Beginning
First you need to create an instance of the SPWorldsClient class:
```
SPWorldsClient client = new SPWorldsClient(new CardAuthorization("card_token", "card_id"));
```
... Where we pass the Card Authorization class to the constructor, which stores the token and id of your card. You can find your token and card ID on the SPWorlds website in the "Поделиться картой" section.
Now you can use the methods of this class. I have added comments to the methods, so you can find out their purpose directly in the IDE. I also highly recommend taking a look at the [official SPWorlds API documentation](https://spworlds.readthedocs.io/ru/latest/api.html#).
# Galloping across SPSharp
## async Task<int> GetBalanceAsync()
The method returns the card balance.
## async Task<string> GetMinecraftNicknameAsync(ulong discordId)
The method returns the Minecraft player's nickname. Discord User Id can be obtained from the user's context menu (if developer options are enabled) or by copying (via the message context menu) a message that mentions the desired user.
## async Task SendPaymentAsync(string receiver, int amount, string comment)
Method of transferring money from your card to another. Param receiver - Receiver's card number.
## async Task<string> CreatePaymentAsync(int amount, string redirectUrl, string webhookUrl, string data)
Creates a payment request and return link to payment page. You can learn more about how this method works from the API documentation.
## async Task<string> GetUuidAsync(string nickname)
Get Profile UUID.
