namespace KweetService.Domain.Text.Utils
{
    public static class RegexConstants
    {
        public static readonly string ONLY_LETTERS = @"^[a-zA-Z]+$";
        public static readonly string ONLY_LETTERS_AND_NUMBERS = @"^[a-zA-Z0-9]+$";
        public static readonly string ONLY_LETTERS_NUMBERS_AND_UNDERSCORES = @"^[a-zA-Z0-9_]+$";
    }
}