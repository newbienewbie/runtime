// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Reflection.Metadata.Ecma335
{
    internal static class HasDeclSecurityTag
    {
        internal const int NumberOfBits = 2;
        internal const int LargeRowSize = 0x00000001 << (16 - NumberOfBits);
        internal const uint TypeDef = 0x00000000;
        internal const uint MethodDef = 0x00000001;
        internal const uint Assembly = 0x00000002;
        internal const uint TagMask = 0x00000003;
        internal const TableMask TablesReferenced =
          TableMask.TypeDef
          | TableMask.MethodDef
          | TableMask.Assembly;
        internal const uint TagToTokenTypeByteVector = (TokenTypeIds.TypeDef >> 24) | (TokenTypeIds.MethodDef >> 16) | (TokenTypeIds.Assembly >> 8);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static EntityHandle ConvertToHandle(uint hasDeclSecurity)
        {
            uint tokenType = (TagToTokenTypeByteVector >> ((int)(hasDeclSecurity & TagMask) << 3)) << TokenTypeIds.RowIdBitCount;
            uint rowId = (hasDeclSecurity >> NumberOfBits);

            if (tokenType == 0 || (rowId & ~TokenTypeIds.RIDMask) != 0)
            {
                Throw.InvalidCodedIndex();
            }

            return new EntityHandle(tokenType | rowId);
        }

        internal static uint ConvertToTag(EntityHandle handle)
        {
            uint tokenType = handle.Type;
            uint rowId = (uint)handle.RowId;
            return (tokenType >> TokenTypeIds.RowIdBitCount) switch
            {
                TokenTypeIds.TypeDef >> TokenTypeIds.RowIdBitCount => rowId << NumberOfBits | TypeDef,
                TokenTypeIds.MethodDef >> TokenTypeIds.RowIdBitCount => rowId << NumberOfBits | MethodDef,
                TokenTypeIds.Assembly >> TokenTypeIds.RowIdBitCount => rowId << NumberOfBits | Assembly,
                _ => 0,
            };
        }
    }
}
