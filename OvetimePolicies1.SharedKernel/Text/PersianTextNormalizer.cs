namespace OvetimePolicies1.SharedKernel.Text;

public static class PersianTextNormalizer
{
    public static string NormalizeYeKeTrim(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var s = value.Trim();
        s = s.Replace('\u064a', '\u06cc'); // Arabic YEH → Persian ی
        s = s.Replace('\u0649', '\u06cc'); // Arabic ALEF MAKSURA
        s = s.Replace('\u0643', '\u06a9'); // Arabic KAF → Persian ک
        return s;
    }
}
