using System.Collections;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace miniMshtml
{
    [ComImport, Guid("3050F536-98B5-11CF-BB82-00AA00BDCE0B"), InterfaceType((short)2), TypeLibType((short)0x1010)]
    public interface DispHTMLTableCell
    {
        [DispId(-2147417085)]
        string innerText { [return: MarshalAs(UnmanagedType.BStr)] [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-2147417085)] get; [param: MarshalAs(UnmanagedType.BStr)] [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-2147417085)] set; }
    }

    [InterfaceType(2)]
    [Guid("3050F548-98B5-11CF-BB82-00AA00BDCE0B")]
    [TypeLibType(4112)]
    public interface DispHTMLSpanElement
    {
        [DispId(-2147417085)]
        string innerText { get; set; }
        [DispId(-2147417610)]
        object getAttribute(string strAttributeName, int lFlags);
    }

    [InterfaceType(2)]
    [Guid("3050F55F-98B5-11CF-BB82-00AA00BDCE0B")]
    [TypeLibType(4112)]
    public interface DispHTMLDocument
    {
        [DispId(1087)]
        IEnumerable getElementsByTagName(string v);
        [DispId(1003)]
        IEnumerable all { get; }
    }

    [TypeLibType(4160)]
    [Guid("626FC520-A41E-11CF-A731-00A0C9082637")]
    public interface IHTMLDocument
    {
        [DispId(1001)]
        object Script { get; }
    }
}