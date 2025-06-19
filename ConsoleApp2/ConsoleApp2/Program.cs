
int LengthOfLongestSubstring(string s)
{
    char[] array = s.ToCharArray();
    char[] arrayDiscriminado = array.Distinct().ToArray();
    return arrayDiscriminado.Length;
}

LengthOfLongestSubstring("abcabcbb");