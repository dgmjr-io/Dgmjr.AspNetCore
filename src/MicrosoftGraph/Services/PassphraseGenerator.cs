/*
 * PasswordGenerator.cs
 *
 *   Created: 2022-12-31-06:39:48
 *   Modified: 2022-12-31-06:39:49
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Identity;

public class PassphraseGenerator(IOptionsMonitor<PassphraseGeneratorOptions> options)
    : IPassphraseGenerator
{
    private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();
private PassphraseGeneratorOptions Options =>
    options?.CurrentValue ?? throw new ArgumentNullException(nameof(options));
private string[] WordList => Options.WordList;
private char[] SpecialCharacters => Options.SpecialCharacters;
private int WordCount => Options.WordCount;
private int EmojiCount => Options.EmojiCount;
private int SpecialCharacterCount => Options.SpecialCharacterCount;
private int LowercaseCharacterCount => Options.LowercaseCharacterCount;
private int UppercaseCharacterCount => Options.UppercaseCharacterCount;
private int CharacterCount => Options.CharacterCount;
private char[] Emoji => Options.Emoji;

public string Generate()
{
    var wordsToGo = WordCount;
    var emojiToGo = EmojiCount;
    var specialCharactersToGo = SpecialCharacterCount;
    var lowercaseCharactersToGo = LowercaseCharacterCount;
    var uppercaseCharactersToGo = UppercaseCharacterCount;
    var charactersToGo = CharacterCount;

    var passphrase = new StringBuilder();

    while (
        wordsToGo > 0
        || emojiToGo > 0
        || specialCharactersToGo > 0
        || lowercaseCharactersToGo > 0
        || uppercaseCharactersToGo > 0
        || charactersToGo > 0
    )
    {
        var word = GetRandomWord();
        passphrase.Append(word);
        wordsToGo--;
        charactersToGo -= word.Length;
        lowercaseCharactersToGo -= word.Count(char.IsLower);
        uppercaseCharactersToGo -= word.Count(char.IsUpper);

        if (emojiToGo > 0)
        {
            var emoji = PickRandomElement(Emoji);
            passphrase.Append(emoji);
            emojiToGo--;
            charactersToGo--;
        }

        if (lowercaseCharactersToGo > 0)
        {
            var emoji = PickRandomElement(Emoji);
            passphrase.Append(emoji);
            emojiToGo--;
            charactersToGo--;
        }

        if (specialCharactersToGo > 0)
        {
            var specialCharacter = PickRandomElement(SpecialCharacters);
            passphrase.Append(specialCharacter);
            specialCharactersToGo--;
            charactersToGo--;
        }
    }

    return passphrase.ToString();
}

private string GetRandomWord() => PickRandomElement(WordList);

private static T PickRandomElement<T>(T[] elements) =>
    elements.Skip(Random.NextInt32(elements.Length - 1)).First();
}
