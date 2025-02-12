﻿using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Report.Pdf.Fonts;
internal class ExpensesReportFontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        var stream = ReadFontFile(faceName);
        stream ??= ReadFontFile(FontHelper.DEFAULT_FONT);
        
        var length = (int)stream!.Length;
        var data = new byte[length];
        stream.ReadExactly(buffer: data, offset: 0, count: length);
        return data;
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        return new FontResolverInfo(familyName);
    }

    private static Stream? ReadFontFile(string fontName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Expenses.Report.Pdf.Fonts.{fontName}.ttf");
    }
}
